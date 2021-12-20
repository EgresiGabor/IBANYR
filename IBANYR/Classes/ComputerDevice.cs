using System;

namespace IBANYR
{
    public class ComputerDevice : NetActiveDevice
    {
        #region Private fields
        string processor;
        int ram;
        int storageCapacity;
        string otherComponent;
        #endregion
        #region Public properties
        public string Processor { get => processor; set => processor = value; }
        public int Ram
        {
            get => ram; 
            set
            {
                if (value >= 0)
                {
                    ram = value;
                }
                else
                {
                    throw new ArgumentException("A RAM mérete csak nem negatív egész szám lehet!");
                }
            }
        }
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
        public string OtherComponent { get => otherComponent; set => otherComponent = value; }
        #endregion
        #region Constructors
        public ComputerDevice(string processor, int ram, int storageCapacity, string otherComponent, string hostName, int uId, string place, string serialNumber, byte warrantyYears, string category, HardwareType hardwareType, bool portable, bool isVirtual, string aName, DateTime purchaseDate, Department owner, AssetState status, string docLink, DateTime? scrappingDate, string otherDescription, int aId = -1) : base(hostName, uId, place, serialNumber, warrantyYears, category, hardwareType, portable, isVirtual, aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription, aId)
        {
            Processor = processor;
            Ram = ram;
            StorageCapacity = storageCapacity;
            OtherComponent = otherComponent;
        }
        #endregion
    }
}
