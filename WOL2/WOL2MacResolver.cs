
using System;
using System.Collections.Generic;	// Dictionary
using System.IO;

namespace WOL2
{
	public class WOL2MacResolver
	{
		public WOL2MacResolver()
		{
			// Go, try read the files
			ReadFile( "oui.txt" );
			
			// Probably will not work as the logger is not initialized yet...
			MOE.Logger.DoLog( "WOL2MacResolver() Initialized. " + m_list.Count + " records loaded.", MOE.Logger.LogLevel.lvlInfo );
		}
		
		public bool ReadFile( String sFile )
		{
			try
			{
				String[] arr = File.ReadAllLines( sFile );
                m_list = new Dictionary<string, string>(arr.Length / 6);

				foreach(String s in arr )
				{
					int idx = 0;
					if( ( idx = s.IndexOf( "(base 16)" ) ) != -1 )
					{
                        string ss = s.Trim();
						String sMac = ss.Substring(0,6).ToUpper();
                        String sMan = "";

                        int pos = idx + 9;
                        if( pos < ss.Length )
                            sMan = ss.Substring(idx + 9).Trim();					
						
						if( sMac.Length == 6 && sMan.Length > 1 )
						{
							try
							{
								m_list.Add( sMac, sMan );
							}
							catch( System.ArgumentException ex )
							{
								// as per may 2009 the oui listing may contain duplicate keys.
								// ignore this.
							}
						}

					}
	
				}
			}
			catch( System.IO.FileNotFoundException )
			{
				MOE.Logger.DoLog( "Cannot find oui.txt. To use the MAC resolve rgo downoad this file from IEEE.", MOE.Logger.LogLevel.lvlWarning );
				return false;
			}
			catch( Exception ex )
			{
				MOE.Logger.DoLog( ex.ToString(), MOE.Logger.LogLevel.lvlWarning );
				MOE.Logger.DoLog( ex.StackTrace, MOE.Logger.LogLevel.lvlDebug );
				return false;
			}

           	// All ok.
			return true;
		}
		
		public string GetManufacturerFromMac( String sMac )
		{
			String sMan = "";
			String sQuery = sMac;
			sQuery = sQuery.Replace( ":", "" );
			sQuery = sQuery.Replace( "-", "" );
			sQuery = sQuery.Substring(0,6).ToUpper();
			
			if( m_list.TryGetValue( sQuery, out sMan ) )
			   return sMan;
			else
				return "unknown";
		}
		
		private Dictionary< string, string> 	m_list = new Dictionary<string, string>();
	}
}
