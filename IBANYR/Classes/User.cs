using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text.RegularExpressions;

namespace IBANYR
{
    public class User
    {
        #region Private fields
        int uId;
        string uName, post, email, phone;
        Department uDepartment;
        DateTime regDate;
        DateTime? permanentLocked;
        bool locked;
        DateTime? deleteDate;
        readonly List<PermissionGroup> permissions;
        readonly List<ItSystemPermission> itSystemPermissions;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int UId
        {
            get => uId; 
            private set
            {
                if (uId == -1)
                {
                    uId = value;
                }
                else
                {
                    throw new InvalidOperationException("A felhasználóazonosító módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Felhasználónév")]
        public string UName
        {
            get => uName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 50)
                {
                    uName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A felhasználónév megadása kötelező, valamint minimum 3 és maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Beosztás")]
        public string Post
        {
            get => post;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    post = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    post = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A beosztás maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Email")]
        public string Email
        {
            get => email;
            set
            {
                string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50 && Regex.IsMatch(value.Trim(), pattern))
                {
                    email = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Az email megadása kötelező, maximum 50 karakter hosszú lehet és megfelelő formátumúnak kell lennie (pl.: user@usermail.hu)!");
                }
            }
        }
        [DisplayName("Telefon")]
        public string Phone
        {
            get => phone; 
            set
            {
                string pattern = @"\(?\d{1,2}\)?-? *\d{3}-? *-?\d{3,4}";
                if (String.IsNullOrEmpty(value))
                {
                    phone = value;
                }
                else if (!String.IsNullOrEmpty(value) && Regex.IsMatch(value.Trim(), pattern))
                {
                    phone = value;
                }
                else
                {
                    throw new ArgumentException("A telefonszám formátuma kötött, maximum 9 számjegyből állhat!");
                }
            }
        }
        [DisplayName("Szervezeti egység")]
        public Department UDepartment { get => uDepartment; set => uDepartment = value; }
        [DisplayName("Regisztráció dátuma")]
        public DateTime RegDate
        {
            get => regDate; 
            set
            {
                if (value != null && value >= SqlDateTime.MinValue.Value)
                {
                    regDate = value;
                }
                else
                {
                    throw new ArgumentException("A felhasználó regisztrációjának dátuma nem lehet null érték, valamint nem lehet korábbi dátum, mint 1753.01.01.!");
                }
            }
        }
        [DisplayName("Ideiglenes zárolás dátuma")]
        public DateTime? PermanentLocked
        {
            get => permanentLocked; 
            set
            {
                if ((value != null && value >= SqlDateTime.MinValue.Value) || value == null)
                {
                    permanentLocked = value;
                }
                else
                {
                    throw new ArgumentException("Az idéglenes zárolás dátuma - annak megadása esetén - nem lehet korábbi dátum, mint 1753.01.01.!");
                }
            }
        }
        [DisplayName("Zárolva")]
        public bool Locked { get => locked; set => locked = value; }
        [DisplayName("Törlés dátuma")]
        public DateTime? DeleteDate
        {
            get => deleteDate; 
            set
            {
                if ((value != null && value >= SqlDateTime.MinValue.Value) || value == null)
                {
                    deleteDate = value;
                }
                else
                {
                    throw new ArgumentException("A törlés dátuma - annak megadása esetén - nem lehet korábbi dátum, mint 1753.01.01.!");
                }
            }
        }
        internal List<PermissionGroup> Permissions { get => permissions.ToList(); }
        internal List<ItSystemPermission> ItSystemPermissions { get => itSystemPermissions.ToList(); }
        #endregion
        #region Constructors
        /// <summary>
        /// Felhasználó példány létrehozása
        /// </summary>
        /// <param name="uName">Felhasználó neve minimum 3 és maximum 50 karakter hosszúságú lehet! Megadása kötelező!</param>
        /// <param name="post">Felhasználó beosztása. Lehet üres, de maximum 50 karakter hosszú lehet!</param>
        /// <param name="email">Felhasználó email címe. Megadása kötelező, de nem lehet hosszabb 50 karakternél!</param>
        /// <param name="phone">Felhasználó telefonszáma. Lehet üres, de nem lehet hosszabb 13 karakternél (Formátuma: (99) 000-0000)!</param>
        /// <param name="uDepartment">Felhasználó szervezeti egysége. <see cref="Department"/> osztályú példány, de felvehet null értéket is!</param>
        /// <param name="regDate">Felhasználó regisztrálásának dátuma. <see cref="DateTime"/> típusú érték, ennél fogva nem vehet fel null értéket!</param>
        /// <param name="permanentLocked">Felhasználó ideiglenes zárolásának dátuma dátuma. Null értéket tárolni képes <see cref="DateTime?"/> típusú!</param>
        /// <param name="locked">Felhasználófiók állapotát adja meg. True érték esetén zárolt.</param>
        /// <param name="uId">Felhasználóazonosító, opcionális paraméter.</param>
        /// <returns><see cref="User"/> osztályú példány</returns>
        public User(string uName, string post, string email, string phone, Department uDepartment, DateTime regDate, DateTime? permanentLocked, bool locked, DateTime? deleteDate = null, int uId = -1)
        {
            if (uId != -1)
            {
                this.uId = uId;
            }
            UName = uName;
            Post = post;
            Email = email;
            Phone = phone;
            UDepartment = uDepartment;
            RegDate = regDate;
            PermanentLocked = permanentLocked;
            Locked = locked;
            DeleteDate = deleteDate;
            this.permissions = new List<PermissionGroup>();
            this.itSystemPermissions = new List<ItSystemPermission>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Felhasználó jogosultsági csoport listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="pName">A listához hozzáadandó jogosultsági csoport <see cref="PermissionGroup"/> példánya!</param>
        public void AddPermission(PermissionGroup pName)
        {
            permissions.Add(pName);
        }
        /// <summary>
        /// Felhasználó rendszerjogosultság listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="permission">A listához hozzáadandó rendszerjogosultság <see cref="ItSystemPermission"/> példánya!</param>
        public void AddItSystemPermission(ItSystemPermission permission)
        {
            itSystemPermissions.Add(permission);
        }
        /// <summary>
        /// Felhasználó jogosultsági csoport listájának ürítésére szolgáló metódus
        /// </summary>
        public void ClearPermission()
        {
            permissions.Clear();
        }
        /// <summary>
        /// Felhasználó rendszerjogosultság listájának ürítésére szolgáló metódus
        /// </summary>
        public void ClearItSystemPermission()
        {
            itSystemPermissions.Clear();
        }
        /// <summary>
        /// Funkció mely megadja, hogy a felhasználó rendelkezik-e a kérdéses jogosultsággal
        /// </summary>
        /// <param name="pName">A keresendő jogosultság neve.</param>
        /// <returns>Amennyiben a keresett jogosultság megtalálható a felhasználó valamely jogosultsági csoportjában akkor True a visszatérés.</returns>
        public bool HasPermission(string pName)
        {
            bool contains = false;
            int index = 0;
            while (index < Permissions.Count && !contains)
            {
                foreach (Permission item in Permissions[index].Permissions)
                {
                    if (item.Equals(pName))
                    {
                        contains = true;
                    }
                }
                index++;
            }
            return contains;
        }
        /// <summary>
        /// Funkció, mely megadja, hogy a felhasználó ideiglenesen zárolva van-e a konfiguráció és a felhasználó tulajdonsága alapján
        /// </summary>
        /// <returns>Amennyiben ideiglenesen zárolt a felhasználó, True a visszatérés.</returns>
        public bool IsPermanentLocked()
        {
            try
            {
                AppConfiguration conf = DBManager.GetConfiguration();
                if (conf.FailedLoginNum == 0 || conf.PermanentLockingPeriod == 0 || !PermanentLocked.HasValue)
                {
                    return false;
                }
                else
                {
                    return !(DBManager.GetCurrentTime().CompareTo(PermanentLocked.Value.AddMinutes(conf.PermanentLockingPeriod)) > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// A felhasználó által használt rendszerek listájának lekérdezésére szolgáló funkció
        /// </summary>
        /// <returns>A felhasználó által használt rendszereket tartalmazó lista</returns>
        public List<ItSystem> GetUserItSystems()
        {
            try
            {
                List<ItSystem> userSystems = new List<ItSystem>();
                foreach (ItSystemPermission item in ItSystemPermissions)
                {
                    if (!userSystems.Contains(DBManager.GetItSystemById(item.SId)))
                    {
                        userSystems.Add(DBManager.GetItSystemById(item.SId));
                    }
                }
                return userSystems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A felhasználó beosztottainak lekérdezésére szolgáló funkció
        /// </summary>
        /// <returns>A felhasználó beosztottainak User osztályú listája</returns>
        public List<User> GetSubordinateUsers()
        {
            try
            {
                List<User> subordinates = new List<User>();
                List<Department> managedDepartments = DBManager.GetDepartmentsList().Where(x => x.ManagerId == UId).ToList();
                List<Department> allSubDepartment = new List<Department>();
                foreach (Department item in managedDepartments)
                {
                    foreach (Department subDept in Department.OrderByHierarchy(DBManager.GetDepartmentsList(), item.DId))
                    {
                        if (!allSubDepartment.Contains(subDept))
                        {
                            allSubDepartment.Add(subDept);
                        }
                    }
                    foreach (User userItem in DBManager.GetUsersList().Where(x => x.UDepartment != null && x.UDepartment.Equals(item) && !x.Equals(this)).ToList())
                    {
                        subordinates.Add(userItem);
                    }
                }
                foreach (Department dept in allSubDepartment)
                {
                    foreach (User item in DBManager.GetUsersList().Where(x => x.UDepartment != null && x.UDepartment.Equals(dept) && !x.Equals(this)).ToList())
                    {
                        subordinates.Add(item);
                    }
                }
                return subordinates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Equals(object obj)
        {
            return obj is User user && user.UId == this.UId;
        }
        public override string ToString()
        {
            return UName;
        }
        #endregion
    }
}
