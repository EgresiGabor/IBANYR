using System;
using System.ComponentModel;
using System.Net;

namespace IBANYR
{
    public class IPv4Address
    {
        #region Private fields
        IPAddress ipv4;
        IPAddress subnetMask;
        #endregion
        #region Public properties
        [DisplayName("IP cím")]
        public IPAddress Ipv4 { get => ipv4; set => ipv4 = value; }
        public string Ipv4String
        {
            get => ipv4.ToString();
            private set
            {
                if (!IPAddress.TryParse(value.Trim(), out ipv4))
                {
                    throw new ArgumentException("A megadott IP cím nem megfelelő!");
                }
            }
        }
        [DisplayName("Alhálózati maszk")]
        public IPAddress SubnetMask { get => subnetMask; set => subnetMask = value; }
        public string SubnetMaskString
        {
            get => subnetMask.ToString();
            private set
            {
                if (!IPAddress.TryParse(value.Trim(), out subnetMask))
                {
                    throw new ArgumentException("A megadott alhálózati maszk nem megfelelő!");
                }
            }
        }
        #endregion
        #region Constructors
        public IPv4Address(IPAddress ipv4, IPAddress subnetMask)
        {
            Ipv4 = ipv4;
            SubnetMask = subnetMask;
        }
        public IPv4Address(string ipv4String, string subnetMaskString)
        {
            Ipv4String = ipv4String;
            SubnetMaskString = subnetMaskString;
        }
        #endregion
        #region Methods and Functions
        public override bool Equals(object obj)
        {
            return obj is IPv4Address ip && this.Ipv4.Equals(ip.Ipv4);
        }
        public override string ToString()
        {
            return $"{Ipv4String} - {SubnetMaskString}";
        }
        #endregion
    }
}
