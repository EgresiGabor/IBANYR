using System;
using System.Text.RegularExpressions;

namespace IBANYR
{
    public class AppConfiguration
    {
        #region Private fields
        short pwValidityPeriod;
        byte pwLength;
        PasswordComplexity pwComplexity;
        byte failedLoginNum;
        byte permanentLockingPeriod;
        short retentionDays;
        bool enableEmail;
        string smtpServer;
        int port;
        bool enableSSL;
        string emailAddress;
        string smtpUserName;
        string smtpPassword;
        #endregion
        #region Public properties
        public short PwValidityPeriod
        {
            get => pwValidityPeriod;
            set
            {
                if (value >= 0 && value <= 365)
                {
                    pwValidityPeriod = value;
                }
                else
                {
                    throw new Exception("A jelszó érvényességi ideje 0 és 365 közötti értéket vehet fel!");
                }
            }
        }
        public byte PwLength
        {
            get => pwLength;
            set
            {
                if (value >= 5 && value <= 50)
                {
                    pwLength = value;
                }
                else
                {
                    throw new Exception("A jelszó kötelező hosszúsága minimum 5 és maximum 50 közötti értéket vehet fel!");
                }
            }
        }
        public PasswordComplexity PwComplexity
        {
            get => pwComplexity;
            set
            {
                if (Enum.IsDefined(typeof(PasswordComplexity), value))
                {
                    pwComplexity = value;
                }
                else
                {
                    throw new ArgumentException("A jelszavak bonyolultsági előírása csak meghatározott értéket vehet fel!");
                }
            }
        }
        public byte FailedLoginNum
        {
            get => failedLoginNum;
            set
            {
                if (value >= 0 && value <= 20)
                {
                    failedLoginNum = value;
                }
                else
                {
                    throw new Exception("A sikertelen belépési próbálkozások száma 0 és 20 közötti értéket vehet fel!");
                }
            }
        }
        public byte PermanentLockingPeriod
        {
            get => permanentLockingPeriod;
            set
            {
                if (value >= 0 && value <= 180)
                {
                    permanentLockingPeriod = value;
                }
                else
                {
                    throw new Exception("Az ideiglenes zárolás ideje 0 és 180 közötti értéket vehet fel!");
                }
            }
        }
        public short RetentionDays
        {
            get => retentionDays;
            set
            {
                if (value >= 0 && value <= 7305)
                {
                    retentionDays = value;
                }
                else
                {
                    throw new Exception("A megőrzési idő maximum 20 év lehet, azaz napokban 0 és 7305 közötti értéket vehet fel!");
                }
            }
        }
        public bool EnableEmail { get => enableEmail; set => enableEmail = value; }
        public string SmtpServer
        {
            get => smtpServer;
            set
            {
                if (EnableEmail)
                {
                    if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 50)
                    {
                        smtpServer = value.Trim();
                    }
                    else
                    {
                        throw new ArgumentException("Email küldés engedélyezése esetén az SMTP szerver címét meg kell adni, ami nem lehet hosszabb mint 50 karakter!");
                    }
                }
                else
                {
                    smtpServer = value;
                }
            }
        }
        public int Port
        {
            get => port;
            set
            {
                if (value >= 0 && value <= 65535)
                {
                    port = value;
                }
                else
                {
                    throw new ArgumentException("Az SMTP portszáma 0 és 65535 közötti értéket vehet fel!");
                }
            }
        }
        public bool EnableSSL { get => enableSSL; set => enableSSL = value; }
        public string EmailAddress
        {
            get => emailAddress; 
            set
            {
                string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (String.IsNullOrEmpty(value))
                {
                    emailAddress = null;
                }
                else if (value.Trim().Length <= 50 && Regex.IsMatch(value.Trim(), pattern))
                {
                    emailAddress = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Az email cím maximum 50 karakter hosszú lehet, és megfelelő formátumúnak kell lennie (pl.: no-reply@ibir.hu)!");
                }
            }
        }
        public string SmtpUserName
        {
            get
            {
                if (!String.IsNullOrEmpty(smtpUserName))
                {
                    return smtpUserName;
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
                    if (!EnableEmail)
                    {
                        smtpUserName = null;
                    }
                    else
                    {
                        throw new ArgumentException("Email küldés engedélyezése esetén az SMTP felhasználói azonosítót meg kell adni!");
                    }
                }
                else if (value.Trim().Length <= 50)
                {
                    smtpUserName = Password.Encrypt(value.Trim());
                }
                else
                {
                    throw new ArgumentException("SMTP felhasználói azonosító maximum 50 karakter hosszú lehet!");
                }
            }
        }
        public string SmtpPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(smtpPassword))
                {
                    return smtpPassword;
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
                    if (!EnableEmail)
                    {
                        smtpPassword = null;
                    }
                    else
                    {
                        throw new ArgumentException("Email küldés engedélyezése esetén az SMTP jelszót meg kell adni!");
                    }
                }
                else if (value.Trim().Length <= 50)
                {
                    smtpPassword = Password.Encrypt(value.Trim());
                }
                else
                {
                    throw new ArgumentException("SMTP jelszó maximum 50 karakter hosszú lehet!");
                }
            }
        }

        #endregion
        #region Constructors
        public AppConfiguration(short pwValidityPeriod, byte pwLength, PasswordComplexity pwComplexity, byte failedLoginNum, byte permanentLockingPeriod, short retentionDays, bool enableEmail = false, string smtpServer = null, int port = 25, bool enableSSL = false, string emailAddress = null, string smtpUserName = null, string smtpPassword = null)
        {
            PwValidityPeriod = pwValidityPeriod;
            PwLength = pwLength;
            PwComplexity = pwComplexity;
            FailedLoginNum = failedLoginNum;
            PermanentLockingPeriod = permanentLockingPeriod;
            RetentionDays = retentionDays;
            EnableEmail = enableEmail;
            SmtpServer = smtpServer;
            Port = port;
            EnableSSL = enableSSL;
            EmailAddress = emailAddress;
            SmtpUserName = smtpUserName;
            SmtpPassword = smtpPassword;
        }
        #endregion
    }
}
