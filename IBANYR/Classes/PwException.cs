using System;

namespace IBANYR
{
    class PwException: Exception
    {
        #region Private fields
        string ownMessage;
        int uId;
        #endregion
        #region Public properties
        public string OwnMessage { get => ownMessage; private set => ownMessage = value; }
        public int UId { get => uId; private set => uId = value; }
        #endregion
        #region Constructors
        /// <summary>
        /// Jelszó kivétel kezelő osztálya
        /// </summary>
        /// <param name="ownMessage">Szabadszöveges üzenet, melyet a programozó ad meg.</param>
        public PwException(string ownMessage) : base()
        {
            OwnMessage = ownMessage;
        }
        #endregion
    }
}
