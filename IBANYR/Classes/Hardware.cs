using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace IBANYR
{
    public enum HardwareType
    {
        [Description("Adattároló")]
        dataStorage,
        [Description("Számítógép")]
        computerDevice,
        [Description("Egyéb aktív hálózati eszköz")]
        otherNetActiveDevice,
        [Description("Egyéb hardver")]
        otherHardware
    }
    public class Hardware : ItAsset, IToCsv
    {
        #region Private fields
        int uId;
        string place;
        string serialNumber;
        byte warrantyYears;
        string category;
        HardwareType hardwareType;
        bool portable;
        bool isVirtual;
        #endregion
        #region Public properties
        [DisplayName("Felhasználó szervezeti egysége")]
        public Department UserDepartment
        {
            get
            {
                return DeviceUser == null ? null : DeviceUser.UDepartment;
            }
        }
        [DisplayName("Hardver felhasználója")]
        public User DeviceUser 
        {
            get
            {
                try
                {
                    if (uId != 0)
                    {
                        return DBManager.GetUserById(int.Parse(uId.ToString()));
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                if (value != null && value is User usr && usr.UId != -1)
                {
                    uId = usr.UId;
                }
                else if (value == null)
                {
                    uId = 0;
                }
                else
                {
                    throw new ArgumentException("Csak rögzítet felhasználó, vagy null érték adható meg!");
                }
            }
        }
        internal int UId
        {
            get => uId; 
            set
            {
                if (value >= 0)
                {
                    uId = value;
                }
                else
                {
                    throw new ArgumentException("A felhasználó azonosítója - annak megadása esetén - csak nem negatív egész szám lehet!");
                }
            }
        }
        [DisplayName("Felhasználási hely")]
        public string Place
        {
            get => place; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    place = null;
                }
                else if (value.Trim().Length <= 50)
                {
                    place = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A hardver felhasználási helye maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Sorozatszám")]
        public string SerialNumber
        {
            get => serialNumber; 
            private set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    serialNumber = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A hardver sorozatszámának megadása kötelező, és maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Garancia évek száma")]
        public byte WarrantyYears
        {
            get => warrantyYears; 
            set
            {
                if (value >= 0 && value <= 255)
                {
                    warrantyYears = value;
                }
                else
                {
                    throw new ArgumentException("A garanciális évek száma 0 és 255 közötti értéket vehet fel!");
                }
            }
        }
        [DisplayName("Hardver kategóriája")]
        public string Category
        {
            get => category; 
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    category = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A hardver kategóriájának megnevezése maximum 50 karakter hosszú lehet!");
                }
            }
        }
        public HardwareType HardwareType
        {
            get => hardwareType;
            private set
            {
                if (Enum.IsDefined(typeof(HardwareType), value))
                {
                    hardwareType = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott értéket adhat meg a hardver típusaként!");
                }
            }
        }
        [DisplayName("Hordozható-e")]
        public bool Portable { get => portable; private set => portable = value; }
        [DisplayName("Virtuális-e")]
        public bool IsVirtual { get => isVirtual; private set => isVirtual = value; }
        #endregion
        #region Constructors
        public Hardware(User deviceUser, string place, string serialNumber, byte warrantyYears, string category, HardwareType hardwareType, bool portable, bool isVirtual, string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1) : base(aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription, aId)
        {
            DeviceUser = deviceUser;
            Place = place;
            SerialNumber = serialNumber;
            WarrantyYears = warrantyYears;
            Category = category;
            HardwareType = hardwareType;
            Portable = portable;
            IsVirtual = isVirtual;
        }
        public Hardware(int uId, string place, string serialNumber, byte warrantyYears, string category, HardwareType hardwareType, bool portable, bool isVirtual, string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1) : base(aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription, aId)
        {
            UId = uId;
            Place = place;
            SerialNumber = serialNumber;
            WarrantyYears = warrantyYears;
            Category = category;
            HardwareType = hardwareType;
            Portable = portable;
            IsVirtual = isVirtual;
        }

        #endregion
        #region Methods and Functions
        /// <summary>
        /// Hardvereket tartalmazó lista CSV fájlba történő exportálására szolgáló statikus metódus
        /// </summary>
        /// <param name="list">Az exportálandó hardverek listája</param>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        public static void ExportToCsv(List<Hardware> list, string path)
        {
            try
            {
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Hardver neve;Beszerzés dátuma;Hardver tulajdonosa;Hardver kategóriája;Hardver típusa;Státusz;Dokumentum hivatkozások;Selejtezés dátuma;Egyéb megjegyzés;Felhasználó szervezeti egysége;Hardver felhasználója;Felhasználási hely;Sorozatszám;Garanciaévek száma;Hordozható-e;Virtuális-e";
                file.WriteLine(header);
                file.Flush();
                foreach (Hardware item in list)
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
        /// A hardver adatainak CSV struktúra szerinti kinyerésére szolgáló funkció
        /// </summary>
        /// <returns>A hardver adatainak pontosvesszővel elválasztott szövegként való visszatérése</returns>
        public virtual string ToCsv()
        {
            return $"{AId};{AName.Replace(';', '|')};{PurchaseDate.ToString("yyyy.MM.dd.")};" +
                $"{(Owner != null ? Owner.ToString().Replace(';', '|') : "")};" +
                $"{(!String.IsNullOrEmpty(Category) ? Category.Replace(';', '|') : "")};" +
                $"{(Attribute.GetCustomAttribute(this.HardwareType.GetType().GetField(this.HardwareType.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};" +
                $"{(Attribute.GetCustomAttribute(this.Status.GetType().GetField(this.Status.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};" +
                $"{(!String.IsNullOrEmpty(DocLink) ? DocLink.Replace(';', '|') : "")};" +
                $"{(ScrappingDate is DateTime scd ? scd.ToString("yyyy.MM.dd.") : "")};" +
                $"{(!String.IsNullOrEmpty(OtherDescription) ? OtherDescription.Replace(';', '|') : "")};" +
                $"{(UserDepartment != null ? UserDepartment.ToString().Replace(';', '|') : "")};" +
                $"{(UId != 0 ? DeviceUser.ToString().Replace(';', '|') : "")};" +
                $"{(!String.IsNullOrEmpty(Place) ? Place.Replace(';', '|') : "")};" +
                $"{SerialNumber.Replace(';', '|')};" +
                $"{WarrantyYears.ToString()};" +
                $"{(Portable ? "Igen" : "Nem")};{(IsVirtual ? "Igen" : "Nem")}";
        }
        public override string ToString()
        {
            return $"{SerialNumber} - {base.ToString()}";
        }
        #endregion
    }
}
