/*
 * WOL2 Main Form
 */
using System;
using System.Collections.Generic;	// Dictionary
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Net.NetworkInformation; 
using System.Net;
using System.Net.Sockets;
using System.Security;

using Microsoft.Win32;
using ListViewSorter;
using CommandLine.Utility;

using WOL2;
using MOE;
using System.IO;
using System.Security.Permissions;


namespace WOL2
{
	[Flags]
	public enum WOLPacketTransferMode
	{
		modeNone = 0x0,
        modeUDP = 0x1,  // unused but kept for compatibility reasons
        modeTCP = 0x2,  // unused but kept for compatibility reasons
		modeBCast = 0x4,
		modeNetCast = 0x8,
		modeSendToHost = 0x10
	}

	/// <summary>
	/// This is the WOL2 Main Form.
	/// </summary>
	public partial class MainForm : Form
	{
		[STAThread]
		public static void Main(string[] args)
		{		
			// Show the window
			Application.EnableVisualStyles();
			MainForm mf = new MainForm( args );
			if( !mf.m_bNoStart )
				Application.Run(mf);
			else
				Application.Exit();
		}
		
		public MainForm( string[] args )
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
		
			// Initialize the command line arguments class
            Arguments CommandLine = new Arguments(args);
            
            // Create a new list view sorter
            m_ListViewSorter = new ListViewColumnSorter();
            listView.ListViewItemSorter = m_ListViewSorter;

			// Load the settings
            #region Read Profile ----------------------

            string sLastFile = "";

            // Check where we should read our settings from
            if (CommandLine["registry"] != null)
            {
                m_bUseRegistryProfile = true;
            }
            else if (!WOL2Profile.HasXmlProfile())
            {
                m_bUseRegistryProfile = true;
            }

            WOL2Profile profile = new WOL2Profile(m_bUseRegistryProfile);
            if (profile.OpenProfile(WOL2Profile.WOL2ProfileAccessMode.ModeRead))
            {
                m_iOnlineCheckInterval = profile.GetSetting("RefreshInterval", 10000); // milli seconds
                m_iWakeDelay = profile.GetSetting("GroupWakeDelay", 500);
                m_iWakePort = profile.GetSetting("WOLPort", 7);
                m_iPingTimeout = profile.GetSetting("PingTimeout", 250);
                listView.View = (View)View.Parse(typeof(View), (string)profile.GetSetting("ViewStyle", "Details"));
                m_PacketTransferOptions = (WOLPacketTransferMode)Enum.Parse(typeof(WOLPacketTransferMode), profile.GetSetting("WOLFlags", "modeBCast"), true);
                m_bAskForSecureOnPwd = profile.GetSetting("AskForSecureOnPwd", false);
                m_bOpenLastFile = profile.GetSetting("OpenLastFile", true);
                sLastFile = profile.GetSetting("LastFile", "");
                m_bHasDoneSurvey = profile.GetSetting("SurveyCompleted", false);

                m_bDoLogging = profile.GetSetting("DoLogging", false);

                // Start Logging?
#if DEBUG
                MOE.Logger.StartLogging("wol2.log", Logger.LogLevel.lvlDebug);
#else
            if (m_bDoLogging)
                MOE.Logger.StartLogging("wol2.log", Logger.LogLevel.lvlDebug);
#endif

                m_bColorizeListView = profile.GetSetting("ColorizeListView", false);
                m_bAutosaveHostFile = profile.GetSetting("AutosaveHostlist", false);
                m_bMinimizeToTray = profile.GetSetting("MinimizeToTray", false);
                m_bConfirmNetActions = profile.GetSetting("ConfirmNetworkOptions", true);
                m_bUseIpV6 = profile.GetSetting("UseIPv6", false);

                // Notification options
                m_bDisplayStateNotifications = profile.GetSetting("DisplayStateNotifications", false);
                m_bAlwaysDisplayNotifications = profile.GetSetting("AlwaysDisplayNotifications", false);
                m_iNotificationTimeout = profile.GetSetting("NotificationTimeout", 3000);   // ms
                m_bUpdateIPInOnlineChecker = profile.GetSetting("UpdateIPAddressesForDHCP", false); 
                
                m_sHostStateChangedCommand = profile.GetSetting("HostStateChangedCommand", "");
                m_sGroupStateChangedCommand = profile.GetSetting("GroupStateChangedCommand", "");

                // Network scanner options
                m_bUnresolvedNameOk = profile.GetSetting("UnresolvedNameOk", false);
                m_bUnresolvedMacOk = profile.GetSetting("UnresolvedMacOk", false);

                // Restore List View Columns
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    int d = profile.GetSetting("ColumnOrder" + i, -1);
                    int w = profile.GetSetting("ColumnWidth" + i, -1);

                    if (d != -1)
                        listView.Columns[i].DisplayIndex = d;
                    if (w != -1)
                    {
                        listView.Columns[i].Width = w;
                    }
                }

                // Restore the list view sort order
                m_ListViewSorter.SortColumn = profile.GetSetting("SortColumn", 0);
                m_ListViewSorter.Order = profile.GetSetting("SortOrder", "Ascending") == "Ascending" ? SortOrder.Ascending : SortOrder.Descending;

                // Make the sort order visible
                ListViewExtensions.SetSortIcon(listView, m_ListViewSorter.SortColumn, m_ListViewSorter.Order);
                listView.Sort();

                // Load tools
                string temp = profile.GetSetting("Tool0", "");
                int idx = 0;
                while (temp != "")
                {
                    WOL2Tool t = WOL2Tool.parse(temp);
                    if (t != null)
                        m_Tools.Add(t.GetName(), t);

                    temp = profile.GetSetting("Tool" + ++idx, "");
                }

                // Load the MRU
                temp = profile.GetSetting("MRUItem1", "");
                idx = 1;
                while (temp != "")
                {
                    m_MruList.Add(temp);
                    temp = profile.GetSetting("MRUItem" + ++idx, "");
                }
                BuildMruList();

                m_iShutdownTimeout = profile.GetSetting("ShutdownTimeout", 60);   // seconds
                m_sShutdownComment = profile.GetSetting("ShutdownComment", "");
                temp = profile.GetSetting("ShutdownPaswd", "");
                if (temp != "")
                {
                    string s = MOE.Utility.Base64Decode(temp);
                    m_sShutdownPaswd = MOE.Utility.SecureStringFromString(s);
                }
                m_sShutdownUser = profile.GetSetting("ShutdownUser", "");
                m_sShutdownDomain = profile.GetSetting("ShutdownDomain", "");
                m_bForceShutdown = profile.GetSetting("ForceShutdown", false);

                m_iRebootTimeout = profile.GetSetting("RebootTimeout", 60);
                m_sRebootComment = profile.GetSetting("RebootComment", "");
                temp = profile.GetSetting("RebootPaswd", "");
                if (temp != "")
                {
                    string s = MOE.Utility.Base64Decode(temp);
                    m_sRebootPaswd = MOE.Utility.SecureStringFromString(s);
                }
                m_sRebootUser = profile.GetSetting("RebootUser", "");
                m_sRebootDomain = profile.GetSetting("RebootDomain", "");
                m_bForceReboot = profile.GetSetting("ForceReboot", false);

                // Done
                profile.CloseProfile();
                profile = null;
            }
			#endregion
				
			// Create an empty document
			CreateNewHostsFile();
				
			// Parse the command line.
			if( CommandLine["file"] != null )
			{
				OpenHostList( CommandLine["file"] );
			} 
            else
			{
				// Check whether to open the last file
				if( m_bOpenLastFile && sLastFile != "" )
				{
					m_sHostFileName = sLastFile;
                    OpenHostList(m_sHostFileName);
				}	
			}
				
			if( CommandLine["wake"] != null )
			{
				string s = CommandLine["wake"];
				string [] sHosts = s.Split( ';' );
					
				Monitor.Enter( m_LockHosts );
					
				foreach( string sHost in sHosts )
				{
					WOL2Host h = m_Hosts.Find( delegate( WOL2Host theHost ) { return theHost.GetName().ToLower() == sHost.ToLower(); } );
					if( h != null )
						WakeHost( h, true );

                    DateTime dwTime = DateTime.Now.AddMilliseconds(m_iWakeDelay);
                    while (DateTime.Now < dwTime)
                        Application.DoEvents();
				}
					
				Monitor.Exit( m_LockHosts );
			}

            if (CommandLine["shutdown"] != null)
            {
                string s = CommandLine["shutdown"];
                string[] sHosts = s.Split(';');

                Monitor.Enter(m_LockHosts);

                foreach (string sHost in sHosts)
                {
                    WOL2Host h = m_Hosts.Find(delegate(WOL2Host theHost) { return theHost.GetName().ToLower() == sHost.ToLower(); });
                    if (h != null)
                        ShutdownHost(h, true);
                }

                Monitor.Exit(m_LockHosts);
            }

            if (CommandLine["reboot"] != null)
            {
                string s = CommandLine["reboot"];
                string[] sHosts = s.Split(';');

                Monitor.Enter(m_LockHosts);

                foreach (string sHost in sHosts)
                {
                    WOL2Host h = m_Hosts.Find(delegate(WOL2Host theHost) { return theHost.GetName().ToLower() == sHost.ToLower(); });
                    if (h != null)
                        RebootHost(h, true);
                }

                Monitor.Exit(m_LockHosts);
            }

            if (CommandLine["wakegrp"] != null)
            {
                string s = CommandLine["wakegrp"];
                string[] sGroups = s.Split(';');

                foreach (string sGroup in sGroups)
                {
                    WOL2Group g;
                    if( m_Groups.TryGetValue( sGroup, out g ) )
                        WakeGroup(g, true);
                }
            }

            if (CommandLine["rebootgrp"] != null)
            {
                string s = CommandLine["rebootgrp"];
                string[] sGroups = s.Split(';');

                foreach (string sGroup in sGroups)
                {
                    WOL2Group g;
                    if (m_Groups.TryGetValue(sGroup, out g))
                        RebootGroup(g, true);
                }
            }

            if (CommandLine["shutdowngrp"] != null)
            {
                string s = CommandLine["shutdowngrp"];
                string[] sGroups = s.Split(';');

                foreach (string sGroup in sGroups)
                {
                    WOL2Group g;
                    if (m_Groups.TryGetValue(sGroup, out g))
                        ShutdownGroup(g, true);
                }
            }

			// Last parameter: Close the App.
			if( CommandLine["close"] != null )
			{
				this.Close();
				m_bNoStart = true;
				return;
			}

			// Refresh the tools menu
			RefreshToolsMenu();
			
			// Kick Up the OnlineStateChecker
			InitOnlineStateChecker();
			
			// Say hello
			lblStatus.Text = MOE.Utility.GetStringFromRes("strWelcome");

            // Load toolbar settings
            ToolStripManager.LoadSettings(this);

            // Make the toolbars visible if they were hidden (by a bug in ToolStripManager)
            toolStrip1.Visible = true;
            toolStripTools.Visible = true;
            menuStrip1.Visible = true;
            statusStrip1.Visible = true;
		}

        /// <summary>
        /// Called on form load
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
		
		/// <summary>
		/// Exits the tool, saving all settings.
		/// </summary>
		public void ExitWOLTool( bool bQuitApp )
		{
            // Save the toolbar
            // Only do this if the window is visible as the toolpositions would be lost otherwise
            if (this.WindowState != FormWindowState.Minimized && this.Visible == true ) 
                ToolStripManager.SaveSettings(this);

            // If the file was changed prop for save
            if (m_bChangedFile)
            {
                string msg = MOE.Utility.GetStringFromRes("strSaveChangedFile");
                DialogResult dr = MessageBox.Show(this, msg, "WOL2", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveHostList(m_sHostFileName.Length > 0 ? m_sHostFileName : null);
                }
            }

            WOL2Profile profile = new WOL2Profile(m_bUseRegistryProfile);
            if (profile.OpenProfile(WOL2Profile.WOL2ProfileAccessMode.ModeWrite))
            {
                profile.SaveSetting("RefreshInterval", m_iOnlineCheckInterval);
                profile.SaveSetting("GroupWakeDelay", m_iWakeDelay);
                profile.SaveSetting("WOLPort", m_iWakePort);
                profile.SaveSetting("PingTimeout", m_iPingTimeout);
                profile.SaveSetting("ViewStyle", listView.View.ToString());
                profile.SaveSetting("OpenLastFile", m_bOpenLastFile);
                profile.SaveSetting("LastFile", m_sHostFileName);
                profile.SaveSetting("DoLogging", m_bDoLogging);
                profile.SaveSetting("ColorizeListView", m_bColorizeListView);
                profile.SaveSetting("AutosaveHostlist", m_bAutosaveHostFile);
                profile.SaveSetting("MinimizeToTray", m_bMinimizeToTray);
                profile.SaveSetting("ConfirmNetworkOptions", m_bConfirmNetActions);
                profile.SaveSetting("UseIPv6", m_bUseIpV6);
                profile.SaveSetting("HostStateChangedCommand", m_sHostStateChangedCommand);
                profile.SaveSetting("GroupStateChangedCommand", m_sGroupStateChangedCommand);

                profile.SaveSetting("DisplayStateNotifications", m_bDisplayStateNotifications);
                profile.SaveSetting("AlwaysDisplayNotifications", m_bAlwaysDisplayNotifications);
                profile.SaveSetting("NotificationTimeout", m_iNotificationTimeout);
                profile.SaveSetting("UpdateIPAddressesForDHCP", m_bUpdateIPInOnlineChecker);
                
                profile.SaveSetting("WOLFlags", m_PacketTransferOptions.ToString());
                profile.SaveSetting("AskForSecureOnPwd", m_bAskForSecureOnPwd);

                profile.SaveSetting("SortColumn", m_ListViewSorter.SortColumn.ToString());
                profile.SaveSetting("SortOrder", m_ListViewSorter.Order.ToString());

                for( int idx = 0; idx < listView.Columns.Count; idx++ )
                {
                    profile.SaveSetting("ColumnOrder" + idx, listView.Columns[idx].DisplayIndex);
                    profile.SaveSetting("ColumnWidth" + idx, listView.Columns[idx].Width);    
                }

                profile.SaveSetting("ShutdownTimeout", m_iShutdownTimeout);
                if (m_sShutdownComment != null)
                    profile.SaveSetting("ShutdownComment", m_sShutdownComment);
                profile.SaveSetting("ShutdownPaswd", MOE.Utility.Base64Encode(MOE.Utility.SecureStringToString(m_sShutdownPaswd)));
                if (m_sShutdownUser != null)
                    profile.SaveSetting("ShutdownUser", m_sShutdownUser);
                if (m_sShutdownDomain != null)
                    profile.SaveSetting("ShutdownDomain", m_sShutdownDomain);
                profile.SaveSetting("ForceShutdown", m_bForceShutdown);

                profile.SaveSetting("RebootTimeout", m_iRebootTimeout);
                if (m_sRebootComment != null)
                    profile.SaveSetting("RebootComment", m_sRebootComment);

                profile.SaveSetting("RebootPaswd", MOE.Utility.Base64Encode(MOE.Utility.SecureStringToString(m_sRebootPaswd)));

                if (m_sRebootUser != null)
                    profile.SaveSetting("RebootUser", m_sRebootUser);
                if (m_sRebootDomain != null)
                    profile.SaveSetting("RebootDomain", m_sRebootDomain);
                profile.SaveSetting("ForceReboot", m_bForceReboot);

                // Network scanner options
                profile.SaveSetting("UnresolvedNameOk", m_bUnresolvedNameOk);
                profile.SaveSetting("UnresolvedMacOk", m_bUnresolvedMacOk);

                // Survey
                profile.SaveSetting("SurveyCompleted", m_bHasDoneSurvey);

                // Save the current window state
                if (this.Visible == false)
                    profile.SaveSetting("Window_State", FormWindowState.Minimized.ToString());
                else
                    profile.SaveSetting("Window_State", this.WindowState.ToString());

                // Reset the window state so we know the window sizes
                this.WindowState = FormWindowState.Normal;

                // Window position
                profile.SaveSetting("Window_X", this.Left);
                profile.SaveSetting("Window_Y", this.Top);
                profile.SaveSetting("Window_Width", this.Width);
                profile.SaveSetting("Window_Height", this.Height);
                
                // Add new tool keys
                int i = 0;
                foreach (WOL2Tool t in m_Tools.Values)
                {
                    profile.SaveSetting("Tool" + i++, t.ToString());
                }

                // Save the MRU
                for (int itm = 0; itm < m_MruList.Count; itm++)
                {
                    if (itm >= 10)
                        break;

                    profile.SaveSetting("MRUItem" + (itm + 1), m_MruList[itm]);
                }
            }
            
            // Done
            profile.CloseProfile();
            profile = null;

			MOE.Logger.StopLogging();
			
			if( bQuitApp )
				Application.Exit();
			
		}
		
		/// <summary>
		/// Wakes a single host.
		/// </summary>
		/// <param name="idx">Index of the host to wake in the list view.</param>
		public bool WakeHost( WOL2Host h, bool bNoConfirm )
		{
            if (!bNoConfirm)
            {
                string sAction = "Wake host " + h.GetName();
                if (ConfirmAction(sAction) == false)
                    return false;
            }

            bool bRet = false;
			if( h != null )
			{
				SendWOLPacket( h );
				bRet = true;
				
				lblStatus.Text = String.Format( MOE.Utility.GetStringFromRes("strSendWolPackageToHost"),h.GetName());
			}
			
			return bRet;
		}
		
		/// <summary>
		/// Wakes all selected hosts (if any).
		/// </summary>
		public bool WakeSelectedHosts()
		{
			if( listView.SelectedItems.Count > 0 )
			{
                string sAction = "Wake " + listView.SelectedItems.Count  + " Hosts";
                if (ConfirmAction(sAction) == false)
                    return false;

				foreach( ListViewItem i in listView.SelectedItems )
				{
					WOL2Host h = (WOL2Host)i.Tag;
					
					if( h != null )
					{
                        if (h.GetMacAddress().Length < 6)
                        {
                            string msg = MOE.Utility.GetStringFromRes("strNeedMacAdressForThat");
                            string sErr = MOE.Utility.GetStringFromRes("strError");
                            MessageBox.Show(this, msg, sErr + " (" + h.ToString() + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            WakeHost( h, true );
					}

                    DateTime dwTime = DateTime.Now.AddMilliseconds(m_iWakeDelay);
                    while (DateTime.Now < dwTime)
                        Application.DoEvents();
				}
			}
			return true;
		}

        /// <summary>
        /// Updates the given host in the list view (if visible)
        /// </summary>
        private void RefreshHost(WOL2Host h)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    // We are, so marshall this call
                    this.Invoke(new UpdateHost(RefreshHost), h);
                }
                catch
                {
                    // Do nothing. Its most likely that the app is closing.
                }

            }
            else
            {
                // Find the list item
                foreach (ListViewItem itm in listView.Items)
                {
                    if (itm.Tag == h)
                    {
                        AssignHostToListItem(h, itm);
                        return;
                    }
                }
            }
        }

		/// <summary>
		/// Inserts all hosts in m_Hosts into the listView.
		/// </summary>		
		private void RefreshHostList()
		{
			// Clean the old list
			listView.Items.Clear();
			listView.BeginUpdate();
			
			// Insert the new items
			Monitor.Enter( m_LockHosts );
			
			foreach( WOL2Host h in m_Hosts )
			{
				// Verify the group
				if(  m_CurrentGroup == null ||
				     ( h.GetGroups() != null && h.GetGroups().Contains( m_CurrentGroup.GetName() ) ) )
				{
				
					// Lock the list view
					Monitor.Enter( listView );
					
					// Create a new item
					ListViewItem i = new ListViewItem();
					
					// Assign the item
					AssignHostToListItem( h, i );
					
					// Insert the list view item
					this.listView.Items.Add( i );
					
					// Release the listview
					Monitor.Exit( listView );
				}
								
			}
			
			Monitor.Exit( m_LockHosts );
			
			// Resize Columns
			//foreach( ColumnHeader x in listView.Columns )
				//x.AutoResize( listView.Items.Count > 0 ? ColumnHeaderAutoResizeStyle.ColumnContent : ColumnHeaderAutoResizeStyle.HeaderSize );
			
			// Done with updating the list view
			listView.EndUpdate();			
		}
		
		public void AssignHostToListItem( WOL2Host h, ListViewItem i )
		{
			// Remove old values in case of an update
			i.SubItems.Clear();
			
			// Update / Add the item
			i.Text = h.GetName();
            switch (h.GetState())
            {
                default:
                case WOL2HostState.wolHostOffline:
                    i.ImageIndex = 0;
                    break;
                case WOL2HostState.wolHostOnline:
                    i.ImageIndex = 1;
                    break;
                case WOL2HostState.wolHostStarting:
                    i.ImageIndex = 2;
                    break;
            }

			// Add the sub items
			i.UseItemStyleForSubItems = false;
			
			i.SubItems.Add( h.GetIpAddress() );
			i.SubItems.Add( h.GetMacAddress() );
			i.SubItems.Add( h.GetDescription() );
			
			System.Windows.Forms.ListViewItem.ListViewSubItem itm = i.SubItems.Add( h.StateAsString() );
			
			if( m_bColorizeListView )
			{
				if( h.GetState() == WOL2HostState.wolHostOnline )
					itm.BackColor = Color.Green;
				else
					itm.BackColor = Color.Red;
			}

            string sManufacturer = "";
            if( h.GetMacAddress() != null && h.GetMacAddress().Length > 4 )
                sManufacturer = m_macResolver.GetManufacturerFromMac(h.GetMacAddress());

            i.SubItems.Add(sManufacturer );

            // Add the IP v 6 address
            i.SubItems.Add(h.GetIpV6Address());
			    
			
			// Wire the two objects together
			i.Tag = h;
			h.SetListViewItem( i );
		}
		
		/// <summary>
		/// Saves the current host file
		/// </summary>	
		/// <param name="sFile">The file to save the host list to or null.</param>		
		public bool SaveHostList( string sFile )
		{
			bool bRet = false;
			
			if( sFile == null )
			{
				// Ask for a xml file
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.FileName = m_sHostFileName;
				saveFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*" ;
				saveFileDialog1.FilterIndex = 1;
				saveFileDialog1.RestoreDirectory = true ;
				
				// Read and filter the raw data
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    while (Path.GetFileName(saveFileDialog1.FileName ).ToLower()== WOL2Profile.PROFILE_FILE_NAME.ToLower())
                    {
                        string msg = MOE.Utility.GetStringFromRes("strOverwriteProfile");
                        MessageBox.Show(this, msg, "WOL2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dr = saveFileDialog1.ShowDialog();
                        if (dr != DialogResult.OK)
                            return false;
                    }

                    sFile = saveFileDialog1.FileName;
                }
                else
                    return false;
			}
			
			if( sFile != null )
			{			
				// Create the XML document
				XmlDocument xml = new XmlDocument();
				xml.LoadXml( "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><WakeOnLan></WakeOnLan>" );
				
				// Insert the content
				XmlNode xmlMain = xml.GetElementsByTagName( "WakeOnLan" )[0];
				
				// <Hosts></Hosts>
				XmlNode xmlHosts = xml.CreateElement( "Hosts" );
				xmlMain.AppendChild( xmlHosts );
			
				Monitor.Enter( m_LockHosts );
				
				foreach( WOL2Host h in m_Hosts )
				{
					// Insert the host tag
					xmlHosts.AppendChild( h.SerializeXml( xml ) );
				}
				
				Monitor.Exit( m_LockHosts );
				
				// <Groups></Grous>
				XmlNode xmlGroups = xml.CreateElement( "Groups" );
				
				Monitor.Enter( m_Groups );
				foreach( WOL2Group g in m_Groups.Values )
				{
					// Insert the host tag
					xmlGroups.AppendChild( g.SerializeXml( xml ) );
				}
				Monitor.Exit( m_Groups );
				
				xmlMain.AppendChild( xmlGroups );
                
                // Get the HostFile Note
                XmlNode tmp = xml.CreateElement("Comment");
                tmp.InnerText = m_sHostFileNote;
                xmlMain.AppendChild(tmp);
                tbtnNote.ToolTipText = m_sHostFileNote;
				
				// Save the file
				xml.Save( sFile );
				m_sHostFileName = sFile;
				bRet = true;
				
				lblStatus.Text = MOE.Utility.GetStringFromRes("strFileSaved");
			}
			
			MOE.Logger.DoLog( "Saved host file as " + sFile, Logger.LogLevel.lvlInfo );

            m_bChangedFile = false;

			return bRet;			
		}
		
		/// <summary>
		/// Opens a host file
		/// </summary>	
		/// <param name="sFile">The file to open.</param>		
		public bool OpenHostList( string sFile )
		{
			bool bRet = false;
			
			if( sFile == null )
			{
				// Ask for a xml file
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				openFileDialog1.FileName = m_sHostFileName;
				openFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*" ;
				openFileDialog1.FilterIndex = 1;
				openFileDialog1.RestoreDirectory = true ;
				
				// Read and filter the raw data
				if(openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					sFile = openFileDialog1.FileName;
				}
				
				
			}
			
			if( sFile != null )
			{			
				int iCount = 0;
				
				// Create the XML document
				XmlDocument xml = new XmlDocument();
				try
				{
					// Try to load the file
					xml.Load( sFile );
					
					// Clean the old host list
					Monitor.Enter( m_LockHosts );
					m_Hosts.Clear();
					m_Groups.Clear();
					Monitor.Exit( m_LockHosts );
					
					m_CurrentGroup = null;

                    // Try to get the host nodes
					XmlNodeList xmlHosts = xml.SelectNodes( "/WakeOnLan/Hosts/Host" );
					
					// Insert all hosts
					Monitor.Enter( m_LockHosts );
					
					foreach( XmlNode hostNode in xmlHosts )
					{
						// Insert the host
						WOL2Host h = new WOL2Host( );
						XmlNode n = hostNode.FirstChild;
						
						if( h.DeserializeXML( n ) )
						{
							m_Hosts.Add( h );
							h.SetState( WOL2HostState.wolHostOffline );
							iCount++;
						}
						
					}
					Monitor.Exit( m_LockHosts );
					
					// Try to get the group nodes
					XmlNodeList xmlGroups = xml.SelectNodes( "/WakeOnLan/Groups/Group" );
					
					// Insert all groups
					Monitor.Enter( m_Groups );
					foreach( XmlNode groupNode in xmlGroups )
					{
						XmlNode n = groupNode.FirstChild;
						WOL2Group g = new WOL2Group();
						g.DeserializeXML( n );
						
						if( g.IsValid() )
						{
							m_Groups.Add( g.GetName(), g );
						}
					}
					Monitor.Exit( m_Groups );
					
					RefreshGroupList();
					
                    // Get the HostFile Note
                    XmlNode tmp = xml.SelectSingleNode("/WakeOnLan/Comment");
                    if (tmp != null)
                    {
                        m_sHostFileNote = tmp.InnerText;
                        tbtnNote.ToolTipText = m_sHostFileNote;
                    }

					// File loaded...
					m_sHostFileName = sFile;
					bRet = true;
					RefreshHostList();
					
					lblStatus.Text = String.Format( MOE.Utility.GetStringFromRes("strFileOpened"), iCount );
					
					MOE.Logger.DoLog( "Opened host file " + sFile + " with " + iCount + " hosts.", Logger.LogLevel.lvlInfo );

                    // Add the file to the MRU list if not present yet
                    if (m_MruList.IndexOf(sFile) == -1)
                    {
                        m_MruList.Insert(0, sFile);
                        BuildMruList();
                    }
					
				} catch
				{
					// Some Error
				}
			}

            // new file
            m_bChangedFile = false;
			
			return bRet;			
		}

        private void BuildMruList()
        {
            mnuMRU.DropDown.Items.Clear();
            foreach (string s in m_MruList)
            {
                int iPos = s.LastIndexOf('\\');
                if (iPos == -1)
                    iPos = s.LastIndexOf('/');
                if (iPos == -1)
                    iPos = s.LastIndexOf(':');

                string name = s;
                if (iPos > 0)
                    name = s.Substring(iPos + 1);

                ToolStripItem itm = mnuMRU.DropDown.Items.Add(name);
                itm.ToolTipText = s;
                itm.Click += new EventHandler(mRUToolStripMenuItem_Click);
            }
        }
		
		/// <summary>
		/// Inserts a new host
		/// </summary>	
		public void InsertNewHost(WOL2Host h)
		{
			if( h == null )
                h = new WOL2Host();

			DlgEditHost dlg = new DlgEditHost( h );
			DialogResult dr = dlg.ShowDialog( this );

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                if (h.IsValid())
                {
                    _AddHost(h);
                }
                else
                {
                    // Re open the edit window
                    InsertNewHost(h);
                }
            }
			
		}

        /**
         * Inserts the host to the current list
         */
        private void _AddHost(WOL2Host h)
        {
            Monitor.Enter(m_LockHosts);

            m_Hosts.Add(h);
            RefreshHostList();

            Monitor.Exit(m_LockHosts);

            ChangedHostsFile();
        }

        /**
         * 
         */
        private void ChangedHostsFile()
        {
            if (m_bAutosaveHostFile && m_sHostFileName != null && m_sHostFileName.Length > 0)
            {
                SaveHostList(m_sHostFileName);
            }
            else
                m_bChangedFile = true;
        }
		
		/// <summary>
		/// Creates a new and empty hosts file
		/// </summary>	
		public void CreateNewHostsFile()
		{
			Monitor.Enter( m_LockHosts );
			m_Hosts.Clear();
			m_sHostFileName = "";
			Monitor.Exit( m_LockHosts );
			
			RefreshHostList();
		}
		
		/// <summary>
		/// Edits the selected host(s)
		/// </summary>	
		public void EditSelectedHost()
		{
			if( listView.SelectedItems.Count > 0 )
			{
				WOL2Host h = (WOL2Host)listView.SelectedItems[0].Tag;
				
				if( h != null )
				{
					DlgEditHost dlg = new DlgEditHost( h );
					dlg.ShowDialog( this );
					
					// Assign the item
					AssignHostToListItem( h, h.GetListViewItem() );

                    // Mark the file as changed
                    ChangedHostsFile();
				}
			}
		}
		
		public void EditSelectedTimer()
		{
			if( listView.SelectedItems.Count > 0 )
			{
				WOL2Host h = (WOL2Host)listView.SelectedItems[0].Tag;
				
				if( h != null )
				{
					DlgEditTimer dlg = new DlgEditTimer( h.GetTimer() );
					dlg.Text = String.Format( MOE.Utility.GetStringFromRes("strEditTimerForHost"), h.GetName() );
					dlg.ShowDialog( this );

                    // Mark the file as changed
                    ChangedHostsFile();
				}
			}
		}

        public void EditSelectedRebootTimer()
        {
            if (listView.SelectedItems.Count > 0)
            {
                WOL2Host h = (WOL2Host)listView.SelectedItems[0].Tag;

                if (h != null)
                {
                    DlgEditTimer dlg = new DlgEditTimer(h.GetRebootTimer());
                    dlg.Text = String.Format(MOE.Utility.GetStringFromRes("strEditRebootTimerForHost"), h.GetName());
                    dlg.ShowDialog(this);

                    // Mark the file as changed
                    ChangedHostsFile();
                }
            }
        }

        public void EditSelectedShutdownTimer()
        {
            if (listView.SelectedItems.Count > 0)
            {
                WOL2Host h = (WOL2Host)listView.SelectedItems[0].Tag;

                if (h != null)
                {
                    DlgEditTimer dlg = new DlgEditTimer(h.GetShutdownTimer());
                    dlg.Text = String.Format(MOE.Utility.GetStringFromRes("strEditShutdownTimerForHost"), h.GetName());
                    dlg.ShowDialog(this);

                    // Mark the file as changed
                    ChangedHostsFile();
                }
            }
        }


		/// <summary>
		/// Removes the selected host(s)
		/// </summary>	
		public void RemoveSelectedHosts()
		{
			if( listView.SelectedItems.Count > 0 )
			{
				foreach( ListViewItem i in listView.SelectedItems )
				{
					WOL2Host h = (WOL2Host)i.Tag;
					
					if( h != null )
					{
						listView.Items.Remove( i );
						Monitor.Enter( m_LockHosts );
						m_Hosts.Remove( h );
						Monitor.Exit( m_LockHosts );
					}
				}

                // Mark the file as changed
                ChangedHostsFile();
			}
		}
		
		/// <summary>
		/// Refresh the tools menu
		/// </summary>
		/// 
		public void RefreshToolsMenu()
		{
			executeToolToolStripMenuItem.DropDown.Items.Clear();
            toolStripTools.Items.Clear();

			foreach( WOL2Tool t in m_Tools.Values )
			{
				ToolStripItem button = toolStripTools.Items.Add( t.GetName( ));
                ToolStripItem i = executeToolToolStripMenuItem.DropDown.Items.Add( t.GetName() );
				i.Click += new EventHandler( OnToolClick );
                button.Click += new EventHandler(OnToolClick);

                // Assign the image
                try
                {
                    i.Image = Image.FromFile(t.GetIconFileName());
                    button.Image = Image.FromFile(t.GetIconFileName());
                }
                catch { }
                
			}
			
			if( m_Tools.Count > 0 )
			{
				toolStripSeparator11.Visible = true;
				executeToolToolStripMenuItem.Visible = true;
                toolStripTools.Visible = true;
			}
			else
			{
				toolStripSeparator11.Visible = false;
				executeToolToolStripMenuItem.Visible = false;
                toolStripTools.Visible = false;
			}
		}
		
		/// <summary>
		/// Tool Click Event Handler
		/// </summary>
		public void OnToolClick( object sender, EventArgs a )
		{
			ToolStripItem i = (ToolStripItem)sender;
			if( i != null )
			{
				string sToolName = i.Text;
				
				WOL2Tool t = null;
				m_Tools.TryGetValue( sToolName, out t );
					
				if( t != null )
				{
                    if (listView.SelectedItems.Count > 0)
                    {
                        foreach (ListViewItem itm in listView.SelectedItems)
                        {
                            WOL2Host h = (WOL2Host)itm.Tag;

                            if (h != null)
                                t.Execute(h);
                        }
                    }
                    else
                    {
                        t.Execute(null);
                    }
				}
			}
		}
		
		#region Shutdown and Reboot code ------------------------------------------------
		
		public void ShutdownSelectedHost( )
		{
			if( listView.SelectedItems.Count > 0 )
			{
                string sAction = "Shutdown " + listView.SelectedItems.Count + " hosts";
                if (ConfirmAction(sAction) == false)
                    return; 
                
                foreach (ListViewItem i in listView.SelectedItems)
				{
					WOL2Host h = (WOL2Host)i.Tag;
					
					if( h != null )
					{
						ShutdownHost( h, true );
					}
				}
			}
		}		
		
		public void ShutdownHost( WOL2Host h, bool bNoConfirm )
		{
            if (!bNoConfirm)
            {
                string sAction = "Shutdown host " + h.GetName();
                if (ConfirmAction(sAction) == false)
                    return;
            }

			if( MOE.Utility.IsRunningOnMono() )
			{
				String sMsg = "Hi fellower Mac or gnu/linux user!\n\nActually shutting down remote hosts is not implemented yet.\nIf you know a commandline call to do that, do not hesitate to contat me.\nI'll be happy to include it ;-)";
				MessageBox.Show( sMsg, "Not implemented yet :-(",
         						MessageBoxButtons.OK, 
         						MessageBoxIcon.Error );
			}
			else	// We're running on .NET this is most likely to happen on a windows machine
			{
                string sDelimiter = "-";

                System.OperatingSystem osInfo = System.Environment.OSVersion;
                if (osInfo.Version.Major >= 6)
                    sDelimiter = "/";

                string sArgs = sDelimiter + "s";
			
				if( m_iShutdownTimeout > 0 )
                    sArgs += " " + sDelimiter + "t " + m_iShutdownTimeout.ToString();
				
				if( m_sShutdownComment != null && m_sShutdownComment.Length > 0 )
                    sArgs += " " + sDelimiter + "c \"" + m_sShutdownComment + "\"";
				
				if( h.IsDynamicHost() )
                    sArgs += " " + sDelimiter + "m \\\\" + h.GetName();
				else
                    sArgs += " " + sDelimiter + "m " + h.GetIpAddress();
				
				if( m_bForceShutdown )
                    sArgs += " " + sDelimiter + "f";
				
				try
				{
					string sDomain = h.GetName();
                    if (m_sShutdownDomain != null && m_sShutdownDomain.Length > 0 )
					    sDomain = m_sShutdownDomain;
					
					if( m_sShutdownUser != null && m_sShutdownUser.Length > 0 && 
					  	m_sShutdownPaswd != null && m_sShutdownPaswd.Length > 0 )
						System.Diagnostics.Process.Start( "shutdown.exe" , sArgs, m_sShutdownUser, m_sShutdownPaswd, sDomain );
					else
						System.Diagnostics.Process.Start("shutdown.exe" , sArgs );
				}
				catch( Exception e )
				{
					MOE.Logger.DoLog( e.ToString(), Logger.LogLevel.lvlError );
				}

			}
		}		
		
		
		public void RebootSelectedHost( )
		{
			if( listView.SelectedItems.Count > 0 )
			{
                string sAction = "Reboot " +listView.SelectedItems.Count+ " hosts";
                if (ConfirmAction(sAction) == false)
                    return;

                foreach( ListViewItem i in listView.SelectedItems )
				{
					WOL2Host h = (WOL2Host)i.Tag;
					
					if( h != null )
					{
						RebootHost( h, true );
					}
				}
			}
		}
		
		public void RebootHost( WOL2Host h, bool bNoConfirm )
		{
            if (!bNoConfirm)
            {
                string sAction = "Reboot host " + h.GetName();
                if (ConfirmAction(sAction) == false)
                    return;
            }

			if( MOE.Utility.IsRunningOnMono() )
			{
				String sMsg = "Hi fellower Mac or gnu/linux user!\n\nActually rebooting remote hosts is not implemented yet.\nIf you know a commandline call to do that, do not hesitate to contat me.\nI'll be happy to include it ;-)";
				MessageBox.Show( sMsg, "Not implemented yet :-(",
         						MessageBoxButtons.OK, 
         						MessageBoxIcon.Error );
			}
			else	// We're running on .NET this is most likely to happen on a windows machine
			{
                
                string sDelimiter = "-";

                System.OperatingSystem osInfo = System.Environment.OSVersion;
                if (osInfo.Version.Major >= 6)
                    sDelimiter = "/";

                string sArgs = sDelimiter + "r";
			
				if( m_iRebootTimeout > 0 )
					sArgs += " " + sDelimiter +"t " + m_iRebootTimeout.ToString();
				
				if( m_sRebootComment != null && m_sRebootComment.Length > 0 )
                    sArgs += " " + sDelimiter + "c \"" + m_sRebootComment + "\"";
				
				if( h.IsDynamicHost() )
                    sArgs += " " + sDelimiter + "m \\\\" + h.GetName();
				else
                    sArgs += " " + sDelimiter + "m " + h.GetIpAddress();
				
				if( m_bForceReboot )
                    sArgs += " " + sDelimiter + "f";
				
				try
				{
                    string sDomain = h.GetName();
                    if (m_sRebootDomain != null && m_sRebootDomain.Length > 0)
                        sDomain = m_sRebootDomain;
                    				
					if( m_sRebootUser != null && m_sRebootUser.Length > 0 && 
					  	m_sRebootPaswd != null && m_sRebootPaswd.Length > 0 )
						System.Diagnostics.Process.Start( "shutdown.exe" , sArgs, m_sRebootUser, m_sRebootPaswd, sDomain );
					else
						System.Diagnostics.Process.Start("shutdown.exe" , sArgs );
				}
				catch( Exception )
				{
					// Some Error... :(
				}
			}
		}
		
		#endregion
		
		#region Online State Checker Code -----------------------------------------------
		
		/// <summary>
		/// Initializes the online state checker thread
		/// </summary>	
		public void InitOnlineStateChecker( )
		{
            MOE.Logger.DoLog("InitOnlineStateChecker(): start.", Logger.LogLevel.lvlDebug);

            OnlineStateChecker chk = new OnlineStateChecker( CheckOnlineStates );
        	chk.BeginInvoke( m_Hosts, 
                       		 new AsyncCallback(	OnlineStateChanged ),
                       		 "" );

            MOE.Logger.DoLog("InitOnlineStateChecker(): done. ", Logger.LogLevel.lvlDebug);
            
		}
		
				
		/// <summary>
		/// Online State Checker
		/// Pings the hosts and changes the state depending on the ping result.
		/// </summary>	
		/// <param name="q">The host queue.</param>	
		public bool CheckOnlineStates( List< WOL2Host > q )
		{
            MOE.Logger.DoLog("CheckOnlineStates(): start. Sleeping " + m_iOnlineCheckInterval + "ms.", Logger.LogLevel.lvlDebug);
            
            // Wait for the next interval
            Thread.Sleep(m_iOnlineCheckInterval);

            MOE.Logger.DoLog("CheckOnlineStates(): Starting check.", Logger.LogLevel.lvlDebug);

            try
            {
                foreach (WOL2Host h in q)
                {
                    try
                    {
                        Ping myPing = new Ping();
                        String ip = null;
                        if (m_bUseIpV6)
                            ip = h.GetIpV6Address();

                        // Fall back to IPv4
                        if (ip == null || ip.Length == 0)
                            ip = h.GetIpAddress();

                        // Get the ping destination
                        String host = h.IsDynamicHost() ? h.GetName() : IPAddress.Parse(ip).ToString();

                        // Start PING
                        byte[] buffer = new byte[32];
                        int timeout = m_iPingTimeout; // ms
                        PingOptions pingOptions = new PingOptions();
                        PingReply reply = myPing.Send(host, timeout, buffer, pingOptions); // send the ping

                        if (reply.Status == IPStatus.Success)
                        {
                            h.SetPingReplyTime(reply.RoundtripTime);
                            h.SetState(WOL2HostState.wolHostOnline);

                            // Update the IPv4 and 6 addresses if required
                            if (m_bUpdateIPInOnlineChecker)
                            {
                                if (reply.Address.AddressFamily == AddressFamily.InterNetwork
                                    && reply.Address.ToString() != h.GetIpAddress() )
                                    h.SetIpAddress(reply.Address.ToString());
                                else if (reply.Address.AddressFamily == AddressFamily.InterNetworkV6
                                    && reply.Address.ToString() != h.GetIpV6Address())
                                {
                                    h.SetIpV6Address(reply.Address.ToString());

                                    // Try to update the IPv4 Address as well
                                    string [] ipv4 = WOL2DNSHelper.ResolveToIPv4(reply.Address.ToString());
                                    if (ipv4 != null)
                                    {
                                        if (ipv4.Length >= 1)
                                            h.SetIpAddress(ipv4[0]);

                                        if (ipv4.Length > 1)
                                        {
                                            MOE.Logger.DoLog("Warning: host " + h + " has more than one IPv4 address. Using the first one!", Logger.LogLevel.lvlWarning);
                                        }
                                    }

                                    // Need to update the host list view
                                    // This might be done twice, if the host changes its state completely...
                                    // But in case the user just enabled the option we are forcing the list view item update that way.
                                    RefreshHost(h);

                                    // mark the file as changed but do not auto save it
                                    m_bChangedFile = true;
                                }

                            }

                            MOE.Logger.DoLog("Host: " + h + " is online.", Logger.LogLevel.lvlDebug);
                        }
                        else if (reply.Status == IPStatus.TimedOut)
                        {
                            h.SetPingReplyTime(-1);
                            h.SetState(WOL2HostState.wolHostOffline);
                            MOE.Logger.DoLog("Host: " + h + " is offline.", Logger.LogLevel.lvlDebug);
                        }
                    }
                    catch (NotSupportedException ex)
                    {
                        h.SetPingReplyTime(-1);
                        h.SetState(WOL2HostState.wolHostOffline);
                        MOE.Logger.DoLog("IPv6 not supported! Host: " + h + " " + ex.ToString(), Logger.LogLevel.lvlWarning);
                    }
                    catch (Exception e)
                    {
                        h.SetPingReplyTime(-1);
                        h.SetState(WOL2HostState.wolHostOffline);
                        MOE.Logger.DoLog("Host: " + h + " " + e.ToString(), Logger.LogLevel.lvlWarning);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MOE.Logger.DoLog("CheckOnlineStates(): InvalidOperationException: " +ex.Message, Logger.LogLevel.lvlDebug);
            }

            MOE.Logger.DoLog("CheckOnlineStates(): done.", Logger.LogLevel.lvlDebug);
			return true;
		}
	
		/// <summary>
		/// Callback & Delegate for the OnlineStateChecker
		/// </summary>	
		/// <param name="result">The result.</param>	
		public void OnlineStateChanged( IAsyncResult result )
		{
			// Check if we are running in the worker thread
			// If yes, we cannot access the list view.
			if( this.InvokeRequired )
			{
                try
                {
                    // We are, so marshall this call
                    this.Invoke(new UpdateListviewStates(OnlineStateChanged),
                                 result);
                }
                catch
                {
                    // Do nothing. Its most likely that the app is closing.
                }
			
			}
			else
			{
				// We are running in the GUI thread. Access to the list is ok.
				Monitor.Enter( listView );

                MOE.Logger.DoLog("OnlineStateChanged(): start.", Logger.LogLevel.lvlDebug);

                try
                {
                    foreach (ListViewItem i in listView.Items)
                    {
                        WOL2Host h = (WOL2Host)i.Tag;
                        bool bChanged = h.HasStateChanged();

                        i.ToolTipText = "Name:\t" + h.GetName() + "\nPing:\t" + h.GetPingReplyTime().ToString();
                        i.SubItems[4].Text = h.StateAsString();

                        if (m_bColorizeListView)
                        {
                            if (h.GetState() == WOL2HostState.wolHostOnline)
                                i.SubItems[4].BackColor = Color.Green;
                            else
                                i.SubItems[4].BackColor = Color.Red;
                        }
                        else
                            i.SubItems[4].BackColor = i.BackColor;

                        switch (h.GetState())
                        {
                            default:
                            case WOL2HostState.wolHostOffline:
                                i.ImageIndex = 0;
                                break;
                            case WOL2HostState.wolHostOnline:
                                i.ImageIndex = 1;
                                break;
                            case WOL2HostState.wolHostStarting:
                                i.ImageIndex = 2;
                                break;
                        }

                        listView.Sort();

                        if (bChanged)
                        {
                            // Run the associated command
                            if (m_sHostStateChangedCommand != null &&
                                m_sHostStateChangedCommand.Length > 1)
                            {
                                try
                                {
                                    string sCmd = m_sHostStateChangedCommand;

                                    sCmd = h.ExpandVariables(sCmd);
                                    
                                    System.Diagnostics.ProcessStartInfo spi = new System.Diagnostics.ProcessStartInfo();
                                    // MOE: I want windows to dagnose script errors
                                    // spi.CreateNoWindow = true;
                                    // spi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                    spi.FileName = "cmd.exe";
                                    spi.Arguments = "/C" + sCmd;

                                    System.Diagnostics.Process.Start( spi );
                                }
                                catch (Exception ex)
                                {
                                    MOE.Logger.DoLog(ex.ToString(), Logger.LogLevel.lvlDebug);
                                }
                            }

                            // Display a notification?
                            if (m_bDisplayStateNotifications)
                            {
                                if (h.IsStateChangedNoftificationEnabled() || m_bAlwaysDisplayNotifications)
                                {
                                    if (notifyIcon1.BalloonTipText.Length > 0)
                                        notifyIcon1.BalloonTipText += "\n";

                                    notifyIcon1.BalloonTipText += String.Format(MOE.Utility.GetStringFromRes("strStateChanged"), h.GetName(), h.StateAsString());

                                    this.notifyIcon1.ShowBalloonTip(m_iNotificationTimeout * 1000);
                                }
                            }
                        }
                    } // For each
                }
                catch (System.InvalidOperationException e)
                {
                    MOE.Logger.DoLog( "OnlineStateChanged(): " + e.ToString(), Logger.LogLevel.lvlWarning);
                }
                    
                MOE.Logger.DoLog("OnlineStateChanged(): done", Logger.LogLevel.lvlDebug);

				
				Monitor.Exit( listView );

                // Run the state ckecker again
                InitOnlineStateChecker();
			}
		}

        private bool ConfirmAction(string sAction)
        {
            if( m_bConfirmNetActions == false )
                return true;

            String sMsg = String.Format(MOE.Utility.GetStringFromRes("strConfirmAction"), sAction);
            if (MessageBox.Show(this, sMsg, "WOL2", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
		
		#endregion
	
		#region Group Code --------------------------------------------------------------
		
		/// <summary>
		/// Refreshes the group list
		/// </summary>	
		public void WakeGroup( WOL2Group g, bool bNoConfirm )
		{
			string sg = g.GetName();

            if (!bNoConfirm)
            {
                string sAction = "Wake Group " + sg;
                if (ConfirmAction(sAction) == false)
                    return;
            }

			Monitor.Enter( m_LockHosts );
			foreach( WOL2Host h in m_Hosts )
			{
				if( h.GetGroups().Contains( sg ) )
					WakeHost( h, true );

                DateTime dwTime = DateTime.Now.AddMilliseconds(m_iWakeDelay);
                while (DateTime.Now < dwTime)
                    Application.DoEvents();
			}
			Monitor.Exit( m_LockHosts );
			
			lblStatus.Text = String.Format( MOE.Utility.GetStringFromRes( "strSendWOLSignal" ),  g.GetName() );
		}
		
		/// <summary>
		/// Refreshes the group list
		/// </summary>	
		public void RefreshGroupList()
		{
			// Remove old tabs
			for( int i = tabControl.TabPages.Count - 1; i > 0; i-- )
			{
				tabControl.TabPages.RemoveAt( i );
			}
			
			// Remove old menu items
			assignToGroupToolStripMenuItem.DropDown.Items.Clear();
			addToGroupToolStripMenuItem.DropDown.Items.Clear();
				
			// Insert new elements
			foreach( WOL2Group g in m_Groups.Values )
			{
				// New tab page
				TabPage t = new TabPage( g.GetName( ) );
				t.Tag = g;
				tabControl.TabPages.Add( t );
				
				// New Menu items
				ToolStripItem i = assignToGroupToolStripMenuItem.DropDown.Items.Add( g.GetName() );
				i.Click += new EventHandler(assignToGroupClicked);
				i = addToGroupToolStripMenuItem.DropDown.Items.Add( g.GetName() );
				i.Click += new EventHandler(addToGroupClicked);
			}
			
			if( m_Groups.Count > 0 )
			{
				assignToGroupToolStripMenuItem.Visible = true;
				addToGroupToolStripMenuItem.Visible = true;
				toolStripSeparator9.Visible = true;
			}
			else
			{
				assignToGroupToolStripMenuItem.Visible = false;
				addToGroupToolStripMenuItem.Visible = false;
				toolStripSeparator9.Visible = false;
			}
		}
		
		/// <summary>
		/// Removes sGroup.
		/// </summary>	
		public void RemoveGroup( string sGroup )
		{
			m_Groups.Remove( sGroup );
			RefreshGroupList();

            // Mark the file as changed
            ChangedHostsFile();
		}
		
		/// <summary>
		/// Rename the current group if any.
		/// </summary>	
		public void RenameCurrentGroup()
		{
			if( m_CurrentGroup != null )
			{
				string sn, s;
				s = m_CurrentGroup.GetName();
				InputBoxDialog ib = new InputBoxDialog();
                ib.FormPrompt = MOE.Utility.GetStringFromRes( "strEditGroup" );
                ib.FormCaption = MOE.Utility.GetStringFromRes("strEditGroupTitle");
				ib.DefaultValue = s;
				ib.ShowDialog( this );
				sn = ib.InputResponse;
				
				if( sn != "" && sn != s )
				{
					m_CurrentGroup.SetName( sn );
					
					// Reorder the hosts
					Monitor.Enter( m_LockHosts );
					foreach( WOL2Host h in m_Hosts )
					{
						string sg = h.GetGroups(), sgn;
						sgn = sg.Replace( s, sn );
							
						if( sgn != sg )
							h.SetGroups( sgn );	
					}
					Monitor.Exit( m_LockHosts );
					
					RefreshGroupList();

                    // Mark the file as changed
                    ChangedHostsFile();
				}
			}
		}
		
		/// <summary>
		/// Add a new group.
		/// </summary>
		public void AddNewGroup()
		{
			string s;

			InputBoxDialog ib = new InputBoxDialog();
			ib.FormPrompt = MOE.Utility.GetStringFromRes( "strNewGroup" ); // "Enter new group name";
            ib.FormCaption = MOE.Utility.GetStringFromRes("strNewGroupTitle"); //  "Add Group";
			ib.ShowDialog( this );
			s = ib.InputResponse;
			
			if( s.Length != 0 )
			{
				try
				{
					m_Groups.Add( s, new WOL2Group( s ) );
				}
				catch( Exception e )
				{
					MOE.Logger.DoLog( e.ToString(), Logger.LogLevel.lvlWarning );
				}
				RefreshGroupList();

                // Mark the file as changed
                ChangedHostsFile();
			}
		}
		
		/// <summary>
		/// Edit the timer for the currently active group
		/// </summary>
		public void EditCurrentGroupTimer()
		{
			if( m_CurrentGroup != null )
			{
				DlgEditTimer dlg = new DlgEditTimer( m_CurrentGroup.GetTimer() );
                String s = String.Format( MOE.Utility.GetStringFromRes("strEditTimerForGroup"), m_CurrentGroup.GetName() );
				dlg.Text = s;
				dlg.ShowDialog( this );

                // Mark the file as changed
                ChangedHostsFile();
			}
		}

        /// <summary>
        /// Edit the reboot timer for the currently active group
        /// </summary>
        public void EditCurrentGroupRebootTimer()
        {
            if (m_CurrentGroup != null)
            {
                DlgEditTimer dlg = new DlgEditTimer(m_CurrentGroup.GetRebootTimer());
                String s = String.Format(MOE.Utility.GetStringFromRes("strEditRebootTimerForGroup"), m_CurrentGroup.GetName());
                dlg.Text = s;
                dlg.ShowDialog(this);

                // Mark the file as changed
                ChangedHostsFile();
            }
        }

        /// <summary>
        /// Edit the shutdown timer for the currently active group
        /// </summary>
        public void EditCurrentGroupShutdownTimer()
        {
            if (m_CurrentGroup != null)
            {
                DlgEditTimer dlg = new DlgEditTimer(m_CurrentGroup.GetShutdownTimer());
                String s = String.Format(MOE.Utility.GetStringFromRes("strEditShutdownTimerForGroup"), m_CurrentGroup.GetName());
                dlg.Text = s;
                dlg.ShowDialog(this);

                // Mark the file as changed
                ChangedHostsFile();
            }
        }
		
		/// <summary>
		/// Assign all selected hosts to the given group.
		/// </summary>
		/// <param name="sg">The group name.</param>
		public void AssignSelectedHostsToGroup( string sg )
		{
			if( listView.SelectedItems.Count > 0 )
			{
				foreach( ListViewItem i in listView.SelectedItems )
				{				
					WOL2Host h = (WOL2Host)i.Tag;
					
					if( h != null )
					{
						h.SetGroups( sg );
					}
				}

                // Mark the file as changed
                ChangedHostsFile();
			}
		}
		
		/// <summary>
		/// Add all selected hosts to the given group.
		/// </summary>
		/// <param name="sg">The group name.</param>
		public void AddSelectedHostsToGroup( string sg )
		{
			if( listView.SelectedItems.Count > 0 )
			{
				foreach( ListViewItem i in listView.SelectedItems )
				{				
					WOL2Host h = (WOL2Host)i.Tag;
					if( h != null )
					{
						string s = h.GetGroups();
                        if (s == null)
                        {
                            h.SetGroups(sg);
                        }else if( !s.Contains( sg ) )
						{
							// Add the group name
							s += " " + sg;
							h.SetGroups( s );
						}	
					}
				}

                // Mark the file as changed
                ChangedHostsFile();
			}
		}
		
		/// <summary>
		/// Reboots all hosts in the given group.
		/// </summary>	
		public void RebootGroup( WOL2Group g, bool bNoConfirm )
		{
			string sg = g.GetName();

            if (!bNoConfirm)
            {
                string sAction = "Reboot Group " + sg;
                if (ConfirmAction(sAction) == false)
                    return;
            }

			Monitor.Enter( m_LockHosts );
			foreach( WOL2Host h in m_Hosts )
			{
				if( h.GetGroups().Contains( sg ) )
					RebootHost( h, true );
			}
			Monitor.Exit( m_LockHosts );
			lblStatus.Text = String.Format( MOE.Utility.GetStringFromRes( "strSendRebootSignal" ), g.GetName() );
		}
		
		/// <summary>
		/// Reboots all hosts in the given group.
		/// </summary>	
		public void ShutdownGroup( WOL2Group g, bool bNoConfirm )
		{
			string sg = g.GetName();

            if (!bNoConfirm)
            {
                string sAction = "Shutdown Group " + sg;
                if (ConfirmAction(sAction) == false)
                    return;
            }

			Monitor.Enter( m_LockHosts );
			foreach( WOL2Host h in m_Hosts )
			{
				if( h.GetGroups().Contains( sg ) )
					ShutdownHost( h, true );
			}
			Monitor.Exit( m_LockHosts );
            lblStatus.Text = String.Format(MOE.Utility.GetStringFromRes("strSendShutdownSignal"), g.GetName());
		}
		
		#endregion
		
		#region WOL Code ----------------------------------------------------------------
		
		/// <summary>
		/// Sends a magic packet to the destination host.
		/// </summary>
		/// <param name="h">The WOLHost to wake.</param>
		public void SendWOLPacket( WOL2Host h )
		{
			if( h == null )
				return;
			
			MOE.Logger.DoLog( "Waking host " + h, MOE.Logger.LogLevel.lvlInfo );
			
			byte[] targetMAC = new byte[6];
			string[] mac = h.GetMacAddress().Split( ':' );
			
			// target mac must be 6-bytes!
			if( mac.Length != 6 )
			{
				mac = h.GetMacAddress().Split( '-' );
			}
			
			// target mac must be 6-bytes!
			if( mac.Length != 6 )
				return;
			
			// Convert String Array to byte Array
			for( int i = 0; i < 6; i++ )
				targetMAC[i] = Convert.ToByte( mac[i], 16 );
			
			// check password
			byte[] password = null;			
			string[] pwd = null;
			if( m_bAskForSecureOnPwd )
			{
				MOE.InputBoxDialog ib = new MOE.InputBoxDialog();
                ib.FormPrompt = MOE.Utility.GetStringFromRes( "strSecureOnPrompt" );
				ib.FormCaption = "SecureOn";
				ib.ShowDialog( this );
				string sn = ib.InputResponse;
				
				if( sn.Length == 12 )
				{
					pwd = new String[6];
					for( int i = 0; i < 6; i++ )
						pwd[i] = sn.Substring((i)*2, 2 );
					
				}
				else if( sn.Length == 12+5 )
				{
					pwd = sn.Split( ':' );
					if( pwd == null )
						pwd = sn.Split( '-' );
				}
				
			}
			else
			{
				
				if( h.GetSecureOnPassword() != null )
				{
					pwd = h.GetSecureOnPassword().Split( ':' );
					if( pwd == null )
						pwd = h.GetSecureOnPassword().Split( '-' );
				}
			}
			
			if( pwd != null )
			{
				if( (pwd.Length == 4) || 
					(pwd.Length == 6) )
				{
					password = new Byte[ pwd.Length ];
				
					// Convert String Array to byte Array
					for( int i = 0; i < pwd.Length; i++ )
						password[i] = Convert.ToByte( pwd[i], 16 );
				}
			}
			
			int packetLength = 6 + (20 * 6);
			if( password != null )
			{
				packetLength += password.Length;
			}
			
			byte[] magicPacket = new byte[packetLength];
			
			// has a 6-byte header of 0xFF
			byte[] header = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
			Buffer.BlockCopy(header, 0, magicPacket, 0, header.Length);
			
			// repeat the destination MAC 16 times
			int offset = 6;
			for(int i = 0 ; i < 16 ; i++)
			{
				Buffer.BlockCopy(targetMAC, 0, magicPacket, offset, targetMAC.Length);
				offset += 6;
			}
			
			if( password != null )
			{
				Buffer.BlockCopy(password, 0, magicPacket, offset, password.Length);
			}
			
			try
			{
				IPEndPoint ep = null;
                WOLPacketTransferMode transfer = h.PacketTransferMode == WOLPacketTransferMode.modeNone ? m_PacketTransferOptions : h.PacketTransferMode;
                if ((transfer & WOLPacketTransferMode.modeSendToHost) == WOLPacketTransferMode.modeSendToHost)
				{
                    string dest = null;

                    if (h.IsDynamicHost())
                    {
                        // Send WOL package to all known DHCP addresses
                        dest = h.GetName();
                        try
                        {
                            foreach (IPAddress ip in Dns.GetHostEntry(dest).AddressList)
                            {
                                ep = new IPEndPoint(ip, m_iWakePort);
                                MOE.Logger.DoLog("Sending DHCP WOL package to " + ep.ToString(), MOE.Logger.LogLevel.lvlInfo);

                                try
                                {
                                    UdpClient c = new UdpClient();
                                    c.Send(magicPacket, magicPacket.Length, ep);
                                }
                                catch { }
                            }
                        }
                        catch { }
                        return;
                    }
                    else
                    {
                        dest = h.GetIpV6Address();
                        if (dest == null || dest.Length == 0 || !m_bUseIpV6)
                            dest = h.GetIpAddress();

                        if (dest != null && dest.Length > 0)
                            ep = new IPEndPoint(IPAddress.Parse(dest), m_iWakePort);
                    }
				}
                else if ((transfer & WOLPacketTransferMode.modeNetCast) == WOLPacketTransferMode.modeNetCast)
				{
                    // Resolve the hostname to an IP address
                    if (h.IsDynamicHost())
                    {
                        try
                        {
                            foreach (IPAddress ip in Dns.GetHostEntry(h.GetName()).AddressList)
                            {
                                try
                                {
                                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                                    {
                                        IPAddress nm = IPAddress.Parse(WOL2DNSHelper.ResolveSubnetMask(ip));
                                        IPAddress snbcast = WOL2DNSHelper.GetBroadcastAddress(ip, nm);

                                        ep = new IPEndPoint(snbcast, m_iWakePort);
                                    }
                                    else
                                        // IPv6 link local bcast http://www.iana.org/assignments/ipv6-multicast-addresses/ipv6-multicast-addresses.xml
                                        ep = new IPEndPoint(IPAddress.Parse("FF02:0:0:0:0:0:0:1" ), m_iWakePort );

                                    /* MOE.Logger.DoLog("Sending DHCP WOL package to " + ep.ToString(), MOE.Logger.LogLevel.lvlInfo);

                                    UdpClient c = new UdpClient();
                                    c.Send(magicPacket, magicPacket.Length, ep); */
                                }
                                catch { }
                            }
                        }
                        catch (Exception ex)
                        {
                            MOE.Logger.DoLog("Cannoot wake host " + h.ToString() +"! Reason: " + ex.Message, MOE.Logger.LogLevel.lvlWarning);
                        }
                        //return;
                    }

                    if( ep == null || !h.IsDynamicHost() )
                    {
                        string sip = null;
                        sip = h.GetIpV6Address();
                        if (sip == null || sip.Length == 0 || !m_bUseIpV6)
                            sip = h.GetIpAddress();

                        if (sip != null)
                        {
                            IPAddress ip = IPAddress.Parse(sip);

                            if (ip.AddressFamily == AddressFamily.InterNetwork)
                            {
                                try
                                {
                                    // Generate a broadcast address
                                    IPAddress nm = IPAddress.Parse(h.GetSubnetMask());
                                    IPAddress snbcast = WOL2DNSHelper.GetBroadcastAddress(ip, nm);

                                    if (snbcast != null)
                                        ep = new IPEndPoint(snbcast, m_iWakePort);
                                }
                                catch { }
                            }
                            else if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                // IPv6 link local bcast http://www.iana.org/assignments/ipv6-multicast-addresses/ipv6-multicast-addresses.xml
                                ep = new IPEndPoint(IPAddress.Parse("FF02:0:0:0:0:0:0:1"), m_iWakePort);   
                            }
                        }                        
                    }					
				}
				else
				{
                    ep = new IPEndPoint(IPAddress.Broadcast, m_iWakePort);
				}

                if (ep == null)
                {
                    MOE.Logger.DoLog("Could not identify an endpoint for " + h.ToString(), MOE.Logger.LogLevel.lvlWarning);
                    return;
                }
				
				MOE.Logger.DoLog( "Will send WOL package to " + ep.ToString(), MOE.Logger.LogLevel.lvlInfo );
				
                // Use the global transfer mode to get the type (tcp/udp)
				// if( ( m_PacketTransferOptions & WOLPacketTransferMode.modeUDP ) == WOLPacketTransferMode.modeUDP ) // use udp, tested and works
				// {
					UdpClient udpClient = new UdpClient();
                    udpClient.Send(magicPacket, magicPacket.Length, ep);

                    MOE.Logger.DoLog("Local Endpoint used: " + udpClient.Client.LocalEndPoint.ToString(), MOE.Logger.LogLevel.lvlInfo);

                    udpClient.Close();
					
				// }
				//else if( ( m_PacketTransferOptions & WOLPacketTransferMode.modeTCP ) == WOLPacketTransferMode.modeTCP )	// use tcp, not tested yet
				// {
					// No other protocol implemented yet
				// }
			}
			catch (ArgumentNullException e) 
			{
				MOE.Logger.DoLog( e.ToString(), Logger.LogLevel.lvlError );
			} 
			catch( SocketException e ) 
			{
				MOE.Logger.DoLog( e.ToString(), Logger.LogLevel.lvlError );
			}

		}
		
		/// <summary>
		/// Calculates the Broadcast Address of an IP Address using the Subnet Mask 
		/// </summary>
		/// <param name="h">The WOLHost to wake.</param>
        /// // MOE 16.11.2012: Replace by GetBroadcastAddress
		/* public IPAddress CalculateBroadCastAddress(IPAddress currentIP, IPAddress ipNetMask)
        {
            string[] strCurrentIP = currentIP.ToString().Split('.');
            string[] strIPNetMask = ipNetMask.ToString().Split('.');

            ArrayList arBroadCast = new ArrayList();

            for (int i = 0; i < 4; i++)
            {
                int nrBCOct = int.Parse(strCurrentIP[i]) | (int.Parse(strIPNetMask[i]) ^ 255);
                arBroadCast.Add(nrBCOct.ToString());
            }
            return IPAddress.Parse(arBroadCast[0] + "." + arBroadCast[1] + "." + arBroadCast[2] + "." + arBroadCast[3]);
        }*/
		
		#endregion
		
		#region Timer Code --------------------------------------------------------------
		
		void TmrAlarmTick(object sender, EventArgs e)
		{
            Thread t = new Thread(new ParameterizedThreadStart(_CheckTimers));
            t.Priority = ThreadPriority.BelowNormal;
            t.IsBackground = true;
            t.Start(DateTime.Now);
		}

        private void _CheckTimers(object o)
        {
            // Check all hosts timers
            Monitor.Enter(m_LockHosts);

            // Get the current date/time
            DateTime time = (DateTime)o;

            UInt64 w_counter = 0;
            UInt64 r_counter = 0;
            UInt64 s_counter = 0;

            foreach (WOL2Host h in m_Hosts)
            {
                if (h.CheckTimer(time))
                {
                    WakeHost(h, true);

                    DateTime dwTime = DateTime.Now.AddMilliseconds(m_iWakeDelay);
                    while (DateTime.Now < dwTime)
                        Application.DoEvents();

                    w_counter++;
                }

                if (h.GetRebootTimer().Check(time))
                {
                    RebootHost(h, true);
                    r_counter++;
                }

                if (h.GetShutdownTimer().Check(time))
                {
                    ShutdownHost(h, true);
                    s_counter++;
                }
            }

            Monitor.Exit(m_LockHosts);

            if (w_counter + r_counter + s_counter > 0)
            {
                MOE.Logger.DoLog("Timer fired for: " + w_counter + " wakes, " + r_counter + " reboots, " + s_counter + " shut downs.", Logger.LogLevel.lvlInfo);
            }


            w_counter = 0;
            r_counter = 0;
            s_counter = 0;



            // Check all group timers
            Monitor.Enter(m_Groups);

            foreach (WOL2Group g in m_Groups.Values)
            {
                if (g.GetTimer().Check(time))
                {
                    WakeGroup(g, true);
                    w_counter++;
                }

                if (g.GetRebootTimer().Check(time))
                {
                    RebootGroup(g, true);
                    r_counter++;
                }

                if (g.GetShutdownTimer().Check(time))
                {
                    ShutdownGroup(g, true);
                    s_counter++;
                }
            }
            Monitor.Exit(m_Groups);

            if (w_counter + r_counter + s_counter > 0)
            {
                MOE.Logger.DoLog("Group timer fired for: " + w_counter + " wakes, " + r_counter + " reboots, " + s_counter + " shut downs.", Logger.LogLevel.lvlInfo);
            }

            UInt64 duration = (UInt64)(DateTime.Now.Ticks - time.Ticks) / 10000; // 1ms is 10000ms
            if (duration > 1000)
                MOE.Logger.DoLog("Checking timers takes " + duration + "ms. Please adjust your timers with respect to that!", Logger.LogLevel.lvlInfo);
        }
		
		#endregion
			
		#region Online Update Code ------------------------------------------------
		public void CheckForOnlineUpdate()
		{
            MOE.WebUpdater upd = new MOE.WebUpdater(UPDATEURL_STRING);
            if (upd.IsUpdateAvaliable())
                upd.Update();
            else
                MessageBox.Show(MOE.Utility.GetStringFromRes("strNoUpdateFound"), MOE.Utility.GetStringFromRes("strUpdateTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        public void DoSurvey(bool force)
        {
            if (!m_bHasDoneSurvey || force)
            {
                string title = MOE.Utility.GetStringFromRes("strSurveyTitle");
                string msg = MOE.Utility.GetStringFromRes("strSurveyText");
                msg = msg.Replace("\\n", "\n");

                DialogResult dr = MessageBox.Show(this, msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("http://de.surveymonkey.com/s/G2RC7SC");
                }
                m_bHasDoneSurvey = true;
            }
        }

		#endregion
		
		#region Network Scanner ---------------------------------------------------
		
		/// <summary>
		/// The event to start the network scanner
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ScanForNewHostsToolStripMenuItemClick(object sender, EventArgs e)
		{
            ScanLocalSubnetsForNewHosts();
		}

        private void ScanLocalSubnetsForNewHosts()
        {
            try
            {
                m_NetworkScanner = new WOLNetworkScanner(new AsyncCallback(NetworkScanFinished), new AsyncCallback(NetworkScanStateCallback));
                m_NetworkScanner.SetPingTimeout(m_iPingTimeout);
                m_NetworkScanner.SetUnresolvedMacOk(m_bUnresolvedMacOk);
                m_NetworkScanner.SetUnsesolvedNameOk(m_bUnresolvedNameOk);
                m_NetworkScanner.ScanSubnets();
                lblStatus.Text = MOE.Utility.GetStringFromRes("strNetworkScanStarted");
            }
            catch (Exception ex)
            {
                MOE.Logger.DoLog("ScanLocalSubnetsForNewHosts(): " + ex.ToString(), Logger.LogLevel.lvlError);
            }
        }
		
		/// <summary>
		/// Callback for the networkscanner to signal the end
		/// of the scan process.
		/// </summary>
		/// <param name="result">The result is a new host list.</param>
		public void NetworkScanStateCallback( IAsyncResult result )
		{
			// Check if we are running in the worker thread
			// If yes, we cannot access the list view.
			if( this.InvokeRequired )
			{
				// We are, so marshall this call
                try{
                    Delegate myDelegate = new UpdateHostlist(NetworkScanStateCallback);
                    this.Invoke( myDelegate,
				             result );
                } catch( Exception ex ) {
                    MOE.Logger.DoLog("NetworkScanStateCallback(): " + ex.ToString(), Logger.LogLevel.lvlDebug);
                }
			}
			else
			{
				if( m_NetworkScanner != null )
                    lblStatus.Text = String.Format( MOE.Utility.GetStringFromRes("strNetworkScanProgress"), m_NetworkScanner.GetScanState() );
			}
		}
		
		/// <summary>
		/// Callback for the networkscanner to signal the end
		/// of the scan process.
		/// </summary>
		/// <param name="result">The result is a new host list.</param>
		public void NetworkScanFinished( IAsyncResult result )
		{
			// Check if we are running in the worker thread
			// If yes, we cannot access the list view.
			if( this.InvokeRequired )
			{
				// We are, so marshall this call
                Delegate myDelegate = new UpdateHostlist( NetworkScanFinished );
				this.Invoke( myDelegate,
				             result );
			}
			else
			{
				int iCount = 0;

                if (m_NetworkScanner == null)
                    return;
				
				Monitor.Enter( m_LockHosts );

                bool bChanged = false;

				foreach( WOL2Host h in m_NetworkScanner.Hosts )
				{
					// Check if this host already exists

                    WOL2Host foundHost = null;
                    if (!m_Hosts.Exists(delegate(WOL2Host theHost) { foundHost = theHost;  return h.Equals(theHost); }))
					{
						if( h != null )
						{
							m_Hosts.Add( h );
                            bChanged = true;
							iCount++;
						}
					}
                    else
                    {
                        if (foundHost != null)
                        {
                            MOE.Logger.DoLog("NetworkScanFinished: Updating host " + foundHost + "...", MOE.Logger.LogLevel.lvlInfo);

                            // If so, update it.
                            foundHost.SetIpAddress(h.GetIpAddress());
                            foundHost.SetIpV6Address(h.GetIpV6Address());
                            foundHost.SetSubnetMask(h.GetSubnetMask());
                            foundHost.SetMacAddress(h.GetMacAddress());
                            foundHost.SetName(h.GetName());

                            MOE.Logger.DoLog("NetworkScanFinished: Updated host " + foundHost, MOE.Logger.LogLevel.lvlInfo);

                            bChanged = true;
                        }
                    }
				}
				
				Monitor.Exit( m_LockHosts );
				
				lblStatus.Text = String.Format( MOE.Utility.GetStringFromRes("strNetworkScanFinished"), iCount);
				m_NetworkScanner = null;
				
				RefreshHostList();

                if( bChanged )
                    // Mark the file as changed
                    ChangedHostsFile();
			}
		}
		
		#endregion

		#region Members -----------------------------------------------------------------
		
		// Public Members
		public bool						m_bNoStart = false;					// Tells the owner not to start (used in combination with the /close cmd line switch)

		// Static Members
		private static Object 			m_LockHosts = "HostsListLock";		// The variable used for locking the host list
		
		// Private Members
		private List< WOL2Host > 		m_Hosts = new List< WOL2Host >();	// The hosts list
		private Dictionary< string, WOL2Group> 	m_Groups = new Dictionary<string, WOL2Group>();		// The groups list
		private Dictionary< string, WOL2Tool >	m_Tools = new Dictionary< string, WOL2Tool >();		// The tools list
        private List<String>            m_MruList = new List<string>();

		private WOL2Group				m_CurrentGroup;						// The current group
		private WOLPacketTransferMode	m_PacketTransferOptions;			// Flags indicating the magic packet transfer mode
		
		private WOLNetworkScanner		m_NetworkScanner;					// The network scanner
		private ListViewColumnSorter	m_ListViewSorter;					// The list view sorter
		
		private string 					m_sHostFileName;					// The current file name
        private string                  m_sHostStateChangedCommand;	    	// The command to execute when a hosts state changes
        private string                  m_sGroupStateChangedCommand;	    // The command to execute when a groups state changes
		private string					m_sShutdownUser;
		private string					m_sRebootUser;
		private string					m_sShutdownDomain;
		private string					m_sRebootDomain;
		private string					m_sShutdownComment;
		private string					m_sRebootComment;
        private string                  m_sHostFileNote;                    // The note attached to the host file
        private SecureString			m_sShutdownPaswd;
		private SecureString			m_sRebootPaswd;
		
		private int						m_iPingTimeout;						// Ping timeout in ms
		private int						m_iOnlineCheckInterval;				// Online state check intervall in ms
		private int						m_iShutdownTimeout;
		private int						m_iRebootTimeout;
        private int                     m_iNotificationTimeout;             // Timeout for the notification tooltip
        private int                     m_iWakeDelay;                       // Delay between each wake signal
        private int                     m_iWakePort;                        // The port to use for WOL
		
		private bool					m_bAskForSecureOnPwd;				// Ask for the secure on password
		private bool					m_bForceShutdown;					
		private bool					m_bForceReboot;
		private bool					m_bOpenLastFile;
		private bool					m_bUnresolvedNameOk;
		private bool					m_bUnresolvedMacOk;
		private	bool					m_bDoLogging;						// True if the user wants do do logging
		private bool					m_bColorizeListView;				// True if the user wants a colorized list view
		private bool					m_bAutosaveHostFile;				// True if the user wants the host file to be saved automatically
        private bool                    m_bDisplayStateNotifications;		// True if the user wants to see notifications if a hosts state changes
        private bool                    m_bAlwaysDisplayNotifications;		// True if the user wants to see notifications for all hosts
        private bool                    m_bMinimizeToTray;		            // True if the application should minimize to the tray instead of the task bar
        private bool                    m_bConfirmNetActions;		        // True if the user wants to be asked to confirm his own actions (implemented after one user shut down his whole company's network by accident :))
        private bool                    m_bUseIpV6;                         // True if the user wants to use IPv6 (with fall back to IPv4)
        private bool                    m_bHasDoneSurvey;                   // True if the user has completed the survey.
        private bool                    m_bUpdateIPInOnlineChecker;         // True if the user wants the program to update the IPv4 Addresses of hosts if the use DHCP.

        private bool                    m_bUseRegistryProfile;              // Use the registry to load / save the profile

		
		private WOL2MacResolver			m_macResolver = new WOL2MacResolver();
			
		// Constants
		private const string UPDATEURL_STRING = "http://oettecds.bplaced.net/updater/wol2.ver";
		
		// Delegates
		delegate bool OnlineStateChecker( List< WOL2Host > q );				// The online state checker delegate
		delegate void UpdateListviewStates( IAsyncResult result );			// The delegate for updating the listview
        delegate void UpdateHostlist(IAsyncResult result);                  // The delegate for updating the host list after a network scan
        delegate void UpdateHost(WOL2Host h);			                    // The delegate for updating a single host

		#endregion

        private void wakeTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedTimer();
        }                  

        private void shutdownTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedShutdownTimer();
        }

        private void rebootTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedRebootTimer();
        }

        private void wakeGroupTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentGroupTimer();
        }

        private void rebootGroupTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentGroupRebootTimer();
        }

        private void shutdownGroupTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentGroupShutdownTimer();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;
        private bool m_bChangedFile;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE && m_bMinimizeToTray)
                    {
                        this.Hide();
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void mRUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem itm = (ToolStripItem)sender;
            OpenHostList(itm.ToolTipText);
        }

        private void exitWOL2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitWOLTool(true);
        }

        private void showWOL2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null, null);
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            windowsRegisrtryToolStripMenuItem.Checked = m_bUseRegistryProfile;
            xMLFileportableToolStripMenuItem.Checked = !m_bUseRegistryProfile;
            periodicallyScanForNewHostsToolStripMenuItem.Checked = tmrPeriodicScan.Enabled;
        }

        private void xMLFileportableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_bUseRegistryProfile)
            {
                m_bUseRegistryProfile = false;
            }
        }

        private void windowsRegisrtryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!m_bUseRegistryProfile)
            {
                string msg = MOE.Utility.GetStringFromRes("strWarnDropProfile");
                if (MessageBox.Show(this, msg, "Wake On Lan 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.OK)
                {
                    m_bUseRegistryProfile = true;
                    WOL2Profile.DropXmlProfile();
                }
            }
        }

        private void fromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV|*.csv";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                FileStream fs = null;
                try
                {
                    fs = File.OpenRead(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "WOL2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StreamReader sr = new StreamReader(fs);
                
                int idx = 0;
                int cnt = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    // Idle while the import is running (each 10 items)
                    if (cnt % 10 == 0)
                    {
                        statusStrip1.Text = "Import: " + cnt;
                        statusStrip1.Update();
                        Application.DoEvents();
                    }

                    if (idx++ > 0)  // skip the header
                    {
                        string[] items = line.Split(';');

                        if( items.Length != 9 )
                        {
                            string msg = MOE.Utility.GetStringFromRes("strCSVLineNotValid");
                            if (MessageBox.Show(this, msg + "\nLine: " + (idx) + "\n'" + line + "'", "WOL2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                                break;
                            else
                                continue;
                        }

                        try
                        {
                            WOL2Host h = new WOL2Host(items[0],    //name
                                                        items[1],   //comment
                                                        items[2],   //ip
                                                        items[3],   //mac 
                                                        items[4],   //sn mask
                                                        WOL2HostState.wolHostOffline,
                                                        WOL2ConnectionType.wolConnectionLan,
                                                        items[5],   //groups
                                                        "",
                                                        items[6],   //secure on pw
                                                        items[7] == "1",   // dhcp flag
                                                        false,
                                                        false,
                                                        items[8],           // IPv6 Address
                                                        m_PacketTransferOptions);  
                            if (h.IsValid())
                            {
                                _AddHost(h);
                                cnt++;
                            }
                        }
                        catch (Exception ex )
                        {
                            string msg = MOE.Utility.GetStringFromRes("strCSVLineNotValid");
                            if (MessageBox.Show(this, msg + "\nLine: " + (idx) + "\n'" + ex.Message, "WOL2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                                break;
                        }
                    }
                }

                // Close the file
                sr.Close();
                fs.Close();

                MessageBox.Show(this, "Added " + cnt + " hosts.", "WOL2",MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void tmrPeriodicScan_Tick(object sender, EventArgs e)
        {
            ScanLocalSubnetsForNewHosts();
        }

        private void periodicallyScanForNewHostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrPeriodicScan.Enabled = !tmrPeriodicScan.Enabled;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InputBoxDialog input = new InputBoxDialog();
            input.DefaultValue = m_sHostFileNote;
            string msg = MOE.Utility.GetStringFromRes("strEditHostListComment");
            string title = MOE.Utility.GetStringFromRes("strEditHostListCommentTitle");
            input.FormPrompt = msg;
            input.FormCaption = title;
            if( input.ShowDialog(this) == DialogResult.OK )
            {
                m_sHostFileNote = input.InputResponse;
                tbtnNote.ToolTipText = m_sHostFileNote;
            }
                
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Restore window pos
            WOL2Profile profile = new WOL2Profile(m_bUseRegistryProfile);
            if (profile.OpenProfile(WOL2Profile.WOL2ProfileAccessMode.ModeRead))
            {
                FormWindowState WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), profile.GetSetting("Window_State", this.WindowState.ToString()));

                // Minimize to tray?
                if (WindowState == FormWindowState.Minimized
                    && m_bMinimizeToTray)
                {
                    this.Hide();
                }
                else
                    this.WindowState = WindowState;

                // Restore window size and position
                this.Left = profile.GetSetting("Window_X", this.Left);
                this.Top = profile.GetSetting("Window_Y", this.Top);
                this.Width = profile.GetSetting("Window_Width", this.Width);
                this.Height = profile.GetSetting("Window_Height", this.Height);

                // Done
                profile.CloseProfile();
                profile = null;
            }

            // Do a little survey
            // MOE: No more for >= 2.0.2.6 
            // DoSurvey(false);
        }

        private void openOnlineSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSurvey(true);
        }
    }
}
