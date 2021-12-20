using System;
using System.Collections.Generic;
using System.Linq;

namespace IBANYR
{
    public class Department
    {
        #region Private fields
        int dId, managerId, superiorDId;
        string dName, dShortName;
        #endregion
        #region Public properties
        public int DId
        {
            get => dId;
            private set
            {
                if (dId == -1)
                {
                    dId = value;
                }
                else
                {
                    throw new InvalidOperationException("A szervezeti egység azonosítójának módosítása nem lehetséges!");
                }
            }
        }
        public string DName
        {
            get => dName;
            set
            {
                if (value.Trim().Length >= 3 && value.Trim().Length <= 150)
                {
                    dName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A szervezeti egység neve minimum 3, maximum 150 karakter hosszú lehet!");
                }
            }
        }
        public string DShortName
        {
            get => dShortName;
            set
            {
                if (value.Trim().Length >= 2 && value.Trim().Length <= 20)
                {
                    dShortName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A szervezeti egység rövidneve minimum 2, maximum 20 karakter hosszú lehet!");
                }
            }
        }
        internal int ManagerId { get => managerId; set => managerId = value; }
        public int SuperiorDId { get => superiorDId; set => superiorDId = value; }
        #endregion
        #region Constructors
        public Department(string dName, string dShortName, int managerId = 0, int superiorDId = 0, int dId = -1)
        {
            if (dId != -1)
            {
                this.dId = dId;
            }
            DName = dName;
            DShortName = dShortName;
            ManagerId = managerId;
            SuperiorDId = superiorDId;
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Funkció, mely az egyes szervezeti egységeket adja vissza a hierachiájuknak megfelelő rendezettségű listában
        /// </summary>
        /// <param name="deptList">A rendezendő szervezeti egységek listája</param>
        /// <param name="index">A paraméter segítségével megadható, hogy melyik azonosítószámú szervezeti egység alárendelt osztályait adja vissza. Az alapértelmezett érték 0, ekkor a szervezetek szintjétől indul a rendezés</param>
        /// <returns>A paraméterként megadott lista elemei hierarchikus sorrendben térnek vissza.</returns>
        public static List<Department> OrderByHierarchy(List<Department> deptList, int index = 0)
        {
            List<Department> resultList = new List<Department>();
            for (int i = 0; i < deptList.Where(x => x.SuperiorDId == index).ToList().Count; i++)
            {
                resultList.Add(deptList.Where(x => x.SuperiorDId == index).ToList()[i]);
                foreach (Department subItem in OrderByHierarchy(deptList, deptList.Where(x => x.SuperiorDId == index).ToList()[i].DId))
                {
                    resultList.Add(subItem);
                }
            }
            return resultList;
        }
        public override bool Equals(object obj)
        {
            return obj is Department dept && dept.DId == this.DId;
        }
        public override string ToString()
        {
            return $"{DName} ({DShortName})";
        }
        #endregion
    }
}
