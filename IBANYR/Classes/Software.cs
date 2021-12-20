using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace IBANYR
{
    class Software : ItAsset, IToCsv
    {
        #region Private fields
        string softwareProducer;
        string softwareDesc;
        int softwareLicenseNum;
        DateTime? licenseDate;
        string productKey;
        List<int> hardwareIds;
        #endregion
        #region Public properties
        public string SoftwareProducer
        {
            get => softwareProducer; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    softwareProducer = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    softwareProducer = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A szoftver gyártójának neve nem haladhatja meg a 50 karaktert!");
                }
            }
        }
        public string SoftwareDesc
        {
            get => softwareDesc; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    softwareDesc = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 200)
                {
                    softwareDesc = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A szoftver leírása nem haladhatja meg a 200 karaktert!");
                }
            }
        }
        public int SoftwareLicenseNum
        {
            get => softwareLicenseNum; 
            set
            {
                if (value >= 0)
                {
                    softwareLicenseNum = value;
                }
                else
                {
                    throw new ArgumentException("A licencszám csak nem negatív egész szám lehet!");
                }
            }
        }
        public DateTime? LicenseDate
        {
            get => licenseDate; 
            set
            {
                if (value == null || (value != null && value >= PurchaseDate))
                {
                    licenseDate = value;
                }
                else
                {
                    throw new ArgumentException("A licenc érvényességi ideje nem lehet korábbi dátum, mint a beszerzés ideje!");
                }
            }
        }
        public string ProductKey
        {
            get
            {
                if (!String.IsNullOrEmpty(productKey))
                {
                    return productKey;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    productKey = null;
                }
                else if (value.Trim().Length <= 150)
                {
                    productKey = Password.Encrypt(value.Trim());
                }
                else
                {
                    throw new ArgumentException("A termékkulcs maximum 150 karakter hosszú lehet!");
                }
            }
        }
        internal List<int> HardwareIds { get => hardwareIds.ToList(); private set => hardwareIds = value; }
        #endregion
        #region Constructors
        public Software(string softwareProducer, string softwareDesc, int softwareLicenseNum, DateTime? licenseDate, string productKey, string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1) : base(aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription, aId)
        {
            SoftwareProducer = softwareProducer;
            SoftwareDesc = softwareDesc;
            SoftwareLicenseNum = softwareLicenseNum;
            LicenseDate = licenseDate;
            if (aId != -1)
            {
                this.productKey = productKey;
            }
            else
            {
                ProductKey = productKey;
            }
            this.hardwareIds = new List<int>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Kapcsolódó hardverek listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="aId">A listához hozzáadandó hardver azonosítószáma!</param>
        public void AddHardwareId(int aId)
        {
            hardwareIds.Add(aId);
        }
        /// <summary>
        /// Kapcsolódó hardverek listájának ürítésére szolgáló metódus
        /// </summary>
        public void ClearHardwareIds()
        {
            hardwareIds.Clear();
        }
        /// <summary>
        /// Szoftvereket tartalmazó lista CSV fájlba történő exportálására szolgáló statikus metódus
        /// </summary>
        /// <param name="list">Az exportálandó szoftverek listája</param>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        public static void ExportToCsv(List<Software> list, string path)
        {
            try
            {
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Szoftver neve;Beszerzés dátuma;Szoftver tulajdonosa;Státusz;Gyártó;Szoftver leírása, funkciója;Licenszszám;Licensz érvényességi dátuma;Dokumentum hivatkozások;Selejtezés dátuma;Egyéb megjegyzés";
                file.WriteLine(header);
                file.Flush();
                foreach (Software item in list)
                {
                    file.WriteLine(item.ToCsv());
                    file.Flush();
                }
                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A szoftver adatainak CSV struktúra szerinti kinyerésére szolgáló funkció
        /// </summary>
        /// <returns>A szoftver adatainak pontosvesszővel elválasztott szövegként való visszatérése</returns>
        public virtual string ToCsv()
        {
            return $"{AId};{AName.Replace(';', '|')};{PurchaseDate.ToString("yyyy.MM.dd.")};" +
                $"{(Owner != null ? Owner.ToString().Replace(';', '|') : "")};" +
                $"{(Attribute.GetCustomAttribute(this.Status.GetType().GetField(this.Status.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};" +
                $"{(!String.IsNullOrEmpty(SoftwareProducer) ? SoftwareProducer.Replace(';', '|') : "")};" +
                $"{(!String.IsNullOrEmpty(SoftwareDesc) ? SoftwareDesc.Replace(';', '|') : "")};" +
                $"{SoftwareLicenseNum};{(LicenseDate is DateTime lcd ? lcd.ToString("yyyy.MM.dd.") : "")};" +
                $"{(!String.IsNullOrEmpty(DocLink) ? DocLink.Replace(';', '|') : "")};" +
                $"{(ScrappingDate is DateTime scd ? scd.ToString("yyyy.MM.dd.") : "")};" +
                $"{(!String.IsNullOrEmpty(OtherDescription) ? OtherDescription.Replace(';', '|') : "")}";
        }
        #endregion
    }

}
