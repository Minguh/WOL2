using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WOL2
{
    class WOL2MacToIPv6Converter
    {
        private WOL2MacToIPv6Converter() {}

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
        public static string ConvertToLinkLocal(string mac)
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
        }
    }
}
