using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace IBANYR
{
    public enum SystemLifeCycle
    {
        [Description("Bevezetés")]
        implementation,
        [Description("Használat/üzemeltetés")]
        operation,
        [Description("Kivonás/archiválás")]
        elimination
    }
    public enum StoredDataType
    {
        [Description("Személyes adat")]
        personalData,
        [Description("Különleges személyes adat")]
        specialPersonalData,
        [Description("Egyéb adat")]
        otherData
    }
    public class ItSystem : IToCsv
    {
        #region Private fields
        int sId;
        string sName, sShortName, version;
        int licenseNumber;
        SystemLifeCycle lifeCycle;
        byte confidentiality, integrity, availability;
        StoredDataType dataType;
        string sDescription;
        int innerDataOwner, adminUser;
        string interfaceDesc;
        int providerPartner, operatorPartner, providerContact, operatorContact;
        short rpo, rto, crt, ert;
        string criticalPeriod;
        List<ItSystemPermission> itSystemPermissions;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int SId
        {
            get => sId;
            private set
            {
                if (sId == -1)
                {
                    sId = value;
                }
                else
                {
                    throw new InvalidOperationException("A rendszerazonosító módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Rendszer megnevezése")]
        public string SName
        {
            get => sName; 
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 150)
                {
                    sName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A rendszernév megadása kötelező, és minimum 3, maximum 150 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Rendszer rövid neve")]
        public string SShortName
        {
            get => sShortName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    sShortName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A rendszer rövid neve nem lehet üres és maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Verziószám")]
        public string Version
        {
            get => version; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    version = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 20)
                {
                    version = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A verziószám megadása esetén az maximum 20 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Licesz száma")]
        public int LicenseNumber
        {
            get => licenseNumber;
            set
            {
                if (value >= 0)
                {
                    licenseNumber = value;
                }
                else
                {
                    throw new ArgumentException("A licenszszám nem lehet negatív!");
                }
            }
        }
        [DisplayName("Védelmi életciklus")]
        public SystemLifeCycle LifeCycle
        {
            get => lifeCycle;
            set
            {
                if (Enum.IsDefined(typeof(SystemLifeCycle), value))
                {
                    lifeCycle = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott értéket adhat meg a rendszer életciklusának!");
                }
            }
        }
        [DisplayName("Bizalmaság")]
        public byte Confidentiality
        {
            get => confidentiality;
            set
            {
                if (value > 0 && value <= 5)
                {
                    confidentiality = value;
                }
                else
                {
                    throw new ArgumentException("A bizalmasság értéke 1 és 5 közötti egész szám lehet!");
                }
            }
        }
        [DisplayName("Sértetlenség")]
        public byte Integrity
        {
            get => integrity;
            set
            {
                if (value > 0 && value <= 5)
                {
                    integrity = value;
                }
                else
                {
                    throw new ArgumentException("A sértetlenség értéke 1 és 5 közötti egész szám lehet!");
                }
            }
        }
        [DisplayName("Rendelkezésre állás")]
        public byte Availability
        {
            get => availability;
            set
            {
                if (value > 0 && value <= 5)
                {
                    availability = value;
                }
                else
                {
                    throw new ArgumentException("A rendelkezésre állás értéke 1 és 5 közötti egész szám lehet!");
                }
            }
        }
        [DisplayName("Biztonsági osztály")]
        public byte SecurityClass { get => new List<byte>(){ confidentiality, integrity, availability }.Max(); }
        [DisplayName("Tárolt adatok típusa")]
        public StoredDataType DataType
        {
            get => dataType;
            set
            {
                if (Enum.IsDefined(typeof(StoredDataType), value))
                {
                    dataType = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott értéket adhat meg az adattípus értékének!");
                }
            }
        }
        [DisplayName("Rendszer leírása (funkciók, tárolt adatok köre, nagyságrendje, szabadon elérhető funkciók)")]
        public string SDescription
        {
            get => sDescription;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 1073741823)
                {
                    sDescription = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A rendszer leírása nem lehet üres, és a karakterek száma nem haladhatja meg a 1.073.741.823 karaktert!");
                }
            }
        }
        internal int InnerDataOwner { get => innerDataOwner; set => innerDataOwner = value; }
        [DisplayName("Adatgazda szervezeti egység")]
        public Department DataOwnerDepartment
        {
            get
            {
                if (innerDataOwner > 0)
                {
                    try
                    {
                        return DBManager.GetDepartmentById(innerDataOwner);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        internal int AdminUser { get => adminUser; set => adminUser = value; }
        [DisplayName("Rendszer más rendszerekkel való kapcsolódásának leírása")]
        public string InterfaceDesc
        {
            get => interfaceDesc; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    interfaceDesc = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 1073741823)
                {
                    interfaceDesc = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A más rendszerekkel való kapcsolódások leírása nem haladhatja meg a 1.073.741.823 karaktert!");
                }
            }
        }
        internal int ProviderPartner { get => providerPartner; set => providerPartner = value; }
        internal int ProviderContact { get => providerContact; set => providerContact = value; }
        internal int OperatorPartner { get => operatorPartner; set => operatorPartner = value; }
        internal int OperatorContact { get => operatorContact; set => operatorContact = value; }
        [DisplayName("RPO")]
        public short Rpo
        {
            get => rpo; 
            set
            {
                if (value >= 0)
                {
                    rpo = value;
                }
                else
                {
                    throw new ArgumentException("A mentési visszaállítási idő értéke csak nem negatív egész szám lehet!");
                }
            }
        }
        [DisplayName("RTO")]
        public short Rto
        {
            get => rto;
            set
            {
                if (value >= 0)
                {
                    rto = value;
                }
                else
                {
                    throw new ArgumentException("A tolerálható kiesési idő értéke csak nem negatív egész szám lehet!");
                }
            }
        }
        [DisplayName("CRT")]
        public short Crt
        {
            get => crt; 
            set
            {
                if (value >= 0 && value >= rto)
                {
                    crt = value;
                }
                else
                {
                    throw new ArgumentException("A kritikus helyreállítási idő értéke csak nem negatív egész szám lehet, és nem lehet kisebb, mint a tolerálható kiesési idő!");
                }
            }
        }
        [DisplayName("ERT")]
        public short Ert
        {
            get => ert;
            set
            {
                if (value >= 0 && value >= crt)
                {
                    ert = value;
                }
                else
                {
                    throw new ArgumentException("A tényleges helyreállítási idő értéke csak nem negatív egész szám lehet, és nem lehet kisebb, mint a kritikus helyreállítási idő!");
                }
            }
        }
        [DisplayName("Kritikus időszak leírása")]
        public string CriticalPeriod
        {
            get => criticalPeriod; 
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 1073741823)
                {
                    criticalPeriod = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A kritikus időszak leírásának megadása kötelező, és hossza nem haladhatja meg a 1.073.741.823 karaktert!");
                }
            }
        }
        internal List<ItSystemPermission> ItSystemPermissions { get => itSystemPermissions.ToList(); private set => itSystemPermissions = value; }
        #endregion
        #region Constructors
        public ItSystem(string sName, string sShortName, string version, int licenseNumber, SystemLifeCycle lifeCycle, byte confidentiality, byte integrity, byte availability, StoredDataType dataType, string sDescription, int innerDataOwner, int adminUser, string interfaceDesc, int providerPartner, int providerContact, int operatorPartner, int operatorContact, short rpo, short rto, short crt, short ert, string criticalPeriod, int sId = -1)
        {
            if (sId != -1)
            {
                this.sId = sId;
            }
            SName = sName;
            SShortName = sShortName;
            Version = version;
            LicenseNumber = licenseNumber;
            LifeCycle = lifeCycle;
            Confidentiality = confidentiality;
            Integrity = integrity;
            Availability = availability;
            DataType = dataType;
            SDescription = sDescription;
            InnerDataOwner = innerDataOwner;
            AdminUser = adminUser;
            InterfaceDesc = interfaceDesc;
            ProviderPartner = providerPartner;
            ProviderContact = providerContact;
            OperatorPartner = operatorPartner;
            OperatorContact = operatorContact;
            Rpo = rpo;
            Rto = rto;
            Crt = crt;
            Ert = ert;
            CriticalPeriod = criticalPeriod;
            itSystemPermissions = new List<ItSystemPermission>();
        }

        #endregion
        #region Methods and Functions
        /// <summary>
        /// A rendszer felhasználóinak listáját lekérdező funkció
        /// </summary>
        /// <returns>A rendszer felhasználóinak listája</returns>
        public List<User> GetItSystemUsers()
        {
            try
            {
                List<User> users = new List<User>();
                foreach (ItSystemPermission permissionItem in ItSystemPermissions)
                {
                    foreach (User userItem in permissionItem.GetItSystemPermissionUsers())
                    {
                        if (!users.Contains(userItem))
                        {
                            users.Add(userItem);
                        }
                    }
                }
                return users;
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Rendszer jogosultságlistájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="sysPermission">A listához hozzáadandó jogosultsági csoport <see cref="ItSystemPermission"/> példánya!</param>
        public void AddPermission(ItSystemPermission sysPermission)
        {
            itSystemPermissions.Add(sysPermission);
        }
        /// <summary>
        /// Rendszereket tartalmazó lista CSV fájlba történő exportálására szolgáló statikus metódus
        /// </summary>
        /// <param name="list">Az exportálandó rendszerek listája</param>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        public static void ExportToCsv(List<ItSystem> list, string path)
        {
            try
            {
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Rendszer megnevezése;Rendszer rövid neve;Verziószám;Licenszszám;Védelmi életciklus;Bizalmasság;Sértetlenség;Rendelkezésre állás;Biztonsági osztály;Rendszer leírása;Adatgazda szervezeti egység;Más rendszerekkel való kapcsolódás leírása;RPO;RTO;CRT;ERT;Kritikus időszak leírása";
                file.WriteLine(header);
                file.Flush();
                foreach (ItSystem item in list)
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
        /// A rendszer adatainak CSV struktúra szerinti kinyerésére szolgáló funkció
        /// </summary>
        /// <returns>A rendszer adatainak pontosvesszővel elválasztott szövegként való visszatérése</returns>
        public virtual string ToCsv()
        {
            return $"{SId};{SName.Replace(';', '|')};{SShortName.Replace(';', '|')};" +
                $"{(!String.IsNullOrEmpty(Version) ? Version.Replace(';', '|') : "")};{LicenseNumber};" +
                $"{(Attribute.GetCustomAttribute(this.LifeCycle.GetType().GetField(this.LifeCycle.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};{Confidentiality};{Integrity};{Availability};{SecurityClass};" +
                $"{SDescription.Replace(';', '|')};{(InnerDataOwner > 0 ? DataOwnerDepartment.ToString().Replace(';', '|') : "")};" +
                $"{(!String.IsNullOrEmpty(InterfaceDesc) ? InterfaceDesc.Replace(';', '|') : "")};" +
                $"{Rpo};{Rto};{Crt};{Ert};{CriticalPeriod.Replace(';', '|')}";
        }
        public override bool Equals(object obj)
        {
            return obj is ItSystem itSys && itSys.SId == this.SId;
        }
        public override string ToString()
        {
            return SShortName;
        }
        #endregion
    }
}
