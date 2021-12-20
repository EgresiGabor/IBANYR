using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IBANYR
{
    class Partner
    {
        #region Private fields
        int partId;
        string partName, taxNumber;
        List<Contact> contacts;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int PartId
        {
            get => partId;
            private set
            {
                if (partId == -1)
                {
                    partId = value;
                }
                else
                {
                    throw new InvalidOperationException("A partnerazonosító módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Szervezet megnevezése")]
        public string PartName
        {
            get => partName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 150)
                {
                    partName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A partner megnevezése nem lehet üres, valamint minimum 3 és maximum 150 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Szervezet adószáma")]
        public string TaxNumber
        {
            get => taxNumber;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length == 8)
                {
                    taxNumber = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Az adószám megadása kötelező, valamint pontosan 8 karakter hosszúnak kell lennie!");
                }
            }
        }

        internal List<Contact> Contacts { get => contacts.ToList(); private set => contacts = value; }
        #endregion
        #region Constructors
        public Partner(string partName, string taxNumber, int partId = -1)
        {
            if (partId != -1)
            {
                this.partId = partId;
            }
            PartName = partName;
            TaxNumber = taxNumber;
            Contacts = new List<Contact>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Kapcsolattartók listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="newContact">A listához hozzáadandó kapcsolattartó <see cref="Contact"/> példánya!</param>
        public void AddContact(Contact newContact)
        {
            this.contacts.Add(newContact);
        }
        public override bool Equals(object obj)
        {
            return obj is Partner partner && partner.PartId == this.PartId;
        }
        public override string ToString()
        {
            return $"{PartName} ({TaxNumber})";
        }
        #endregion
    }
}
