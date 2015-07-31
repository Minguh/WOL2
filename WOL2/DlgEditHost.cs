/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 16.12.2008
 * Zeit: 14:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using WOL2;
using System.Net;

namespace WOL2
{
	/// <summary>
	/// Description of DlgEditHost.
	/// </summary>
	public partial class DlgEditHost : Form
    {
        #region Members
        
        // The host assigned to this dialog
        private WOL2Host m_Host;
        
        #endregion
        
        
        public DlgEditHost( WOL2Host h )
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			
			// Assign the host to this instance
			m_Host = h;
			
			// Check if the host is a new one
			/* if( !m_Host.IsValid() )
			{
				// Create a new host
			}
			else
			{*/
				// Edit an existing host
				txtComment.Text 	= m_Host.GetDescription();
				txtIp.Text 			= m_Host.GetIpAddress();
                txtIPv6.Text        = m_Host.GetIpV6Address();
				txtMac.Text 		= m_Host.GetMacAddress();
				txtSnMask.Text 		= m_Host.GetSubnetMask();
				txtName.Text 		= m_Host.GetName();
				txtGroups.Text		= m_Host.GetGroups();
				chkDHCP.Checked		= m_Host.IsDynamicHost();
				chkNotify.Checked	= m_Host.IsStateChangedNoftificationEnabled();
				txtSecureOn.Text	= m_Host.GetSecureOnPassword();

                WOLPacketTransferMode f = m_Host.PacketTransferMode;

                if ((f & WOLPacketTransferMode.modeBCast) == WOLPacketTransferMode.modeBCast)
                    cboWolMode.SelectedIndex = 1;
                else if ((f & WOLPacketTransferMode.modeNetCast) == WOLPacketTransferMode.modeNetCast)
                    cboWolMode.SelectedIndex = 2;
                else if ((f & WOLPacketTransferMode.modeSendToHost) == WOLPacketTransferMode.modeSendToHost)
                    cboWolMode.SelectedIndex = 3;
                else
                    cboWolMode.SelectedIndex = 0;

			// }
		}
			
		void BtnOkClick(object sender, EventArgs e)
		{
            m_Host.SetName(txtName.Text);
            m_Host.SetMacAddress(txtMac.Text);
            m_Host.SetSubnetMask(txtSnMask.Text);
            m_Host.SetDescription(txtComment.Text);
            m_Host.SetIpAddress(txtIp.Text);
            m_Host.SetGroups(txtGroups.Text);
            m_Host.SetIsDynamicHost(chkDHCP.Checked);
            m_Host.SetIsStateChangedNoftificationEnabled(chkNotify.Checked);
            m_Host.SetSecureOnPassword(txtSecureOn.Text);
            m_Host.SetIpV6Address(txtIPv6.Text);

            WOLPacketTransferMode f = WOLPacketTransferMode.modeNone;
            switch (cboWolMode.SelectedIndex)
            {
                case 1:
                    f = WOLPacketTransferMode.modeBCast;
                    break;
                case 2:
                    f = WOLPacketTransferMode.modeNetCast;
                    break;
                case 3:
                    f = WOLPacketTransferMode.modeSendToHost;
                    break;
                
            }
            m_Host.PacketTransferMode = f;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            string lookup = txtName.Text;
            if (lookup.Length > 0)
            {
                string ipv6 = WOL2DNSHelper.ResolveToIPv6Local(lookup);
                if (ipv6 == null)
                {
                    lookup = txtIp.Text;
                    if (lookup.Length > 0)
                        ipv6 = WOL2DNSHelper.ResolveToIPv6Local(lookup);
                }

                if (ipv6 != null)
                    txtIPv6.Text = ipv6;
            }
        }

        private void btnLookUpIpV4_Click(object sender, EventArgs e)
        {
            string lookup = txtName.Text;
            if (lookup.Length > 0)
            {
                string[] ipv4 = WOL2DNSHelper.ResolveToIPv4(lookup);

                if (ipv4 == null || ipv4.Length == 0)
                {
                    string msg = MOE.Utility.GetStringFromRes("strHostnameInValid");
                    MessageBox.Show(this, msg, "Wake on lan tool 2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                contextMenuStrip1.Items.Clear();
                foreach (string s in ipv4)
                    contextMenuStrip1.Items.Add(s);

                contextMenuStrip1.Show(this.Left + btnLookUpIpV4.Left, this.Top + btnLookUpIpV4.Bottom);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(txtName.Text);
                txtName.Text = entry.HostName;
                
                string msg = MOE.Utility.GetStringFromRes("strHostnameValid");
                MessageBox.Show(this, msg, "Wake on lan tool 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                string msg = MOE.Utility.GetStringFromRes("strHostnameInValid");
                MessageBox.Show(this, msg, "Wake on lan tool 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHostLookup_Click(object sender, EventArgs e)
        {
            try
            {
                string lookup = txtIp.Text;
                if (lookup.Length == 0)
                    lookup = txtIPv6.Text;

                if (lookup.Length > 0)
                {
                    IPHostEntry entry = Dns.GetHostEntry(lookup);
                    txtName.Text = entry.HostName;
                }
            }
            catch { }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            txtIp.Text = e.ClickedItem.Text;

            // find the subnet mask
            string sn = WOL2DNSHelper.ResolveSubnetMask(IPAddress.Parse(txtIp.Text));
            if (sn != null)
                txtSnMask.Text = sn;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string mac = WOL2DNSHelper.GetMACAddress(txtName.Text);
            if( mac == null || mac.Length == 0 )
                mac = WOL2DNSHelper.GetMACAddress(txtIp.Text);

            if (mac != null || mac.Length > 0)
                txtMac.Text = mac;
        }
	}
}
