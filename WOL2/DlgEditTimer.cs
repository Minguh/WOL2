/*
 * WEOL2 Timer modification dialog box
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WOL2
{
	/// <summary>
	/// Description of DlgEditTimer.
	/// </summary>
	public partial class DlgEditTimer : Form
	{
		public DlgEditTimer( WOL2Timer t )
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			
			m_Timer = t;
			m_theTimer = new WOL2Timer( t );
			
			chkTimerEnabled.Checked = m_theTimer.IsEnabled();
			
			UpdateDescription();
		}
		
		// Event Handlers -----------------------------------------------------------
		
		void LbDaysSelectedIndexChanged(object sender, EventArgs e)
		{
			int iDay = lbDays.SelectedIndex;
			WOL2TimerDay dt = m_theTimer.GetTimeForDay( iDay );
			if( dt != null )
			{
				txtHour.Text 		= dt.WakeHour.ToString();
				txtMinute.Text 		= dt.WakeMinute.ToString();
				txtSecond.Text 		= dt.WakeSecond.ToString();
				chkEnabled.Checked	= dt.IsEnabled;
			}
		}

		void LinkLabel1Click(object sender, EventArgs e)
		{
			foreach( int i in lbDays.CheckedIndices )
			{
				WOL2TimerDay dt = m_theTimer.GetTimeForDay( i );
				if( dt != null )
				{
					dt.WakeHour 	= Convert.ToInt32( txtHour.Text );
					dt.WakeMinute	= Convert.ToInt32( txtMinute.Text );
					dt.WakeSecond	= Convert.ToInt32( txtSecond.Text );
					dt.IsEnabled	= chkEnabled.Checked;
				}
			}
			UpdateDescription();
		}
		
		void ChkTimerEnabledCheckedChanged(object sender, System.EventArgs e)
		{
			m_theTimer.SetIsEnabled( chkTimerEnabled.Checked );
			UpdateDescription();
		}
		
		protected void UpdateDescription()
		{
			string s;
			bool bFirst = true;
			
			if( m_theTimer.IsEnabled() )
			{
				s = MOE.Utility.GetStringFromRes("strTimerSetup");
				
				for( int i = 0; i < 7; i++ )
				{
					if( m_theTimer.GetTimeForDay( i ).IsEnabled )
					{
						if( !bFirst )
							s += "; ";
						
						s += lbDays.Items[i];
						s += " (";
						s += m_theTimer.GetTimeForDay(i).ToString();
						s += ")";
						
						bFirst = false;
					}
				}
				
				if( bFirst ) // No timer at all
					s = MOE.Utility.GetStringFromRes("strNoTimer");
				else
					s += ".";

			}
			else
				s = MOE.Utility.GetStringFromRes("strTimerIsDisabled");
			
			lblSummary.Text = s;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			m_Timer.SetIsEnabled( m_theTimer.IsEnabled() );
			for( int i = 0; i < 7; i++ )
			{
				m_Timer.GetTimeForDay(i).IsEnabled = m_theTimer.GetTimeForDay(i).IsEnabled;
				m_Timer.GetTimeForDay(i).WakeHour = m_theTimer.GetTimeForDay(i).WakeHour;
				m_Timer.GetTimeForDay(i).WakeMinute = m_theTimer.GetTimeForDay(i).WakeMinute;
				m_Timer.GetTimeForDay(i).WakeSecond = m_theTimer.GetTimeForDay(i).WakeSecond;
			}
			this.Close();
		}
		
		// Members ------------------------------------------------------------------
		
		WOL2Timer m_Timer;
		WOL2Timer m_theTimer;
	}
}
