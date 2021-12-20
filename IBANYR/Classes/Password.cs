using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace IBANYR
{
    public enum PasswordComplexity
    {
        [Description("nincs előírás")]
        nothing,
        [Description("szöveget és számot kell tartalmaznia")]
        string_number,
        [Description("kis- és nagybetűt tartalmaznia kell")]
        low_uppercase,
        [Description("kis- és nagybetűt, valamint számot tartalmaznia kell")]
        low_uppercase_number,
        [Description("kis-, nagybetűt, számot és egy különleges karaktert tartalmaznia kell")]
        low_uppercase_number_specialchar,
    }

    public static class Password
    {
        #region Private fields
        readonly static int saltSize = 4;
        readonly static char[] chars = "$%#@!*+?&<>,.;:'§=|-aábcdeéfghiíjklmnoóöőpqrstuúüűvwxyz0123456789AÁBCDEÉFGHIÍJKLMNOÓÖŐPQRSTUÚÜŰVWXYZ".ToCharArray();
        static string privateKey = "titkosKulcs";
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Jelszó titkosító
        /// </summary>
        /// <param name="originalPw">Titkosítatlan jelszó</param>
        /// <returns>32 karakter hosszúságú hash</returns>
        public static string PwEncryptor(string originalPw)
        {
            // Convert the string original value to a byte array
            var originalData = Encoding.UTF8.GetBytes(originalPw);

            // Create a 4-byte salt using a cryptographically secure random number generator
            var saltData = new byte[saltSize];
            var rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltData);

            // Append the salt to the end of the original
            var saltedPasswordData = new byte[originalData.Length + saltData.Length];
            Array.Copy(originalData, 0, saltedPasswordData, 0, originalData.Length);
            Array.Copy(saltData, 0, saltedPasswordData, originalData.Length, saltData.Length);

            var sha = new SHA1Managed();
            var hashData = sha.ComputeHash(saltedPasswordData);

            var hashSaltData = new byte[hashData.Length + saltData.Length];
            Array.Copy(hashData, 0, hashSaltData, 0, hashData.Length);
            Array.Copy(saltData, 0, hashSaltData, hashData.Length, saltData.Length);
            return Convert.ToBase64String(hashSaltData);
        }
        /// <summary>
        /// Megadott jelszó - hash összehasonlító
        /// </summary>
        /// <param name="password">Összehasonlítandó jelszó</param>
        /// <param name="hash">Tárolt hash</param>
        /// <returns>egyezés esetén true, egyébként false</returns>
        public static bool StringToHashComparer(string password, string hash)
        {
            var hashData = Convert.FromBase64String(hash);
            // First, pluck the four-byte salt off of the end of the hash
            var saltData = new byte[saltSize];
            Array.Copy(hashData, hashData.Length - saltData.Length, saltData, 0, saltData.Length);

            var passwordData = Encoding.UTF8.GetBytes(password);

            // Append the salt to the end of the original
            var saltedPasswordData = new byte[passwordData.Length + saltData.Length];
            Array.Copy(passwordData, 0, saltedPasswordData, 0, passwordData.Length);
            Array.Copy(saltData, 0, saltedPasswordData, passwordData.Length, saltData.Length);

            // Create a new SHA-1 instance and compute the hash 
            var sha = new SHA1Managed();
            var newHashData = sha.ComputeHash(saltedPasswordData);

            // Add salt bytes onto end of the original hash for storage
            var newHashSaltData = new byte[newHashData.Length + saltData.Length];
            Array.Copy(newHashData, 0, newHashSaltData, 0, newHashData.Length);
            Array.Copy(saltData, 0, newHashSaltData, newHashData.Length, saltData.Length);
            // Compare and return
            return (Convert.ToBase64String(hashData).Equals(Convert.ToBase64String(newHashSaltData)));
        }
        /// <summary>
        /// Jelszó generátor
        /// </summary>
        /// <param name="pwLength">A generálandó jelszó hossza, mely alapértelmezetten 8</param>
        /// <returns>A kért karakterszámú generált jelszó</returns>
        public static string PasswordGenerator(PasswordComplexity complexity, byte pwLength)
        {
            string generatedPw;
            Random rnd = new Random();
            do
            {
                generatedPw = String.Empty;
                for (int i = 0; i < pwLength; i++)
                {
                    generatedPw += chars[rnd.Next(0, chars.Length)];
                }
            } while (!PwComplexityChecker(complexity, pwLength, generatedPw));

            return generatedPw;
        }
        /// <summary>
        /// Jelszó komplexitás ellenőrző funkció
        /// </summary>
        /// <param name="complexity">A jelszó bonyolultsága</param>
        /// <param name="pwLength">A jelszó előírt hossza</param>
        /// <param name="password">Az ellenőrizendő jelszó</param>
        /// <returns>Ha megfelelt a jelszószabályoknak akkor true, egyébként false</returns>
        public static bool PwComplexityChecker(PasswordComplexity complexity, byte pwLength, string password)
        {
            string regexRule = String.Empty;
            bool isSpecialChar = true;
            switch (complexity)
            {
                case PasswordComplexity.nothing:
                    regexRule = ".{" + pwLength + ",}";
                    break;
                case PasswordComplexity.string_number:
                    regexRule = "(?=.*?[A-Za-z])(?=.*?[0-9]).{" + pwLength + ",}";
                    break;
                case PasswordComplexity.low_uppercase:
                    regexRule = "(?=.*?[A-Z])(?=.*?[a-z]).{" + pwLength + ",}";
                    break;
                case PasswordComplexity.low_uppercase_number:
                    regexRule = "(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{" + pwLength + ",}";
                    break;
                case PasswordComplexity.low_uppercase_number_specialchar:
                    int i = 0;
                    while (i < password.Length && Char.IsLetterOrDigit(password[i]))
                    {
                        i++;
                    }
                    isSpecialChar = i < password.Length;
                    regexRule = "(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{" + pwLength + ",}";
                    break;
            }
            Regex rg = new Regex(regexRule);
            return rg.IsMatch(password) && isSpecialChar;
        }
        /// <summary>
        /// Titkosító
        /// </summary>
        /// <param name="toEncrypt">Titkosítandó karakterlánc</param>
        /// <returns>Titkosított karakterlánc</returns>
        public static string Encrypt(string toEncrypt)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(privateKey));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(toEncrypt);
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }

        }
        /// <summary>
        /// Kititkosító
        /// </summary>
        /// <param name="hash">Titkosított karakterlánc</param>
        /// <returns>Kititkosított kakaterlánc</returns>
        public static string Decrypt(string hash)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(privateKey));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(hash);
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }

        #endregion
    }
}
