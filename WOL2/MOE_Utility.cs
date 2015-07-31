/*
 * Benutzer: MOE
 * Datum: 06.01.2009
 * Zeit: 13:36
 */
using System;
using System.Security;
using System.Resources;
using System.Reflection;

namespace MOE
{
	/// <summary>
	/// MOE.Utility is a utility class with various functions.
	/// Currently they areassorted, as sorting them does not yet make any sese.
	/// </summary>
	public class Utility
	{
		// You may not instanciate this class
		protected Utility()
		{
		}
	
		/**
		 * This function returns true if the .NET code is executed within the MONO framework
		 */
		public static bool IsRunningOnMono()
		{
			return Type.GetType ("Mono.Runtime") != null;
		}
		
		/**
		 * This function converts a secure string into a string
		 */
		public static string SecureStringToString( SecureString ss )
		{
			string s = null;
			if( ss == null )
				return "";
			
			IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(ss);
			try 
			{
				s = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
			} 
			finally 
			{
				System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
			}
			
			return s;
		}
		
		/**
		 * This function converts a string into a secure string
		 */
		public static SecureString SecureStringFromString( string s )
		{
			SecureString ss = new SecureString();
			if( s != null )
			{
				for( int i = 0; i < s.Length; i++ )
					ss.AppendChar( System.Convert.ToChar( s[i] ) );
			}
			return ss;
		}
		
		/**
		 * This function encodes the given strin in BASE64
		 */
		public static string Base64Encode( string s )
		{
			string se = null;
			
			if( s != null )
			{
				byte[] b = System.Text.Encoding.Unicode.GetBytes( s );
				se = Convert.ToBase64String( b );
			}
			
			return se;
		}
		
		/**
		 * This function decodes the given BASE64 encoded string.
		 */
		public static string Base64Decode( string s )
		{
			string sd = null;
			
			try
			{
				byte [] b = Convert.FromBase64String( s );
				sd = System.Text.Encoding.Unicode.GetString( b );
			}
			catch( Exception )
			{
				
			}
				
			return sd;
		}

        /// <summary>
        /// Get a string from the resource file.
        /// </summary>
        /// <param name="sName">The name of the string resource you want to load.</param>
        /// <param name="sDefault">The default value if sName could not be found.</param>
        public static string GetStringFromRes(string sName )
        {
            // Get the current assembly
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // Create a resource manager for the current assembly
            // WOL2.Properties.Resources is the name of the resources file in the properties package
            ResourceManager resmgr = new ResourceManager("WOL2.Properties.Resources", assembly);

            // Load the value of string value for Client
            try
            {
                string s = resmgr.GetString(sName);
                if (s != null)
                    return s;
            }
            catch
            {
                MOE.Logger.DoLog("Translation Error: String not found: " + sName, Logger.LogLevel.lvlError);
            }

            return "";
                  
        }
	}
}
