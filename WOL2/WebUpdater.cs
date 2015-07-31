/*
 * MOE Ulitities Web Updater
 * Last Change: 15.01.2009
 */
 
using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace MOE
{
	/// <summary>
	/// The webupdater checks whether there is an update for the current app.
	/// </summary>
	public class WebUpdater
	{
		/// <summary>
		/// Constructs a new WebUpdater given an URL.
		/// </summary>
		/// <param name="sUrl">The url where to look for the update.</param>
		public WebUpdater( string sUrl )
		{
			m_sUrl = sUrl;
		}
		
		/// <summary>
		/// Checks whether an update for the current App is avaliable.
		/// </summary>
		/// <returns>true if update is avaliable</returns>
		public bool IsUpdateAvaliable()
		{
			bool bRet = false;
			
			if( m_sUrl.Length == 0 )
				return false;
			
			try
			{
				System.Net.WebClient Client = new WebClient();
			    Stream strm = Client.OpenRead( m_sUrl );
			    StreamReader sr = new StreamReader(strm);
			    string line;
			    
			    while( ( line = sr.ReadLine() ) !=null )
			    {
			        
			        if( line.Contains( VERSION_STRING ) )
			        {
			        	m_sVersionString = line.Substring( VERSION_STRING.Length );
			        }
			        else if( line.Contains( DOWNLOAD_STRING ) )
			        {
			        	m_sDownloadString = line.Substring( DOWNLOAD_STRING.Length );
			        }
			        else if( line.Contains( MESSAGE_STRING ) )
			        {
			        	m_sMessageString = line.Substring( MESSAGE_STRING.Length );
			        }
			    }
			    
			    strm.Close();
	
			    if( m_sDownloadString.Length > 0 && m_sVersionString.Length > 0 )
			    {
			    	Version vApp = Assembly.GetExecutingAssembly().GetName().Version;
			    	Version vNew = new Version( m_sVersionString );
			    	
			    	if( vNew.CompareTo( vApp ) > 0 )
			    		bRet = true;
			    }
			}
			catch( Exception )
			{
				// Some error
			}
			
		    return bRet;
		}
		
		/// <summary>
		/// Calls the default app on the download URL
		/// </summary>
		public void Update()
		{
			// get the messagebox text
			string s = "The version "; 
			s += GetVersionString(); 
			s += " is avaliable for download.";
			
			if( m_sMessageString != null && m_sMessageString.Length > 0 )
			{
				s += "\n\n";
				s += m_sMessageString;
			}
			
			s += "\n\nDo you wish to download the update?";
			
			// Get the Messagebox title
			AssemblyProductAttribute a = (AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false )[0];
			
			
			string t = a.Product;
			t += ": Online Update";
			
			DialogResult dr = MessageBox.Show( s, t,
     						MessageBoxButtons.YesNo, 
     						MessageBoxIcon.Question );
			
			if( dr == DialogResult.Yes )
				System.Diagnostics.Process.Start( m_sDownloadString );
		}
		
		/// <summary>
		/// Returns the download URL
		/// </summary>
		public string GetDownloadUrl()
		{
			return m_sDownloadString;
		}
		
		/// <summary>
		/// Returns the version string
		/// </summary>
		public string GetVersionString()
		{
			return m_sVersionString;
		}
		
		#region Members
		private string m_sUrl;
		private string m_sVersionString;
		private string m_sDownloadString;
		private string m_sMessageString;
		
		// Constants
		private const string VERSION_STRING = "Current Version=";
		private const string DOWNLOAD_STRING = "Download=";
		private const string MESSAGE_STRING = "Message=";
		#endregion
	}
}
