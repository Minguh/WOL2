/*
 * This is the WOL2 About screen.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
// using System.ComponentModel;
using System.Reflection;

namespace WOL2
{
	/// <summary>
	/// About Screen with Link Label to open the homepage.
	/// Nothing so special.
	/// </summary>
	public partial class DlgAbout : Form
	{
		public DlgAbout()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
            this.Text = String.Format("Wake On Lan 2 - Version {0}", AssemblyVersion);
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.oette.info");
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.Close();
		}

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
	}
}
