/*
 * WOL2 Timer and TimerDay Class
 * 
 */
using System;
using System.Xml;
using System.Collections;

namespace WOL2
{

	public class WOL2TimerDay
	{
		public WOL2TimerDay( int iWakeHour, int iWakeMinute, int iWakeSecond, bool bIsEnabled )
		{
			WakeHour 	= iWakeHour;
			WakeMinute 	= iWakeMinute;
			WakeSecond 	= iWakeSecond;
			IsEnabled 	= bIsEnabled;
		}
		
		public WOL2TimerDay()
		{
		}
		
		public WOL2TimerDay( WOL2TimerDay t )
		{
			WakeHour = t.WakeHour;
			WakeMinute = t.WakeMinute;
			WakeSecond = t.WakeSecond;
			IsEnabled = t.IsEnabled;
		}
		
		// Functions ----------------------------------------------------------------
		
		/// <summary>
		/// Returns true if this timer fires for the given DateTime.
		/// </summary>
		public bool Check(DateTime check)
		{
            if (check.Hour == this.WakeHour &&
                check.Minute == this.WakeMinute &&
                check.Second == this.WakeSecond)
				return true;
			else
				return false;
		}
		
		/// <summary>
		/// Recreates a timer from an XML node.
		/// </summary>
		/// <param name="n">The XML node to recreate this timer from.</param>	
		public bool DeserializeXML( XmlNode n )
		{
			while( n != null )
			{
				if( n.Name == "WakeHour" )
					WakeHour = Convert.ToInt32( n.InnerText );
				else if( n.Name == "WakeMinute" )
					WakeMinute = Convert.ToInt32( n.InnerText );
				else if( n.Name == "WakeSecond" )
					WakeSecond = Convert.ToInt32( n.InnerText );
				else if( n.Name == "WakeEnabled" )
					IsEnabled = ( n.InnerText == "1" ? true : false );
				
				// Next please
				n = n.NextSibling;
			}
			return true;
		}
		
		/// <summary>
		/// Returns the XML representation of the timer.
		/// </summary>
		/// <param name="doc">The XML document used to create the XmlNode.</param>	
		public bool SerializeXml( XmlNode n, XmlDocument doc ) 
		{
			XmlNode h = doc.CreateElement( "WakeHour" );
			XmlNode m = doc.CreateElement( "WakeMinute" );
			XmlNode s = doc.CreateElement( "WakeSecond" );
			XmlNode e = doc.CreateElement( "WakeEnabled" );
			
			h.InnerText = WakeHour.ToString();
			m.InnerText = WakeMinute.ToString();
			s.InnerText = WakeSecond.ToString();
			e.InnerText = IsEnabled ? "1" : "0";
			
			n.AppendChild( h );
			n.AppendChild( m );
			n.AppendChild( s );
			n.AppendChild( e );
			
			return true;
		}
		
		/// <summary>
		/// Returns the string representation of the timer.
		/// </summary>
		public override string ToString()
		{
			string s;
			s = WakeHour.ToString() + ":" + WakeMinute.ToString() + ":" + WakeSecond.ToString();
			return s;
		}
		
		// Members ------------------------------------------------------------------
		
		public int WakeHour;
		public int WakeMinute;
		public int WakeSecond;
		public bool IsEnabled;
	}
		
	/// <summary>
	/// Description of WOL2Timer.
	/// </summary>
	public class WOL2Timer
	{
		public WOL2Timer()
		{
			for( int i = 0; i < 7 ; i++ )
				m_Days.Add( new WOL2TimerDay() );
		}
		
		public WOL2Timer( WOL2Timer t )
		{
			for( int i = 0; i < 7 ; i++ )
				m_Days.Add( new WOL2TimerDay( t.GetTimeForDay( i ) ) );
			
			m_bIsEnabled = t.IsEnabled();
		}
		
		// Functions ----------------------------------------------------------------
		
		/// <summary>
		/// Returns true if this timer fires now.
		/// </summary>
		public bool Check(DateTime check)
		{
			int iDay = -1;

            switch (check.DayOfWeek)
			{
				case DayOfWeek.Monday:
					iDay = 0;
					break;
				case DayOfWeek.Tuesday:
					iDay = 1;
					break;
				case DayOfWeek.Wednesday:
					iDay = 2;
					break;
				case DayOfWeek.Thursday:
					iDay = 3;
					break;
				case DayOfWeek.Friday:
					iDay = 4;
					break;
				case DayOfWeek.Saturday:
					iDay = 5;
					break;
				case DayOfWeek.Sunday:
					iDay = 6;
					break;
				
				default: break;
			}

            if (iDay > -1 && this.m_bIsEnabled)
            {
                WOL2TimerDay tmr = m_Days[iDay] as WOL2TimerDay;
                if (tmr!=null)
                {
                    if (tmr.IsEnabled)
                    {
                        return ((WOL2TimerDay)m_Days[iDay]).Check(check);
                    }
                }
            }
            return false;
		}
		
		/// <summary>
		/// Returns true is this timer is enabled
		/// </summary>
		public bool IsEnabled()
		{
			return m_bIsEnabled;
		}

		/// <summary>
		/// Sets whether this timer is enabled
		/// </summary>
		/// <param name="b">True if the timer is enabled</param>	
		public void SetIsEnabled( bool b )
		{
			m_bIsEnabled = b;
		}
		
		/// <summary>
		/// Returns the day timer for the given day.
		/// </summary>
		/// <param name="iDay">Weekday number. (0=Monday ... 6=Sunday)</param>	
		public WOL2TimerDay GetTimeForDay( int iDay )
		{
			if( iDay >= 0 && iDay <= 6 )
				return (WOL2TimerDay)m_Days[ iDay ];
			else
				return null;
		}		
		
		/// <summary>
		/// Recreates a timer from an XML node.
		/// </summary>
		/// <param name="n">The XML node to recreate this timer from.</param>	
		public bool DeserializeXML( XmlNode n )
		{
			while( n != null )
			{
                if (n.Name == "TimerEnabled")
                {
                    this.m_bIsEnabled = (n.InnerText == "1" ? true : false);
                }
				else if( n.Name.Length == 5 )
				{
					string sDay = n.Name.Substring( 4 );
					int iDay = Convert.ToInt32( sDay ) - 1;
					
					WOL2TimerDay d = (WOL2TimerDay)m_Days[iDay];
					d.DeserializeXML( n.FirstChild );
				}
				
				// Next please
				n = n.NextSibling;
			}
			return true;
		}
		
		/// <summary>
		/// Returns the XML representation of the timer.
		/// </summary>
		/// <param name="doc">The XML document used to create the XmlNode.</param>	
		public XmlNode SerializeXml( XmlDocument doc, String nodeName ) 
		{
			
            // Create new host tag
            XmlNode xmlTimer = doc.CreateElement(nodeName);

            XmlNode tmp = doc.CreateElement("TimerEnabled");
            tmp.InnerText = IsEnabled() ? "1" : "0";
            xmlTimer.AppendChild(tmp);

			for( int i = 1; i <= 7; i++ )
			{
				WOL2TimerDay d = (WOL2TimerDay)m_Days[i-1];
				
				XmlNode n = doc.CreateElement( "Day_" + i.ToString() );
				d.SerializeXml( n, doc );
				
				xmlTimer.AppendChild( n );
			}
			
			return xmlTimer;
		}
		
		// Members ------------------------------------------------------------------
		
		private ArrayList 	m_Days	= new ArrayList();	
		private bool 		m_bIsEnabled;
	}
}
