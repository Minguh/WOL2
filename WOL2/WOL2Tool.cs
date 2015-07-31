/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 13.01.2009
 * Zeit: 16:55
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Windows.Forms;

namespace WOL2
{
    /// <summary>
    /// Description of WOL2Tool.
    /// </summary>
    public class WOL2Tool
    {
        public WOL2Tool()
        {
            m_sName = "";
            m_sCmdLine = "";
            m_sCmd = "";
        }

        public WOL2Tool(string sName, string sCmd, string sCmdLine, string sIcon)
        {
            m_sCmd = sCmd;
            m_sCmdLine = sCmdLine;
            m_sName = sName;
            m_sIconFileName = sIcon;
        }

        /// <summary>
        /// Executes this tool on the given Host.
        /// </summary>
        /// <param name="h">the host to call this tool for</param>
        /// <returns></returns>
        public bool Execute(WOL2Host h)
        {
            bool bRet = false;

            string param = GetCmdLine();

            if (h != null)
            {
                param = h.ExpandVariables(param);
            }

            // Expand environment variables
            param = Environment.ExpandEnvironmentVariables(param);
            string cmd = Environment.ExpandEnvironmentVariables(m_sCmd);

            try
            {
                System.Diagnostics.Process.Start(cmd, param);
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message +"\n\n" + cmd + "\n" + param, "WOL2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bRet;
        }

        public override string ToString()
        {
            return m_sName + "¦" + m_sCmd + "¦" + m_sCmdLine + "¦" + m_sIconFileName;
        }

        public static WOL2Tool parse(string s)
        {
            string sName="", sCmd="", sParams="", sIcon="";
            string[] items = s.Split('¦');
            for (int idx = 0; idx < items.Length; idx++)
            {
                switch (idx)
                {
                    case 0:
                        sName = items[idx];
                        break;
                    case 1:
                        sCmd = items[idx];
                        break;
                    case 2:
                        sParams = items[idx];
                        break;
                    case 3:
                        sIcon = items[idx];
                        break;
                }
            }

            if (sName.Length > 0 && sCmd.Length > 0)
                return new WOL2Tool(sName, sCmd, sParams, sIcon);
            else
                return null;
        }

        public string GetName()
        {
            return m_sName;
        }

        public void SetName(string n)
        {
            m_sName = n;
        }

        public string GetCommand()
        {
            return m_sCmd;
        }

        public void SetCommand(string c)
        {
            m_sCmd = c;
        }

        public string GetCmdLine()
        {
            return m_sCmdLine;
        }

        public void SetCmdLine(string c)
        {
            m_sCmdLine = c;
        }

        public string GetIconFileName()
        {
            return m_sIconFileName;
        }

        public void SetIconFileName(string c)
        {
            m_sIconFileName = c;
        }

        public bool IsValid()
        {
            return (m_sName.Length > 0 && m_sCmd.Length > 0);
        }

        #region Members -----------------------------------------------------------

        private string m_sName;
        private string m_sCmd;
        private string m_sCmdLine;
        private string m_sIconFileName;

        #endregion
    }

}
