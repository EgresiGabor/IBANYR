using System;
using System.Collections.Generic;
using System.Linq;

namespace IBANYR
{
    public class ItSystemPermission
    {
        #region Private fields
        int sysPId, sId, superiorSysPId;
        string sysPName, sysPDescription;
        #endregion
        #region Public properties
        public int SysPId
        {
            get => sysPId;
            private set
            {
                if (sysPId == -1)
                {
                    sysPId = value;
                }
                else
                {
                    throw new InvalidOperationException("A rendszerhez tartozó jogosultság azonosítójának módosítása nem lehetséges!");
                }
            }
        }
        public string SysPName
        {
            get => sysPName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                {
                    sysPName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A rendszerhez tartozó jogosultság megnevezése nem lehet üres, és maximum 50 karakter hosszú lehet!");
                }
            }
        }
        public string SysPDescription
        {
            get => sysPDescription; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    sysPDescription = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 4000)
                {
                    sysPDescription = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A rendszerjogosultság leírása nem haladhatja meg a 4000 karaktert!");
                }
            }
        }
        public int SId
        {
            get => sId;
            private set
            {
                if (value > 0)
                {
                    sId = value;
                }
                else
                {
                    throw new InvalidOperationException("Csak az adatbázisban szereplő rendszerhez lehetséges jogosultság rögzítése!");
                }
            }
        }
        public int SuperiorSysPId
        {
            get => superiorSysPId; 
            set
            {
                if (value >= 0)
                {
                    superiorSysPId = value;
                }
                else
                {
                    throw new InvalidOperationException("Felettes jog megadása esetén, csak a már létező jogosultságok közül adható meg egy!");
                }
            }
        }
        #endregion
        #region Constructors
        public ItSystemPermission(string sysPName, string sysPDescription, int superiorSysPId, int sId, int sysPId = -1)
        {
            if (sysPId != -1)
            {
                this.sysPId = sysPId;
            }
            SId = sId;
            SysPName = sysPName;
            SysPDescription = sysPDescription;
            SuperiorSysPId = superiorSysPId;
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Adott jogosultságával rendelkező felhasználók listáját lekérdező funkció
        /// </summary>
        /// <returns>A rendszerreljoggal rendelkező felhasználók listája</returns>
        public List<User> GetItSystemPermissionUsers()
        {
            try
            {
                return DBManager.GetUsersList().Where(x => x.ItSystemPermissions.Contains(this)).ToList();
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

        public override bool Equals(object obj)
        {
            return obj is ItSystemPermission sysPer && sysPer.SysPId == this.SysPId;
        }
        public override string ToString()
        {
            return SysPName;
        }
        #endregion
    }
}
