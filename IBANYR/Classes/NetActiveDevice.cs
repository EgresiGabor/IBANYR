using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IBANYR
{
    public class NetActiveDevice : Hardware
    {
        #region Private fields
        string hostName;
        List<NIC> nicsList;
        #endregion
        #region Public properties
        [DisplayName("Hosztnév")]
        public string HostName
        {
            get => hostName; 
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    hostName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A hoszt név megadása kötelező és maximum 50 karakter hosszú lehet!");
                }
            }
        }
        public List<NIC> NicsList { get => nicsList.ToList(); private set => nicsList = value; }
        #endregion
        #region Constructors
        public NetActiveDevice(string hostName, int uId, string place, string serialNumber, byte warrantyYears, string category, HardwareType hardwareType, bool portable, bool isVirtual, string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1) : base(uId, place, serialNumber, warrantyYears, category, hardwareType, portable, isVirtual, aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription, aId)
        {
            HostName = hostName;
            this.nicsList = new List<NIC>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Hálózati adapter lista feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="nic">A listához hozzáadandó hálózati adapter <see cref="NIC"/> példánya!</param>
        public void AddNIC(NIC nic)
        {
            nicsList.Add(nic);
        }
        /// <summary>
        /// Hálózati adapter listája ürítésére szolgáló metódus
        /// </summary>
        public void ClearNIC()
        {
            nicsList.Clear();
        }
        public override string ToCsv()
        {
            return $"{base.ToCsv()};";
        }
        #endregion
    }
}
