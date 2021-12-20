using System;

namespace IBANYR
{
    class DBException: Exception
    {
        #region Private fields
        string originalMessage;
        #endregion
        #region Public properties
        public string OriginalMessage { get => originalMessage; }
        #endregion
        #region Constructors
        /// <summary>
        /// Adatbázis kivétel kezelő osztálya
        /// </summary>
        /// <param name="message">Szabadszöveges üzenet, melyet a programozó ad meg és továbbdobódik általános kivétel üzenetének.</param>
        /// <param name="originalMessage">Az osztály saját tulajdonsága. Az eredeti hiba által generált üzenet tárolására, előhívására szolgál.</param>
        public DBException(string message, string originalMessage) : base(message)
        {
            this.originalMessage = originalMessage;
        }
        #endregion
    }
}
