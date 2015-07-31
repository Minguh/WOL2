/*
 * This is the WOL2 nework scanner window implementation file.
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace WOL2
{
	/// <summary>
	/// WOL2 Network Scanner Window
	/// </summary>
	public partial class DlgNetworkScanner : Form
	{
		public DlgNetworkScanner( List< WOL2Host > hl )
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			foreach( NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces() )
			{
				cboNic.Items.Add( new WOL2NicFacade( ni ) );
			}
			cboNic.SelectedIndex = 0;
			
			m_HostList = hl;
		}
		
		#region Get/Set Methods
		public void SetPingTimeout( int timeout )
		{
			m_iPingTimeout = timeout;
		}
		
		public void SetUnresolvedMacOk( bool ok )
		{
			m_bUnresolvedMacOk = ok;
		}
		
		public void SetUnresolvedNameOk( bool ok )
		{
			m_bUnresolvedNameOk = ok;
		}

        public bool ChangedHostList {get; private set;}

		#endregion
		
		#region Members
		private int m_iPingTimeout = 0;
		private bool m_bUnresolvedMacOk = false;
		private bool m_bUnresolvedNameOk = false;
		
		private List< WOL2Host > m_HostList = null;
		delegate void UIDelegate ( IAsyncResult result );				// The delegate for marshalling calls to the UI
		WOLNetworkScanner m_NetworkScanner;
		#endregion
		
		#region Callbacks
		public void NetworkScanFinished( IAsyncResult result )
		{
			if( this.InvokeRequired )
			{
				// We are, so marshall this call
				this.Invoke( new UIDelegate( NetworkScanFinished ),
				             result );
			}
			else
			{
				progressBar1.Value = 100;
				btnScan.Enabled = true;
				
				// Leave all items in the list
				// lbHosts.Items.Clear();
				
				foreach( WOL2Host h in m_NetworkScanner.Hosts )
				{
					lbHosts.Items.Add( h, true );
				}
				
				if( lbHosts.Items.Count > 0 )
					lbHosts.SelectedIndex = 0;

			}
			
		}
		
		public void NetworkScanStateCallback( IAsyncResult result )
		{
			if( this.InvokeRequired )
			{
				// We are, so marshall this call
				this.Invoke( new UIDelegate( NetworkScanStateCallback ),
				             result );
			}
			else
			{
				progressBar1.Value = (int)m_NetworkScanner.GetScanState();
			}
		}
		#endregion
		
		#region EventHandlers
		void CboNicSelectedIndexChanged(object sender, EventArgs e)
		{
			WOL2NicFacade nif = (WOL2NicFacade)cboNic.Items[ cboNic.SelectedIndex ];
			cboNetwork.Items.Clear();
			cboNetwork.Text = "";
			
			foreach( String s in nif.getNetworks() )
			{
				cboNetwork.Items.Add( s );
			}
			
			if( cboNetwork.Items.Count > 0 )
				cboNetwork.SelectedIndex=0;
			else
				cboNetwork.Text = MOE.Utility.GetStringFromRes("strNoNetworksFound");
		}

		void BtnScanClick(object sender, EventArgs e)
		{
			try
			{
				String sNet = cboNetwork.Text;
				int iPos = sNet.IndexOf( "-" );
				if( iPos > 0 )
				{
					sNet = sNet.Substring( 0, iPos ).Trim();
				}
				else 
					return;
				
				String sBc = cboNetwork.Text;
				int iPos2 = sBc.IndexOf( "/", ++iPos );
				if( iPos2 > 0 )
				{
					sBc = sBc.Substring( iPos, iPos2-iPos ).Trim();
				}
				else
					return;
				
				String sNm = cboNetwork.Text;
				sNm = sNm.Substring( ++iPos2, sNm.Length - iPos2 ).Trim();
				
				
				IPAddress from = IPAddress.Parse( sNet );
				IPAddress to = IPAddress.Parse( sBc );
				IPAddress nm = IPAddress.Parse( sNm );
				
				btnScan.Enabled = false;
				
				m_NetworkScanner = new WOLNetworkScanner(  new AsyncCallback( NetworkScanFinished ), new AsyncCallback( NetworkScanStateCallback ) );
				m_NetworkScanner.SetPingTimeout( m_iPingTimeout );
				m_NetworkScanner.SetUnresolvedMacOk( m_bUnresolvedMacOk );
				m_NetworkScanner.SetUnsesolvedNameOk( m_bUnresolvedNameOk );
				m_NetworkScanner.ScanIPv4Range( from, to, nm);
			}
			catch( Exception ex )
			{
				MOE.Logger.DoLog( "DlgNetworkScanner: " + ex.ToString(), MOE.Logger.LogLevel.lvlError );
			}
		}
		#endregion

		
		void BtnOkClick(object s, EventArgs x)
		{
			int iCount = 0;
            bool bChanged = false;
            foreach( WOL2Host h in lbHosts.CheckedItems )
			{
				// Check if this host already exists
		        WOL2Host foundHost = null;
                if (!m_HostList.Exists(delegate(WOL2Host theHost) { foundHost = theHost;  return h.Equals(theHost); } ))
                {
                    //if (h != null)
                    //{
                    MOE.Logger.DoLog("DlgNetworkScanner: Adding new Host " + h, MOE.Logger.LogLevel.lvlInfo);
                        m_HostList.Add(h);
                        iCount++;
                        bChanged = true;
                    //}
                }
                else
                {
                    // Check if a host was found, that is equal to the current one
                    if (foundHost != null)
                    {
                        MOE.Logger.DoLog("DlgNetworkScanner: Updating host " + foundHost + "...", MOE.Logger.LogLevel.lvlInfo);
                        
                        // If so, update it.
                        foundHost.SetIpAddress(h.GetIpAddress());
                        foundHost.SetIpV6Address(h.GetIpV6Address());
                        foundHost.SetSubnetMask(h.GetSubnetMask());
                        foundHost.SetMacAddress(h.GetMacAddress());
                        foundHost.SetName(h.GetName());
                        bChanged = true;
                        MOE.Logger.DoLog("DlgNetworkScanner: Updated host " + foundHost, MOE.Logger.LogLevel.lvlInfo);
                    }
                }
			}

            ChangedHostList = bChanged;
		}
		
		void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i = 0; i < lbHosts.Items.Count; i++)
			     lbHosts.SetItemChecked(i, true);
		}
		
		void DeselectAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i = 0; i < lbHosts.Items.Count; i++)
			     lbHosts.SetItemChecked(i, false);
		}
		
		void ClearTheListToolStripMenuItemClick(object sender, EventArgs e)
		{
			lbHosts.Items.Clear();
		}

        private void btnAddAndClose_Click(object sender, EventArgs e)
        {
            BtnOkClick(new object(), new EventArgs());
            this.Close();
        }
	}
	
	class WOL2NicFacade
	{
		public WOL2NicFacade( NetworkInterface ni )
		{
            MOE.Logger.DoLog("Creating WOL2NicFacade for NIC " + ni.Name + " (" + ni.NetworkInterfaceType + " - " + ni.OperationalStatus +  ")", MOE.Logger.LogLevel.lvlDebug);
            m_ni = ni;
		}
		
		public override String ToString()
		{
			String s = m_ni.Description;
			
			if( m_ni.OperationalStatus != OperationalStatus.Up )
				s += " " + MOE.Utility.GetStringFromRes("strDisconnected");
				
			return s;
		}
		
		public List<String> getNetworks()
		{
			List<String> lst = new List<string>();
			
			foreach( UnicastIPAddressInformation uipi in m_ni.GetIPProperties().UnicastAddresses ) 
			{
				if( uipi.Address != null && uipi.Address.ToString() != "127.0.0.1" )
				{
					if( uipi.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
					{
						if( uipi.Address != null && uipi.IPv4Mask != null )
                        {
                            IPAddress ip = WOL2DNSHelper.GetNetworkAddress( uipi.Address, uipi.IPv4Mask );
                            IPAddress bc = WOL2DNSHelper.GetBroadcastAddress(uipi.Address, uipi.IPv4Mask);
						
						    lst.Add( ip.ToString() + " - " + bc.ToString() + " / " + uipi.IPv4Mask );
                        }
                        else
                            MOE.Logger.DoLog( "Network " + uipi.ToString() + " is invalid!", MOE.Logger.LogLevel.lvlWarning );
					}
				}
			}
            MOE.Logger.DoLog("WOL2NicFacade.getNetworks() for NIC " + m_ni.Name + " returns a list of " + lst.Count + " networks.", MOE.Logger.LogLevel.lvlDebug);
			return lst;
		}
		
		private NetworkInterface m_ni;
	}
}
