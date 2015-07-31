using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Xml;
using System.IO;

namespace WOL2
{
    class WOL2Profile
    {
        /**
         * Constructs a new WOL2 profile class.
         */
        public WOL2Profile(bool useRegistry)
        {
            UseRegistry = useRegistry;
        }

        /**
         * Defines the profile access modes
         */
        public enum WOL2ProfileAccessMode
        {
            ModeClosed = 0,
            ModeRead = 1,
            ModeWrite = 2
        }

        /**
         * Opens the profile for reading / writing.
         */
        public bool OpenProfile(WOL2ProfileAccessMode mode)
        {
            switch (mode)
            {

                case WOL2ProfileAccessMode.ModeRead:
                    {
                        // If in xml mode open the xml file
                        if (!UseRegistry)
                        {
                            m_xmlProfile = new XmlDocument();
                            try
                            {
                                // Load the file
                                m_xmlProfile.Load(PROFILE_FILE_NAME);

                                // Get the main node
                                m_xmlMain = m_xmlProfile.GetElementsByTagName("WakeOnLanProfile")[0];
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                    break;

                case WOL2ProfileAccessMode.ModeWrite:
                    {
                        // If in xml mode open a new xml file
                        if (!UseRegistry)
                        {

                            // Create the XML document
                            m_xmlProfile = new XmlDocument();
                            m_xmlProfile.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><WakeOnLanProfile></WakeOnLanProfile>");

                            // Get the main node
                            m_xmlMain = m_xmlProfile.GetElementsByTagName("WakeOnLanProfile")[0];
                        }
                        else
                        {
                            // if in Reg. mode: clear the old keys
                            try
                            {
                                Registry.CurrentUser.DeleteSubKeyTree(PROFILE_REG_KEY);
                            }
                            catch
                            {
                            }
                        }
                    }
                    break;

                case WOL2ProfileAccessMode.ModeClosed:
                    {
                        // Close the file if any
                        if ( m_Mode == WOL2ProfileAccessMode.ModeWrite && m_xmlProfile != null )
                        {
                            // Save the file
                            try
                            {
                                m_xmlProfile.Save(PROFILE_FILE_NAME);
                            }
                            catch 
                            {
                                return false;
                            }
                        }
                            
                        m_xmlProfile = null;
                        m_xmlMain = null;
                    }
                    break;
            }

            m_Mode = mode;
            
            // all done
            return true;
        }

        /**
         * Closes the profile.
         */
        public bool CloseProfile()
        {
            return OpenProfile(WOL2ProfileAccessMode.ModeClosed);
        }

        /**
         * Returns the current access mode.
         */
        public WOL2ProfileAccessMode GetCurrentAccessMode()
        {
            return m_Mode;
        }

        /**
         * Returns true if the XML profile is available for reading.
         * (PROFILE_FILE_NAME exists.)
         */
        public static bool HasXmlProfile()
        {
            return File.Exists(PROFILE_FILE_NAME);
        }

        /**
         * Delete the XML profile.
         * (PROFILE_FILE_NAME exists.)
         */
        public static void DropXmlProfile()
        {
            if(File.Exists(PROFILE_FILE_NAME))
                File.Delete(PROFILE_FILE_NAME);
        }

        /**
         * Gets the specified setting from the profile.
         */
        private string _GetSetting(string sWhat, string sDefault)
        {
            string ret = sDefault;
            if (UseRegistry)
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(PROFILE_REG_KEY);

                object value = regKey.GetValue(sWhat);
                if (value != null)
                    ret = value.ToString();
            }
            else
            {
                XmlNodeList list = m_xmlProfile.SelectNodes("/WakeOnLanProfile/" + sWhat);
                if (list.Count > 0)
                {
                    XmlNode node = list[0];
                    ret = node.InnerText;
                }

            }
            return ret;
        }

        public string GetSetting(string sWhat, string sDefault)
        {
            string ret = sDefault;
            try
            {
                ret = _GetSetting(sWhat, sDefault);
            }
            catch { }
            return ret;
        }

        public int GetSetting(string sWhat, int iDefault)
        {
            int ret = iDefault;
            try
            {
                ret = int.Parse(_GetSetting(sWhat, iDefault.ToString()));
            }
            catch{}
            return ret;
        }

        public bool GetSetting(string sWhat, bool bDefault)
        {
            bool ret = bDefault;
            try
            {
                ret = bool.Parse(_GetSetting(sWhat, bDefault.ToString()));
            }
            catch { }
            return ret;
        }

        /**
         * Saves the current setting to the profile.
         */
        public void SaveSetting(string sWhat, string sValue)
        {
            if (UseRegistry)
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(PROFILE_REG_KEY);
                regKey.SetValue(sWhat, sValue );
            }
            else
            {
                // Fill the tag
                try
                {
                    XmlNode tmp = m_xmlProfile.CreateElement(sWhat);
                    tmp.InnerText = sValue;
                    m_xmlMain.AppendChild(tmp);
                }
                catch { }
            }
        }

        public void SaveSetting(string sWhat, int Value)
        {
            SaveSetting( sWhat, Value.ToString() );
        }

        public void SaveSetting(string sWhat, bool Value)
        {
            SaveSetting( sWhat, Value.ToString() );
        }

        // Members
        #region members
            private const string PROFILE_REG_KEY = "Software\\MOette\\WOL2";    // the registry key we operate on
            public const string PROFILE_FILE_NAME = "WOL2.profile.xml";        // the xml file name we operate on
            public bool UseRegistry {get; private set;}                        // true if the profile is saved / loaded from the registry

            private WOL2ProfileAccessMode m_Mode = WOL2ProfileAccessMode.ModeClosed;  // the curren access mode
            private XmlDocument m_xmlProfile;                                   // the xml file we operate on
            private XmlNode m_xmlMain;                                          // the main node of the xml file
        #endregion
    }
}
