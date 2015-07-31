using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace WOL2
{
    public static class WOL2DNSHelper
    {

        // Windows API do use ARP to get the MAC Address
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        static extern int SendARP(UInt32 DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);


        /**
         * Converts a mac address in format aa:bb:cc:dd:ee:ff (or aa-bb-cc-dd-ee-ff) into a link local IPv6 address.
         * 
         * A mac address is 48 bits, an IPv6 address is 128 bits. 
         * Here’s the conversion process step by step:

            take the mac address: for example 52:74:f2:b1:a8:7f
            throw ff:fe in the middle: 52:74:f2:ff:fe:b1:a8:7f
            reformat to IPv6 notation 5274:f2ff:feb1:a87f
            convert the first octet from hexadecimal to binary: 52 -> 01010010
            invert the bit at position 2 (0x02): 01010010 -> 01010000
            convert octet back to hexadecimal: 01010000 -> 50
            replace first octet with newly calculated one: 5074:f2ff:feb1:a87f
            prepend the link-local prefix: fe80::5074:f2ff:feb1:a87f
         */
        /*public static string ConvertToLinkLocal(string mac)
        {
            string ret = null;

            string[] mac_octet = mac.Split(':');

            // target mac must be 6-bytes!
            if (mac_octet.Length != 6)
            {
                mac_octet = mac.Split('-');
            }

            // Convert to IPV6 link local address
            if (mac_octet.Length == 6)
            {
                ret = "fe80::";
                int octet = Int16.Parse(mac_octet[0], System.Globalization.NumberStyles.HexNumber);
                octet ^= 0x02;
                ret += String.Format("{0:X}", octet);
                ret += mac_octet[1];
                ret += ":";
                ret += mac_octet[2];
                ret += "ff:fe";
                ret += mac_octet[3];
                ret += ":";
                ret += mac_octet[4];
                ret += mac_octet[5];
            }

            return ret;
        }*/

        /**
         * Uses the DNS system to resolve the IPv6 link local address of a host.
         * 'host' can be an ip address or a host name.
         */
        public static string ResolveToIPv6Local(string host)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(host);
                foreach (IPAddress ip in entry.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6
                        && ip.IsIPv6LinkLocal)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch { }
            return null;
        }

        /**
         * Uses the DNS system to resolve the IPv4 addresses of a ipv6 address / hostname.
         * 'host' can be an ip address or a host name.
         */
        public static string [] ResolveToIPv4(string host)
        {
            List<string> list = new List<string>();

            try
            {
                IPHostEntry entry = Dns.GetHostEntry(host);
                foreach (IPAddress ip in entry.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        list.Add(ip.ToString());
                    }
                }
            }
            catch { }

            string[] ret = new string[list.Count];
            int idx = 0;
            foreach (string s in list)
            {
                ret[idx++] = s;
            }

            return ret;
        }

        /**
         * Returns the subnetmask to a given IPv4 address or null if none was found.
         */
        public static string ResolveSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (unicastIPAddressInformation.IPv4Mask != null &&
                            ( address.Equals(unicastIPAddressInformation.Address) ||
                              IsInSameSubnet( address, unicastIPAddressInformation.Address, 
                                              unicastIPAddressInformation.IPv4Mask ) ) )
                        {
                            return unicastIPAddressInformation.IPv4Mask.ToString();
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Calculates the broadcast address given an IP Address and a subnet mask.
        /// </summary>
        /// <param name="address">The IP to calculate the broadcast from.</param>
        /// <param name="subnetMask">The subnet mask to calculate the broadcast from.</param>
        /// <returns>The broadcast address</returns>
        public static IPAddress GetBroadcastAddress( IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();
	
            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
	
            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }
		

        /**
         * Calculates the network address from IPv4 + Subnetmask
         */
        public static IPAddress GetNetworkAddress(this IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            return new IPAddress(broadcastAddress);
        }

        /**
         * Checks if two IPv4 addresses are in the same subnet.
         */
        public static bool IsInSameSubnet(this IPAddress address2, IPAddress address, IPAddress subnetMask)
        {
            IPAddress network1 = GetNetworkAddress(address, subnetMask);
            IPAddress network2 = GetNetworkAddress(address2, subnetMask);

            return network1.Equals(network2);
        }

        /// <summary>
        /// Get the MAC Address of a given IPv4 Address / Hostname.
        /// </summary>
        /// <param name="hostNameOrAddress">Hostname or IPv4 Address</param>
        /// <returns>MAC Address or an empty string.</returns>
        public static string GetMACAddress(string hostNameOrAddress)
        {
            IPAddress ip;
            
            if (!IPAddress.TryParse(hostNameOrAddress, out ip))
            {
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(hostNameOrAddress);
                    if (hostEntry.AddressList.Length == 0)
                        return ""; // We were not able to resolve given hostname / address

                    // Get all known IPs for that host.
                    foreach (IPAddress pIp in hostEntry.AddressList)
                    {
                        // Only IPv4 supports ARP
                        if (pIp.AddressFamily == AddressFamily.InterNetwork)
                        {
                            // We need to establish a connection to that host first
                            Ping ping = new Ping();
                            PingReply reply = ping.Send(pIp);

                            // Resolve ARP
                            string mac = _ARPCall((UInt32)pIp.Address);
                            if (mac != null && mac.Length > 0)
                                return mac;
                        }
                        else if (pIp.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            // TODO: Implement IPv6 Support
                            // ResolveIpNetEntry2 + GetIpNetTable2 
                        }
                    }

                }
                catch { }
            }
            else
                return _ARPCall( (UInt32)ip.Address );

            return "";
        }

        /**
         * Internal W32 API facade for SendARP API.
         */
        private static string _ARPCall(UInt32 ipsrc)
        {
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;

            if (SendARP(ipsrc, 0, macAddr, ref macAddrLen) != 0)
                return ""; // The SendARP call failed

            string sMac = "";
            sMac += String.Format("{0:x2}", macAddr[0]);
            sMac += ":";
            sMac += String.Format("{0:x2}", macAddr[1]);
            sMac += ":";
            sMac += String.Format("{0:x2}", macAddr[2]);
            sMac += ":";
            sMac += String.Format("{0:x2}", macAddr[3]);
            sMac += ":";
            sMac += String.Format("{0:x2}", macAddr[4]);
            sMac += ":";
            sMac += String.Format("{0:x2}", macAddr[5]);

            return sMac;
        }
    }
}
