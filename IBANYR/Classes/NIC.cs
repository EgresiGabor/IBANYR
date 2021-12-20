using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace IBANYR
{
    public enum NICType
    {
        Ethernet,
        WiFi
    }
    public enum IpAddressingType
    {
        [Description("Dinamikus (DHCP)")]
        dhcp,
        [Description("Statikus")]
        staticIp
    }
    public class NIC
    {
        #region Private fields
        byte[] macAddressData;
        NICType nicType;
        IpAddressingType ipv4Addressing;
        List<IPv4Address> ipv4Addresses;
        #endregion
        #region Public properties
        internal byte[] MacAddressData
        {
            get => macAddressData; 
            private set
            {
                if (value != null && value.Length == 6)
                {
                    macAddressData = value;
                }
                else
                {
                    throw new ArgumentException("A MAC cím megadása kötelező, mely egy 6 tagú byte tömb lehet!");
                }
            }
        }
        [DisplayName("MAC cím")]
        public string MacAddressString
        {
            get
            {
                string macAddressString = String.Empty;
                for (int i = 0; i < macAddressData.Length; i++)
                {
                    macAddressString += $"{Convert.ToString(macAddressData[i], 16).ToUpper().PadLeft(2,'0')}{(i+1 < macAddressData.Length ? ":" : "")}";
                }
                return macAddressString;
            }
            private set
            {
                string pattern = @"([0-9a-fA-F]{2}:){5}[0-9a-fA-F]{2}";
                if (!String.IsNullOrEmpty(value) && Regex.IsMatch(value, pattern))//rx.Match(value).Success)
                {
                    string[] stringArray = value.Split(':');
                    byte[] mac = new byte[stringArray.Length];
                    for (int i = 0; i < mac.Length; i++)
                    {
                        mac[i] = byte.Parse(stringArray[i], System.Globalization.NumberStyles.HexNumber);
                    }
                    macAddressData = mac;
                }
            }
        }
        [DisplayName("Adapter típusa")]
        public NICType NicType
        {
            get => nicType; 
            private set
            {
                if (Enum.IsDefined(typeof(NICType), value))
                {
                    nicType = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott típusú hálózati adapter rögzítése lehetséges!");
                }
            }
        }
        [DisplayName("Címkezelés")]
        public IpAddressingType Ipv4Addressing
        {
            get => ipv4Addressing; 
            set
            {
                if (Enum.IsDefined(typeof(IpAddressingType), value))
                {
                    ipv4Addressing = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott címzéstípus adható meg!");
                }
            }
        }

        internal List<IPv4Address> Ipv4Addresses { get => ipv4Addresses.ToList(); private set => ipv4Addresses = value; }
        #endregion
        #region Constructors
        public NIC(byte[] macAddressData, NICType nicType, IpAddressingType ipv4Addressing)
        {
            MacAddressData = macAddressData;
            NicType = nicType;
            Ipv4Addressing = ipv4Addressing;
            ipv4Addresses = new List<IPv4Address>();
        }

        public NIC(string macAddressString, NICType nicType, IpAddressingType ipv4Addressing)
        {
            MacAddressString = macAddressString;
            NicType = nicType;
            Ipv4Addressing = ipv4Addressing;
            ipv4Addresses = new List<IPv4Address>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Az IP cím lista feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="ip">A listához hozzáadandó IP cím <see cref="IPv4Address"/> példánya!</param>
        public void AddIpv4(IPv4Address ip)
        {
            if (ipv4Addresses.Count == 0 || ipv4Addresses.Where(x=>x.Equals(ip)).ToList().Count == 0)
            {
                ipv4Addresses.Add(ip);
            }
            else
            {
                throw new ArgumentException("Ez az IP cím már rögzítve van ehhez a hálózati adapterhez!");
            }
        }
        /// <summary>
        /// Az IP cím lista ürítésére szolgáló metódus
        /// </summary>
        public void ClearIpv4()
        {
            ipv4Addresses.Clear();
        }
        /// <summary>
        /// A hálózati adapterhez tartozó IP címek kiírására szolgáló funkció
        /// </summary>
        /// <returns>IP címek egy karakterláncként |-val elválasztva</returns>
        public string GetIpv4String()
        {
            string result = String.Empty;
            if (ipv4Addresses.Count > 0)
            {
                foreach (IPv4Address item in ipv4Addresses)
                {
                    result += item.Ipv4String + " | ";
                }
            }
            return result;
        }
        public override string ToString()
        {
            return $"{MacAddressString} - {NicType}";
        }
        #endregion
    }
}
