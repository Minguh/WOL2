/*
 * WOL2 CSV Export Dialog
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.IO;

using Microsoft.Win32;

namespace WOL2
{
	/// <summary>
	/// CSV Exporter Dialog
	/// </summary>
	public partial class DlgCSVExport : Form
	{
		public DlgCSVExport( List< WOL2Host > hl )
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();	
			
			m_HostList = hl;
			
			RegistryKey regKey = Registry.CurrentUser.OpenSubKey(
									"Software\\MOette\\WOL2");
			
			if( regKey != null )
			{
				object value = null;
				
				value = regKey.GetValue( "LastCSVHeader" );
				if( value != null )
					cboHdr.Items.Add( value.ToString() );
				cboHdr.SelectedIndex = cboHdr.Items.Count -1;
				
				value = regKey.GetValue( "LastCSVFormat" );
				if( value != null )
					cboFormat.Items.Add( value.ToString() );
				cboFormat.SelectedIndex = cboFormat.Items.Count -1;
			}
		}
		
		#region Members
		List< WOL2Host > m_HostList;
		#endregion
		
		#region event handlers
		void CboHdrSelectedIndexChanged(object sender, EventArgs e)
		{
			if( cboFormat.Text.Length == 0 )
				cboFormat.Text = cboHdr.Text;
		}
		
		void CboHdrTextUpdate(object sender, EventArgs e)
		{
			if( cboFormat.Text.Length == 0 )
				cboFormat.Text = cboHdr.Text;
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			// Reset state label
			lblState.Text = "";
			progressBar1.Value = 0;
			
			// Ask for file name
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.FileName = "";
			saveFileDialog1.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*" ;
			saveFileDialog1.FilterIndex = 1;
			saveFileDialog1.RestoreDirectory = true ;
			
			// Read and filter the raw data
			String sFile;
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				sFile = saveFileDialog1.FileName;
			}
			else
				return;
			
			try
			{
                FileStream fs = File.Create(sFile);
				StreamWriter sw = new StreamWriter( fs );
				
				// Write the header
				if( cboHdr.Text.Length>0 )
					sw.WriteLine( cboHdr.Text );
				
				// Write the hosts
				int count = 0;
				foreach( WOL2Host h in m_HostList )
				{
					sw.WriteLine( h.SerializeCSV( cboFormat.Text ) );
					progressBar1.Value = 100 * ++count / m_HostList.Count;
				}
				
				// All done.
				sw.Close();
                fs.Close();

                lblState.Text = String.Format( MOE.Utility.GetStringFromRes("strCsvSavedAs"), sFile );
				progressBar1.Value = 100;
			}
			catch( Exception ex )
			{
				MOE.Logger.DoLog( "CSV Export: " + ex.ToString(), 
				                  MOE.Logger.LogLevel.lvlError );
				MOE.Logger.DoLog( ex.StackTrace, MOE.Logger.LogLevel.lvlDebug );	
			}
		}
		#endregion
		
		
		void DlgCSVExportFormClosing(object sender, FormClosingEventArgs e)
		{
			RegistryKey regKey = Registry.CurrentUser.CreateSubKey(
										"Software\\MOette\\WOL2");
			
			if( regKey != null )
			{
				regKey.SetValue( "LastCSVHeader", cboHdr.Text );
				regKey.SetValue( "LastCSVFormat", cboFormat.Text );
			}
		}
	}
}
