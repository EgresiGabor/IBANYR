using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;

namespace IBANYR
{
    public enum AssetState
    {
        [Description("Használatban")]
        inUse,
        [Description("Használaton kívül")]
        outOfOrder,
        [Description("Selejtezendő")]
        forScrapping,
        [Description("Selejtezve")]
        discarded
    }
    public abstract class ItAsset
    {
        #region Private fields
        int aId;
        string aName;
        Department owner;
        DateTime purchaseDate;
        AssetState status;
        string docLink;
        DateTime? scrappingDate;
        string otherDescription;
        List<ItSystem> itSystems;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int AId
        {
            get => aId; 
            private set
            {
                if (aId == -1)
                {
                    aId = value;
                }
                else
                {
                    throw new InvalidOperationException("Az eszközazonosító módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Eszköz neve")]
        public string AName
        {
            get => aName; 
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 50)
                {
                    aName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Az eszköznév megadása kötelező, és minimum 3, maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Beszerzés dátuma")]
        public DateTime PurchaseDate
        {
            get => purchaseDate; 
            set
            {
                if (value != null && value >= SqlDateTime.MinValue.Value)
                {
                    purchaseDate = value;
                }
                else
                {
                    throw new ArgumentException("A beszerzés dátuma nem lehet null érték, valamint nem lehet korábbi dátum, mint 1753.01.01.!");
                }
            }
        }
        [DisplayName("Eszköz tulajdonosa")]
        public Department Owner { get => owner; set => owner = value; }
        [DisplayName("Státusz")]
        public AssetState Status
        {
            get => status; 
            set
            {
                if (Enum.IsDefined(typeof(AssetState), value))
                {
                    status = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott értéket adhat meg státusznak!");
                }
            }
        }
        [DisplayName("Dokumentum hivatkozások")]
        public string DocLink
        {
            get => docLink; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    docLink = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 4000)
                {
                    docLink = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A dokumentum hivatkozások tartalma nem haladhatja meg a 4000 karaktert!");
                }
            }
        }
        [DisplayName("Selejtezés dátuma")]
        public DateTime? ScrappingDate
        {
            get => scrappingDate; 
            set
            {
                if (value == null || (value != null && value >= purchaseDate))
                {
                    scrappingDate = value;
                }
                else
                {
                    throw new ArgumentException("A selejtezés dátuma nem lehet korábbi mint a beszerzés dátuma!");
                }
            }
        }
        [DisplayName("Egyéb megjegyzés")]
        public string OtherDescription
        {
            get => otherDescription; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    otherDescription = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 1073741823)
                {
                    otherDescription = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Az egyéb megjegyzés tartalma nem haladhatja meg a 1.073.741.823 karaktert!");
                }
            }
        }
        internal List<ItSystem> ItSystems { get => itSystems.ToList(); private set => itSystems = value; }
        [DisplayName("Bizalmaság")]
        public byte Confidentiality
        {
            get
            {
                byte confidentiality = 0;
                if (itSystems.Count != 0)
                {
                    confidentiality = itSystems.Select(x => x.Confidentiality).ToList().Max();
                }
                return confidentiality;
            }
        }
        [DisplayName("Sértetlenség")]
        public byte Integrity
        {
            get
            {
                byte integrity = 0;
                if (itSystems.Count != 0)
                {
                    integrity = itSystems.Select(x => x.Integrity).ToList().Max();
                }
                return integrity;
            }
        }
        [DisplayName("Rendelkezésre állás")]
        public byte Availability
        {
            get
            {
                byte availability = 0;
                if (itSystems.Count != 0)
                {
                    availability = itSystems.Select(x => x.Availability).ToList().Max();
                }
                return availability;
            }
        }
        #endregion
        #region Constructors
        protected ItAsset(string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1)
        {
            if (aId != -1)
            {
                this.aId = aId;
            }
            AName = aName;
            PurchaseDate = purchaseDate;
            Owner = owner;
            Status = status;
            DocLink = docLink;
            ScrappingDate = scrappingDate;
            OtherDescription = otherDescription;
            ItSystems = new List<ItSystem>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Kapcsolódó rendszerek listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="itSys">A listához hozzáadandó rendszer <see cref="ItSystem"/> példánya!</param>
        public void AddItSystems(ItSystem itSys)
        {
            itSystems.Add(itSys);
        }
        /// <summary>
        /// Kapcsolódó rendszerek listájának ürítésére szolgáló metódus
        /// </summary>
        public void ClearItSystems()
        {
            itSystems.Clear();
        }
        public override string ToString()
        {
            return $"{AName}";
        }
        #endregion
    }
}
