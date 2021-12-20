using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IBANYR
{
    public class PermissionGroup
    {
        #region Private fields
        int gId;
        string gName, gDescription;
        readonly List<Permission> permissions;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int GId
        {
            get => gId;
            private set
            {
                if (gId == -1)
                {
                    gId = value;
                }
                else
                {
                    throw new InvalidOperationException("A csoportazonosító módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Csoportnév")]
        public string GName
        {
            get => gName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 25)
                {
                    gName = value;
                }
                else
                {
                    throw new ArgumentException("A csoportnév megadása kötelező, valamint minimum 3 és maximum 25 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Csoport leírása")]
        public string GDescription
        {
            get => gDescription;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 4000)
                {
                    gDescription = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A leírás nem lehet üres, és hossza nem haladhatja meg a 4000 karaktert!");
                }
            }
        }
        internal List<Permission> Permissions { get => permissions.ToList(); }
        #endregion
        #region Constructors
        public PermissionGroup(string gName, string gDescription, int gId = -1)
        {
            if (gId != -1)
            {
                this.gId = gId;
            }
            GName = gName;
            GDescription = gDescription;
            this.permissions = new List<Permission>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Jogok listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="permisson">A listához hozzáadandó jog <see cref="Permission"/> példánya!</param>
        public void AddPermission(Permission permission)
        {
            permissions.Add(permission);
        }
        public override string ToString()
        {
            return GName;
        }
        #endregion
    }
}
