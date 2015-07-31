/*
 * WOL2 Host Class
 * 
 */
using System;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WOL2
{
	public enum WOL2HostState
	{
		wolHostOffline = 0,
		wolHostOnline,
		wolHostStarting
	};
	
	public enum WOL2ConnectionType
	{
		wolConnectionLan = 0,
		wolConnectionWlan,
		wolConnectionBluetooth,
		wolConnectionVpn,
		wolConnection3g
	};
	
	/// <summary>
	/// Host Definition for WOL2
	/// </summary>
	public class WOL2Host
	{
		public WOL2Host()
		{
			m_nState 			= WOL2HostState.wolHostOffline;
			m_lPingReplyTime 	= -1;
            m_bStateChanged = false;
            PacketTransferMode = WOLPacketTransferMode.modeNone;
		}
		
		public WOL2Host( string sName, string sDescription, string sIpAddress,
		                 string sMacAddress, string sSubnetMask, /* string sSubnetAddress , */
		                 WOL2HostState nState, WOL2ConnectionType nConnection,
		                 string sGroups, string sIconFile, string sSecureOnPwd, bool bIsDynamicHost, 
		                 bool bWakeOnAlarm, bool bNotifyOnStateChanges, string sIpv6Address, WOLPacketTransferMode transfer )
		{
			m_sName 			= sName;
			m_sDescription 		= sDescription;
			m_sIpAddress 		= sIpAddress;
            m_sIpv6Address      = sIpv6Address;
			m_sMacAddress		= sMacAddress;
			// m_sSubnetAddress	= sSubnetAddress;
			m_sSubnetMask		= sSubnetMask;
			m_nState			= nState;
			m_nConnectionType	= nConnection;
			m_sIconFile			= sIconFile;
			m_sGroups			= sGroups;
			m_sSecureOnPasswd	= sSecureOnPwd;
			m_bWakeOnAlarm		= bWakeOnAlarm;
			m_bNotifyOnStateChanges = bNotifyOnStateChanges;
			m_bIsDynamicHost 	= bIsDynamicHost;
			m_lPingReplyTime 	= -1;
            m_bStateChanged     = false;
            PacketTransferMode = transfer;
		}
		
		/// <summary>
		/// Returns the host name.
		/// </summary>
		public string GetName( )
		{
			return m_sName;
		}
		
		/// <summary>
		/// Sets the host name.
		/// </summary>
		public void SetName( string sName )
		{
			m_sName = sName;
		}

		/// <summary>
		/// Returns the host IP Address.
		/// </summary>
		public string GetIpAddress( )
		{
			return m_sIpAddress;
		}

        /// <summary>
        /// Sets the host IP Address.
        /// </summary>
        public void SetIpAddress(string sIp)
        {
            m_sIpAddress = sIp;
        }

        /// <summary>
		/// Sets the host IPv6 Address.
		/// </summary>
		public void SetIpV6Address( string sIpV6 )
		{
			m_sIpv6Address = sIpV6;
		}

        /// <summary>
        /// Returns the host IPv6 Address.
        /// </summary>
        public string GetIpV6Address()
        {
            return m_sIpv6Address;
        }


		/// <summary>
		/// Returns the host MAC Adress.
		/// </summary>
		public string GetMacAddress( )
		{
			return m_sMacAddress;
		}
		
		/// <summary>
		/// Sets the host MAC Adress.
		/// </summary>
		public void SetMacAddress( string sMac )
		{
			// Set the normalized MAC address
			// If normalizing fails an empty mac will be returned making 
			// this host invalid.
			m_sMacAddress = NormalizeMacAddress( sMac );
		}
		
		/// <summary>
		/// Normalizes the given MAC Address
		/// </summary>
		/// <param name="sMac">The Address to normalize</param>
		/// <returns>The normalized MAC address or en empty string.</returns>
		private String NormalizeMacAddress( String sMac )
		{
			string s = "";
			String[] sMacArr = null; 
			try
			{
				if( sMac.Length == 12 )		// Format: aabbccddeeff
				{
					sMacArr = new String[6];
					sMacArr[0] = sMac.Substring(0,2);
					sMacArr[1] = sMac.Substring(2,2);
					sMacArr[2] = sMac.Substring(4,2);
					sMacArr[3] = sMac.Substring(6,2);
					sMacArr[4] = sMac.Substring(8,2);
					sMacArr[5] = sMac.Substring(10,2);
				}
				
				if( sMac.Length == 17  		// Format: aa:bb:cc:dd:ee:ff
					&& ( sMac.Contains( ":" ) || sMac.Contains( "-" ) ) )
				{
					sMacArr = sMac.Split( ':' );
					if( sMacArr.Length != 6 )
						sMacArr = sMac.Split( '-' );
				}
				
				if( sMacArr.Length == 6 )
				{
					s = sMacArr[0];
					s += ":";
					s += sMacArr[1];
					s += ":";
					s += sMacArr[2];
					s += ":";
					s += sMacArr[3];
					s += ":";
					s += sMacArr[4];
					s += ":";
					s += sMacArr[5];
				}   
			}
			catch( Exception ex )
			{
				MOE.Logger.DoLog( "NormalizeMacAddress(): " + ex.ToString(), MOE.Logger.LogLevel.lvlWarning );
			}
			
			return s;
			    
		}

		/* /// <summary>
		/// Returns the host subnet address.
		/// </summary>
		public string GetSubnetAddress( )
		{
			return m_sSubnetAddress;
		}*/
		
		/* /// <summary>
		/// Sets the host subnet address.
		/// </summary>
		public void SetSubnetAddress( string sSubnetAddress )
		{
			m_sSubnetAddress = sSubnetAddress;
		}*/

		/// <summary>
		/// Returns the host subnet mask.
		/// </summary>
		public string GetSubnetMask( )
		{
			return m_sSubnetMask;
		}
		
		/// <summary>
		/// Sets the host subnet mask.
		/// </summary>
		public void SetSubnetMask( string sSubnetMask )
		{
			m_sSubnetMask = sSubnetMask;
		}

		/// <summary>
		/// Returns the host description.
		/// </summary>
		public string GetDescription( )
		{
			return m_sDescription;
		}
		
		/// <summary>
		/// Sets the host description.
		/// </summary>
		public void SetDescription( string sDesc )
		{
			m_sDescription = sDesc;
		}
		
		/// <summary>
		/// Returns the hosts groups.
		/// </summary>
		public string GetGroups( )
		{
			return m_sGroups;
		}
		
		/// <summary>
		/// Sets the hosts groups.
		/// </summary>
		public void SetGroups( string sGroups )
		{
			m_sGroups = sGroups;
		}
		
		/// <summary>
		/// Returns the hosts SecureOn Password.
		/// </summary>
		public string GetSecureOnPassword( )
		{
			return m_sSecureOnPasswd;
		}
		
		/// <summary>
		/// Sets the hosts SecureOn Password.
		/// </summary>
		public void SetSecureOnPassword( string spwd )
		{
			m_sSecureOnPasswd = spwd;
		}
		
		/// <summary>
		/// Returns the hosts icon file.
		/// </summary>
		public string GetIconFile( )
		{
			return m_sIconFile;
		}
		
		/// <summary>
		/// Sets the hosts icon file.
		/// </summary>
		public void SetIconFile( string sIconFile )
		{
			m_sIconFile = sIconFile;
		}
		
		/// <summary>
		/// Returns true if the hosts uses DHCP.
		/// </summary>
		public bool IsDynamicHost( )
		{
			return m_bIsDynamicHost;
		}
		
		/// <summary>
		/// Sets whether the hosts uses DHCP.
		/// </summary>
		public void SetIsDynamicHost( bool b )
		{
			m_bIsDynamicHost = b;
		}
		
		/// <summary>
		/// Returns true if a notification should be displayed when the hosts state changes.
		/// </summary>
		public bool IsStateChangedNoftificationEnabled( )
		{
			return m_bNotifyOnStateChanges;
		}
		
		/// <summary>
		/// Sets if a notification should be displayed when the hosts state changes.
		/// </summary>
		public void SetIsStateChangedNoftificationEnabled( bool b )
		{
			m_bNotifyOnStateChanges = b;
		}

		/// <summary>
		/// Returns true if the host has a active timer associated.
		/// </summary>
		public bool IsWakeEnabled( )
		{
			return m_bWakeOnAlarm;
		}
		
		/// <summary>
		/// Sets whether the host has a active timer associated.
		/// </summary>
		public void SetIsWakeEnabled( bool b )
		{
			m_bWakeOnAlarm = b;
		}
		
		/// <summary>
		/// Changes the state of the host. Returns the previous state.
		/// </summary>
		public WOL2HostState SetState( WOL2HostState nState )
		{
			WOL2HostState oldState = m_nState;
			m_nState = nState;

            if (oldState != nState)
                m_bStateChanged = true;

			return oldState;
		}
		
		/// <summary>
		/// Returns the current state.
		/// </summary>
		public WOL2HostState GetState( )
		{
            m_bStateChanged = false;
            return m_nState;
		}

        /// <summary>
        /// Returns true when the state of this host has changed 
        /// after the last call to HasStateChanged() or GetState().
        /// 
        /// The StateChanged flag is reset after a call to HasStateChanged() 
        /// or GetState().
        /// </summary>
        public bool HasStateChanged( )
		{
            bool b = m_bStateChanged;
            m_bStateChanged = false;
            return b;
		}
        
		
		/// <summary>
		/// Changes the connection type of the host. Returns the previous type.
		/// </summary>
		public WOL2ConnectionType SetConnectionType( WOL2ConnectionType nConnectionType )
		{
			WOL2ConnectionType oldType = m_nConnectionType;
			m_nConnectionType = nConnectionType;
			return oldType;
		}
		
		/// <summary>
		/// Returns the hosts connection type.
		/// </summary>
		public WOL2ConnectionType GetConnectionType( )
		{
			return m_nConnectionType;
		}
		
		/// <summary>
		/// Changes the ping reply time of this host (or -1).
		/// </summary>
		public void SetPingReplyTime( long nTime )
		{
			m_lPingReplyTime = nTime;
		}
		
		/// <summary>
		/// Returns the hosts ping reply time.
		/// </summary>
		public long GetPingReplyTime( )
		{
			return m_lPingReplyTime;
		}
		
		/// <summary>
		/// Changes the associated list view item
		/// </summary>
		public void SetListViewItem( ListViewItem i )
		{
			m_ListItem = i;
		}
		
		/// <summary>
		/// Returns the associated list view item
		/// </summary>
		public ListViewItem GetListViewItem( )
		{
			return m_ListItem;
		}
		
		/// <summary>
		/// Changes the associated timer
		/// </summary>
		public void SetTimer( WOL2Timer t )
		{
			m_Timer = t;
		}
		
		/// <summary>
		/// Returns the associated wake timer
		/// </summary>
		public WOL2Timer GetTimer( )
		{
			return m_Timer;
		}

        /// <summary>
        /// Returns the associated reboot timer
        /// </summary>
        public WOL2Timer GetRebootTimer()
        {
            return m_RebootTimer;
        }

        /// <summary>
        /// Returns the associated shutdown timer
        /// </summary>
        public WOL2Timer GetShutdownTimer()
        {
            return m_ShutdownTimer;
        }
		
		/// <summary>
		/// Returns the string representation of the host.
		/// </summary>
		public override string ToString()
		{
			string s;
			s = m_sName + " (" + m_sIpAddress + " / " + m_sMacAddress + ")";
			return s;
		}
		
		/// <summary>
		/// Returns the XML representation of the host.
		/// </summary>
		/// <param name="doc">The XML document used to create the XmlNode.</param>	
		public XmlNode SerializeXml( XmlDocument doc ) 
		{
			// Create new host tag
			XmlNode xmlHost = doc.CreateElement( "Host" );
			
			// Fill the host tag
			XmlNode tmp = doc.CreateElement( "HostName" );
			tmp.InnerText = GetName();
			xmlHost.AppendChild( tmp );
			
			tmp = doc.CreateElement( "IPAddress" );
			tmp.InnerText = GetIpAddress();
			xmlHost.AppendChild( tmp );

            tmp = doc.CreateElement("IPV6Address");
            tmp.InnerText = GetIpV6Address();
            xmlHost.AppendChild(tmp);

			tmp = doc.CreateElement( "MACAddress" );
			tmp.InnerText = GetMacAddress();
			xmlHost.AppendChild( tmp );
			
			/* tmp = doc.CreateElement( "SubnetAddress" );
			tmp.InnerText = GetSubnetAddress();
			xmlHost.AppendChild( tmp ); */	// MOE: Not used anymore.
			
			tmp = doc.CreateElement( "SubnetMask" );
			tmp.InnerText = GetSubnetMask();
			xmlHost.AppendChild( tmp );
			
			tmp = doc.CreateElement( "IsDynamicHost" );
			tmp.InnerText = m_bIsDynamicHost ? "1" : "0";
			xmlHost.AppendChild( tmp );
			
            // MOE: Eacht timer has the enabled flag
			/* tmp = doc.CreateElement( "WakeOnAlarm" );
			tmp.InnerText = m_Timer.IsEnabled() ? "1" : "0";
			xmlHost.AppendChild( tmp ); */
			
			tmp = doc.CreateElement( "Comment" );
			tmp.InnerText = GetDescription();
			xmlHost.AppendChild( tmp );	
			
			tmp = doc.CreateElement( "Groups" );
			tmp.InnerText = m_sGroups;
			xmlHost.AppendChild( tmp );	
			
			// TODO: Serialize ConnectionType 
			tmp = doc.CreateElement( "ConnectionType" );
			tmp.InnerText = "";
			xmlHost.AppendChild( tmp );
			
			// TODO: Serialize Icon File 
			tmp = doc.CreateElement( "IconFile" );
			tmp.InnerText = "";
			xmlHost.AppendChild( tmp );
			
			// TODO: Serialize GridPositionX
			tmp = doc.CreateElement( "GridPositionX" );
			tmp.InnerText = "0";
			xmlHost.AppendChild( tmp );
			
			// TODO: Serialize GridPositionY
			tmp = doc.CreateElement( "GridPositionY" );
			tmp.InnerText = "0";
			xmlHost.AppendChild( tmp );
			
			tmp = doc.CreateElement( "NotifyOnStateChanges" );
			tmp.InnerText = m_bNotifyOnStateChanges ? "1" : "0";
			xmlHost.AppendChild( tmp );
			
			// Fill the Timer tag
			tmp = m_Timer.SerializeXml( doc, "Timer" );
			xmlHost.AppendChild( tmp );

            // Fill the Timer tag
            tmp = m_ShutdownTimer.SerializeXml(doc, "ShutdownTimer" );
            xmlHost.AppendChild(tmp);

            // Fill the Timer tag
            tmp = m_RebootTimer.SerializeXml(doc, "RebootTimer" );
            xmlHost.AppendChild(tmp);
			
			// Save the SecureOn password.
			tmp = doc.CreateElement( "SecureOnPwd" );
			tmp.InnerText = GetSecureOnPassword();
			xmlHost.AppendChild( tmp );
            
            // Save the PackageTransferMode
            tmp = doc.CreateElement("TransferMode");
            tmp.InnerText = PacketTransferMode.ToString();
            xmlHost.AppendChild(tmp);
			
			return xmlHost;
		}
		
		/// <summary>
		/// Recreates a host from an XML node.
		/// </summary>
		/// <param name="n">The XML node to recreate this host from.</param>	
		public bool DeserializeXML( XmlNode n )
		{
			while( n != null )
			{
                if (n.Name == "HostName")
                    SetName(n.InnerText);
                else if (n.Name == "IPAddress")
                    SetIpAddress(n.InnerText);
                else if (n.Name == "IPV6Address")
                    SetIpV6Address(n.InnerText);
                else if (n.Name == "MACAddress")
                    SetMacAddress(n.InnerText);
                else if (n.Name == "SecureOnPwd")
                    SetSecureOnPassword(n.InnerText);
                /* else if( n.Name == "SubnetAddress" )
                    SetSubnetAddress( n.InnerText );	*/	// MOE: Not used anymore.
                else if (n.Name == "SubnetMask")
                    SetSubnetMask(n.InnerText);
                else if (n.Name == "Comment")
                    SetDescription(n.InnerText);
                else if (n.Name == "Groups")
                    SetGroups(n.InnerText);
                else if (n.Name == "IconFile")
                    SetIconFile(n.InnerText);
                else if (n.Name == "IsDynamicHost")
                    m_bIsDynamicHost = (n.InnerText == "1" ? true : false);

                // Old Attribute "WakeOnAlarm" is mapped to the wake timer
                else if (n.Name == "WakeOnAlarm")
                    m_Timer.SetIsEnabled(n.InnerText == "1" ? true : false);
                // else if( n.Name == "ConnectionType" )
                //TODO: Load ConnectionType
                else if (n.Name == "Timer")
                    m_Timer.DeserializeXML(n.FirstChild);
                else if (n.Name == "ShutdownTimer")
                    m_ShutdownTimer.DeserializeXML(n.FirstChild);
                else if (n.Name == "RebootTimer")
                    m_RebootTimer.DeserializeXML(n.FirstChild);
                else if (n.Name == "NotifyOnStateChanges")
                    m_bNotifyOnStateChanges = (n.InnerText == "1" ? true : false);
                else if (n.Name == "TransferMode")
                {
                    try
                    {
                        PacketTransferMode = (WOLPacketTransferMode)Enum.Parse(typeof(WOLPacketTransferMode), n.InnerText);
                    }
                    catch { }
                }


				n = n.NextSibling;
			}
			
			return IsValid();
		}
		
		/// <summary>
		/// Serializes the Host using a format string
		/// </summary>
		/// <param name="sFormat">The format string used to serialize the host.</param>
		/// <returns>The serialized host</returns>
		public String SerializeCSV( String sFormat )
		{
			String s = sFormat;
			s = s.Replace( "{NAME}", GetName() );
			s = s.Replace( "{IP}", GetIpAddress() );
            s = s.Replace( "{IPV6}", GetIpV6Address());
			s = s.Replace( "{MAC}", GetMacAddress() );
			s = s.Replace( "{COMMENT}", GetDescription() );
			s = s.Replace( "{SUBNETMASK}", GetSubnetMask() );
			s = s.Replace( "{GROUPS}", GetGroups() );
			
			return s;
		}

        /// <summary>
        /// Expands the given string using placeholder variables
        /// </summary>
        /// <param name="sFormat">The format string to expand.</param>
        /// <returns>The expanded string.</returns>
        public string ExpandVariables(string what)
        {
            String s = what;
            s = s.Replace("%name%", GetName());
            s = s.Replace("%ip%", GetIpAddress());
            s = s.Replace("%ipv6%", GetIpV6Address());
            s = s.Replace("%mac%", GetMacAddress());
            s = s.Replace("%comment%", GetDescription());
            s = s.Replace("%snmask%", GetSubnetMask());
            s = s.Replace("%groups%", GetGroups());
            s = s.Replace("%state%", StateAsString());
            s = s.Replace("%dname%", IsDynamicHost() ? GetName() : GetIpAddress() );
            try
            {
                if( s.IndexOf("%dipv4%") >= 0 )
                    s = s.Replace("%dipv4%", WOL2DNSHelper.ResolveToIPv4(GetName())[0]);
            }
            catch { }
            try
            {
                if (s.IndexOf("%dipv6%") >= 0)
                    s = s.Replace("%dipv6%", WOL2DNSHelper.ResolveToIPv6Local(GetName()));
            }
            catch { }
            return s;
        }
		
		/// <summary>
		/// Checks whether this host has a valid name, ip, mac and subnet mask.
		/// </summary>
		/// <returns></returns>
		public bool IsValid()
		{
			if( m_sName != null && 
                m_sName.Length > 0 &&
			      m_sMacAddress != null && 
                  m_sMacAddress.Length > 0 )
				return true;
			else	
				return false;
		}
		
		/// <summary>
		/// Checks whether this host has the same MAC Address as 'h'.
		/// </summary>
		/// <param name="h">Other host.</param>
		/// <returns></returns>
		public bool Equals( WOL2Host h )
		{
			// If the host has a mac address compare those
            if( h.GetMacAddress() != null && h.GetMacAddress().Length >0 &&
                GetMacAddress() != null &&  GetMacAddress().Length>0 &&
                h.GetMacAddress().ToLower() == GetMacAddress().ToLower() )
				return true;
            // if it has an ip v6 address and this one is equal
            else if( h.GetIpV6Address() != null && h.GetIpV6Address().Length>0 &&
                     GetIpV6Address() != null && GetIpV6Address().Length>0 && 
                     h.GetIpV6Address()  == GetIpV6Address() )
                return true;
            // if it uses DHCP and the hostname is equal 
            else if (IsDynamicHost() &&
                     GetName() != null && GetName().Length > 0 &&
                     GetName() == h.GetName())
                return true;
            // if it does not use DHCP and the IPv4 Address is equal 
            else if (!IsDynamicHost() &&
                     GetIpAddress() != null && GetIpAddress().Length > 0 &&
                     GetIpAddress() == h.GetIpAddress())
                return true;
            else
				return false;
		}
		
		/// <summary>
		/// Returns this hosts state as a string
		/// </summary>
		public string StateAsString()
		{
			string t = MOE.Utility.GetStringFromRes("strUnknown");
			
			switch( GetState() )
			{
				case WOL2HostState.wolHostOffline:
					t = MOE.Utility.GetStringFromRes("strOffline");
					break;
				case WOL2HostState.wolHostOnline:
					t = MOE.Utility.GetStringFromRes("strOnline");
					break;
				case WOL2HostState.wolHostStarting:
					t = MOE.Utility.GetStringFromRes("strStarting");
					break;
			}
				
			return t;
		}

        /// <summary>
        /// Check if this hosts timer fires for the given DateTime
        /// </summary>
        /// <param name="check">Time to check.</param>
        /// <returns></returns>
        public bool CheckTimer(DateTime check)
        {
#if DEBUG
            Debug.Print("HOST ONLINE CHECK: " + ToString() + " at " + check.ToString());
#endif

            if (GetTimer().Check(check))
            {
                MOE.Logger.DoLog("HOST " + ToString() + " - Timer fires for " + check.ToString(),MOE.Logger.LogLevel.lvlInfo);
                return true;
            }
            else
                return false;
        }

        // Properties
        public WOLPacketTransferMode PacketTransferMode { get; set; }   // The desired packet transfer mode
		
		// Members
		private string 				m_sName;					// The host name
		private string 				m_sDescription;				// The hosts description
		private string 				m_sIpAddress;				// The hosts IPv4 address
        private string              m_sIpv6Address;             // The hosts IPv6 address     
		private string 				m_sMacAddress;				// The hosts MAC address
		private string 				m_sSubnetMask;				// The hosts Subnet Mask
		// private string 				m_sSubnetAddress;			// The hosts Subnet Address, not used anymore
		private string 				m_sGroups;					// The groups this host belongs to
		private string 				m_sIconFile;				// The Icon file for this host
		private string				m_sSecureOnPasswd;			// The SecureOn password for this host
        private bool                m_bStateChanged;            // The state of this host has changed
		
		private WOL2HostState 		m_nState;					// The current host state
		private WOL2ConnectionType	m_nConnectionType;			// The hosts connection type

		private WOL2Timer			m_Timer = new WOL2Timer();	                // The wake timer for this host
        private WOL2Timer           m_ShutdownTimer = new WOL2Timer();	        // The shutdown timer for this host
        private WOL2Timer           m_RebootTimer = new WOL2Timer();	        // The reboot timer for this host
		
		private bool				m_bIsDynamicHost;			// Indicates whether this host uses DHCP or not
		private bool 				m_bNotifyOnStateChanges;	// Indicates whether a notification is to be displayed when the state of the host changes
		private bool				m_bWakeOnAlarm;				// Indicates whether the timer for this host is active
		
		private long				m_lPingReplyTime;			// The reply time of the last ping or -1 if offline
		
		private ListViewItem		m_ListItem;					// The associated ListViewItem
	}		
}
