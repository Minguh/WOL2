/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 08.07.2009
 * Zeit: 12:10
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace MOE
{
	/// <summary>
	/// Description of MOE_Logger.
	/// </summary>
	public class Logger
	{
		protected Logger()
		{
		}
				/**
		 * Log Levels for DoLog
		 */
		public enum LogLevel
		{
			lvlDebug = 0,
			lvlInfo = 1,
			lvlWarning = 2,
			lvlError = 3
		}

        private static string LogLevelToString(LogLevel lvl)
        {
            switch (lvl)
            { 
                case LogLevel.lvlDebug:
                    return "Debug    | ";
                case LogLevel.lvlError:
                    return "Error    | ";
                case LogLevel.lvlInfo:
                    return "Info     | ";
                case LogLevel.lvlWarning:
                    return "Warning  | ";
            }
            return "";
        }
		
		/**
		 * Initialize Logging
		 */
		public static void StartLogging( String sFile, LogLevel lvl )
		{
            try
            {
                m_LogFs = new FileStream(sFile, FileMode.Append, FileAccess.Write);
                m_LogWriter = new StreamWriter(m_LogFs);
                m_LogLevel = lvl;

                DoLog(DateTime.Now.ToString() + ": " + Application.ProductName + " version " + Application.ProductVersion + " starting...", LogLevel.lvlInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not start Logging:\n" + ex.ToString());
            }
		}
		
		/**
		 * Logging Function
		 */
		public static void DoLog( string s, LogLevel lvl )
		{
			if( m_LogWriter != null )
			{
				if( lvl >= m_LogLevel )
				{
					m_LogWriter.WriteLine( LogLevelToString(lvl) + s );
					m_LogWriter.Flush();
				}
			}
		}
		
		/**
		 * Called to stop logging
		 */
		public static void StopLogging()
		{
			if( m_LogWriter == null )
				return;
			
			DoLog( DateTime.Now.ToString() + ": Application is terminating.", LogLevel.lvlInfo );
			
			m_LogWriter.Close();
			
			m_LogWriter = null;
			m_LogFs = null;
		}
		
		#region Members
		private static FileStream m_LogFs = null;
		private static StreamWriter m_LogWriter = null;
		private static LogLevel m_LogLevel = LogLevel.lvlDebug;
		#endregion
	}
}
