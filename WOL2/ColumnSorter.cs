using System;
using System.Collections;
using System.Text.RegularExpressions;	
using System.Windows.Forms;

namespace ListViewSorter
{
	/// <summary>
	/// This class is an implementation of the 'IComparer' interface.
	/// </summary>
	public class ListViewColumnSorter : IComparer
	{
		/// <summary>
		/// Specifies the column to be sorted
		/// </summary>
		private int ColumnToSort;
		/// <summary>
		/// Specifies the order in which to sort (i.e. 'Ascending').
		/// </summary>
		private SortOrder OrderOfSort;
		/// <summary>
		/// Case insensitive comparer object
		/// </summary>
		//private CaseInsensitiveComparer ObjectCompare;
		private NumberCaseInsensitiveComparer ObjectCompare;
		private ImageTextComparer FirstObjectCompare;

		/// <summary>
		/// Class constructor.  Initializes various elements
		/// </summary>
		public ListViewColumnSorter()
		{
			// Initialize the column to '0'
			ColumnToSort = 0;

			// Initialize the sort order to 'none'
			//OrderOfSort = SortOrder.None;
			OrderOfSort = SortOrder.Ascending;

			// Initialize the CaseInsensitiveComparer object
			ObjectCompare = new NumberCaseInsensitiveComparer();//CaseInsensitiveComparer();
			FirstObjectCompare = new ImageTextComparer();
		}

		/// <summary>
		/// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
		/// </summary>
		/// <param name="x">First object to be compared</param>
		/// <param name="y">Second object to be compared</param>
		/// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
		public int Compare(object x, object y)
		{
			int compareResult;
			ListViewItem listviewX, listviewY;

			// Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem)x;
			listviewY = (ListViewItem)y;

			if (ColumnToSort == 0)
			{
				compareResult = FirstObjectCompare.Compare(x,y);
			}
			else if( ColumnToSort == 1 )	// IP
			{
				compareResult = -1;
				
				string sIp1 = listviewX.SubItems[ColumnToSort].Text;
				string sIp2 = listviewY.SubItems[ColumnToSort].Text;

				if( sIp1 == sIp2 )
					compareResult = 0;	// Identical
				else if( sIp1.Length > 0 && sIp2.Length > 0 )
				{
				
					string[] sIp1p = sIp1.Split( '.' );
					string[] sIp2p = sIp2.Split( '.' );
					
					// Might be IPs
					if( sIp1p.Length == 4 && sIp2p.Length == 4 )
					{
				
						if( Convert.ToInt32( sIp1p[0] ) < Convert.ToInt32( sIp2p[0] ) )
					   		compareResult = -1;
					   	else if( Convert.ToInt32( sIp1p[0] ) > Convert.ToInt32( sIp2p[0] ) )
					   		compareResult = 1;
					   	else
					   	{
					   		if( Convert.ToInt32( sIp1p[1] ) < Convert.ToInt32( sIp2p[1] ) )
					   			compareResult = -1;
					   		else if( Convert.ToInt32( sIp1p[1] ) > Convert.ToInt32( sIp2p[1] ) )
					   			compareResult = 1;
					   		else
					   		{
					   			if( Convert.ToInt32( sIp1p[2] ) < Convert.ToInt32( sIp2p[2] ) )
						   			compareResult = -1;
						   		else if( Convert.ToInt32( sIp1p[2] ) > Convert.ToInt32( sIp2p[2] ) )
						   			compareResult = 1;
						   		else
						   		{
						   			if( Convert.ToInt32( sIp1p[3] ) < Convert.ToInt32( sIp2p[3] ) )
						   				compareResult = -1;	
						   			else if( Convert.ToInt32( sIp1p[3] ) > Convert.ToInt32( sIp2p[3] ) )
						   				compareResult = 1;
						   		}
					   		}
							
						}
					}
				}
			}
			else if( ColumnToSort == 2 )	// MAC
			{
				compareResult = -1;
				
				string sIp1 = listviewX.SubItems[ColumnToSort].Text;
				string sIp2 = listviewY.SubItems[ColumnToSort].Text;

				if( sIp1 == sIp2 )
					compareResult = 0;	// Identical
				else if( sIp1.Length > 0 && sIp2.Length > 0 )
				{
				
					string[] sIp1p = sIp1.Split( ':' );
					string[] sIp2p = sIp2.Split( ':' );
					
					// Might be MAC Adresses
					if( sIp1p.Length == 6 && sIp2p.Length == 6 )
					{
				
						if( Convert.ToInt32( sIp1p[0], 16 ) < Convert.ToInt32( sIp2p[0], 16 ) )
					   		compareResult = -1;
					   	else if( Convert.ToInt32( sIp1p[0], 16 ) > Convert.ToInt32( sIp2p[0], 16 ) )
					   		compareResult = 1;
					   	else
					   	{
					   		if( Convert.ToInt32( sIp1p[1], 16 ) < Convert.ToInt32( sIp2p[1], 16 ) )
					   			compareResult = -1;
					   		else if( Convert.ToInt32( sIp1p[1], 16 ) > Convert.ToInt32( sIp2p[1], 16 ) )
					   			compareResult = 1;
					   		else
					   		{
					   			if( Convert.ToInt32( sIp1p[2], 16 ) < Convert.ToInt32( sIp2p[2], 16 ) )
						   			compareResult = -1;
						   		else if( Convert.ToInt32( sIp1p[2], 16 ) > Convert.ToInt32( sIp2p[2], 16 ) )
						   			compareResult = 1;
						   		else
						   		{
						   			if( Convert.ToInt32( sIp1p[3], 16 ) < Convert.ToInt32( sIp2p[3], 16 ) )
						   				compareResult = -1;	
						   			else if( Convert.ToInt32( sIp1p[3], 16 ) > Convert.ToInt32( sIp2p[3], 16 ) )
						   				compareResult = 1;
						   			else
						   			{
						   				if( Convert.ToInt32( sIp1p[4], 16 ) < Convert.ToInt32( sIp2p[4], 16 ) )
						   					compareResult = -1;
								   		else if( Convert.ToInt32( sIp1p[4], 16 ) > Convert.ToInt32( sIp2p[4], 16 ) )
								   			compareResult = 1;
								   		else
							   			{	
								   			if( Convert.ToInt32( sIp1p[5], 16 ) < Convert.ToInt32( sIp2p[5], 16 ) )
									   			compareResult = -1;
									   		else if( Convert.ToInt32( sIp1p[5], 16 ) > Convert.ToInt32( sIp2p[5], 16 ) )
									   			compareResult = 1;
							   			}
					   				}
								}
					   		}
					   	}
					}
				}
			}
			else
			{
				// Compare the two items
				compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text,listviewY.SubItems[ColumnToSort].Text);
			}

			// Calculate correct return value based on object comparison
			if (OrderOfSort == SortOrder.Ascending)
			{
				// Ascending sort is selected, return normal result of compare operation
				return compareResult;
			}
			else if (OrderOfSort == SortOrder.Descending)
			{
				// Descending sort is selected, return negative result of compare operation
				return (-compareResult);
			}
			else
			{
				// Return '0' to indicate they are equal
				return 0;
			}
		}
    
		/// <summary>
		/// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
		/// </summary>
		public int SortColumn
		{
			set
			{
				ColumnToSort = value;
			}
			get
			{
				return ColumnToSort;
			}
		}

		/// <summary>
		/// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
		/// </summary>
		public SortOrder Order
		{
			set
			{
				OrderOfSort = value;
			}
			get
			{
				return OrderOfSort;
			}
		}
    
	}

	public class ImageTextComparer : IComparer
	{
		//private CaseInsensitiveComparer ObjectCompare;
		private NumberCaseInsensitiveComparer ObjectCompare;
        
		public ImageTextComparer()
		{
			// Initialize the CaseInsensitiveComparer object
			ObjectCompare = new NumberCaseInsensitiveComparer();//CaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			ListViewItem listviewX, listviewY;

			// Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem)x;
			listviewY = (ListViewItem)y;

			return ObjectCompare.Compare(listviewX.Text,listviewY.Text);
		}
	}

	public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
	{
		public NumberCaseInsensitiveComparer ()
		{
			
		}

		public new int Compare(object x, object y)
		{
			if( (x is System.String) && IsWholeNumber((string)x) 
			    && (y is System.String) && IsWholeNumber((string)y)
			    && ((string)x).Length > 0 && ((string)y).Length > 0
			   )
			{
				return base.Compare(System.Convert.ToInt32(x),System.Convert.ToInt32(y));
			}
			else
			{
				return base.Compare(x,y);
			}
		}

		private bool IsWholeNumber(string strNumber)
		{
			Regex objNotWholePattern=new Regex("[^0-9]");
			return !objNotWholePattern.IsMatch(strNumber);
		}  
	}

}
