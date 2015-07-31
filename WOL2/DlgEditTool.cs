/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 14.01.2009
 * Zeit: 09:13
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WOL2
{
	/// <summary>
	/// Description of DlgEditTool.
	/// </summary>
	public partial class DlgEditTool : Form
	{
		public DlgEditTool( WOL2Tool t )
		{
			InitializeComponent();
			m_theTool = t;
			
			txtName.Text = t.GetName();
			txtCommand.Text = t.GetCommand();
			txtParams.Text = t.GetCmdLine();
            txtIconFileName.Text = t.GetIconFileName();
            UpdateIcon();
		}

        private void UpdateIcon()
        {
            if (File.Exists(txtIconFileName.Text))
            {
                imgIcon.Image = Image.FromFile(txtIconFileName.Text);
            }
            else
                imgIcon.Image = null;

        }
		
		#region Members
		private WOL2Tool m_theTool;
		#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if( openFileDialog1.InitialDirectory.Length == 0 )
                openFileDialog1.InitialDirectory = Application.StartupPath +"\\icons";

            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtIconFileName.Text = openFileDialog1.FileName;
                UpdateIcon();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_theTool.SetName(txtName.Text);
            m_theTool.SetCommand(txtCommand.Text);
            m_theTool.SetCmdLine(txtParams.Text);

            string icon = txtIconFileName.Text;
            if( icon.IndexOf( Application.StartupPath +"\\icons" ) == 0 )
                icon = icon.Replace(Application.StartupPath +"\\icons", ".\\icons" );

            m_theTool.SetIconFileName(icon);

            this.DialogResult = DialogResult.OK;
            Close();
        }
	}
}
