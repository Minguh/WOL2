/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 05.01.2009
 * Zeit: 15:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Net.NetworkInformation;
using System.IO;

namespace WOL2
{
	/// <summary>
	/// Description of DlgOptions.
	/// </summary>
	public partial class frmDlgOptions : Form
	{
		public frmDlgOptions()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			rbSendToBCast.Checked = true;
			
		}
	
		#region General Tab -------------------------------------------------------------
		
		public void SetRefreshInterval( int i )
		{
			numRefreshInterval.Value = i/1000;
		}
		
		public int GetRefreshInterval( )
		{
			return (int)numRefreshInterval.Value*1000;
		}

        public void SetWakeDelay(int i)
        {
            numWakeDelay.Value = i;
        }

        public int GetWakeDelay()
        {
            return (int)numWakeDelay.Value;
        }
		
		public void SetPingTimout( int iTimeout )
		{
			numPingTimeout.Value = iTimeout;
		}
		
		public int GetPingTimeout()
		{
			return (int)numPingTimeout.Value;
		}
		
		public void SetOpenLastUsedFile( bool b )
		{
			chkOpenLastFile.Checked = b;
		}

		public bool GetOpenLastUsedFile()
		{
			return chkOpenLastFile.Checked;
		}

        public void SetCmdHostStateChanged(string s)
        {
            txtCmdHostChange.Text = s;
        }

        public string GetCmdHostStateChanged()
        {
            return txtCmdHostChange.Text;
        }

        public void SetCmdGroupStateChanged(string s)
        {
            txtCmdGroupChange.Text = s;
        }

        public string GetCmdGroupStateChanged()
        {
            return txtCmdGroupChange.Text;
        }

        public void SetConfirmNetworkOperations(bool b)
        {
            chkConfirmNetworkOperations.Checked = b;
        }

        public bool GetConfirmNetworkOperations()
        {
            return chkConfirmNetworkOperations.Checked;
        }

        public void SetMinimizeToTray(bool b)
        {
            chkMinimizeToTray.Checked = b;
        }

        public bool GetMinimizeToTray()
        {
            return chkMinimizeToTray.Checked;
        }
		
		public void SetTools( Dictionary< string, WOL2Tool > td )
		{
			m_Tools = td;
            
            // Clear the icon list
            imgLstTools.Images.Clear();
			
			foreach( WOL2Tool t in m_Tools.Values )
			{
				AddTool( t );
			}
		}
		
		private void AddTool( WOL2Tool t )
		{
			ListViewItem i = listView1.Items.Add( t.GetName() );
			i.SubItems.Add( t.GetCommand() );
			i.SubItems.Add( t.GetCmdLine() );
			i.Tag = t;

            // Load the icon
            string icon = t.GetIconFileName();
            if (icon != null && File.Exists(icon))
            {
                imgLstTools.Images.Add(icon, Image.FromFile(icon));
                i.ImageKey = icon;
            }

		}
		
		#endregion

        #region Netw. Monitor ---------------------------------------------------

        public void SetDisplayNotifications(bool b)
        {
            chkDisplayNotifications.Checked = b;
        }

        public bool GetDisplayNotifications()
        {
            return chkDisplayNotifications.Checked;
        }

        public void SetAlwaysDisplayNotifications(bool b)
        {
            chkDisplayNotificationsAlways.Checked = b;
        }

        public bool GetAlwaysDisplayNotifications()
        {
            return chkDisplayNotificationsAlways.Checked;
        }

        public void SetNotificationTimeout(int i)
        {
            txtNotificationTimeout.Value = i;            
        }

        public int GetNotificationTimeout()
        {
            return (int)txtNotificationTimeout.Value;
        }

        public void SetWOLPort(int i)
        {
            numWolPort.Value = i;
        }

        public int GetWOLPort()
        {
            return (int)numWolPort.Value;
        }

        public void SetUseIpV6(bool b)
        {
            chkIpV6.Checked = b;
        }

        public bool GetUseIpV6()
        {
            return chkIpV6.Checked;
        }

        #endregion

        #region WOL Tab -----------------------------------------------------------------

        public void SetAskForSecureOnPwd( bool b )
		{
			chkAskForSecureOn.Checked = b;
		}
		
		public bool GetAskForSecureOnPwd()
		{
			return chkAskForSecureOn.Checked;
		}
		
		public void SetWOLFlags( WOLPacketTransferMode f )
		{
			if( ( f & WOLPacketTransferMode.modeBCast ) == WOLPacketTransferMode.modeBCast )
				rbSendToBCast.Checked = true;
			else if( ( f & WOLPacketTransferMode.modeNetCast ) == WOLPacketTransferMode.modeNetCast )
				rbSendToNetwork.Checked = true;
			else if( ( f & WOLPacketTransferMode.modeSendToHost ) == WOLPacketTransferMode.modeSendToHost )
				rbSendToNode.Checked = true;
		}
		
		public WOLPacketTransferMode GetWOLFlags( )
		{
			WOLPacketTransferMode f = WOLPacketTransferMode.modeNone;
				
			if( rbSendToBCast.Checked ) 
				f |= WOLPacketTransferMode.modeBCast;
			else if( rbSendToNetwork.Checked ) 
				f |= WOLPacketTransferMode.modeNetCast;
			else if( rbSendToNode.Checked ) 
				f |= WOLPacketTransferMode.modeSendToHost;
			
			return f;
		}
		
		#endregion
		
		#region Shutdown / Reboot Tab ---------------------------------------------------
		
		public void SetShutdownTimeout( int i )
		{
			numTimeoutShutdown.Value = i;
		}
		
		public int GetShutdownTimeout( )
		{
			return (int)numTimeoutShutdown.Value;
		}
		
		public void SetShutdownComment( string sComment )
		{
			txtCommentShutdown.Text = sComment;
		}
		
		public string GetShutdownComment()
		{
			return txtCommentShutdown.Text;
		}
		
		public void SetShutdownUser( string sUser )
		{
			txtUserShutdown.Text = sUser;
		}
		
		public string GetShutdownUser( )
		{
			return txtUserShutdown.Text;
		}
		
		public void SetShutdownDomain( string sDomain )
		{
			txtShutdownDomain.Text = sDomain;
		}
		
		public string GetShutdownDomain( )
		{
			return txtShutdownDomain.Text;
		}
		
		public void SetShutdownPaswd( SecureString sPwd )
		{
			if( sPwd != null )
				txtPasswdShutdown.Text = MOE.Utility.SecureStringToString(sPwd);
			
		}
		
		public SecureString GetShutdownPaswd()
		{
			SecureString ss = new SecureString();
			for (int i = 0; i < txtPasswdShutdown.Text.Length; i++)
        		ss.AppendChar(System.Convert.ToChar(txtPasswdShutdown.Text[i]));
			
			ss.MakeReadOnly();
			
			return ss;
		}
		
		public void SetForceShutdown( bool b )
		{
			chkForceShutdown.Checked = b;
		}
		
		public bool GetForceShutdown( )
		{
			return chkForceShutdown.Checked;
		}
		
		// Reboot
		
		public void SetRebootTimeout( int i )
		{
			numTimeoutReboot.Value = i;
		}
		
		public int GetRebootTimeout( )
		{
			return (int)numTimeoutReboot.Value;
		}
		
		public void SetRebootComment( string sComment )
		{
			txtCommentReboot.Text = sComment;
		}
		
		public string GetRebootComment()
		{
			return txtCommentReboot.Text;
		}
		
		public void SetRebootUser( string sUser )
		{
			txtUserReboot.Text = sUser;
		}
		
		public string GetRebootUser( )
		{
			return txtUserReboot.Text;
		}
		
		public void SetRebootPaswd( SecureString sPwd )
		{
			if( sPwd != null )
			{
				txtPasswdReboot.Text = MOE.Utility.SecureStringToString( sPwd );
			}
		}
		
		public SecureString GetRebootPaswd()
		{
			SecureString ss = new SecureString();
			for (int i = 0; i < txtPasswdReboot.Text.Length; i++)
        		ss.AppendChar(System.Convert.ToChar(txtPasswdReboot.Text[i]));
			
			ss.MakeReadOnly();
			
			return ss;
		}
		
		public void SetRebootDomain( string sDomain )
		{
			txtRebootDomain.Text = sDomain;
		}
		
		public string GetRebootDomain( )
		{
			return txtRebootDomain.Text;
		}
		
		public void SetForceReboot( bool b )
		{
			chkForceReboot.Checked = b;
		}
		
		public bool GetForceReboot( )
		{
			return chkForceReboot.Checked;
		}
		
		public void SetUnresolvedNameOk( bool bOk )
		{
			chkAddIfNameResolved.Checked = !bOk;
		}
		
		public bool GetUnresolvedNameOk()
		{
			return !chkAddIfNameResolved.Checked;
		}
		
		public void SetUnresolvedMacOk( bool bOk )
		{
			chkAddIfMacResolved.Checked = !bOk;
		}
		
		public bool GetUnresolvedMacOk()
		{
			return !chkAddIfMacResolved.Checked;
		}
			
		public void SetDoLogging( bool b )
		{
			chkDoLogging.Checked = b;
		}
		
		public bool GetDoLogging()
		{
			return chkDoLogging.Checked;
		}
		
		public void SetColorizeListView( bool b )
		{
			chkColorizeListView.Checked = b;
		}
		
		public bool GetColorizeListView()
		{
			return chkColorizeListView.Checked;
		}
		
		public void SetAutosaveHostlist( bool b )
		{
			chkAutosaveHostlist.Checked = b;
		}
		
		public bool GetAutosaveHostlist()
		{
			return chkAutosaveHostlist.Checked;
		}

        public void SetUpdateIPAddresses(bool b)
        {
            chkUpdateIPAddresses.Checked = b;
        }

        public bool GetUpdateIPAddresses()
        {
            return chkUpdateIPAddresses.Checked;
        }
		#endregion
		
		#region General Controls --------------------------------------------------------
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Close();
		}
		
		#endregion
		
		void AddToolToolStripMenuItemClick(object sender, EventArgs e)
		{
			WOL2Tool nt = new WOL2Tool();
			DlgEditTool dlg = new DlgEditTool( nt );
			
			if( dlg.ShowDialog( this ) == DialogResult.OK &&
			   nt.IsValid() )
			{
				m_Tools.Add( nt.GetName(), nt );
				AddTool( nt );
			}
		}
		
		void ModifyToolToolStripMenuItemClick(object sender, EventArgs e)
		{
			if( listView1.SelectedItems.Count > 0 )
			{
				ListViewItem i = listView1.SelectedItems[0];
				
				if( i != null )
				{
					WOL2Tool nt = new WOL2Tool( i.Text, i.SubItems[1].Text, i.SubItems[2].Text, i.ImageKey );
					DlgEditTool dlg = new DlgEditTool( nt );
					
					if( dlg.ShowDialog( this ) == DialogResult.OK &&
					   nt.IsValid() )
					{
						i.SubItems[0].Text = nt.GetName();
						i.SubItems[1].Text = nt.GetCommand();
						i.SubItems[2].Text = nt.GetCmdLine();
                        
                        // Load the icon
                        string icon = nt.GetIconFileName();
                        i.ImageKey = nt.GetIconFileName();
                        
                        if (icon != null && File.Exists(icon))
                        {
                            if( !imgLstTools.Images.ContainsKey( icon) )
                                imgLstTools.Images.Add(icon, Image.FromFile(icon));
                            i.ImageKey = icon;
                        }
						
						WOL2Tool t = (WOL2Tool)i.Tag;
						if( t != null )
						{
							t.SetName( nt.GetName() );
							t.SetCommand( nt.GetCommand() );
							t.SetCmdLine( nt.GetCmdLine() );
                            t.SetIconFileName(nt.GetIconFileName());
						}
					}
				}
			}
		}
		
		void DeleteToolToolStripMenuItemClick(object sender, EventArgs e)
		{
			if( listView1.SelectedItems.Count > 0 )
			{
				ListViewItem i = listView1.SelectedItems[0];
				
				if( i != null )
				{
					if( i.Tag != null )
						m_Tools.Remove( ((WOL2Tool)i.Tag).GetName() );
					listView1.Items.Remove( i );
				}
			}
		}
	#region Members ---------------------------------------------------------------
	private Dictionary< string, WOL2Tool >	m_Tools = null;
	#endregion

    private void btnChooseCmdHost_Click(object sender, EventArgs e)
    {
        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            txtCmdHostChange.Text = "\"" + ofd.FileName + "\"";
        }
    }

    private void btnChooseCmdGroup_Click(object sender, EventArgs e)
    {
        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            txtCmdGroupChange.Text = "\"" + ofd.FileName + "\"";
        }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        ModifyToolToolStripMenuItemClick(new object(), new EventArgs());
    }

    }
}
