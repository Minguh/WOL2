/*
 * This is the WOL2 Network Scanner.
 */
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Threading;


namespace WOL2
{
	/// <summary>
	/// This is the WOL2 Network scanner.
	/// It can scan for computers in all connected networks, 
	/// in a given network or in an IP range.
	/// </summary>
	public class WOLNetworkScanner
	{
	
		public WOLNetworkScanner( AsyncCallback finishedCallback,
		                         	AsyncCallback stateCallback )
		{
			m_iPingTimeout = 50;
			m_lMaxScans = 0;
            m_lFinishedScans = 0;
			m_lScansRunning = 0;
			m_finishedCallback = finishedCallback;
			m_stateCallback = stateCallback;
			m_bAddIfHostnameResolved = false;
			m_bAddIfMacResolved = true;
		}
		
		/// <summary>
		/// This function scans all subnets the computer is connected to.
		/// </summary>
		public void ScanSubnets()
		{
			// Single threaded call: 
			// ScanLocalSubnets( Hosts );
			
			// Multi threaded:
			SubnetScanner ss = new SubnetScanner( ScanNetworks );
        	ss.BeginInvoke( Hosts, 
                       		 new AsyncCallback(	SubnetScanFinished ),
                       		 "finished" );
			
			return;
		}
		
		/// <summary>
		/// Async. callback for signalling the end of the subnet scan.
		/// </summary>
		/// <param name="result"></param>
		private void SubnetScanFinished( IAsyncResult result )
		{
			// Nothing to do in here
		}
		
		/// <summary>
		/// Scans all reachable networks
		/// </summary>
		/// <param name="hl"> ununsed </param>
		/// <returns> success </returns>
		private bool ScanNetworks( List< WOL2Host > hl )
		{
			bool bRet = false;
			try
			{
				foreach( NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces() )
				{
					if( ni.OperationalStatus == OperationalStatus.Up )
					{
						MOE.Logger.DoLog( "Found NIC " + ni.Name +"; MAC=" + ni.GetPhysicalAddress(), MOE.Logger.LogLevel.lvlInfo );
						foreach( UnicastIPAddressInformation uipi in ni.GetIPProperties().UnicastAddresses ) 
						{
							if( uipi.Address != null && uipi.Address.ToString() != "127.0.0.1" )
							{
								if( uipi.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
								{
									MOE.Logger.DoLog( "NIC " + ni.Name + " has IPv4 address " + uipi.Address, MOE.Logger.LogLevel.lvlInfo );
								
									if( uipi.IPv4Mask != null )
									{
										ScanIPv4Network( uipi.Address, uipi.IPv4Mask );
									}
								}
								else
									MOE.Logger.DoLog( "NIC " + ni.Name + " uses an unsupported protocol: " + uipi.Address.AddressFamily.ToString(), MOE.Logger.LogLevel.lvlWarning );
							}
						}
					}
				}
			}
			catch( Exception e )
			{
				MOE.Logger.DoLog( e.ToString(), MOE.Logger.LogLevel.lvlWarning );
			}
			return bRet;
		}
		
		public void ScanIPv4Network(IPAddress Address, IPAddress IPv4Mask )
		{
            IPAddress ip = WOL2DNSHelper.GetNetworkAddress(Address, IPv4Mask);
            IPAddress bc = WOL2DNSHelper.GetBroadcastAddress(Address, IPv4Mask);
			
			MOE.Logger.DoLog( "ScanIPv4Network: Scanning network " + ip + " with mask " + IPv4Mask, MOE.Logger.LogLevel.lvlInfo );
			
			// 'ip' is now the network address
			ScanIPv4Range( ip, bc, IPv4Mask );
		}

		/// <summary>
		/// Scans an IPv4 range
		/// </summary>
		/// <param name="from">Starting address</param>
		/// <param name="to">end address</param>
		/// <param name="Subnet">Subnet Mask for the network</param>
		public void ScanIPv4Range(IPAddress from, IPAddress to, IPAddress Subnet )
		{
			MOE.Logger.DoLog( "ScanIPv4Range: Scanning range from " + from + " to " + to, MOE.Logger.LogLevel.lvlInfo );

            // Initialize the scan
            m_lFinishedScans = 0;

            // Calculate the number of hosts to scan
            /* IPAddress r = new IPAddress(to.Address - from.Address );
            string [] s = r.ToString().Split('.');
            if (s.Length == 4)
            {
                m_lMaxScans = Int16.Parse(s[3]);
                m_lMaxScans *= 1 + Int16.Parse(s[2]);
                m_lMaxScans *= 1 + Int16.Parse(s[1]);
                m_lMaxScans *= 1 + Int16.Parse(s[0]);
            }   */         

			// scan while the end of the range is not reached
            while (true)
			{
				from.Address += 0x01000000;	// Advance to next IP

                // Contruct a temporary host element
				WOL2Host h = new WOL2Host();
				h.SetIpAddress( from.ToString() );
				h.SetSubnetMask( Subnet.ToString() );

                // Add the job
                MOE.Logger.DoLog("ScanIPv4Range(): Added scan job: " + h.GetIpAddress(), MOE.Logger.LogLevel.lvlDebug);
                Monitor.Enter(m_Jobs);
                m_Jobs.Add(h);
                m_lMaxScans++;
                Monitor.Exit(m_Jobs);
               
                // Stop if the end IP is reached...
                if (from.ToString() == to.ToString())
                    break;

                // Increment the second octett if the first is full
                if ((from.Address & 0x00000000ff000000) == 0x00000000ff000000)
                {
                        from.Address += 0x0000000000010000;
                }
			}

            // Start the async job processor
            ProcessJobs();

		}
		
		/// <summary>
		/// This function scans a single host
		/// </summary>
		/// <param name="h">A WOL2Host containing the information 
		/// required to scan a host.</param>
		/// <returns>True, if the host was successfully scanned.</returns>
		private bool ScanHost( WOL2Host h )
		{
            bool bRet = false;
			
			IPAddress ip = IPAddress.Parse( h.GetIpAddress() );
			
			byte[] buffer = new byte[32];
			Ping myPing = new Ping(); 
			PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(ip, m_iPingTimeout, buffer, pingOptions); // send the ping 
			
			if( reply.Status == IPStatus.Success )
			{	
				// Found a host
				// WOL2Host h = new WOL2Host();
				try
				{
					h.SetIpAddress( ip.ToString() );
                    h.SetMacAddress(WOL2DNSHelper.GetMACAddress(h.GetIpAddress()));
					h.SetName( Dns.GetHostEntry( h.GetIpAddress() ).HostName );

                    // ipv6 lookup
                    string lookup = h.GetName();
                    string ipv6 = WOL2DNSHelper.ResolveToIPv6Local(lookup);
                    if (ipv6 == null)
                    {
                        lookup = h.GetIpAddress();
                        ipv6 = WOL2DNSHelper.ResolveToIPv6Local(lookup);
                    }

                    if( ipv6 != null )
                        h.SetIpV6Address(ipv6);
					
					// check if the hostname was found
                    bool bAdd = true;
					if( m_bAddIfHostnameResolved )
						bAdd = ( h.GetIpAddress() != h.GetName() );

					if( m_bAddIfMacResolved )
						bAdd = ( h.GetMacAddress().Length != 0 );
					
					if( bAdd )
					{
						Monitor.Enter( Hosts );
  						  Hosts.Add( h );
						Monitor.Exit( Hosts );
					}

                    MOE.Logger.DoLog("ScanHost(): Found host: " + h + ". " + (bAdd ? "Adding it." : "Not adding it."), MOE.Logger.LogLevel.lvlInfo);
					
					bRet = bAdd;
				}
				catch(System.Net.Sockets.SocketException se )
				{
					MOE.Logger.DoLog( se.ToString(), MOE.Logger.LogLevel.lvlWarning );
				}
				catch( Exception ex )
				{
					MOE.Logger.DoLog( ex.ToString(), MOE.Logger.LogLevel.lvlWarning );
				}
			}

            MOE.Logger.DoLog("ScanHost(): finished job " + h.GetIpAddress(), MOE.Logger.LogLevel.lvlDebug );
            
			return bRet;
		}

        /// <summary>
        /// This function starts a job processor that will process all pending scan jobs.
        /// </summary>
        public void ProcessJobs()
        {
            if (m_JobProcessor == null)
            {
                MOE.Logger.DoLog("ProcessJobs: Initializing Job Processor.", MOE.Logger.LogLevel.lvlInfo);
                m_JobProcessor = new JobProcessor(JobProcessorFunc);
                m_JobProcessor.BeginInvoke(null, null);
            }
            else
                MOE.Logger.DoLog("ProcessJobs: Job Processor is already running.", MOE.Logger.LogLevel.lvlDebug);
        }

        /// <summary>
        /// This function gets asynchronously called by the job processor.
        /// It will process all pending scan jobs.
        /// </summary>
        private void JobProcessorFunc()
        {
            while (m_Jobs.Count != 0)
            {
                Monitor.Enter(m_Jobs);
                WOL2Host h = m_Jobs[0];
                Monitor.Exit(m_Jobs);      
                
                // Wait for a free scan slot
                while (m_lScansRunning > 255)
                    Thread.Sleep(10);

                // Kick up a new scanner thread
                m_lScansRunning++;

                MOE.Logger.DoLog("JobProcessor: Spawning new scan process for: " + h.GetIpAddress(), MOE.Logger.LogLevel.lvlDebug);

                HostScanner hs = new HostScanner(ScanHost);
                hs.BeginInvoke(h,
                                 new AsyncCallback(HostScanFinished),
                                 0);

                Monitor.Enter(m_Jobs);
                m_Jobs.Remove(h); 
                Monitor.Exit(m_Jobs); 
            }

            // Done :-)
            MOE.Logger.DoLog("JobProcessor: All jobs done.", MOE.Logger.LogLevel.lvlDebug);
            // m_finishedCallback.Invoke( null );

            m_JobProcessor = null;
        }
		
		/// <summary>
		/// Async. Callback for signalling the end of the scan process.
		/// </summary>
		/// <param name="result"></param>
		private void HostScanFinished( IAsyncResult result )
		{
			/* Decrement the counter and signal the end 
			 * of the scan process if this is the last scan
			 */
			m_stateCallback( result );

            m_lFinishedScans++;
            m_lScansRunning--;

            if (m_lFinishedScans == m_lMaxScans)
            {
                MOE.Logger.DoLog("HostScanFinished(): Last job finished.", MOE.Logger.LogLevel.lvlDebug);
                m_finishedCallback.Invoke(null);
            }
			   
			
		}

    	/// <summary>
		/// Set the PING timeout.
		/// </summary>
		/// <param name="i">Time a host is given to reply to the scan package.</param>
		public void SetPingTimeout( int i )
		{
			m_iPingTimeout = i;
		}
		
		/// <summary>
		/// Set whether hosts will be added if they do not have a DNS name.
		/// </summary>
		/// <param name="bOk"></param>
		public void SetUnsesolvedNameOk( bool bOk )
		{
			m_bAddIfHostnameResolved = !bOk;
		}
		
		/// <summary>
		/// Set whether hosts will be added if we can not determine their MAC
		/// address.
		/// </summary>
		/// <param name="bOk"></param>
		public void SetUnresolvedMacOk( bool bOk )
		{
			m_bAddIfMacResolved = !bOk;
		}
		
		/// <summary>
		/// Returns the progress in percent of the scan.
		/// </summary>
		/// <returns>Progress in % of the currently running scan. (If any.)</returns>
		public long GetScanState()
		{
            if (m_lMaxScans == 0)
                return 0;

            long state = m_lFinishedScans * 100 / m_lMaxScans;

            if (state > 100)
                state = 100;

			return state;
		}
		
		#region Members -----------------------------------------------------------
		delegate bool 					SubnetScanner( List< WOL2Host > h );	// The scanner delegate
		delegate bool 					HostScanner( WOL2Host h );				// The host scanner delegate
        delegate void                   JobProcessor();               // The background job processor delegate
		public List< WOL2Host > 		Hosts = new List< WOL2Host >();			// The Hosts list
        public List<WOL2Host>           m_Jobs = new List<WOL2Host>();			// The Scan Job list

        JobProcessor                    m_JobProcessor = null;                  // The background job processor
		
		int 							m_iPingTimeout;							// The ping timeout
		long							m_lScansRunning;						// Scan counter
		long							m_lMaxScans;							// Indicates how many scans were running, used for calculating the percentage
        long                            m_lFinishedScans;                       // Finished scans
		bool							m_bAddIfMacResolved;					// Add hosts only if the mac address could be resolved
		bool							m_bAddIfHostnameResolved;				// Add hosts only if their name could be resolved.
		AsyncCallback					m_finishedCallback;						// The callback to call when the scan finished
		AsyncCallback					m_stateCallback;						// The callback to call when the scan state changes
		
		delegate void StateChanged( int statePercentage );

		#endregion
	}
}
