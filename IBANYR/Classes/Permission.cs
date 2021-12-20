using System;

namespace IBANYR
{
    public class Permission
    {
        #region Private fields
        int pId;
        string pName, pDescription;
        #endregion
        #region Public properties
        public int PId
        {
            get => pId;
            private set
            {
                if (pId == -1)
                {
                    pId = value;
                }
                else
                {
                    throw new InvalidOperationException("A jogosultságazonosító módosítása nem lehetséges!");
                }
            }
        }
        public string PName
        {
            get => pName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 25)
                {
                    pName = value;
                }
                else
                {
                    throw new ArgumentException("A jogosultságnév megadása kötelező, valamint minimum 3 és maximum 25 karakter hosszú lehet!");
                }
            }
        }
        public string PDescription
        {
            get => pDescription;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 300)
                {
                    pDescription = value;
                }
                else
                {
                    throw new ArgumentException("A leírás nem lehet üres és maximum 300 karakter hosszú lehet!");
                }
            }
        }
        #endregion
        #region Constructors
        public Permission(string pName, string pDescription, int pId = -1)
        {
            if (pId != -1)
            {
                this.pId = pId;
            }
            PName = pName;
            PDescription = pDescription;
        }
        #endregion
        #region Methods and Functions
        public override bool Equals(object obj)
        {
            return obj is String name && name == this.PName || obj is Permission perm && base.Equals(perm);
        }
        public override string ToString()
        {
            return PName;
        }
        #endregion
    }
}
