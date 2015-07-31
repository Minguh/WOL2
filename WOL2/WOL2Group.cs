/*
 * WOL2 Group Class
 */
using System;
using System.Xml;

namespace WOL2
{
	/// <summary>
	/// Description of WOL2Group.
	/// </summary>
	public class WOL2Group
	{
		public WOL2Group( string sName )
		{
			m_sName = sName;
		}
		
		public WOL2Group()
		{
		}
		
		// Functions ----------------------------------------------------------------
		
		/// <summary>
		/// Returns the groups name
		/// </summary>
		public string GetName()
		{
			return m_sName;
		}
		
		/// <summary>
		/// Sets the groups name
		/// </summary> 
		public void SetName( string name )
		{
			m_sName = name;
		}
		
		/// <summary>
		/// Returns the groups name
		/// </summary>
		public string GetDescription()
		{
			return m_sDescription;
		}
		
		/// <summary>
		/// Sets the groups name
		/// </summary> 
		public void SetDescription( string desc )
		{
			m_sDescription = desc;
		}
		
		/// <summary>
		/// Returns the associated wake timer
		/// </summary>
		public WOL2Timer GetTimer()
		{
			return m_Timer;
		}

        /// <summary>
        /// Returns the associated timer
        /// </summary>
        public WOL2Timer GetRebootTimer()
        {
            return m_RebootTimer;
        }

        /// <summary>
        /// Returns the associated timer
        /// </summary>
        public WOL2Timer GetShutdownTimer()
        {
            return m_ShutdownTimer;
        }
		
		/// <summary>
		/// Sets the associated timer
		/// </summary>
		public void SetTimer( WOL2Timer t )
		{
			m_Timer = t;
		}
		
		/// <summary>
		/// Checks if this group is valid
		/// </summary>
		public bool IsValid()
		{
			return ( m_sName != null && m_sName.Length > 0 );
		}
		
		/// <summary>
		/// Recreates a group from an XML node.
		/// </summary>
		/// <param name="n">The XML node to recreate this group from.</param>	
		public bool DeserializeXML( XmlNode n )
		{
			while( n != null )
			{
				if( n.Name == "GroupName" )
					m_sName = n.InnerText;
				
                // The old WakeOnAlarm attribute is now mapped to the wake timer
                else if( n.Name == "WakeOnAlarm" )
					m_Timer.SetIsEnabled( n.InnerText == "1" ? true : false );
				else if( n.Name == "Comment" )
					m_sDescription = n.InnerText;
				else if( n.Name == "Timer" )
					m_Timer.DeserializeXML( n.FirstChild );
                else if (n.Name == "RebootTimer")
                    m_RebootTimer.DeserializeXML(n.FirstChild);
                else if (n.Name == "ShutdownTimer")
                    m_ShutdownTimer.DeserializeXML(n.FirstChild);
				
				// Next please
				n = n.NextSibling;
			}
			return true;
		}
		
		/// <summary>
		/// Returns the XML representation of the group.
		/// </summary>
		/// <param name="doc">The XML document used to create the XmlNode.</param>	
		public XmlNode SerializeXml( XmlDocument doc ) 
		{
			// Create new host tag
			XmlNode xmlGroup = doc.CreateElement( "Group" );
			
			// Fill the Name tag
			XmlNode tmp = doc.CreateElement( "GroupName" );
			tmp.InnerText = GetName();
			xmlGroup.AppendChild( tmp );
			
			// Fill the Comment tag
			tmp = doc.CreateElement( "Comment" );
			tmp.InnerText = GetDescription();
			xmlGroup.AppendChild( tmp );
			
			// Fill the WakeOnAlarm tag
			/* tmp = doc.CreateElement( "WakeOnAlarm" );
			tmp.InnerText = m_Timer.IsEnabled() ? "1" : "0";
			xmlGroup.AppendChild( tmp ); */
			
			// Fill the Timer tags
			tmp = m_Timer.SerializeXml( doc, "Timer" );
			xmlGroup.AppendChild( tmp );
            tmp = m_ShutdownTimer.SerializeXml(doc, "ShutdownTimer");
            xmlGroup.AppendChild(tmp);
            tmp = m_RebootTimer.SerializeXml(doc, "RebootTimer");
            xmlGroup.AppendChild(tmp);
			
			return xmlGroup;
		}
		
		// Members ------------------------------------------------------------------
		
		private string 			m_sName;					// The groups name
		private string 			m_sDescription;				// The groups description
		private WOL2Timer		m_Timer = new WOL2Timer();	        // The groups wake timer
        private WOL2Timer       m_RebootTimer = new WOL2Timer();	// The groups reboot timer
        private WOL2Timer       m_ShutdownTimer = new WOL2Timer();	// The groups shutdown timer
		
	}
}
