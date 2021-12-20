using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace IBANYR
{
    class Contact
    {
        #region Private fields
        int contId;
        string contName, email, address, phone;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int ContId
        {
            get => contId;
            private set
            {
                if (contId == -1)
                {
                    contId = value;
                }
                else
                {
                    throw new InvalidOperationException("A kapcsolattartó azonosítójának módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Kapcsolattartó neve")]
        public string ContName
        {
            get => contName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length >= 3 && value.Trim().Length <= 50)
                {
                    contName = value;
                }
                else
                {
                    throw new ArgumentException("A kapcsolattartó nevét meg kell adni! A név minimum 3 és maximum 50 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Email cím")]
        public string Email
        {
            get => email;
            set
            {
                string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (String.IsNullOrEmpty(value))
                {
                    email = null;
                }
                else if (value.Trim().Length <= 50 && Regex.IsMatch(value.Trim(), pattern))
                {
                    email = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Az email cím maximum 50 karakter hosszú lehet, és megfelelő formátumúnak kell lennie (pl.: no-reply@ibir.hu)!");
                }
            }
        }
        [DisplayName("Levelezési cím")]
        public string Address
        {
            get => address;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    address = null;
                }
                else if (value.Trim().Length <= 200)
                {
                    address = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A cím maximum 200 karakter hosszú lehet!");
                }
            }
        }
        [DisplayName("Telefonszám")]
        public string Phone
        {
            get => phone; 
            set
            {
                string pattern = @"\(?\d{1,2}\)?-? *\d{3}-? *-?\d{3,4}";
                if (String.IsNullOrEmpty(value))
                {
                    phone = null;
                }
                else if (Regex.IsMatch(value.Trim(), pattern))
                {
                    phone = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A telefonszám formátuma kötött, maximum 9 számjegyből állhat!");
                }
            }
        }
        #endregion
        #region Constructors
        public Contact(string contName, string email, string address, string phone, int contId = -1)
        {
            if (contId != -1)
            {
                this.contId = contId;
            }
            ContName = contName;
            Email = email;
            Address = address;
            Phone = phone;
        }
        #endregion
        #region Methods and Functions
        public override bool Equals(object obj)
        {
            return obj is Contact contact && contact.ContId == this.ContId;
        }
        public override string ToString()
        {
            return ContName;
        }
        #endregion
    }
}
