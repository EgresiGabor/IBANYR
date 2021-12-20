using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IBANYR;

namespace IBANYRUnitTest
{
    [TestClass]
    public class CreateInstanceTest
    {
        [TestMethod]
        public void CreateInstanceTest_AppConfiguration_ReturnInstanceWithValidProperties()
        {
            short pwValidityPeriod = 90;
            byte pwLength = 8;
            PasswordComplexity pwComplexity = PasswordComplexity.low_uppercase_number_specialchar;
            byte failedLoginNum = 3;
            byte permanentLockingPeriod = 10;
            short retentionDays = 365;
            bool enableEmail = true;
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            bool enableSSL = true;
            string emailAddress = "mail@exaple.com";
            string smtpUserName = "userName";
            string smtpPassword = "PassWord";

            AppConfiguration testedInstance = new AppConfiguration(pwValidityPeriod, pwLength, pwComplexity, failedLoginNum, permanentLockingPeriod, retentionDays, enableEmail, smtpServer, port, enableSSL, emailAddress, smtpUserName, smtpPassword);

            Assert.AreEqual(testedInstance.PwValidityPeriod, pwValidityPeriod);
            Assert.AreEqual(testedInstance.PwLength, pwLength);
            Assert.AreEqual(testedInstance.PwComplexity, pwComplexity);
            Assert.AreEqual(testedInstance.FailedLoginNum, failedLoginNum);
            Assert.AreEqual(testedInstance.PermanentLockingPeriod, permanentLockingPeriod);
            Assert.AreEqual(testedInstance.RetentionDays, retentionDays);
            Assert.AreEqual(testedInstance.EnableEmail, enableEmail);
            Assert.AreEqual(testedInstance.SmtpServer, smtpServer);
            Assert.AreEqual(testedInstance.Port, port);
            Assert.AreEqual(testedInstance.EnableSSL, enableSSL);
            Assert.AreEqual(testedInstance.EmailAddress, emailAddress);
            Assert.AreEqual(testedInstance.SmtpUserName, Password.Encrypt(smtpUserName));
            Assert.AreEqual(testedInstance.SmtpPassword, Password.Encrypt(smtpPassword));
        }

        [TestMethod]
        public void CreateInstanceTest_ComputerDevice_ReturnInstanceWithValidProperties()
        {
            string processor = "Core i5 1070";
            int ram = 16000;
            int storageCapacity = 250000;
            string otherComponent = "ASUS PH-GTX1650-O4GD6-P GeForce GTX 1650";
            string hostName = "Home-Pc";
            int uId = 0;
            string place = "168-as iroda";
            string serialNumber = "CG856458-IZ456";
            byte warrantyYears = 3;
            string category = "Asztali PC";
            HardwareType hardwareType = HardwareType.computerDevice;
            bool portable = false;
            bool isVirtual = false;
            string aName = "Lenovo IdeaCenter 5";
            DateTime purchaseDate = DateTime.Parse("2021-08-10");
            Department owner = new Department("Osztálynév", "NEV");
            AssetState status = AssetState.inUse;
            string docLink = "C/12564/2021";
            DateTime? scrappingDate = null;
            string otherDescription = "Jó kis gép!";

            ComputerDevice testedInstance = new ComputerDevice(processor, ram, storageCapacity, otherComponent, hostName, uId, place, serialNumber, warrantyYears, category, hardwareType, portable, isVirtual, aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription);

            Assert.AreEqual(testedInstance.Processor, processor);
            Assert.AreEqual(testedInstance.Ram, ram);
            Assert.AreEqual(testedInstance.StorageCapacity, storageCapacity);
            Assert.AreEqual(testedInstance.OtherComponent, otherComponent);
            Assert.AreEqual(testedInstance.HostName, hostName);
            Assert.AreEqual(testedInstance.DeviceUser, null);
            Assert.AreEqual(testedInstance.Place, place);
            Assert.AreEqual(testedInstance.SerialNumber, serialNumber);
            Assert.AreEqual(testedInstance.WarrantyYears, warrantyYears);
            Assert.AreEqual(testedInstance.Category, category);
            Assert.AreEqual(testedInstance.HardwareType, hardwareType);
            Assert.AreEqual(testedInstance.Portable, portable);
            Assert.AreEqual(testedInstance.IsVirtual, isVirtual);
            Assert.AreEqual(testedInstance.AName, aName);
            Assert.AreEqual(testedInstance.PurchaseDate, purchaseDate);
            Assert.AreEqual(testedInstance.Owner, owner);
            Assert.AreEqual(testedInstance.Status, status);
            Assert.AreEqual(testedInstance.DocLink, docLink);
            Assert.AreEqual(testedInstance.ScrappingDate, scrappingDate);
            Assert.AreEqual(testedInstance.OtherDescription, otherDescription);
        }

        [TestMethod]
        public void CreateInstanceTest_NetActiveDevice_ReturnInstanceWithValidProperties()
        {
            string hostName = "D-Link router";
            int uId = 0;
            string place = "168-as iroda";
            string serialNumber = "CG856458-IZ456";
            byte warrantyYears = 3;
            string category = "Router";
            HardwareType hardwareType = HardwareType.otherNetActiveDevice;
            bool portable = false;
            bool isVirtual = false;
            string aName = "D-Link router";
            DateTime purchaseDate = DateTime.Parse("2021-08-10");
            Department owner = new Department("Osztálynév", "NEV");
            AssetState status = AssetState.inUse;
            string docLink = "C/12564/2021";
            DateTime? scrappingDate = null;
            string otherDescription = "Elvégzi a hálózat irányítását.";

            NetActiveDevice testedInstance = new NetActiveDevice(hostName, uId, place, serialNumber, warrantyYears, category, hardwareType, portable, isVirtual, aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription);

            Assert.AreEqual(testedInstance.HostName, hostName);
            Assert.AreEqual(testedInstance.DeviceUser, null);
            Assert.AreEqual(testedInstance.Place, place);
            Assert.AreEqual(testedInstance.SerialNumber, serialNumber);
            Assert.AreEqual(testedInstance.WarrantyYears, warrantyYears);
            Assert.AreEqual(testedInstance.Category, category);
            Assert.AreEqual(testedInstance.HardwareType, hardwareType);
            Assert.AreEqual(testedInstance.Portable, portable);
            Assert.AreEqual(testedInstance.IsVirtual, isVirtual);
            Assert.AreEqual(testedInstance.AName, aName);
            Assert.AreEqual(testedInstance.PurchaseDate, purchaseDate);
            Assert.AreEqual(testedInstance.Owner, owner);
            Assert.AreEqual(testedInstance.Status, status);
            Assert.AreEqual(testedInstance.DocLink, docLink);
            Assert.AreEqual(testedInstance.ScrappingDate, scrappingDate);
            Assert.AreEqual(testedInstance.OtherDescription, otherDescription);
        }
    }
    [TestClass]
    public class OwnMethodTest
    {
        [TestMethod]
        public void ToCsvTest_Hardware_ReturnString()
        {
            string processor = "Core i5 1070";
            int ram = 16000;
            int storageCapacity = 250000;
            string otherComponent = "ASUS PH-GTX1650-O4GD6-P GeForce GTX 1650";
            string hostName = "Home-Pc";
            int uId = 0;
            string place = "168-as iroda";
            string serialNumber = "CG856458-IZ456";
            byte warrantyYears = 3;
            string category = "Asztali PC";
            HardwareType hardwareType = HardwareType.computerDevice;
            bool portable = false;
            bool isVirtual = false;
            string aName = "Lenovo IdeaCenter 5";
            DateTime purchaseDate = DateTime.Parse("2021-08-10");
            Department owner = new Department("Osztálynév", "NEV");
            AssetState status = AssetState.inUse;
            string docLink = "C/12564/2021";
            DateTime? scrappingDate = null;
            string otherDescription = "Jó kis gép!";

            Hardware testedInstance = new ComputerDevice(processor, ram, storageCapacity, otherComponent, hostName, uId, place, serialNumber, warrantyYears, category, hardwareType, portable, isVirtual, aName, purchaseDate, owner, status, docLink, scrappingDate, otherDescription);

            Assert.IsNotNull(testedInstance.ToCsv());
        }

        [TestMethod]
        public void AddNICTest_NetActiveDevice_ReturnList()
        {
            NetActiveDevice testedInstance = new NetActiveDevice("D-Link router", 0, "168-as iroda", "CG856458-IZ456", 3, "Router", HardwareType.otherNetActiveDevice, false, false, "D-Link router", DateTime.Parse("2021-08-10"), new Department("Osztálynév", "NEV"), AssetState.inUse, "C/12564/2021", null, "Elvégzi a hálózat irányítását.");

            testedInstance.AddNIC(new NIC("0A:12:FF:B0:22:03", NICType.Ethernet, IpAddressingType.dhcp));

            Assert.IsTrue(testedInstance.NicsList.Count == 1);
        }

        [TestMethod]
        public void StringToHashComparerTest_Password_ReturnTrue()
        {
            string password = "PróbaJelszó123";
            string encryptedPw = Password.PwEncryptor(password);

            Assert.AreNotEqual(password, encryptedPw);
            Assert.IsTrue(Password.StringToHashComparer(password, encryptedPw));
        }

        [TestMethod]
        public void EncryptDecryptTest_Password_ReturnTrue()
        {
            string password = "PróbaJelszó123";
            string encryptedPw = Password.Encrypt(password);

            Assert.AreNotEqual(password, encryptedPw);
            Assert.AreEqual(Password.Decrypt(encryptedPw), password);
        }
    }
}
