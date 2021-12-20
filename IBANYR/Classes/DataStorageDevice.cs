using System;

namespace IBANYR
{
    class DataStorageDevice : Hardware
    {
        #region Private fields
        int storageCapacity;
        bool encrypted;
        string recoveryKey;
        #endregion
        #region Public properties
        public int StorageCapacity
        {
            get => storageCapacity; 
            set
            {
                if (value >= 0)
                {
                    storageCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Az adattároló kapacitása csak nem negatív egész szám lehet!");
                }
            }
        }
        public bool Encrypted { get => encrypted; set => encrypted = value; }
        public string RecoveryKey
        {
            get => recoveryKey; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (!Encrypted)
                    {
                        recoveryKey = null;
                    }
                    else
                    {
                        throw new ArgumentException("Titkosított meghajtó esetén a helyreállítási kulcsot meg kell adni!");
                    }
                }
                else if (value.Trim().Length <= 150)
                {
                    recoveryKey = Password.Encrypt(value.Trim());
                }
                else
                {
                    throw new ArgumentException("A helyreállítási kulcs maximum 150 karakter hosszú lehet!");
                }
            }
        }
        #endregion
        #region Constructors
        public DataStorageDevice(int storageCapacity, bool encrypted, string recoveryKey, int uId, string place, string serialNumber, byte warrantyYears, string category, HardwareType hardwareType, bool portable, bool isVirtual, string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1) : base(uId, place, serialNumber, warrantyYears, category, hardwareType, portable, isVirtual, aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription, aId)
        {
            StorageCapacity = storageCapacity;
            Encrypted = encrypted;
            RecoveryKey = recoveryKey;
        }
        #endregion
    }
}
