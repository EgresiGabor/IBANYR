using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;

namespace IBANYR
{
    static class DBManager
    {
        #region Private fields
        readonly static SqlConnection conn = new SqlConnection();
        readonly static SqlCommand cmd = new SqlCommand();
        #endregion
        #region Open connection
        /// <summary>
        /// Adatbáziskapcsolat megnyitása
        /// </summary>
        /// <param name="connStr">Az adatbázis eléréséhez szükséges connection string</param>
        public static void OpenConnection()
        {
            try
            {
                AppSetting setting = new AppSetting();
                conn.ConnectionString = Password.Decrypt(setting.GetConnectionString());
                    //ConfigurationManager.ConnectionStrings["IBANYR.Properties.Settings.IBANYRConnectionString"].ConnectionString);
                conn.Open();
                cmd.Connection = conn;
            }
            catch (Exception ex)
            {
                throw new DBException("Csatlakozás az adatbázishoz sikertelen!", ex.Message);
            }
        }
        public static bool TestConnection()
        {
            try
            {
                OpenConnection();
                CloseConnection();
                return true;
            }
            catch (DBException)
            {
                return false;
            }
        }
        #endregion
        #region Close connection
        /// <summary>
        /// Adatbáziskapcsolat zárása
        /// </summary>
        public static void CloseConnection()
        {
            try
            {
                conn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new DBException("Adatbáziskapcsolat bontása sikertelen!", ex.Message);
            }
        }
        #endregion
        #region Data management
        #region Create data
        /// <summary>
        /// Karbantartásinaplóba bejegyzés rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="newMaintenance">Az új bejegyzés MaintenanceLog példánya</param>
        public static void CreateMaintenanceLog(MaintenanceLog newMaintenance)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "INSERT INTO [MaintenanceLogs] OUTPUT INSERTED.[LogId] VALUES (@mType, @mMethod, @startDate, @endDate, @activitiesDesc, @docLink, @mName);";
                cmd.Parameters.AddWithValue("@mType", (int)newMaintenance.MType);
                cmd.Parameters.AddWithValue("@mMethod", (int)newMaintenance.MMethod);
                cmd.Parameters.AddWithValue("@startDate", newMaintenance.StartDate);
                cmd.Parameters.AddWithValue("@endDate", newMaintenance.EndDate != null ? (DateTime)newMaintenance.EndDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@activitiesDesc", newMaintenance.ActivitiesDesc);
                cmd.Parameters.AddWithValue("@docLink", String.IsNullOrEmpty(newMaintenance.DocLink) ? (object)DBNull.Value : newMaintenance.DocLink);
                cmd.Parameters.AddWithValue("@mName", newMaintenance.MName);
                int index = -1;
                index = (int)cmd.ExecuteScalar();
                if (index != -1)
                {
                    foreach (int item in newMaintenance.AffectedComponentsId)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [MaintenanceLogs_Hardwares] VALUES (@logId, @hardId);";
                        cmd.Parameters.AddWithValue("@logId", index);
                        cmd.Parameters.AddWithValue("@hardId", item);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (int item in newMaintenance.AffectedItSystemsId)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [MaintenanceLogs_ItSystems] VALUES (@logId, @sId);";
                        cmd.Parameters.AddWithValue("@logId", index);
                        cmd.Parameters.AddWithValue("@sId", item);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new Exception("Karbantartási naplóbejegyzés rögzítése sikertelen!");
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Karbantartási naplóbejegyzés rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szoftver rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="newSoftware">Az új szoftver Software példánya</param>
        public static void CreateSoftware(Software newSoftware)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "INSERT INTO [ItAssets] OUTPUT INSERTED.[AId] VALUES (@aName, @purchaseDate, @ownerId, @status, @docLink, @scrappingDate, @otherDescription);";
                cmd.Parameters.AddWithValue("@aName", newSoftware.AName);
                cmd.Parameters.AddWithValue("@purchaseDate", newSoftware.PurchaseDate);
                cmd.Parameters.AddWithValue("@ownerId", newSoftware.Owner == null ? (object)DBNull.Value : newSoftware.Owner.DId);
                cmd.Parameters.AddWithValue("@status", (int)newSoftware.Status);
                cmd.Parameters.AddWithValue("@docLink", String.IsNullOrEmpty(newSoftware.DocLink) ? (object)DBNull.Value : newSoftware.DocLink);
                cmd.Parameters.AddWithValue("@scrappingDate", newSoftware.ScrappingDate != null ? (DateTime)newSoftware.ScrappingDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@otherDescription", String.IsNullOrEmpty(newSoftware.OtherDescription) ? (object)DBNull.Value : newSoftware.OtherDescription);
                int index = -1;
                index = (int)cmd.ExecuteScalar();
                if (index != -1)
                {
                    foreach (ItSystem item in newSoftware.ItSystems)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [ItAssets_ItSystems] VALUES (@aId, @sId);";
                        cmd.Parameters.AddWithValue("@aId", index);
                        cmd.Parameters.AddWithValue("@sId", item.SId);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [Softwares] VALUES (@aId, @softwareProducer, @softwareDesc, @softwareLicenseNum, @licenseDate, @productKey);";
                    cmd.Parameters.AddWithValue("@aId", index);
                    cmd.Parameters.AddWithValue("@softwareProducer", String.IsNullOrEmpty(newSoftware.SoftwareProducer) ? (object)DBNull.Value : newSoftware.SoftwareProducer);
                    cmd.Parameters.AddWithValue("@softwareDesc", String.IsNullOrEmpty(newSoftware.SoftwareDesc) ? (object)DBNull.Value : newSoftware.SoftwareDesc);
                    cmd.Parameters.AddWithValue("@softwareLicenseNum", newSoftware.SoftwareLicenseNum);
                    cmd.Parameters.AddWithValue("@licenseDate", newSoftware.LicenseDate != null ? (DateTime)newSoftware.LicenseDate : SqlDateTime.Null);
                    cmd.Parameters.AddWithValue("@productKey", String.IsNullOrEmpty(newSoftware.ProductKey) ? (object)DBNull.Value : newSoftware.ProductKey);
                    cmd.ExecuteNonQuery();
                    foreach (int item in newSoftware.HardwareIds)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [Softwares_Hardwares] VALUES (@softAId, @hardAId);";
                        cmd.Parameters.AddWithValue("@softAId", index);
                        cmd.Parameters.AddWithValue("@hardAId", item);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new Exception("Szoftver rögzítése sikertelen!");
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Szoftver rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Hardver rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="newHardware">Az új hardver Hardware példánya</param>
        public static void CreateHardware(Hardware newHardware)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "INSERT INTO [ItAssets] OUTPUT INSERTED.[AId] VALUES (@aName, @purchaseDate, @ownerId, @status, @docLink, @scrappingDate, @otherDescription);";
                cmd.Parameters.AddWithValue("@aName", newHardware.AName);
                cmd.Parameters.AddWithValue("@purchaseDate", newHardware.PurchaseDate);
                cmd.Parameters.AddWithValue("@ownerId", newHardware.Owner == null ? (object)DBNull.Value : newHardware.Owner.DId);
                cmd.Parameters.AddWithValue("@status", (int)newHardware.Status);
                cmd.Parameters.AddWithValue("@docLink", String.IsNullOrEmpty(newHardware.DocLink) ? (object)DBNull.Value : newHardware.DocLink);
                cmd.Parameters.AddWithValue("@scrappingDate", newHardware.ScrappingDate != null ? (DateTime)newHardware.ScrappingDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@otherDescription", String.IsNullOrEmpty(newHardware.OtherDescription) ? (object)DBNull.Value : newHardware.OtherDescription);
                int index = -1;
                index = (int)cmd.ExecuteScalar();
                if (index != -1)
                {
                    foreach (ItSystem item in newHardware.ItSystems)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [ItAssets_ItSystems] VALUES (@aId, @sId);";
                        cmd.Parameters.AddWithValue("@aId", index);
                        cmd.Parameters.AddWithValue("@sId", item.SId);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [Hardwares] VALUES (@aId, @uId, @place, @serialNumber, @warrantyYears, @category, @hardwareType, @portable, @virtual);";
                    cmd.Parameters.AddWithValue("@aId", index);
                    cmd.Parameters.AddWithValue("@uId", newHardware.UId == 0 ? (object)DBNull.Value : newHardware.UId);
                    cmd.Parameters.AddWithValue("@place", String.IsNullOrEmpty(newHardware.Place) ? (object)DBNull.Value : newHardware.Place);
                    cmd.Parameters.AddWithValue("@serialNumber", newHardware.SerialNumber);
                    cmd.Parameters.AddWithValue("@warrantyYears", newHardware.WarrantyYears);
                    cmd.Parameters.AddWithValue("@category", newHardware.Category);
                    cmd.Parameters.AddWithValue("@hardwareType", (int)newHardware.HardwareType);
                    cmd.Parameters.AddWithValue("@portable", newHardware.Portable);
                    cmd.Parameters.AddWithValue("@virtual", newHardware.IsVirtual);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (newHardware is DataStorageDevice dsd)
                    {
                        cmd.CommandText = "INSERT INTO [DataStorageDevices] VALUES (@aId, @storageCapacity, @encrypted, @recoveryKey);";
                        cmd.Parameters.AddWithValue("@aId", index);
                        cmd.Parameters.AddWithValue("@storageCapacity", dsd.StorageCapacity);
                        cmd.Parameters.AddWithValue("@encrypted", dsd.Encrypted);
                        cmd.Parameters.AddWithValue("@recoveryKey", String.IsNullOrEmpty(dsd.RecoveryKey) ? (object)DBNull.Value : dsd.RecoveryKey);
                        cmd.ExecuteNonQuery();
                    }
                    else if (newHardware is NetActiveDevice nad)
                    {
                        cmd.CommandText = "INSERT INTO [NetActiveDevices] VALUES (@aId, @hostName);";
                        cmd.Parameters.AddWithValue("@aId", index);
                        cmd.Parameters.AddWithValue("@hostName", String.IsNullOrEmpty(nad.HostName) ? (object)DBNull.Value : nad.HostName);
                        cmd.ExecuteNonQuery();
                        foreach (NIC item in nad.NicsList)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = "INSERT INTO [NICs] OUTPUT INSERTED.[NicId] VALUES (@macAddressData, @nicType, @ipv4Addressing, @aId);";
                            cmd.Parameters.AddWithValue("@macAddressData", item.MacAddressData);
                            cmd.Parameters.AddWithValue("@nicType", (int)item.NicType);
                            cmd.Parameters.AddWithValue("@ipv4Addressing", (int)item.Ipv4Addressing);
                            cmd.Parameters.AddWithValue("@aId", index);
                            int nicIndex = -1;
                            nicIndex = (int)cmd.ExecuteScalar();
                            foreach (IPv4Address ipItem in item.Ipv4Addresses)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "INSERT INTO [Ipv4Addresses] VALUES (@nicId, @ipv4Address, @subnetMask)";
                                cmd.Parameters.AddWithValue("@nicId", nicIndex);
                                cmd.Parameters.AddWithValue("@ipv4Address", ipItem.Ipv4.GetAddressBytes());
                                cmd.Parameters.AddWithValue("@subnetMask", ipItem.SubnetMask.GetAddressBytes());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (nad is ComputerDevice comp)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = "INSERT INTO [ComputerDevices] VALUES (@aId, @processor, @ram, @storageCapacity, @otherComponent);";
                            cmd.Parameters.AddWithValue("@aId", index);
                            cmd.Parameters.AddWithValue("@processor", String.IsNullOrEmpty(comp.Processor) ? (object)DBNull.Value : comp.Processor);
                            cmd.Parameters.AddWithValue("@ram", comp.Ram);
                            cmd.Parameters.AddWithValue("@storageCapacity", comp.StorageCapacity);
                            cmd.Parameters.AddWithValue("@otherComponent", String.IsNullOrEmpty(comp.OtherComponent) ? (object)DBNull.Value : comp.OtherComponent);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    throw new Exception("Hardver rögzítése sikertelen!");
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Hardver rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Rendszerjogosultság rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="newItSystemPermission">Rögzítendő rendszerjogosultság példány</param>
        public static void CreateItSystemPermission(ItSystemPermission newItSystemPermission)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [ItSystemPermissions] OUTPUT INSERTED.[SysPId] VALUES (@sysPName, @sysPDescription, @superiorSysPId, @sId)";
                cmd.Parameters.AddWithValue("@sysPName", newItSystemPermission.SysPName);
                cmd.Parameters.AddWithValue("@sysPDescription", String.IsNullOrEmpty(newItSystemPermission.SysPDescription) ? (object)DBNull.Value :  newItSystemPermission.SysPDescription);
                cmd.Parameters.AddWithValue("@superiorSysPId", newItSystemPermission.SuperiorSysPId == 0 ? (object)DBNull.Value : newItSystemPermission.SuperiorSysPId);
                cmd.Parameters.AddWithValue("@sId", newItSystemPermission.SId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszerjogosultság rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// IT Rendszer rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="newSystem">Rögzítendő rendszer példány</param>
        public static void CreateItSystem(ItSystem newItSystem)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [ItSystems] OUTPUT INSERTED.[SId] VALUES (@sName, @sShortName, @version, @licenseNumber, @lifeCycle, @confidentiality, @integrity, @availability, @dataType, @sDescription, @innerDataOwner, @adminUser, @interfaceDesc, @providerPartner, @providerContact, @operatorPartner, @operatorContact, @rpo, @rto, @crt, @ert, @criticalPeriod)";
                cmd.Parameters.AddWithValue("@sName", newItSystem.SName);
                cmd.Parameters.AddWithValue("@sShortName", newItSystem.SShortName);
                cmd.Parameters.AddWithValue("@version", String.IsNullOrEmpty(newItSystem.Version) ? (object)DBNull.Value : newItSystem.Version);
                cmd.Parameters.AddWithValue("@licenseNumber", newItSystem.LicenseNumber);
                cmd.Parameters.AddWithValue("@lifeCycle", (int)newItSystem.LifeCycle);
                cmd.Parameters.AddWithValue("@confidentiality", newItSystem.Confidentiality);
                cmd.Parameters.AddWithValue("@integrity", newItSystem.Integrity);
                cmd.Parameters.AddWithValue("@availability", newItSystem.Availability);
                cmd.Parameters.AddWithValue("@dataType", (int)newItSystem.DataType);
                cmd.Parameters.AddWithValue("@sDescription", newItSystem.SDescription);
                cmd.Parameters.AddWithValue("@innerDataOwner", newItSystem.InnerDataOwner == 0 ? (object)DBNull.Value : newItSystem.InnerDataOwner);
                cmd.Parameters.AddWithValue("@adminUser", newItSystem.AdminUser == 0 ? (object)DBNull.Value : newItSystem.AdminUser);
                cmd.Parameters.AddWithValue("@interfaceDesc", String.IsNullOrEmpty(newItSystem.InterfaceDesc) ? (object)DBNull.Value : newItSystem.InterfaceDesc);
                cmd.Parameters.AddWithValue("@providerPartner", newItSystem.ProviderPartner == 0 ? (object)DBNull.Value : newItSystem.ProviderPartner);
                cmd.Parameters.AddWithValue("@providerContact", newItSystem.ProviderContact == 0 ? (object)DBNull.Value : newItSystem.ProviderContact);
                cmd.Parameters.AddWithValue("@operatorPartner", newItSystem.OperatorPartner == 0 ? (object)DBNull.Value : newItSystem.OperatorPartner);
                cmd.Parameters.AddWithValue("@operatorContact", newItSystem.OperatorContact == 0 ? (object)DBNull.Value : newItSystem.OperatorContact);
                cmd.Parameters.AddWithValue("@rpo", newItSystem.Rpo);
                cmd.Parameters.AddWithValue("@rto", newItSystem.Rto);
                cmd.Parameters.AddWithValue("@crt", newItSystem.Crt);
                cmd.Parameters.AddWithValue("@ert", newItSystem.Ert);
                cmd.Parameters.AddWithValue("@criticalPeriod", newItSystem.CriticalPeriod);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszer rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Partner rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="newPartner">Rögzítendő partner példány</param>
        /// <param name="newPartnerId">Az újonnan rögzített partner azonosítója</param>
        public static void CreatePartner(Partner newPartner, out int newPartnerId)
        {
            try
            {
                newPartnerId = 0;
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [Partners] OUTPUT INSERTED.[PartId] VALUES (@partName, @taxNumber)";
                cmd.Parameters.AddWithValue("@partName", newPartner.PartName);
                cmd.Parameters.AddWithValue("@taxNumber", newPartner.TaxNumber);
                newPartnerId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new DBException("Naplóbejegyzés rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Naplóbejegyzés rögzítésére szolgáló metódus.
        /// </summary>
        /// <param name="uId">Felhasználó azonosítószám, aki az eseményt indította</param>
        /// <param name="eventType">Esemény típusa</param>
        /// <param name="eventDesc">Esemény részletesebb leírása</param>
        public static void CreateLog(int uId, EventType eventType, string eventDesc)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [Logs] OUTPUT INSERTED.[LogId] VALUES (@uId, @eventType, @eventDesc, GETDATE())";
                cmd.Parameters.AddWithValue("@uId", uId);
                cmd.Parameters.AddWithValue("@eventType", (int)eventType);
                cmd.Parameters.AddWithValue("@eventDesc", eventDesc);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Naplóbejegyzés rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Felhasználó rögzítésére szolgáló funkció.
        /// </summary>
        /// <param name="newUser">Az új felhasználó User példánya</param>
        /// <param name="mailWasSent">A regisztrációs email kiküldésének sikerességét jelző bool érték</param>
        /// <returns>Az új felhasználó generált jelszava</returns>
        public static string CreateUser(User newUser, out bool mailWasSent)
        {
            try
            {
                AppConfiguration conf = GetConfiguration();
                string password = Password.PasswordGenerator(conf.PwComplexity, conf.PwLength);
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "INSERT INTO [Users] OUTPUT INSERTED.[UId] VALUES (@uName, @email, @phone, @regDate, @permanentLocked, @locked, @post, @dId, @deleteDate)";
                cmd.Parameters.AddWithValue("@uName", newUser.UName);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@phone", String.IsNullOrEmpty(newUser.Phone) ? (object)DBNull.Value : newUser.Phone);
                cmd.Parameters.AddWithValue("@regDate", newUser.RegDate);
                cmd.Parameters.AddWithValue("@permanentLocked", SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@locked", newUser.Locked);
                cmd.Parameters.AddWithValue("@post", String.IsNullOrEmpty(newUser.Post) ? (object)DBNull.Value : newUser.Post);
                cmd.Parameters.AddWithValue("@dId", newUser.UDepartment == null ? (object)DBNull.Value : newUser.UDepartment.DId);
                cmd.Parameters.AddWithValue("@deleteDate", SqlDateTime.Null);
                int index = -1;
                index = (int)cmd.ExecuteScalar();
                if (index != -1)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [UserPasswords] VALUES (@uId, @hashedPw, @pwModifiedDate)";
                    cmd.Parameters.AddWithValue("@uId", index);
                    cmd.Parameters.AddWithValue("@hashedPw", Password.PwEncryptor(password));
                    cmd.Parameters.AddWithValue("@pwModifiedDate", SqlDateTime.Null);
                    cmd.ExecuteNonQuery();
                    foreach (PermissionGroup item in newUser.Permissions)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [Groups_Users] VALUES (@gId, @uId);";
                        cmd.Parameters.AddWithValue("@gId", item.GId);
                        cmd.Parameters.AddWithValue("@uId", index);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new Exception("Felhasználó rögzítése sikertelen!");
                }
                cmd.Transaction.Commit();
                mailWasSent = conf.EnableEmail && !newUser.Locked;
                if (conf.EnableEmail && !newUser.Locked)
                {
                    try
                    {
                        EmailSender.SendEmail("Regisztrációs email", $"<p>Önt felhasználóként regisztrálták az <i>Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszerébe</i> <b>{newUser.UName}</b> néven a(z) <b>{newUser.Email}</b> email címmel!</p><p>A rendszerbe való belépéshez az automatikusan generált jelszava: <b>{password}</b></p>", newUser);
                    }
                    catch (Exception)
                    {
                        mailWasSent = false;
                    }
                }
                return password;
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Felhasználó rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Jogosultsági csoport rögzítése.
        /// </summary>
        /// <param name="newGroup">Az új csoport PermissionGroup példánya</param>
        public static void CreateGroup(PermissionGroup newGroup)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "INSERT INTO [Groups] OUTPUT INSERTED.GId VALUES (@gName, @gDescription)";
                cmd.Parameters.AddWithValue("@gName", newGroup.GName.Trim());
                cmd.Parameters.AddWithValue("@gDescription", newGroup.GDescription.Trim());
                int index = (int)cmd.ExecuteScalar();
                foreach (Permission item in newGroup.Permissions)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [Permissions_Groups] VALUES (@pId, @gId);";
                    cmd.Parameters.AddWithValue("@pId", item.PId);
                    cmd.Parameters.AddWithValue("@gId", index);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Jogosultsági csoport rögzítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szervezeti egység rögzítése.
        /// </summary>
        /// <param name="newDepartment">Az új szervezeti egység Department példánya</param>
        public static void CreateDepartment(Department newDepartment)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [Departments] OUTPUT INSERTED.DId VALUES (@dName, @dShortName, @managerId, @superiorDId)";
                cmd.Parameters.AddWithValue("@dName", newDepartment.DName.Trim());
                cmd.Parameters.AddWithValue("@dShortName", newDepartment.DShortName.Trim());
                cmd.Parameters.AddWithValue("@managerId", newDepartment.ManagerId == 0 ? (object)DBNull.Value : newDepartment.ManagerId);
                cmd.Parameters.AddWithValue("@superiorDId", newDepartment.SuperiorDId == 0 ? (object)DBNull.Value : newDepartment.SuperiorDId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Szervezeti egység rögzítése sikertelen!", ex.Message);
            }
        }
        #endregion
        #region Read data
        /// <summary>
        /// Aktuális idő kikérése az adatbázisból
        /// </summary>
        /// <returns>DateTime formátumú visszatérési érték</returns>
        public static DateTime GetCurrentTime()
        {
            try
            {
                cmd.CommandText = "SELECT GETDATE();";
                return (DateTime)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new DBException("Hiba az időpont lekérdezése közben!", ex.Message);
            }
        }
        /// <summary>
        /// Szűrt karbantartási naplóbejegyzések listázása.
        /// </summary>
        /// <returns>MaintenanceLog osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<MaintenanceLog> GetFilteredMaintenanceLogsList(int rowsPerPage, int pageNum, Hardware affectedComponent, ItSystem affectedItSystem, MaintenanceType? mType, MaintenanceMethod? mMethod, DateTime? startDate, DateTime? endDate, string activitiesDesc, string mName, out int sumResultsNumber)
        {
            try
            {
                List<MaintenanceLog> logList = new List<MaintenanceLog>();
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "SELECT COUNT(DISTINCT [MaintenanceLogs].[LogId]) FROM [MaintenanceLogs]" +
                    "LEFT JOIN [MaintenanceLogs_Hardwares] ON [MaintenanceLogs].[LogId] = [MaintenanceLogs_Hardwares].[LogId]" +
                    "LEFT JOIN [MaintenanceLogs_ItSystems] ON [MaintenanceLogs].[LogId] = [MaintenanceLogs_ItSystems].[LogId] WHERE 0 = 0";
                string filterCondition = String.Empty;
                if (affectedComponent != null)
                {
                    filterCondition += " AND [HardId] = @hardId";
                    cmd.Parameters.AddWithValue("@hardId", affectedComponent.AId);
                }
                if (affectedItSystem != null)
                {
                    filterCondition += " AND [ItSId] = @sId";
                    cmd.Parameters.AddWithValue("@sId", affectedItSystem.SId);
                }
                if (mType != null && Enum.IsDefined(typeof(MaintenanceType), mType))
                {
                    filterCondition += " AND [MType] = @mType";
                    cmd.Parameters.AddWithValue("@mType", (int)mType);
                }
                if (mMethod != null && Enum.IsDefined(typeof(MaintenanceMethod), mMethod))
                {
                    filterCondition += " AND [MMethod] = @mMethod";
                    cmd.Parameters.AddWithValue("@mMethod", (int)mMethod);
                }
                if (startDate != null)
                {
                    filterCondition += " AND [StartDate] >= @startDate";
                    cmd.Parameters.AddWithValue("@startDate", (DateTime)startDate);
                }
                if (endDate != null)
                {
                    filterCondition += " AND [EndDate] <= @endDate";
                    cmd.Parameters.AddWithValue("@endDate", (DateTime)endDate);
                }
                if (!String.IsNullOrEmpty(activitiesDesc))
                {
                    filterCondition += " AND [ActivitiesDesc] LIKE @activitiesDesc";
                    cmd.Parameters.AddWithValue("@activitiesDesc", "%" + activitiesDesc + "%");
                }
                if (!String.IsNullOrEmpty(mName))
                {
                    filterCondition += " AND [MName] LIKE @mName";
                    cmd.Parameters.AddWithValue("@mName", "%" + mName + "%");
                }
                cmd.CommandText += filterCondition;
                sumResultsNumber = (int)cmd.ExecuteScalar();
                //A bejegyzések lekérdezése
                cmd.CommandText = $"SELECT *, [MaintenanceLogs].[LogId] AS [LogMId]," +
                    $"[MaintenanceLogs_Hardwares].[LogId] AS[LogAId]," +
                    $"[MaintenanceLogs_ItSystems].[LogId] AS[LogSId] FROM[MaintenanceLogs]" +
                    $"LEFT JOIN[MaintenanceLogs_Hardwares] ON[MaintenanceLogs].[LogId] = [MaintenanceLogs_Hardwares].[LogId]" +
                    $"LEFT JOIN[MaintenanceLogs_ItSystems] ON[MaintenanceLogs].[LogId] = [MaintenanceLogs_ItSystems].[LogId] WHERE 0 = 0" +
                    $"AND [MaintenanceLogs].[LogId] = ANY(" +
                    $"SELECT TOP (@rowsPerPage) [MaintenanceLogs].[LogId] FROM[MaintenanceLogs]" +
                    $"LEFT JOIN[MaintenanceLogs_Hardwares] ON[MaintenanceLogs].[LogId] = [MaintenanceLogs_Hardwares].[LogId]" +
                    $"LEFT JOIN[MaintenanceLogs_ItSystems] ON[MaintenanceLogs].[LogId] = [MaintenanceLogs_ItSystems].[LogId]" +
                    $"WHERE [MaintenanceLogs].[LogId] < ALL(" +
                    $"SELECT TOP (@prevLogs) [MaintenanceLogs].[LogId] FROM[MaintenanceLogs]" +
                    $"LEFT JOIN[MaintenanceLogs_Hardwares] ON[MaintenanceLogs].[LogId] = [MaintenanceLogs_Hardwares].[LogId]" +
                    $"LEFT JOIN[MaintenanceLogs_ItSystems] ON[MaintenanceLogs].[LogId] = [MaintenanceLogs_ItSystems].[LogId]" +
                    $"WHERE 0 = 0 {filterCondition} ORDER BY[StartDate] DESC) {filterCondition} ORDER BY[StartDate] DESC)" +
                    $"ORDER BY[StartDate] DESC";
                cmd.Parameters.AddWithValue("@rowsPerPage", rowsPerPage);
                cmd.Parameters.AddWithValue("@prevLogs", (pageNum - 1) * rowsPerPage);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    MaintenanceLog log = null;
                    while (reader.Read())
                    {
                        if (log == null || log.LogId != (int)reader["LogMId"])
                        {
                            if (log != null)
                            {
                                logList.Add(log);
                            }
                            log = new MaintenanceLog(
                                (MaintenanceType)(int)reader["MType"],
                                (MaintenanceMethod)(int)reader["MMethod"],
                                (DateTime)reader["StartDate"],
                                reader["EndDate"] == DBNull.Value ? null : (DateTime?)reader["EndDate"],
                                reader["ActivitiesDesc"].ToString(),
                                reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                reader["MName"].ToString(),
                                (int)reader["LogMId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("HardId")) && !log.AffectedComponentsId.Contains((int)reader["HardId"]))
                        {
                            log.AddAffectedComponentsId((int)reader["HardId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("ItSId")) && !log.AffectedItSystemsId.Contains((int)reader["ItSId"]))
                        {
                            log.AddAffectedItSystemsId((int)reader["ItSId"]);
                        }
                    }
                    if (log != null)
                    {
                        logList.Add(log);
                    }
                    reader.Close();
                }
                cmd.Transaction.Commit();
                return logList;

            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Karbantartási naplóbejegyzések lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi szoftver adatának listázása.
        /// </summary>
        /// <returns>Software osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<Software> GetSoftwaresList()
        {
            try
            {
                List<Software> softwareList = new List<Software>();
                cmd.CommandText = "SELECT *, [Softwares].[AId] AS [SwAId], [ItAssets_ItSystems].[AId] AS [SysAId]," +
                    "[ItSystems].[SId] AS [SysSId], [ItSystemPermissions].[SId] AS [PerSID]" +
                    "FROM [ItAssets] LEFT JOIN [ItAssets_ItSystems] ON [ItAssets].[AId] = [ItAssets_ItSystems].[AId]" +
                    "LEFT JOIN [ItSystems] ON [ItAssets_ItSystems].[SId] = [ItSystems].[SId]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystems].[SId] = [ItSystemPermissions].[SId]" +
                    "LEFT JOIN [Departments] ON [ItAssets].[OwnerId] = [Departments].[DId]" +
                    "LEFT JOIN [Softwares] ON [ItAssets].[AId] = [Softwares].[AId]" +
                    "LEFT JOIN [Softwares_Hardwares] ON [Softwares].[AId] = [Softwares_Hardwares].[SoftAId]" +
                    "WHERE [Softwares].[AId] IS NOT NULL";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Software software = null;
                    while (reader.Read())
                    {
                        if (software == null || software.AId != (int)reader["SwAId"])
                        {
                            if (software != null)
                            {
                                softwareList.Add(software);
                            }
                            software = new Software(
                                reader["SoftwareProducer"] == DBNull.Value ? null : reader["SoftwareProducer"].ToString(),
                                reader["SoftwareDesc"] == DBNull.Value ? null : reader["SoftwareDesc"].ToString(),
                                reader["SoftwareLicenseNum"] == DBNull.Value ? 0 : (int)reader["SoftwareLicenseNum"],
                                reader["LicenseDate"] == DBNull.Value ? null : (DateTime?)reader["LicenseDate"],
                                reader["ProductKey"] == DBNull.Value ? null : reader["ProductKey"].ToString(),
                                reader["AName"].ToString(),
                                (DateTime)reader["PurchaseDate"],
                                reader["OwnerId"] == DBNull.Value ? null : new Department(
                                    reader["DName"].ToString(),
                                    reader["DShortName"].ToString(),
                                    reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                    reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                    (int)reader["DId"]),
                                (AssetState)reader["Status"],
                                reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                (int)reader["SwAId"]);
                        }
                        //Ha sorban van ItSystem azonosító
                        if (!reader.IsDBNull(reader.GetOrdinal("SysSId")))
                        {
                            //ha a ItSystem még nem szerepel a listában, akkor hozzáadjuk
                            if (software.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"]) == -1)
                            {
                                software.AddItSystems(new ItSystem(
                                    reader["SName"].ToString(),
                                    reader["SShortName"].ToString(),
                                    reader["Version"].ToString(),
                                    (int)reader["LicenseNumber"],
                                    (SystemLifeCycle)(int)reader["LifeCycle"],
                                    (byte)reader["Confidentiality"],
                                    (byte)reader["Integrity"],
                                    (byte)reader["Availability"],
                                    (StoredDataType)(int)reader["DataType"],
                                    reader["SDescription"].ToString(),
                                    reader["InnerDataOwner"] == DBNull.Value ? 0 : (int)reader["InnerDataOwner"],
                                    reader["AdminUser"] == DBNull.Value ? 0 : (int)reader["AdminUser"],
                                    reader["InterfaceDesc"] == DBNull.Value ? null : reader["InterfaceDesc"].ToString(),
                                    reader["ProviderPartner"] == DBNull.Value ? 0 : (int)reader["ProviderPartner"],
                                    reader["ProviderContact"] == DBNull.Value ? 0 : (int)reader["ProviderContact"],
                                    reader["OperatorPartner"] == DBNull.Value ? 0 : (int)reader["OperatorPartner"],
                                    reader["OperatorContact"] == DBNull.Value ? 0 : (int)reader["OperatorContact"],
                                    (short)reader["RPO"],
                                    (short)reader["RTO"],
                                    (short)reader["CRT"],
                                    (short)reader["ERT"],
                                    reader["CriticalPeriod"].ToString(),
                                    (int)reader["SysSId"]));
                            }
                            //ha a sor tartalmaz jogosultság azonosítót és még nincs a hardwarehez kapcsolt rendszer listájában
                            if (!reader.IsDBNull(reader.GetOrdinal("SysPId")) && (software.ItSystems[software.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"])] as ItSystem).ItSystemPermissions.FindIndex(x => x.SysPId == (int)reader["SysPId"]) == -1)
                            {
                                software.ItSystems[software.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"])].AddPermission(new ItSystemPermission(
                                    reader["SysPName"].ToString(),
                                    reader["SysPDescription"] == DBNull.Value ? null : reader["SysPDescription"].ToString(),
                                    reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"],
                                    (int)reader["PerSID"],
                                    (int)reader["SysPId"]));
                            }
                        }
                        //Ha sorban van számítógépazonosító, és azt a szoftver kapcsolódó számítógép listája még nem tartalmazza
                        if (!reader.IsDBNull(reader.GetOrdinal("HardAId")) && software.HardwareIds.FindIndex(x => x == (int)reader["HardAId"]) == -1)
                        {
                            software.AddHardwareId((int)reader["HardAId"]);
                        }
                    }
                    if (software != null)
                    {
                        softwareList.Add(software);
                    }
                    reader.Close();
                }
                return softwareList;
            }
            catch (Exception ex)
            {
                throw new DBException("Szoftverek lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A szoftvergyártók kiolvasásár szolgáló funkció
        /// </summary>
        /// <returns>Egy a szoftvergyártókat szövegként tartalmazó lista a visszatérési érték</returns>
        public static List<string> GetSoftwareProducers()
        {
            try
            {
                List<string> producers = new List<string>();
                cmd.CommandText = $"SELECT DISTINCT [SoftwareProducer] FROM [Softwares]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("SoftwareProducer")))
                        {
                            producers.Add(reader["SoftwareProducer"].ToString());
                        }
                    }
                    reader.Close();
                }
                return producers;
            }
            catch (Exception ex)
            {
                throw new DBException("Szoftvergyártók lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Adott azonosítószámú hardver lekérdezése.
        /// </summary>
        /// <param name="aId">A keresendő hardware azonosítószáma</param>
        /// <returns>Hardware osztályú példánnyal tér vissza ami null értékű, ha nincs találat.</returns>
        public static Hardware GetHardwareById(int aId)
        {
            try
            {
                Hardware hardware = null;
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT *, [Hardwares].[AId] AS [HwAId], [NetActiveDevices].[AId] AS [NadAId]," +
                    "[NICs].[AId] AS [NicAId], [ComputerDevices].[AId] AS [comAId], [ComputerDevices].[StorageCapacity] AS [comStorageCapacity]," +
                    "[DataStorageDevices].[AId] AS [dsdAId], [ItAssets_ItSystems].[AId] AS [SysAId]," +
                    "[ItSystems].[SId] AS [SysSId], [ItSystemPermissions].[SId] AS [PerSID]," +
                    "[NICs].[NicId] AS [NICsNicId], [IPv4Addresses].[NicId] AS [IPv4NicId]" +
                    "FROM [ItAssets] LEFT JOIN [ItAssets_ItSystems] ON [ItAssets].[AId] = [ItAssets_ItSystems].[AId]" +
                    "LEFT JOIN [ItSystems] ON [ItAssets_ItSystems].[SId] = [ItSystems].[SId]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystems].[SId] = [ItSystemPermissions].[SId]" +
                    "LEFT JOIN [Departments] ON [ItAssets].[OwnerId] = [Departments].[DId]" +
                    "LEFT JOIN [Hardwares] ON [ItAssets].[AId] = [Hardwares].[AId]" +
                    "LEFT JOIN [DataStorageDevices] ON [Hardwares].[AId] = [DataStorageDevices].[AId]" +
                    "LEFT JOIN [NetActiveDevices] ON [Hardwares].[AId] = [NetActiveDevices].[AId]" +
                    "LEFT JOIN [ComputerDevices] ON [NetActiveDevices].[AId] = [ComputerDevices].[AId]" +
                    "LEFT JOIN [NICs] ON [NetActiveDevices].[AId] = [NICs].[AId]" +
                    "LEFT JOIN [IPv4Addresses] ON [NICs].[NicId] = [IPv4Addresses].[NicId] WHERE [Hardwares].[AId] = @aId";
                cmd.Parameters.AddWithValue("@aId", aId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (hardware == null)
                        {
                            switch ((HardwareType)(int)reader["HardwareType"])
                            {
                                case HardwareType.dataStorage:
                                    hardware = new DataStorageDevice(
                                        (int)reader["StorageCapacity"],
                                        (bool)reader["Encrypted"],
                                        reader["RecoveryKey"] == DBNull.Value ? null : reader["RecoveryKey"].ToString(),
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                                case HardwareType.computerDevice:
                                    hardware = new ComputerDevice(
                                        reader["Processor"] == DBNull.Value ? null : reader["Processor"].ToString(),
                                        (int)reader["Ram"],
                                        (int)reader["comStorageCapacity"],
                                        reader["OtherComponent"] == DBNull.Value ? null : reader["OtherComponent"].ToString(),
                                        reader["HostName"] == DBNull.Value ? null : reader["HostName"].ToString(),
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                                case HardwareType.otherNetActiveDevice:
                                    hardware = new NetActiveDevice(
                                        reader["HostName"] == DBNull.Value ? null : reader["HostName"].ToString(),
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                                case HardwareType.otherHardware:
                                    hardware = new Hardware(
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                            }
                        }
                        //Ha sorban van ItSystem azonosító
                        if (!reader.IsDBNull(reader.GetOrdinal("SysSId")))
                        {
                            //ha a ItSystem még nem szerepel a listában, akkor hozzáadjuk
                            if (hardware.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"]) == -1)
                            {
                                hardware.AddItSystems(new ItSystem(
                                    reader["SName"].ToString(),
                                    reader["SShortName"].ToString(),
                                    reader["Version"].ToString(),
                                    (int)reader["LicenseNumber"],
                                    (SystemLifeCycle)(int)reader["LifeCycle"],
                                    (byte)reader["Confidentiality"],
                                    (byte)reader["Integrity"],
                                    (byte)reader["Availability"],
                                    (StoredDataType)(int)reader["DataType"],
                                    reader["SDescription"].ToString(),
                                    reader["InnerDataOwner"] == DBNull.Value ? 0 : (int)reader["InnerDataOwner"],
                                    reader["AdminUser"] == DBNull.Value ? 0 : (int)reader["AdminUser"],
                                    reader["InterfaceDesc"] == DBNull.Value ? null : reader["InterfaceDesc"].ToString(),
                                    reader["ProviderPartner"] == DBNull.Value ? 0 : (int)reader["ProviderPartner"],
                                    reader["ProviderContact"] == DBNull.Value ? 0 : (int)reader["ProviderContact"],
                                    reader["OperatorPartner"] == DBNull.Value ? 0 : (int)reader["OperatorPartner"],
                                    reader["OperatorContact"] == DBNull.Value ? 0 : (int)reader["OperatorContact"],
                                    (short)reader["RPO"],
                                    (short)reader["RTO"],
                                    (short)reader["CRT"],
                                    (short)reader["ERT"],
                                    reader["CriticalPeriod"].ToString(),
                                    (int)reader["SysSId"]));
                            }
                            //ha a sor tartalmaz jogosultság azonosítót és még nincs a hardwarehez kapcsolt rendszer listájában
                            if (!reader.IsDBNull(reader.GetOrdinal("SysPId")) && (hardware.ItSystems[hardware.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"])] as ItSystem).ItSystemPermissions.FindIndex(x => x.SysPId == (int)reader["SysPId"]) == -1)
                            {
                                hardware.ItSystems[hardware.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"])].AddPermission(new ItSystemPermission(
                                    reader["SysPName"].ToString(),
                                    reader["SysPDescription"] == DBNull.Value ? null : reader["SysPDescription"].ToString(),
                                    reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"],
                                    (int)reader["PerSID"],
                                    (int)reader["SysPId"]));
                            }
                        }
                        //Ha sorban van MAC cím és az eszköz hálózati eszköz
                        if (!reader.IsDBNull(reader.GetOrdinal("NICsNicId")) && hardware is NetActiveDevice nad)
                        {
                            //Ha az eszköz hálózati adapterek listája még nem tartalmazza
                            if (nad.NicsList.FindIndex(x => x.MacAddressData.SequenceEqual((byte[])reader["MacAddressData"])) == -1)
                            {
                                nad.AddNIC(new NIC(
                                    (byte[])reader["MacAddressData"],
                                    (NICType)reader["NICType"],
                                    (IpAddressingType)reader["IPv4Addressing"]));
                            }
                            //Ha tartalmaz IPv4 adattáblájábol NicId-t és 
                            if (!reader.IsDBNull(reader.GetOrdinal("IPv4NicId")) && nad.NicsList[nad.NicsList.FindIndex(x => x.MacAddressData.SequenceEqual((byte[])reader["MacAddressData"]))].Ipv4Addresses.FindIndex(x => x.Ipv4 != null && x.Ipv4.GetAddressBytes().SequenceEqual((byte[])reader["IPv4Address"])) == -1)
                            {
                                nad.NicsList[nad.NicsList.FindIndex(x => x.MacAddressData.SequenceEqual((byte[])reader["MacAddressData"]))].AddIpv4(new IPv4Address(
                                    new IPAddress((byte[])reader["IPv4Address"]),
                                    new IPAddress((byte[])reader["SubnetMask"])));
                            }

                        }
                    }
                    reader.Close();
                }
                return hardware;
            }
            catch (Exception ex)
            {
                throw new DBException("Hardver lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi hardver adatának listázása.
        /// </summary>
        /// <returns>Hardware osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<Hardware> GetHardwaresList()
        {
            try
            {
                List<Hardware> hardwareList = new List<Hardware>();
                cmd.CommandText = "SELECT *, [Hardwares].[AId] AS [HwAId], [NetActiveDevices].[AId] AS [NadAId]," +
                    "[NICs].[AId] AS [NicAId], [ComputerDevices].[AId] AS [comAId], [ComputerDevices].[StorageCapacity] AS [comStorageCapacity]," +
                    "[DataStorageDevices].[AId] AS [dsdAId], [ItAssets_ItSystems].[AId] AS [SysAId]," +
                    "[ItSystems].[SId] AS [SysSId], [ItSystemPermissions].[SId] AS [PerSID]," +
                    "[NICs].[NicId] AS [NICsNicId], [IPv4Addresses].[NicId] AS [IPv4NicId]" +
                    "FROM [ItAssets] LEFT JOIN [ItAssets_ItSystems] ON [ItAssets].[AId] = [ItAssets_ItSystems].[AId]" +
                    "LEFT JOIN [ItSystems] ON [ItAssets_ItSystems].[SId] = [ItSystems].[SId]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystems].[SId] = [ItSystemPermissions].[SId]" +
                    "LEFT JOIN [Departments] ON [ItAssets].[OwnerId] = [Departments].[DId]" +
                    "LEFT JOIN [Hardwares] ON [ItAssets].[AId] = [Hardwares].[AId]" +
                    "LEFT JOIN [DataStorageDevices] ON [Hardwares].[AId] = [DataStorageDevices].[AId]" +
                    "LEFT JOIN [NetActiveDevices] ON [Hardwares].[AId] = [NetActiveDevices].[AId]" +
                    "LEFT JOIN [ComputerDevices] ON [NetActiveDevices].[AId] = [ComputerDevices].[AId]" +
                    "LEFT JOIN [NICs] ON [NetActiveDevices].[AId] = [NICs].[AId]" +
                    "LEFT JOIN [IPv4Addresses] ON [NICs].[NicId] = [IPv4Addresses].[NicId] WHERE [Hardwares].[AId] IS NOT NULL";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Hardware hardware = null;
                    while (reader.Read())
                    {
                        if (hardware == null || hardware.AId != (int)reader["AId"])
                        {
                            if (hardware != null)
                            {
                                hardwareList.Add(hardware);
                            }
                            switch ((HardwareType)(int)reader["HardwareType"])
                            {
                                case HardwareType.dataStorage:
                                    hardware = new DataStorageDevice(
                                        (int)reader["StorageCapacity"],
                                        (bool)reader["Encrypted"],
                                        reader["RecoveryKey"] == DBNull.Value ? null : reader["RecoveryKey"].ToString(),
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                                case HardwareType.computerDevice:
                                    hardware = new ComputerDevice(
                                        reader["Processor"] == DBNull.Value ? null : reader["Processor"].ToString(),
                                        (int)reader["Ram"],
                                        (int)reader["comStorageCapacity"],
                                        reader["OtherComponent"] == DBNull.Value ? null : reader["OtherComponent"].ToString(),
                                        reader["HostName"] == DBNull.Value ? null : reader["HostName"].ToString(),
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                                case HardwareType.otherNetActiveDevice:
                                    hardware = new NetActiveDevice(
                                        reader["HostName"] == DBNull.Value ? null : reader["HostName"].ToString(),
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                                case HardwareType.otherHardware:
                                    hardware = new Hardware(
                                        reader["UId"] == DBNull.Value ? 0 : (int)reader["UId"],
                                        reader["Place"] == DBNull.Value ? null : reader["Place"].ToString(),
                                        reader["SerialNumber"].ToString(),
                                        (byte)reader["WarrantyYears"],
                                        reader["Category"].ToString(),
                                        (HardwareType)reader["HardwareType"],
                                        (bool)reader["Portable"],
                                        (bool)reader["Virtual"],
                                        reader["AName"].ToString(),
                                        (DateTime)reader["PurchaseDate"],
                                        reader["OwnerId"] == DBNull.Value ? null : new Department(
                                            reader["DName"].ToString(),
                                            reader["DShortName"].ToString(),
                                            reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                            reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                            (int)reader["DId"]),
                                        (AssetState)reader["Status"],
                                        reader["DocLink"] == DBNull.Value ? null : reader["DocLink"].ToString(),
                                        reader["ScrappingDate"] == DBNull.Value ? null : (DateTime?)reader["ScrappingDate"],
                                        reader["OtherDescription"] == DBNull.Value ? null : reader["OtherDescription"].ToString(),
                                        (int)reader["HwAId"]);
                                    break;
                            }
                        }
                        //Ha sorban van ItSystem azonosító
                        if (!reader.IsDBNull(reader.GetOrdinal("SysSId")))
                        {
                            //ha a ItSystem még nem szerepel a listában, akkor hozzáadjuk
                            if (hardware.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"]) == -1)
                            {
                                hardware.AddItSystems(new ItSystem(
                                    reader["SName"].ToString(),
                                    reader["SShortName"].ToString(),
                                    reader["Version"].ToString(),
                                    (int)reader["LicenseNumber"],
                                    (SystemLifeCycle)(int)reader["LifeCycle"],
                                    (byte)reader["Confidentiality"],
                                    (byte)reader["Integrity"],
                                    (byte)reader["Availability"],
                                    (StoredDataType)(int)reader["DataType"],
                                    reader["SDescription"].ToString(),
                                    reader["InnerDataOwner"] == DBNull.Value ? 0 : (int)reader["InnerDataOwner"],
                                    reader["AdminUser"] == DBNull.Value ? 0 : (int)reader["AdminUser"],
                                    reader["InterfaceDesc"] == DBNull.Value ? null : reader["InterfaceDesc"].ToString(),
                                    reader["ProviderPartner"] == DBNull.Value ? 0 : (int)reader["ProviderPartner"],
                                    reader["ProviderContact"] == DBNull.Value ? 0 : (int)reader["ProviderContact"],
                                    reader["OperatorPartner"] == DBNull.Value ? 0 : (int)reader["OperatorPartner"],
                                    reader["OperatorContact"] == DBNull.Value ? 0 : (int)reader["OperatorContact"],
                                    (short)reader["RPO"],
                                    (short)reader["RTO"],
                                    (short)reader["CRT"],
                                    (short)reader["ERT"],
                                    reader["CriticalPeriod"].ToString(),
                                    (int)reader["SysSId"]));
                            }
                            //ha a sor tartalmaz jogosultság azonosítót és még nincs a hardwarehez kapcsolt rendszer listájában
                            if (!reader.IsDBNull(reader.GetOrdinal("SysPId")) && (hardware.ItSystems[hardware.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"])] as ItSystem).ItSystemPermissions.FindIndex(x => x.SysPId == (int)reader["SysPId"]) == -1)
                            {
                                hardware.ItSystems[hardware.ItSystems.FindIndex(x => x.SId == (int)reader["SysSId"])].AddPermission(new ItSystemPermission(
                                    reader["SysPName"].ToString(),
                                    reader["SysPDescription"] == DBNull.Value ? null : reader["SysPDescription"].ToString(),
                                    reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"],
                                    (int)reader["PerSID"],
                                    (int)reader["SysPId"]));
                            }
                        }
                        //Ha sorban van MAC cím és az eszköz hálózati eszköz
                        if (!reader.IsDBNull(reader.GetOrdinal("NICsNicId")) && hardware is NetActiveDevice nad)
                        {
                            //Ha az eszköz hálózati adapterek listája még nem tartalmazza
                            if (nad.NicsList.FindIndex(x => x.MacAddressData.SequenceEqual((byte[])reader["MacAddressData"])) == -1)
                            {
                                nad.AddNIC(new NIC(
                                    (byte[])reader["MacAddressData"],
                                    (NICType)reader["NICType"],
                                    (IpAddressingType)reader["IPv4Addressing"]));
                            }
                            //Ha tartalmaz IPv4 adattáblájábol NicId-t és 
                            if (!reader.IsDBNull(reader.GetOrdinal("IPv4NicId")) && nad.NicsList[nad.NicsList.FindIndex(x => x.MacAddressData.SequenceEqual((byte[])reader["MacAddressData"]))].Ipv4Addresses.FindIndex(x => x.Ipv4 != null && x.Ipv4.GetAddressBytes().SequenceEqual((byte[])reader["IPv4Address"])) == -1)
                            {
                                nad.NicsList[nad.NicsList.FindIndex(x => x.MacAddressData.SequenceEqual((byte[])reader["MacAddressData"]))].AddIpv4(new IPv4Address(
                                    new IPAddress((byte[])reader["IPv4Address"]),
                                    new IPAddress((byte[])reader["SubnetMask"])));
                            }

                        }
                    }
                    if (hardware != null)
                    {
                        hardwareList.Add(hardware);
                    }
                    reader.Close();
                }
                return hardwareList;
            }
            catch (Exception ex)
            {
                throw new DBException("Hardverek lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A eszköztulajdonos szervezetek/szervezeti egységek kiolvasásár szolgáló funkció
        /// </summary>
        /// <returns>Department formátumú találatokat tartalmazó lista a visszatérési érték, ha nincs találat akkor üres lista tér vissza</returns>
        public static List<Department> GetItAssetOwners()
        {
            try
            {
                List<int> ownerIds = new List<int>();
                List<Department> owners = new List<Department>();
                cmd.CommandText = $"SELECT DISTINCT [OwnerId] FROM [ItAssets]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["OwnerId"] != DBNull.Value)
                        {
                            ownerIds.Add((int)reader["OwnerId"]);
                        }
                    }
                    reader.Close();
                }
                foreach (int dId in ownerIds)
                {
                    owners.Add(GetDepartmentById(dId));
                }
                return owners;
            }
            catch (Exception ex)
            {
                throw new DBException("Eszköztulajdonosok lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A hardverkategóriák kiolvasásár szolgáló funkció
        /// </summary>
        /// <returns>Egy a kategóriákat szövegként tartalmazó lista a visszatérési érték</returns>
        public static List<string> GetHardwareCategories()
        {
            try
            {
                List<string> categories = new List<string>();
                cmd.CommandText = $"SELECT DISTINCT [Category] FROM [Hardwares]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(reader["Category"].ToString());
                    }
                    reader.Close();
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw new DBException("Hardverkategóriák lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott sorozatszámú hardver létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="sNumber">Az ellenőrizendő sorozatszám</param>
        /// <param name="aId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező hardvert ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező név esetén true, egyébként false</returns>
        public static bool IsSerialNumberExists(string sNumber, int aId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Hardwares] WHERE [SerialNumber] = @sNumber{(aId != 0 ? " AND [AId] <> @aId;" : ";")}";
                cmd.Parameters.AddWithValue("@sNumber", sNumber.Trim());
                if (aId != 0)
                {
                    cmd.Parameters.AddWithValue("@aId", aId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Beállítások kiolvasása a Configurations adattáblából
        /// </summary>
        /// <returns>Configuration formátumú példány a visszatérési érték</returns>
        public static AppConfiguration GetConfiguration()
        {
            try
            {
                AppConfiguration conf = null;
                cmd.CommandText = $"SELECT * FROM [Configurations]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                            conf = new AppConfiguration(
                                (short)reader["PwValidityPeriod"],
                                (byte)reader["PwLength"],
                                (PasswordComplexity)reader["PwComplexity"],
                                (byte)reader["FailedLoginNum"],
                                (byte)reader["PermanentLockingPeriod"],
                                (short)reader["RetentionDays"],
                                (bool)reader["EnableEmail"],
                                reader["SmtpServer"].ToString(),
                                (int)reader["Port"],
                                (bool)reader["EnableSSL"],
                                reader["EmailAddress"] == DBNull.Value ? null : reader["EmailAddress"].ToString(),
                                reader["SmtpUserName"] == DBNull.Value ? null : Password.Decrypt(reader["SmtpUserName"].ToString()),
                                reader["SmtpPassword"] == DBNull.Value ? null : Password.Decrypt(reader["SmtpPassword"].ToString()));
                    }
                    reader.Close();
                }
                return conf;
            }
            catch (Exception ex)
            {
                throw new DBException("Beállítások lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Rendszerjogosultság lekérdezése azonosítószám alapján
        /// </summary>
        /// <param name="sysPId">A keresendő rendszerjogosultság azonosítószáma</param>
        /// <returns>ItSystemPermission osztályú példány a visszatérés, mely null értékű, ha nincs találat.</returns>
        public static ItSystemPermission GetItSystemPermissionById(int sysPId)
        {
            try
            {
                ItSystemPermission systemPermission = null;
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM [ItSystemPermissions] WHERE [SysPId] = @sysPId";
                cmd.Parameters.AddWithValue("@sysPId", sysPId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        systemPermission = new ItSystemPermission(
                            reader["SysPName"].ToString(),
                            reader["SysPDescription"] == DBNull.Value ? null : reader["SysPDescription"].ToString(),
                            reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"],
                            (int)reader["SId"],
                            (int)reader["SysPId"]);
                    }
                    reader.Close();
                }
                return systemPermission;
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszerjogosultság lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi rendszer adatának listázása.
        /// </summary>
        /// <returns>ItSystem osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<ItSystem> GetItSystemsList()
        {
            try
            {
                List<ItSystem> systemList = new List<ItSystem>();
                cmd.CommandText = "SELECT *, [ItSystemPermissions].[SId] AS [PerSID] FROM [ItSystems]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystems].[SId] = [ItSystemPermissions].[SId]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ItSystem itSystem = null;
                    while (reader.Read())
                    {
                        if (itSystem == null || itSystem.SId != (int)reader["SId"])
                        {
                            if (itSystem != null)
                            {
                                systemList.Add(itSystem);
                            }
                            itSystem = new ItSystem(
                                reader["SName"].ToString(),
                                reader["SShortName"].ToString(),
                                reader["Version"].ToString(),
                                (int)reader["LicenseNumber"],
                                (SystemLifeCycle)(int)reader["LifeCycle"],
                                (byte)reader["Confidentiality"],
                                (byte)reader["Integrity"],
                                (byte)reader["Availability"],
                                (StoredDataType)(int)reader["DataType"],
                                reader["SDescription"].ToString(),
                                reader["InnerDataOwner"] == DBNull.Value ? 0 : (int)reader["InnerDataOwner"],
                                reader["AdminUser"] == DBNull.Value ? 0 : (int)reader["AdminUser"],
                                reader["InterfaceDesc"] == DBNull.Value ? null : reader["InterfaceDesc"].ToString(),
                                reader["ProviderPartner"] == DBNull.Value ? 0 : (int)reader["ProviderPartner"],
                                reader["ProviderContact"] == DBNull.Value ? 0 : (int)reader["ProviderContact"],
                                reader["OperatorPartner"] == DBNull.Value ? 0 : (int)reader["OperatorPartner"],
                                reader["OperatorContact"] == DBNull.Value ? 0 : (int)reader["OperatorContact"],
                                (short)reader["RPO"],
                                (short)reader["RTO"],
                                (short)reader["CRT"],
                                (short)reader["ERT"],
                                reader["CriticalPeriod"].ToString(),
                                (int)reader["SId"]);
                        }
                        //Ha van az adott sorban jogosultsági csoport megnevezve
                        if (!reader.IsDBNull(reader.GetOrdinal("SysPId")))
                        {
                            itSystem.AddPermission(new ItSystemPermission(
                                reader["SysPName"].ToString(),
                                reader["SysPDescription"] == DBNull.Value ? null : reader["SysPDescription"].ToString(),
                                reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"],
                                (int)reader["PerSID"],
                                (int)reader["SysPId"]));
                        }
                    }
                    if (itSystem != null)
                    {
                        systemList.Add(itSystem);
                    }
                    reader.Close();
                }
                return systemList;
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszerek lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi partner adatának listázása.
        /// </summary>
        /// <returns>Partner osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<Partner> GetPartnersList()
        {
            try
            {
                List<Partner> partnerList = new List<Partner>();
                cmd.CommandText = "SELECT *, [Contacts].[PartId] AS [ConPartId] FROM [Partners]" +
                    "LEFT JOIN [Contacts] ON [Partners].[PartId] = [Contacts].[PartId]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Partner partner = null;
                    while (reader.Read())
                    {
                        if (partner == null || partner.PartId != (int)reader["PartId"])
                        {
                            if (partner != null)
                            {
                                partnerList.Add(partner);
                            }
                            partner = new Partner(
                                reader["PartName"].ToString(),
                                reader["TaxNumber"].ToString(),
                                (int)reader["PartId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("ContName")))
                        {
                            partner.AddContact(new Contact(
                                reader["ContName"].ToString(),
                                reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                                reader["Address"] == DBNull.Value ? null : reader["Address"].ToString(),
                                reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                                (int)reader["ContId"]));
                        }
                    }
                    if (partner != null)
                    {
                        partnerList.Add(partner);
                    }
                    reader.Close();
                }
                return partnerList;
            }
            catch (Exception ex)
            {
                throw new DBException("Partnerek lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Partner lekérdezése azonosító alapján.
        /// </summary>
        /// <param name="partId">A lekérdezendő partner azonosítója</param>
        /// <returns>Találat esetén Partner osztályú példány, egyébként null.</returns>
        public static Partner GetPartnerById(int partId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT *, [Contacts].[PartId] AS [ConPartId] FROM [Partners]" +
                    "LEFT JOIN [Contacts] ON [Partners].[PartId] = [Contacts].[PartId] WHERE [Partners].[PartId] = @partId";
                cmd.Parameters.AddWithValue("@partId", partId);
                Partner partner = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (partner == null)
                        {
                            partner = new Partner(
                                reader["PartName"].ToString(),
                                reader["TaxNumber"].ToString(),
                                (int)reader["PartId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("ContName")))
                        {
                            partner.AddContact(new Contact(
                                reader["ContName"].ToString(),
                                reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                                reader["Address"] == DBNull.Value ? null : reader["Address"].ToString(),
                                reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                                (int)reader["ContId"]));
                        }
                    }
                    reader.Close();
                }
                return partner;
            }
            catch (Exception ex)
            {
                throw new DBException("Partner lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi felhasználó adataának listázása.
        /// </summary>
        /// <param name="dId">Opcionális paraméter, a szervezeti egység szerinti lekérdezéshez</param>
        /// <returns>User osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<User> GetUsersList(int dId = 0)
        {
            try
            {
                List<User> userList = new List<User>();
                if (dId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@dId", dId);
                }
                cmd.CommandText = "SELECT *, [Users].[DId] AS [UserDId], [Groups_Users].[UId] AS [Groups_UsersUId]," +
                    "[Permissions_Groups].[GId] AS [Permissions_GroupsGId], [Permissions_Groups].[PId] AS [Permissions_GroupsPId]," +
                    "[ItSystemPermissions_Users].[UId] AS [ItSysUserUId]  FROM [Users] " +
                    "LEFT JOIN [ItSystemPermissions_Users] ON [Users].[UId] = [ItSystemPermissions_Users].[UId]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystemPermissions_Users].[SysPId] = [ItSystemPermissions].[SysPId]" +
                    "LEFT JOIN [Departments] ON [Users].[DId] = [Departments].[DId]" +
                    "LEFT JOIN [Groups_Users] ON [Users].[UId] = [Groups_Users].[UId]" +
                    "LEFT JOIN [Permissions_Groups] ON [Groups_Users].[GId] = [Permissions_Groups].[GId]" +
                    "LEFT JOIN [Groups] ON [Permissions_Groups].[GId] = [Groups].[GId]" +
                    $"LEFT JOIN [Permissions] ON [Permissions_Groups].[PId] = [Permissions].[PId]{(dId > 0 ? " WHERE [Users].[DId] = @dId;" : ";")}";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    User user = null;
                    while (reader.Read())
                    {
                        if (user == null || user.UId != (int)reader["UId"])
                        {
                            if (user != null)
                            {
                                userList.Add(user);
                            }
                            user = new User(
                                reader["UName"].ToString(),
                                reader["Post"] == DBNull.Value ? null : reader["Post"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                                reader["DId"] == DBNull.Value ? null : new Department(
                                    reader["DName"].ToString(),
                                    reader["DShortName"].ToString(),
                                    reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"],
                                    reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"],
                                    (int)reader["DId"]),
                                (DateTime)reader["RegDate"],
                                reader["PermanentLocked"] == DBNull.Value ? null : (DateTime?)reader["PermanentLocked"],
                                (bool)reader["Locked"],
                                reader["DeleteDate"] == DBNull.Value ? null : (DateTime?)reader["DeleteDate"],
                                (int)reader["UId"]);
                        }
                        //Ha van az adott sorban jogosultsági csoport megnevezve
                        if (!reader.IsDBNull(reader.GetOrdinal("GName")))
                        {
                            //Ha a felhasználó jogosultságaihoz az adott csoport még nincs hozzáadva
                            if (user.Permissions.FindIndex(x => x.GId == (int)reader["GId"]) == -1)
                            {
                                user.AddPermission(new PermissionGroup(reader["GName"].ToString(), reader["GDescription"].ToString(), (int)reader["GId"]));
                            }
                            //Ha az adott sorban van egyedi jog megnevezve és az még nincs a jogosultsági csoporthoz adva
                            if (!reader.IsDBNull(reader.GetOrdinal("PName")) && (user.Permissions[user.Permissions.FindIndex(x => x.GId == (int)reader["GId"])] as PermissionGroup).Permissions.FindIndex(x => x.PId == (int)reader["PId"]) == -1)
                            {
                                user.Permissions[user.Permissions.FindIndex(x => x.GId == (int)reader["GId"])].AddPermission(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                            }
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("SysPId")))
                        {
                            //Ha a felhasználó jogosultságaihoz az adott csoport még nincs hozzáadva
                            if (user.ItSystemPermissions.FindIndex(x => x.SysPId == (int)reader["SysPId"]) == -1)
                            {
                                user.AddItSystemPermission(new ItSystemPermission(reader["SysPName"].ToString(), reader["SysPDescription"].ToString(), reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"], (int)reader["SId"], (int)reader["SysPId"]));
                            }
                        }
                    }
                    if (user != null)
                    {
                        userList.Add(user);
                    }
                    reader.Close();
                }
                return userList;
            }
            catch (Exception ex)
            {
                throw new DBException("Felhasználók lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi jogosultsági csoport listázása.
        /// </summary>
        /// <returns>PermissionGroup osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<PermissionGroup> GetGroupsList()
        {
            try
            {
                List<PermissionGroup> groupList = new List<PermissionGroup>();
                cmd.CommandText = "SELECT * FROM [Groups]" +
                "LEFT JOIN [Permissions_Groups] ON [Groups].[GId] = [Permissions_Groups].[GId]" +
                "LEFT JOIN [Permissions] ON [Permissions_Groups].[PId] = [Permissions].[PId]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (groupList.Count == 0 || groupList.FindIndex(x => x.GId == (int)reader["GId"]) == -1) 
                        {
                            groupList.Add(new PermissionGroup(reader["GName"].ToString(), reader["GDescription"].ToString(), (int)reader["GId"]));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("PName")))
                        {
                            groupList[groupList.FindIndex(x => x.GId == (int)reader["GId"])].AddPermission(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                        }
                    }
                    reader.Close();
                }
                return groupList;
            }
            catch (Exception ex)
            {
                throw new DBException("Jogosultsági csoportok lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi jogosultság listázása.
        /// </summary>
        /// <returns>Permission osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<Permission> GetPermissionsList()
        {
            try
            {
                List<Permission> permissionList = new List<Permission>();
                cmd.CommandText = "SELECT * FROM [Permissions]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        permissionList.Add(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                    }
                    reader.Close();
                }
                return permissionList;
            }
            catch (Exception ex)
            {
                throw new DBException("Jogosultságok lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi szervezeti egység listázása.
        /// </summary>
        /// <returns>Department osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<Department> GetDepartmentsList()
        {
            try
            {
                List<Department> departmentList = new List<Department>();
                cmd.CommandText = "SELECT * FROM [Departments]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departmentList.Add(new Department(reader["DName"].ToString(), reader["DShortName"].ToString(), reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"], reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"], (int)reader["DId"]));
                    }
                    reader.Close();
                }
                return departmentList;
            }
            catch (Exception ex)
            {
                throw new DBException("Szervezeti egységek lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szervezeti egység lekérdezése azonosítószám alapján
        /// </summary>
        /// <param name="dId">A keresendő szervezeti egység azonosítószáma</param>
        /// <returns>Department osztályú példány a visszatérés, mely null értékű, ha nincs találat.</returns>
        public static Department GetDepartmentById(int dId)
        {
            try
            {
                Department department = null;
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM [Departments] WHERE [DId] = @dId";
                cmd.Parameters.AddWithValue("@dId", dId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        department = new Department(reader["DName"].ToString(), reader["DShortName"].ToString(), reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"], reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"], (int)reader["DId"]);
                    }
                    reader.Close();
                }
                return department;
            }
            catch (Exception ex)
            {
                throw new DBException("Szervezeti egység lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott rendszernév létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="sName">Az ellenőrizendő rendszernév</param>
        /// <param name="sId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező rendszert ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező név esetén true, egyébként false</returns>
        public static bool IsSNameExists(string sName, int sId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [ItSystems] WHERE [SName] = @sName{(sId != 0 ? " AND [SId] <> @sId;" : ";")}";
                cmd.Parameters.AddWithValue("@sName", sName.Trim());
                if (sId != 0)
                {
                    cmd.Parameters.AddWithValue("@sId", sId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott rövid rendszernév létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="sShortName">Az ellenőrizendő rendszer rövidneve</param>
        /// <param name="sId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező rendszert ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező név esetén true, egyébként false</returns>
        public static bool IsSShortNameExists(string sShortName, int sId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [ItSystems] WHERE [SShortName] = @sShortName{(sId != 0 ? " AND [SId] <> @sId;" : ";")}";
                cmd.Parameters.AddWithValue("@sShortName", sShortName.Trim());
                if (sId != 0)
                {
                    cmd.Parameters.AddWithValue("@sId", sId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott felhasználónév létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="uName">Az ellenőrizendő felhasználónév</param>
        /// <param name="uId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező felhasználót ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező név esetén true, egyébként false</returns>
        public static bool IsUNameExists(string uName, int uId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Users] WHERE [UName] = @uName{(uId != 0 ? " AND [UId] <> @uId;" : ";")}";
                cmd.Parameters.AddWithValue("@uName", uName.Trim());
                if (uId != 0)
                {
                    cmd.Parameters.AddWithValue("@uId", uId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott email címmel rendelkező felhasználó létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="email">Az ellenőrizendő email cím</param>
        /// <param name="uId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező felhasználót ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező email cím esetén true, egyébként false</returns>
        public static bool IsEmailExists(string email, int uId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Users] WHERE [Email] = @email{(uId != 0 ? " AND [UId] <> @uId;" : ";")}";
                cmd.Parameters.AddWithValue("@email", email.Trim());
                if (uId != 0)
                {
                    cmd.Parameters.AddWithValue("@uId", uId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott csoportnév létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="gName">Az ellenőrizendő csoportnév</param>
        /// <param name="gId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező csoportot ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező név esetén true, egyébként false</returns>
        public static bool IsGNameExists(string gName, int gId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Groups] WHERE [GName] = @gName{(gId != 0 ? " AND [GId] <> @gId;" : ";")}";
                cmd.Parameters.AddWithValue("@gName", gName.Trim());
                if (gId != 0)
                {
                    cmd.Parameters.AddWithValue("@gId", gId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott néven és/vagy törzsszámú partner létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="partner">Az ellenőrizendő partner</param>
        /// <param name="partId">Opcionális paraméterként megadható annak a prtnernek az azonosítója, akit figyelmen kívűl kell lehet hagyni a vizsgálat során</param>
        /// <returns>Létező néven és/vagy törzsszámú partner esetén true, egyébként false</returns>
        public static bool IsPartnerExists(Partner partner, int partId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Partners] WHERE ([PartName] = @partName OR [TaxNumber] = @taxNumber) {(partId != 0 ? " AND [PartId] <> @partId; " : "; ")}";
                cmd.Parameters.AddWithValue("@partName", partner.PartName);
                cmd.Parameters.AddWithValue("@taxNumber", partner.TaxNumber);
                if (partId != 0)
                {
                    cmd.Parameters.AddWithValue("@partId", partId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével email cím alapján lekérdezehtőek a felhasználói adatok.
        /// </summary>
        /// <param name="email">A keresendő felhasználó email címe</param>
        /// <returns>User osztályú példány a visszatérés, mely null értékű, ha nincs találat.</returns>
        public static User GetUserByEmail(string email)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT *, [Users].[DId] AS [UserDId], [Groups_Users].[UId] AS [Groups_UsersUId]," +
                    "[Permissions_Groups].[GId] AS [Permissions_GroupsGId], [Permissions_Groups].[PId] AS [Permissions_GroupsPId]," +
                    "[ItSystemPermissions_Users].[UId] AS [ItSysUserUId]  FROM [Users] " +
                    "LEFT JOIN [ItSystemPermissions_Users] ON [Users].[UId] = [ItSystemPermissions_Users].[UId]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystemPermissions_Users].[SysPId] = [ItSystemPermissions].[SysPId]" +
                    "LEFT JOIN [Departments] ON [Users].[DId] = [Departments].[DId]" +
                    "LEFT JOIN [Groups_Users] ON [Users].[UId] = [Groups_Users].[UId]" +
                    "LEFT JOIN [Permissions_Groups] ON [Groups_Users].[GId] = [Permissions_Groups].[GId]" +
                    "LEFT JOIN [Groups] ON [Permissions_Groups].[GId] = [Groups].[GId]" +
                    "LEFT JOIN [Permissions] ON [Permissions_Groups].[PId] = [Permissions].[PId] WHERE [Email] = @email";
                cmd.Parameters.AddWithValue("@email", email.Trim());
                User user = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (user == null)
                        {
                            Department dept = reader["DId"] == DBNull.Value ? null : new Department(reader["DName"].ToString(), reader["DShortName"].ToString(), reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"], reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"], (int)reader["DId"]);
                            DateTime? permanentLocked = reader["PermanentLocked"] == DBNull.Value ? null : (DateTime?)reader["PermanentLocked"];
                            DateTime? deleteDate = reader["DeleteDate"] == DBNull.Value ? null : (DateTime?)reader["DeleteDate"];
                            user = new User(reader["UName"].ToString(), reader["Post"] == DBNull.Value ? null : reader["Post"].ToString(), reader["Email"].ToString(), reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(), dept, (DateTime)reader["RegDate"], permanentLocked, (bool)reader["Locked"], deleteDate, (int)reader["UId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("GName")))
                        {
                            if (user.Permissions.FindIndex(x => x.GId == (int)reader["GId"]) == -1)
                            {
                                user.AddPermission(new PermissionGroup(reader["GName"].ToString(), reader["GDescription"].ToString(), (int)reader["GId"]));
                            }
                            //Ha az adott sorban van egyedi jog megnevezve és az még nincs a jogosultsági csoporthoz adva
                            if (!reader.IsDBNull(reader.GetOrdinal("PName")) && (user.Permissions[user.Permissions.FindIndex(x => x.GId == (int)reader["GId"])] as PermissionGroup).Permissions.FindIndex(x => x.PId == (int)reader["PId"]) == -1)
                            {
                                user.Permissions[user.Permissions.FindIndex(x => x.GId == (int)reader["GId"])].AddPermission(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                            }
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("SysPId")))
                        {
                            if (user.ItSystemPermissions.FindIndex(x => x.SysPId == (int)reader["SysPId"]) == -1)
                            {
                                user.AddItSystemPermission(new ItSystemPermission(reader["SysPName"].ToString(), reader["SysPDescription"].ToString(), reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"], (int)reader["SId"], (int)reader["SysPId"]));
                            }
                        }
                    }
                    reader.Close();
                }
                return user == null || user.DeleteDate != null ? null : user;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével a felhasználóhoz tartozó jelszó megfelelőségét ellenőrizhetjük.
        /// </summary>
        /// <param name="user">A felhasználó, akinek jelszavát ellenőrizzük</param>
        /// <param name="password">A megadott ellenőrizendő jelszó</param>
        /// <param name="failedLoginNum">megadja a konfigurációban rögzített sikertelen bejelentkezések maximális számát</param>
        /// <returns>Jelszó egyezősége esetén true, egyébként false értékkel tér vissza</returns>
        public static bool UserPasswordChecker(User user, string password, out int failedLoginNum)
        {
            try
            {
                string userHashedPassword = String.Empty;
                AppConfiguration conf = GetConfiguration();
                failedLoginNum = conf.FailedLoginNum;
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT [HashedPw] FROM [UserPasswords] WHERE [UId] = @uId";
                cmd.Parameters.AddWithValue("@uId", user.UId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userHashedPassword = reader["HashedPw"].ToString();
                    }
                    reader.Close();
                }
                return Password.StringToHashComparer(password, userHashedPassword);
            }
            catch (Exception ex)
            {
                throw new DBException("Sikertelen bejelentkezés!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció megadja, hogy a felhasználó jelszó érvényességi ideje lejárt-e.
        /// </summary>
        /// <param name="user">A felhasználó, akinek jelszóérvényességi idejét ellenőrizzük</param>
        /// <returns>Lejárt jelszóérvényességi idő esetén true, egyébként false</returns>
        public static bool IsTimeToUpdatePw(User user)
        {
            try
            {
                DateTime? lastModifiedDate = null;
                AppConfiguration conf = GetConfiguration();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT [PwModifiedDate] FROM [UserPasswords] WHERE [UId] = @uId";
                cmd.Parameters.AddWithValue("@uId", user.UId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lastModifiedDate = reader["PwModifiedDate"] == DBNull.Value ? null : (DateTime?)reader["PwModifiedDate"];
                    }
                    reader.Close();
                }
                if (conf.PwValidityPeriod > 0)
                {
                    return lastModifiedDate == null || DBManager.GetCurrentTime().CompareTo(lastModifiedDate.Value.AddDays(conf.PwValidityPeriod)) > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new DBException("Sikertelen bejelentkezés!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével rendszer azonosítója alapján lekérdezhető a rendszer példánya.
        /// </summary>
        /// <param name="sId">A keresendő rendszer azonosító száma</param>
        /// <returns>ItSystem osztályú példány a visszatérés, mely null értékű, ha nincs találat.</returns>
        public static ItSystem GetItSystemById(int sId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT *, [ItSystemPermissions].[SId] AS [PerSID] FROM [ItSystems]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystems].[SId] = [ItSystemPermissions].[SId] WHERE [ItSystems].[SId] = @sId";
                cmd.Parameters.AddWithValue("@sId", sId);
                ItSystem itSystem = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (itSystem == null)
                        {
                            itSystem = new ItSystem(
                                reader["SName"].ToString(),
                                reader["SShortName"].ToString(),
                                reader["Version"].ToString(),
                                (int)reader["LicenseNumber"],
                                (SystemLifeCycle)(int)reader["LifeCycle"],
                                (byte)reader["Confidentiality"],
                                (byte)reader["Integrity"],
                                (byte)reader["Availability"],
                                (StoredDataType)(int)reader["DataType"],
                                reader["SDescription"].ToString(),
                                reader["InnerDataOwner"] == DBNull.Value ? 0 : (int)reader["InnerDataOwner"],
                                reader["AdminUser"] == DBNull.Value ? 0 : (int)reader["AdminUser"],
                                reader["InterfaceDesc"].ToString(),
                                reader["ProviderPartner"] == DBNull.Value ? 0 : (int)reader["ProviderPartner"],
                                reader["ProviderContact"] == DBNull.Value ? 0 : (int)reader["ProviderContact"],
                                reader["OperatorPartner"] == DBNull.Value ? 0 : (int)reader["OperatorPartner"],
                                reader["OperatorContact"] == DBNull.Value ? 0 : (int)reader["OperatorContact"],
                                (short)reader["RPO"],
                                (short)reader["RTO"],
                                (short)reader["CRT"],
                                (short)reader["ERT"],
                                reader["CriticalPeriod"].ToString(),
                                (int)reader["SId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("SysPId")))
                        {
                            itSystem.AddPermission(new ItSystemPermission(
                                reader["SysPName"].ToString(),
                                reader["SysPDescription"].ToString(),
                                reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"],
                                (int)reader["PerSID"],
                                (int)reader["SysPId"]));
                        }
                    }
                    reader.Close();
                }

                return itSystem;
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszer lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével felhasználó azonosítója alapján lekérdezhetőek a felhasználói adatok.
        /// </summary>
        /// <param name="uId">A keresendő felhasználó azonosító száma</param>
        /// <returns>User osztályú példány a visszatérés, mely null értékű, ha nincs találat.</returns>
        public static User GetUserById(int uId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT *, [Users].[DId] AS [UserDId], [Groups_Users].[UId] AS [Groups_UsersUId]," +
                    "[Permissions_Groups].[GId] AS [Permissions_GroupsGId], [Permissions_Groups].[PId] AS [Permissions_GroupsPId]," +
                    "[ItSystemPermissions_Users].[UId] AS [ItSysUserUId]  FROM [Users] " +
                    "LEFT JOIN [ItSystemPermissions_Users] ON [Users].[UId] = [ItSystemPermissions_Users].[UId]" +
                    "LEFT JOIN [ItSystemPermissions] ON [ItSystemPermissions_Users].[SysPId] = [ItSystemPermissions].[SysPId]" +
                    "LEFT JOIN [Departments] ON [Users].[DId] = [Departments].[DId]" +
                    "LEFT JOIN [Groups_Users] ON [Users].[UId] = [Groups_Users].[UId]" +
                    "LEFT JOIN [Permissions_Groups] ON [Groups_Users].[GId] = [Permissions_Groups].[GId]" +
                    "LEFT JOIN [Groups] ON [Permissions_Groups].[GId] = [Groups].[GId]" +
                    "LEFT JOIN [Permissions] ON [Permissions_Groups].[PId] = [Permissions].[PId] WHERE [Users].[UId] = @uId";
                cmd.Parameters.AddWithValue("@uId", uId);
                User user = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (user == null)
                        {
                            Department dept = reader["DId"] == DBNull.Value ? null : new Department(reader["DName"].ToString(), reader["DShortName"].ToString(), reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"], reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"], (int)reader["DId"]);
                            DateTime? permanentLocked = reader["PermanentLocked"] == DBNull.Value ? null : (DateTime?)reader["PermanentLocked"];
                            DateTime? deleteDate = reader["DeleteDate"] == DBNull.Value ? null : (DateTime?)reader["DeleteDate"];
                            user = new User(reader["UName"].ToString(), reader["Post"] == DBNull.Value ? null : reader["Post"].ToString(), reader["Email"].ToString(), reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(), dept, (DateTime)reader["RegDate"], permanentLocked, (bool)reader["Locked"], deleteDate, (int)reader["UId"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("GName")))
                        {
                            if (user.Permissions.FindIndex(x => x.GId == (int)reader["GId"]) == -1)
                            {
                                user.AddPermission(new PermissionGroup(reader["GName"].ToString(), reader["GDescription"].ToString(), (int)reader["GId"]));
                            }
                            //Ha az adott sorban van egyedi jog megnevezve és az még nincs a jogosultsági csoporthoz adva
                            if (!reader.IsDBNull(reader.GetOrdinal("PName")) && (user.Permissions[user.Permissions.FindIndex(x => x.GId == (int)reader["GId"])] as PermissionGroup).Permissions.FindIndex(x => x.PId == (int)reader["PId"]) == -1)
                            {
                                user.Permissions[user.Permissions.FindIndex(x => x.GId == (int)reader["GId"])].AddPermission(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                            }
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("SysPId")))
                        {
                            if (user.ItSystemPermissions.FindIndex(x => x.SysPId == (int)reader["SysPId"]) == -1)
                            {
                                user.AddItSystemPermission(new ItSystemPermission(reader["SysPName"].ToString(), reader["SysPDescription"].ToString(), reader["SuperiorSysPId"] == DBNull.Value ? 0 : (int)reader["SuperiorSysPId"], (int)reader["SId"], (int)reader["SysPId"]));
                            }
                        }
                    }
                    reader.Close();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott szervezetiegység név létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="dName">Az ellenőrizendő név</param>
        /// <param name="dId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező szervezeti egységet ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező név esetén true, egyébként false</returns>
        public static bool IsDNameExists(string dName, int dId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Departments] WHERE [DName] = @dName{(dId != 0 ? " AND [DId] <> @dId;" : ";")}";
                cmd.Parameters.AddWithValue("@dName", dName.Trim());
                if (dId != 0)
                {
                    cmd.Parameters.AddWithValue("@dId", dId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// A funkció segítségével lekérdezhető, hogy adott szervezetiegység rövid név létezik-e már az adatbázisban vagy sem.
        /// </summary>
        /// <param name="dShortName">Az ellenőrizendő rövid név</param>
        /// <param name="dId">Opcionális paraméter, mellyel megadhatjuk, hogy adott id-val rendelkező szervezeti egységet ne vegyen figyelembe a keresés során</param>
        /// <returns>Létező rövid név esetén true, egyébként false</returns>
        public static bool IsDShortNameExists(string dShortName, int dId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = $"SELECT * FROM [Departments] WHERE [DShortName] = @dShortName{(dId != 0 ? " AND [DId] <> @dId;" : ";")}";
                cmd.Parameters.AddWithValue("@dShortName", dShortName.Trim());
                if (dId != 0)
                {
                    cmd.Parameters.AddWithValue("@dId", dId);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                return exists;
            }
            catch (Exception ex)
            {
                throw new DBException("Lekérdezés sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Valamennyi naplóbejegyzés listázása.
        /// </summary>
        /// <returns>SystemLog osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<SystemLog> GetLogsList()
        {
            try
            {
                List<SystemLog> logList = new List<SystemLog>();
                cmd.CommandText = "SELECT *, [Logs].[UId] AS [LogUId], [Users].[DId] AS [UserDId], [Groups_Users].[UId] AS [Groups_UsersUId]," +
                    "[Permissions_Groups].[GId] AS [Permissions_GroupsGId], [Permissions_Groups].[PId] AS [Permissions_GroupsPId] FROM [Logs]" +
                    "LEFT JOIN [Users] ON [Logs].[UId] = [Users].[UId]" +
                    "LEFT JOIN [Departments] ON [Users].[DId] = [Departments].[DId]" +
                    "LEFT JOIN [Groups_Users] ON [Users].[UId] = [Groups_Users].[UId]" +
                    "LEFT JOIN [Permissions_Groups] ON [Groups_Users].[GId] = [Permissions_Groups].[GId]" +
                    "LEFT JOIN [Groups] ON [Permissions_Groups].[GId] = [Groups].[GId]" +
                    $"LEFT JOIN [Permissions] ON [Permissions_Groups].[PId] = [Permissions].[PId];";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    SystemLog log = null;
                    while (reader.Read())
                    {
                        if (log == null || log.LogId != (int)reader["LogId"])
                        {
                            if (log != null)
                            {
                                logList.Add(log);
                            }
                            Department dept = reader["DId"] == DBNull.Value ? null : new Department(reader["DName"].ToString(), reader["DShortName"].ToString(), reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"], reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"], (int)reader["DId"]);
                            DateTime? permanentLocked = reader["PermanentLocked"] == DBNull.Value ? null : (DateTime?)reader["PermanentLocked"];
                            DateTime? deleteDate = reader["DeleteDate"] == DBNull.Value ? null : (DateTime?)reader["DeleteDate"];
                            log = new SystemLog(new User(reader["UName"].ToString(), reader["Post"] == DBNull.Value ? null : reader["Post"].ToString(), reader["Email"].ToString(), reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(), dept, (DateTime)reader["RegDate"], permanentLocked, (bool)reader["Locked"], deleteDate, (int)reader["UId"]), reader["EventDesc"].ToString(), (EventType)(int)reader["EventType"], (DateTime)reader["Date"], (int)reader["LogId"]);

                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("GName")))
                        {
                            //Ha a felhasználó jogosultságaihoz az adott csoport még nincs hozzáadva
                            if (log.User.Permissions.FindIndex(x => x.GId == (int)reader["GId"]) == -1)
                            {
                                log.User.AddPermission(new PermissionGroup(reader["GName"].ToString(), reader["GDescription"].ToString(), (int)reader["GId"]));
                            }
                            //Ha az adott sorban van egyedi jog megnevezve és az még nincs a jogosultsági csoporthoz adva
                            if (!reader.IsDBNull(reader.GetOrdinal("PName")) && (log.User.Permissions[log.User.Permissions.FindIndex(x => x.GId == (int)reader["GId"])] as PermissionGroup).Permissions.FindIndex(x => x.PId == (int)reader["PId"]) == -1)
                            {
                                log.User.Permissions[log.User.Permissions.FindIndex(x => x.GId == (int)reader["GId"])].AddPermission(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                            }
                        }
                    }
                    if (log != null)
                    {
                        logList.Add(log);
                    }
                    reader.Close();
                }
                return logList;
            }
            catch (Exception ex)
            {
                throw new DBException("Felhasználók lekérdezése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szűrt naplóbejegyzések listázása.
        /// </summary>
        /// <returns>SystemLog osztályú példányokat tartalmazó listával tér vissza.</returns>
        public static List<SystemLog> GetFilteredLogsList(int rowsPerPage, int pageNum, DateTime? dateFrom, DateTime? dateTo, int uId, EventType? evType, out int sumResultsNumber)
        {
            try
            {
                //Az összes találat száma
                List<SystemLog> logList = new List<SystemLog>();
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "SELECT COUNT([LogId]) FROM [Logs] WHERE 0 = 0";
                string filterCondition = String.Empty;
                if (dateFrom != null)
                {
                    filterCondition += " AND [Date] >= @dateFrom";
                    cmd.Parameters.AddWithValue("@dateFrom", (DateTime)dateFrom);
                }
                if (dateTo != null)
                {
                    filterCondition += " AND [Date] <= @dateTo";
                    cmd.Parameters.AddWithValue("@dateTo", (DateTime)dateTo);
                }
                if (uId != 0)
                {
                    filterCondition += " AND [Logs].[UId] = @uId";
                    cmd.Parameters.AddWithValue("@uId", uId);
                }
                if (evType != null && Enum.IsDefined(typeof(EventType), evType))
                {
                    filterCondition += " AND [EventType] = @evType";
                    cmd.Parameters.AddWithValue("@evType", (int)evType);
                }
                cmd.CommandText += filterCondition;
                sumResultsNumber = (int)cmd.ExecuteScalar();
                //A bejegyzések lekérdezése
                cmd.CommandText = "SELECT *, [Logs].[UId] AS [LogUId], [Users].[DId] AS [UserDId], [Groups_Users].[UId] AS [Groups_UsersUId]," +
                    "[Permissions_Groups].[GId] AS [Permissions_GroupsGId], [Permissions_Groups].[PId] AS [Permissions_GroupsPId] FROM [Logs]" +
                    "LEFT JOIN [Users] ON [Logs].[UId] = [Users].[UId]" +
                    "LEFT JOIN [Departments] ON [Users].[DId] = [Departments].[DId]" +
                    "LEFT JOIN [Groups_Users] ON [Users].[UId] = [Groups_Users].[UId]" +
                    "LEFT JOIN [Permissions_Groups] ON [Groups_Users].[GId] = [Permissions_Groups].[GId]" +
                    "LEFT JOIN [Groups] ON [Permissions_Groups].[GId] = [Groups].[GId]" +
                    "LEFT JOIN [Permissions] ON [Permissions_Groups].[PId] = [Permissions].[PId] WHERE" +
                    $"[LogId] = ANY(SELECT TOP (@rowsPerPage) [LogId] FROM [Logs] WHERE [LogId] < ALL(SELECT TOP (@prevLogs) [LogId] FROM [Logs] WHERE 0 = 0 {filterCondition} ORDER BY [Date] DESC) {filterCondition} ORDER BY [Date] DESC) ORDER BY [Date] DESC, [LogId] DESC";
                cmd.Parameters.AddWithValue("@rowsPerPage", rowsPerPage);
                cmd.Parameters.AddWithValue("@prevLogs", (pageNum - 1) * rowsPerPage);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    SystemLog log = null;
                    while (reader.Read())
                    {
                        if (log == null || log.LogId != (int)reader["LogId"])
                        {
                            if (log != null)
                            {
                                logList.Add(log);
                            }
                            Department dept = reader["DId"] == DBNull.Value ? null : new Department(reader["DName"].ToString(), reader["DShortName"].ToString(), reader["ManagerId"] == DBNull.Value ? 0 : (int)reader["ManagerId"], reader["SuperiorDId"] == DBNull.Value ? 0 : (int)reader["SuperiorDId"], (int)reader["DId"]);
                            DateTime? permanentLocked = reader["PermanentLocked"] == DBNull.Value ? null : (DateTime?)reader["PermanentLocked"];
                            DateTime? deleteDate = reader["DeleteDate"] == DBNull.Value ? null : (DateTime?)reader["DeleteDate"];
                            log = new SystemLog(new User(reader["UName"].ToString(), reader["Post"] == DBNull.Value ? null : reader["Post"].ToString(), reader["Email"].ToString(), reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(), dept, (DateTime)reader["RegDate"], permanentLocked, (bool)reader["Locked"], deleteDate, (int)reader["LogUId"]), reader["EventDesc"].ToString(), (EventType)(int)reader["EventType"], (DateTime)reader["Date"], (int)reader["LogId"]);

                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("GName")))
                        {
                            //Ha a felhasználó jogosultságaihoz az adott csoport még nincs hozzáadva
                            if (log.User.Permissions.FindIndex(x => x.GId == (int)reader["GId"]) == -1)
                            {
                                log.User.AddPermission(new PermissionGroup(reader["GName"].ToString(), reader["GDescription"].ToString(), (int)reader["GId"]));
                            }
                            //Ha az adott sorban van egyedi jog megnevezve és az még nincs a jogosultsági csoporthoz adva
                            if (!reader.IsDBNull(reader.GetOrdinal("PName")) && (log.User.Permissions[log.User.Permissions.FindIndex(x => x.GId == (int)reader["GId"])] as PermissionGroup).Permissions.FindIndex(x => x.PId == (int)reader["PId"]) == -1)
                            {
                                log.User.Permissions[log.User.Permissions.FindIndex(x => x.GId == (int)reader["GId"])].AddPermission(new Permission(reader["PName"].ToString(), reader["PDescription"].ToString(), (int)reader["PId"]));
                            }
                        }
                    }
                    if (log != null)
                    {
                        logList.Add(log);
                    }
                    reader.Close();
                }
                cmd.Transaction.Commit();
                return logList;

            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Naplóbejegyzések lekérdezése sikertelen!", ex.Message);
            }
        }
        #endregion
        #region Update data
        /// <summary>
        /// Karbantartási naplóbejegyzés adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedMaintenance">Frissített adatokat tartalmazó bejegyzés MaintenanceLog példánya</param>
        public static void UpdateMaintenanceLog(MaintenanceLog modifiedMaintenance)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "UPDATE [MaintenanceLogs] SET [EndDate] = @endDate, [ActivitiesDesc] = @activitiesDesc, [DocLink] = @docLink, [MName] = @mName WHERE [LogId] = @logId";
                cmd.Parameters.AddWithValue("@logId", modifiedMaintenance.LogId);
                cmd.Parameters.AddWithValue("@endDate", modifiedMaintenance.EndDate != null ? (DateTime)modifiedMaintenance.EndDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@activitiesDesc", modifiedMaintenance.ActivitiesDesc);
                cmd.Parameters.AddWithValue("@docLink", String.IsNullOrEmpty(modifiedMaintenance.DocLink) ? (object)DBNull.Value : modifiedMaintenance.DocLink);
                cmd.Parameters.AddWithValue("@mName", modifiedMaintenance.MName);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [MaintenanceLogs_Hardwares] WHERE [LogId] = @logId;";
                cmd.Parameters.AddWithValue("@logId", modifiedMaintenance.LogId);
                cmd.ExecuteNonQuery();
                foreach (int item in modifiedMaintenance.AffectedComponentsId)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [MaintenanceLogs_Hardwares] VALUES (@logId, @hardId);";
                    cmd.Parameters.AddWithValue("@logId", modifiedMaintenance.LogId);
                    cmd.Parameters.AddWithValue("@hardId", item);
                    cmd.ExecuteNonQuery();
                }
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [MaintenanceLogs_ItSystems] WHERE [LogId] = @logId;";
                cmd.Parameters.AddWithValue("@logId", modifiedMaintenance.LogId);
                cmd.ExecuteNonQuery();
                foreach (int item in modifiedMaintenance.AffectedItSystemsId)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [MaintenanceLogs_ItSystems] VALUES (@logId, @itSId);";
                    cmd.Parameters.AddWithValue("@logId", modifiedMaintenance.LogId);
                    cmd.Parameters.AddWithValue("@itSId", item);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Karbantartási naplóbejegyzés adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szoftver adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedSoftware">Frissített adatokat tartalmazó szoftver Software példánya</param>
        public static void UpdateSoftware(Software modifiedSoftware)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "UPDATE [Softwares] SET [SoftwareProducer] = @softwareProducer, [SoftwareDesc] = @softwareDesc, [SoftwareLicenseNum] = @softwareLicenseNum, [LicenseDate] = @licenseDate, [ProductKey] = @productKey WHERE [AId] = @aId";
                cmd.Parameters.AddWithValue("@aId", modifiedSoftware.AId);
                cmd.Parameters.AddWithValue("@softwareProducer", String.IsNullOrEmpty(modifiedSoftware.SoftwareProducer) ? (object)DBNull.Value : modifiedSoftware.SoftwareProducer);
                cmd.Parameters.AddWithValue("@softwareDesc", String.IsNullOrEmpty(modifiedSoftware.SoftwareDesc) ? (object)DBNull.Value : modifiedSoftware.SoftwareDesc);
                cmd.Parameters.AddWithValue("@softwareLicenseNum", modifiedSoftware.SoftwareLicenseNum);
                cmd.Parameters.AddWithValue("@licenseDate", modifiedSoftware.LicenseDate != null ? (DateTime)modifiedSoftware.LicenseDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@productKey", String.IsNullOrEmpty(modifiedSoftware.ProductKey) ? (object)DBNull.Value : modifiedSoftware.ProductKey);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [Softwares_Hardwares] WHERE [SoftAId] = @softAId;";
                cmd.Parameters.AddWithValue("@softAId", modifiedSoftware.AId);
                cmd.ExecuteNonQuery();
                foreach (int item in modifiedSoftware.HardwareIds)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [Softwares_Hardwares] VALUES (@softAId, @hardAId);";
                    cmd.Parameters.AddWithValue("@softAId", modifiedSoftware.AId);
                    cmd.Parameters.AddWithValue("@hardAId", item);
                    cmd.ExecuteNonQuery();
                }
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [ItAssets] SET [AName] = @aName, [PurchaseDate] = @purchaseDate, [OwnerId] = @ownerId, [Status] = @status, [DocLink] = @docLink, [ScrappingDate] = @scrappingDate, [OtherDescription] = @otherDescription WHERE [AId] = @aId";
                cmd.Parameters.AddWithValue("@aId", modifiedSoftware.AId);
                cmd.Parameters.AddWithValue("@aName", modifiedSoftware.AName);
                cmd.Parameters.AddWithValue("@purchaseDate", modifiedSoftware.PurchaseDate);
                cmd.Parameters.AddWithValue("@ownerId", modifiedSoftware.Owner == null ? (object)DBNull.Value : modifiedSoftware.Owner.DId);
                cmd.Parameters.AddWithValue("@status", (int)modifiedSoftware.Status);
                cmd.Parameters.AddWithValue("@docLink", String.IsNullOrEmpty(modifiedSoftware.DocLink) ? (object)DBNull.Value : modifiedSoftware.DocLink);
                cmd.Parameters.AddWithValue("@scrappingDate", modifiedSoftware.ScrappingDate != null ? (DateTime)modifiedSoftware.ScrappingDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@otherDescription", String.IsNullOrEmpty(modifiedSoftware.OtherDescription) ? (object)DBNull.Value : modifiedSoftware.OtherDescription);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [ItAssets_ItSystems] WHERE [AId] = @aId;";
                cmd.Parameters.AddWithValue("@aId", modifiedSoftware.AId);
                cmd.ExecuteNonQuery();
                foreach (ItSystem item in modifiedSoftware.ItSystems)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [ItAssets_ItSystems] VALUES (@aId, @sId);";
                    cmd.Parameters.AddWithValue("@aId", modifiedSoftware.AId);
                    cmd.Parameters.AddWithValue("@sId", item.SId);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Szoftver adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Hardver adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedHardware">Frissített adatokat tartalmazó hardver Hardware példánya</param>
        public static void UpdateHardware(Hardware modifiedHardware)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                if (modifiedHardware is NetActiveDevice nad)
                {
                    cmd.CommandText = "DELETE FROM [IPv4Addresses] WHERE [NicId] = ANY(SELECT [NicId] FROM [NICs] WHERE [AId] = @aId); DELETE FROM [NICs] WHERE [AId] = @aId;";
                    cmd.Parameters.AddWithValue("@aId", nad.AId);
                    cmd.ExecuteNonQuery();
                    foreach (NIC item in nad.NicsList)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [NICs] OUTPUT INSERTED.[NicId] VALUES (@macAddressData, @nicType, @ipv4Addressing, @aId);";
                        cmd.Parameters.AddWithValue("@macAddressData", item.MacAddressData);
                        cmd.Parameters.AddWithValue("@nicType", (int)item.NicType);
                        cmd.Parameters.AddWithValue("@ipv4Addressing", (int)item.Ipv4Addressing);
                        cmd.Parameters.AddWithValue("@aId", nad.AId);
                        int nicId = -1;
                        nicId = (int)cmd.ExecuteScalar();
                        if (nicId != -1)
                        {
                            foreach (IPv4Address ipv4 in item.Ipv4Addresses)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "INSERT INTO [IPv4Addresses] VALUES (@nicId, @ipv4Address, @subnetMask);";
                                cmd.Parameters.AddWithValue("@nicId", nicId);
                                cmd.Parameters.AddWithValue("@ipv4Address", ipv4.Ipv4.GetAddressBytes());
                                cmd.Parameters.AddWithValue("@subnetMask", ipv4.SubnetMask.GetAddressBytes());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            throw new Exception("Hálózati adapter rögzítése sikertelen!");
                        }
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE [NetActiveDevices] SET [HostName] = @hostName WHERE [AId] = @aId";
                    cmd.Parameters.AddWithValue("@hostName", String.IsNullOrEmpty(nad.HostName) ? (object)DBNull.Value : nad.HostName);
                    cmd.Parameters.AddWithValue("@aId", nad.AId);
                    cmd.ExecuteNonQuery();
                    if (nad is ComputerDevice comp)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE [ComputerDevices] SET [Processor] = @processor, [Ram] = @ram, [StorageCapacity] = @storageCapacity, [OtherComponent] = @processor WHERE [AId] = @aId";
                        cmd.Parameters.AddWithValue("@aId", comp.AId);
                        cmd.Parameters.AddWithValue("@processor", String.IsNullOrEmpty(comp.Processor) ? (object)DBNull.Value : comp.Processor);
                        cmd.Parameters.AddWithValue("@ram", comp.Ram);
                        cmd.Parameters.AddWithValue("@storageCapacity", comp.StorageCapacity);
                        cmd.Parameters.AddWithValue("@otherComponent", String.IsNullOrEmpty(comp.OtherComponent) ? (object)DBNull.Value : comp.OtherComponent);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (modifiedHardware is DataStorageDevice dsd)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE [DataStorageDevices] SET [StorageCapacity] = @storageCapacity, [Encrypted] = @encrypted, [RecoveryKey] = @recoveryKey WHERE [AId] = @aId";
                    cmd.Parameters.AddWithValue("@storageCapacity", dsd.StorageCapacity);
                    cmd.Parameters.AddWithValue("@encrypted", dsd.Encrypted);
                    cmd.Parameters.AddWithValue("@recoveryKey", String.IsNullOrEmpty(dsd.RecoveryKey) ? (object)DBNull.Value : dsd.RecoveryKey);
                    cmd.Parameters.AddWithValue("@aId", dsd.AId);
                    cmd.ExecuteNonQuery();
                }
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [Hardwares] SET [UId] = @uId, [Place] = @place, [WarrantyYears] = @warrantyYears, [Category] = @category, [HardwareType] = @hardwareType WHERE [AId] = @aId";
                cmd.Parameters.AddWithValue("@aId", modifiedHardware.AId);
                cmd.Parameters.AddWithValue("@uId", modifiedHardware.UId == 0 ? (object)DBNull.Value : modifiedHardware.UId);
                cmd.Parameters.AddWithValue("@place", String.IsNullOrEmpty(modifiedHardware.Place) ? (object)DBNull.Value : modifiedHardware.Place);
                cmd.Parameters.AddWithValue("@warrantyYears", modifiedHardware.WarrantyYears);
                cmd.Parameters.AddWithValue("@category", modifiedHardware.Category);
                cmd.Parameters.AddWithValue("@hardwareType", (int)modifiedHardware.HardwareType);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [ItAssets] SET [AName] = @aName, [PurchaseDate] = @purchaseDate, [OwnerId] = @ownerId, [Status] = @status, [DocLink] = @docLink, [ScrappingDate] = @scrappingDate, [OtherDescription] = @otherDescription WHERE [AId] = @aId";
                cmd.Parameters.AddWithValue("@aId", modifiedHardware.AId);
                cmd.Parameters.AddWithValue("@aName", modifiedHardware.AName);
                cmd.Parameters.AddWithValue("@purchaseDate", modifiedHardware.PurchaseDate);
                cmd.Parameters.AddWithValue("@ownerId", modifiedHardware.Owner == null ? (object)DBNull.Value : modifiedHardware.Owner.DId);
                cmd.Parameters.AddWithValue("@status", (int)modifiedHardware.Status);
                cmd.Parameters.AddWithValue("@docLink", String.IsNullOrEmpty(modifiedHardware.DocLink) ? (object)DBNull.Value : modifiedHardware.DocLink);
                cmd.Parameters.AddWithValue("@scrappingDate", modifiedHardware.ScrappingDate != null ? (DateTime)modifiedHardware.ScrappingDate : SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@otherDescription", String.IsNullOrEmpty(modifiedHardware.OtherDescription) ? (object)DBNull.Value : modifiedHardware.OtherDescription);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [ItAssets_ItSystems] WHERE [AId] = @aId;";
                cmd.Parameters.AddWithValue("@aId", modifiedHardware.AId);
                cmd.ExecuteNonQuery();
                foreach (ItSystem item in modifiedHardware.ItSystems)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [ItAssets_ItSystems] VALUES (@aId, @sId);";
                    cmd.Parameters.AddWithValue("@aId", modifiedHardware.AId);
                    cmd.Parameters.AddWithValue("@sId", item.SId);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Hardver adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Rendszerjogosultság frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedPermission">Frissített rendszerjogosultság példánya</param>
        public static void UpdateItSystemPermission(ItSystemPermission modifiedPermission)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [ItSystemPermissions] SET [SysPName] = @sysPName, [SysPDescription] = @sysPDescription, [SuperiorSysPId] = @superiorSysPId WHERE [SysPId] = @sysPId";
                cmd.Parameters.AddWithValue("@sysPName", modifiedPermission.SysPName);
                cmd.Parameters.AddWithValue("@sysPDescription", String.IsNullOrEmpty(modifiedPermission.SysPDescription) ? (object)DBNull.Value : modifiedPermission.SysPDescription);
                cmd.Parameters.AddWithValue("@superiorSysPId", modifiedPermission.SuperiorSysPId == 0 ? (object)DBNull.Value : modifiedPermission.SuperiorSysPId);
                cmd.Parameters.AddWithValue("@sysPId", modifiedPermission.SysPId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszerjogosultság frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Partner adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedPartner">Frissített adatokat tartalmazó Partner példány</param>
        /// <param name="newContactId">Új kapcsolatartó rögzítése esetén annak azonosítószámát adja meg</param>
        public static void UpdatePartner(Partner modifiedPartner, out int newContactId)
        {
            try
            {
                newContactId = 0;
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "UPDATE [Partners] SET [PartName] = @partName, [TaxNumber] = @taxNumber WHERE [PartId] = @partId";
                cmd.Parameters.AddWithValue("@partName", modifiedPartner.PartName);
                cmd.Parameters.AddWithValue("@taxNumber", modifiedPartner.TaxNumber);
                cmd.Parameters.AddWithValue("@partId", modifiedPartner.PartId);
                cmd.ExecuteNonQuery();
                foreach (Contact item in modifiedPartner.Contacts)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@contName", item.ContName);
                    cmd.Parameters.AddWithValue("@email", item.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@address", item.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", item.Phone ?? (object)DBNull.Value);
                    if (item.ContId == 0)
                    {
                        cmd.CommandText = "INSERT INTO [Contacts] OUTPUT INSERTED.[ContId] VALUES (@contName, @email, @address, @phone, @partId);";
                        cmd.Parameters.AddWithValue("@partId", modifiedPartner.PartId);
                        newContactId = (int)cmd.ExecuteScalar();
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE [Contacts] SET [ContName]=@contName, [Email]=@email, [Address]=@address, [Phone]=@phone WHERE [ContId]=@contId;";
                        cmd.Parameters.AddWithValue("@contId", item.ContId);
                        cmd.ExecuteNonQuery();
                    }
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Partner adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Rendszer adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedItSystem">Frissített rendszer ItSystem példánya</param>
        public static void UpdateItSystem(ItSystem modifiedItSystem)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [ItSystems] SET [SName] = @sName, [SShortName] = @sShortName, [Version] = @version, [LicenseNumber] = @licenseNumber, [LifeCycle] = @lifeCycle, [Confidentiality] = @confidentiality, [Integrity] = @integrity, [Availability] = @availability, [DataType] = @dataType, [SDescription] = @sDescription, [InnerDataOwner] = @innerDataOwner, [AdminUser] = @adminUser, [InterfaceDesc] = @interfaceDesc, [ProviderPartner] = @providerPartner, [ProviderContact] = @providerContact, [OperatorPartner] = @operatorPartner, [OperatorContact] = @operatorContact, [RPO] = @rpo, [RTO] = @rto, [CRT] = @crt, [ERT] = @ert, [CriticalPeriod] = @criticalPeriod WHERE [SId] = @sId";
                cmd.Parameters.AddWithValue("@sName", modifiedItSystem.SName);
                cmd.Parameters.AddWithValue("@sShortName", modifiedItSystem.SShortName);
                cmd.Parameters.AddWithValue("@version", String.IsNullOrEmpty(modifiedItSystem.Version) ? (object)DBNull.Value : modifiedItSystem.Version);
                cmd.Parameters.AddWithValue("@licenseNumber", modifiedItSystem.LicenseNumber);
                cmd.Parameters.AddWithValue("@lifeCycle", (int)modifiedItSystem.LifeCycle);
                cmd.Parameters.AddWithValue("@confidentiality", modifiedItSystem.Confidentiality);
                cmd.Parameters.AddWithValue("@integrity", modifiedItSystem.Integrity);
                cmd.Parameters.AddWithValue("@availability", modifiedItSystem.Availability);
                cmd.Parameters.AddWithValue("@dataType", (int)modifiedItSystem.DataType);
                cmd.Parameters.AddWithValue("@sDescription", modifiedItSystem.SDescription);
                cmd.Parameters.AddWithValue("@innerDataOwner", modifiedItSystem.InnerDataOwner == 0 ? (object)DBNull.Value : modifiedItSystem.InnerDataOwner);
                cmd.Parameters.AddWithValue("@adminUser", modifiedItSystem.AdminUser == 0 ? (object)DBNull.Value : modifiedItSystem.AdminUser);
                cmd.Parameters.AddWithValue("@interfaceDesc", String.IsNullOrEmpty(modifiedItSystem.InterfaceDesc) ? (object)DBNull.Value : modifiedItSystem.InterfaceDesc);
                cmd.Parameters.AddWithValue("@providerPartner", modifiedItSystem.ProviderPartner == 0 ? (object)DBNull.Value : modifiedItSystem.ProviderPartner);
                cmd.Parameters.AddWithValue("@providerContact", modifiedItSystem.ProviderContact == 0 ? (object)DBNull.Value : modifiedItSystem.ProviderContact);
                cmd.Parameters.AddWithValue("@operatorPartner", modifiedItSystem.OperatorPartner == 0 ? (object)DBNull.Value : modifiedItSystem.OperatorPartner);
                cmd.Parameters.AddWithValue("@operatorContact", modifiedItSystem.OperatorContact == 0 ? (object)DBNull.Value : modifiedItSystem.OperatorContact);
                cmd.Parameters.AddWithValue("@rpo", modifiedItSystem.Rpo);
                cmd.Parameters.AddWithValue("@rto", modifiedItSystem.Rto);
                cmd.Parameters.AddWithValue("@crt", modifiedItSystem.Crt);
                cmd.Parameters.AddWithValue("@ert", modifiedItSystem.Ert);
                cmd.Parameters.AddWithValue("@criticalPeriod", modifiedItSystem.CriticalPeriod);
                cmd.Parameters.AddWithValue("@sId", modifiedItSystem.SId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Rendszer adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Beállítások adatbázisban való frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedConf">Frissített beállítások Configuration példánya</param>
        public static void UpdateConfiguration(AppConfiguration modifiedConf)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [Configurations] SET [PwValidityPeriod] = @validityPeriod, [PwLength] = @length, [PwComplexity] = @complexity, [FailedLoginNum] = @loginNum, [PermanentLockingPeriod] = @lockingPeriod, [EnableEmail] = @enableEmail, [SmtpServer] = @smtpServer, [Port] = @port, [EnableSSL] = @enableSSL, [EmailAddress] = @emailAddress, [SmtpUserName] = @smtpUserName, [SmtpPassword] = @smtpPassword, [RetentionDays] = @retentionDays";
                cmd.Parameters.AddWithValue("@validityPeriod", modifiedConf.PwValidityPeriod);
                cmd.Parameters.AddWithValue("@length", modifiedConf.PwLength);
                cmd.Parameters.AddWithValue("@complexity", (int)modifiedConf.PwComplexity);
                cmd.Parameters.AddWithValue("@loginNum", modifiedConf.FailedLoginNum);
                cmd.Parameters.AddWithValue("@lockingPeriod", modifiedConf.PermanentLockingPeriod);
                cmd.Parameters.AddWithValue("@enableEmail", modifiedConf.EnableEmail);
                cmd.Parameters.AddWithValue("@smtpServer", modifiedConf.SmtpServer ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@port", modifiedConf.Port);
                cmd.Parameters.AddWithValue("@enableSSL", modifiedConf.EnableSSL);
                cmd.Parameters.AddWithValue("@emailAddress", modifiedConf.EmailAddress ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@smtpUserName", modifiedConf.SmtpUserName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@smtpPassword", modifiedConf.SmtpPassword ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@retentionDays", modifiedConf.RetentionDays);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Beállítások frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Felhasználó adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedUser">Frissített adatokat tartalmazó felhasználó User példánya</param>
        public static void UpdateUser(User modifiedUser)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "UPDATE [Users] SET [UName] = @uName, [Email] = @email, [Phone] = @phone, [PermanentLocked] = @permanentLocked, [Locked] = @locked, [Post] = @post, [DId] = @dId WHERE [UId] = @uId";
                cmd.Parameters.AddWithValue("@uName", modifiedUser.UName);
                cmd.Parameters.AddWithValue("@email", modifiedUser.Email);
                cmd.Parameters.AddWithValue("@phone", String.IsNullOrEmpty(modifiedUser.Phone) ? (object)DBNull.Value : modifiedUser.Phone);
                cmd.Parameters.AddWithValue("@permanentLocked", modifiedUser.PermanentLocked == null ? SqlDateTime.Null : (DateTime)modifiedUser.PermanentLocked);
                cmd.Parameters.AddWithValue("@locked", modifiedUser.Locked);
                cmd.Parameters.AddWithValue("@post", String.IsNullOrEmpty(modifiedUser.Post) ? (object)DBNull.Value : modifiedUser.Post);
                cmd.Parameters.AddWithValue("@dId", modifiedUser.UDepartment == null ? (object)DBNull.Value : modifiedUser.UDepartment.DId);
                cmd.Parameters.AddWithValue("@uId", modifiedUser.UId);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [Groups_Users] WHERE [UId] = @uId;";
                cmd.Parameters.AddWithValue("@uId", modifiedUser.UId);
                cmd.ExecuteNonQuery();
                foreach (PermissionGroup item in modifiedUser.Permissions)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [Groups_Users] VALUES (@gId, @uId);";
                    cmd.Parameters.AddWithValue("@gId", item.GId); 
                    cmd.Parameters.AddWithValue("@uId", modifiedUser.UId);
                    cmd.ExecuteNonQuery();
                }
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [ItSystemPermissions_Users] WHERE [UId] = @uId;";
                cmd.Parameters.AddWithValue("@uId", modifiedUser.UId);
                cmd.ExecuteNonQuery();
                foreach (ItSystemPermission item in modifiedUser.ItSystemPermissions)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [ItSystemPermissions_Users] VALUES (@sysPId, @uId);";
                    cmd.Parameters.AddWithValue("@sysPId", item.SysPId);
                    cmd.Parameters.AddWithValue("@uId", modifiedUser.UId);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Felhasználó adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Felhasználó jelszavának frissítésére szolgáló metódus
        /// </summary>
        /// <param name="user">A felhasználó User példánya</param>
        /// <param name="oldPassword">Régi jelszó</param>
        /// <param name="newPassword">Új jelszó</param>
        public static void UpdateUserPw(User user, string oldPassword, string newPassword)
        {
            try
            {
                AppConfiguration conf = GetConfiguration();
                string oldHashedPw = String.Empty;
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT [HashedPw] FROM [UserPasswords] WHERE [UId] = @uId";
                cmd.Parameters.AddWithValue("@uId", user.UId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oldHashedPw = reader["HashedPw"].ToString();
                    }
                    reader.Close();
                }
                if (Password.StringToHashComparer(oldPassword, oldHashedPw))
                {
                    if (Password.PwComplexityChecker(conf.PwComplexity, conf.PwLength, newPassword))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE [UserPasswords] SET [HashedPw] = @hashedPw, [PwModifiedDate] = GETDATE() WHERE [UId] = @uId";
                        cmd.Parameters.AddWithValue("@hashedPw", Password.PwEncryptor(newPassword));
                        cmd.Parameters.AddWithValue("@uId", user.UId);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new PwException($"Az új jelszó nem felel meg az elvárásoknak!\n\rA jelszónak legalább {conf.PwLength} karakter hosszúnak kell lennie, továbbá {(Attribute.GetCustomAttribute(conf.PwComplexity.GetType().GetField(conf.PwComplexity.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description}!");
                    }
                }
                else
                {
                    throw new PwException("A jelenlegi jelszó helytelen!");
                }
            }
            catch (Exception ex)
            {
                if (ex is PwException)
                {
                    throw ex;
                }
                else
                {
                    throw new DBException("Jelszó frissítése sikertelen!", ex.Message);
                }
            }
        }
        /// <summary>
        /// Felhasználó jelszavának frissítésére szolgáló funkció.
        /// </summary>
        /// <param name="modifiedUser">A felhasználó User példánya</param>
        /// <param name="mailWasSent">Régi jelszó</param>
        public static string UpdateUserPw(User modifiedUser, out bool mailWasSent)
        {
            try
            {
                AppConfiguration conf = GetConfiguration();
                string newPassword = Password.PasswordGenerator(conf.PwComplexity, conf.PwLength);
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [UserPasswords] SET [HashedPw] = @hashedPw, [PwModifiedDate] = @pwModifiedDate WHERE [UId] = @uId";
                cmd.Parameters.AddWithValue("@hashedPw", Password.PwEncryptor(newPassword));
                cmd.Parameters.AddWithValue("@pwModifiedDate", SqlDateTime.Null);
                cmd.Parameters.AddWithValue("@uId", modifiedUser.UId);
                cmd.ExecuteNonQuery();
                mailWasSent = conf.EnableEmail;
                if (conf.EnableEmail)
                {
                    try
                    {
                        EmailSender.SendEmail("Jelszó módosítás", $"<p>Az Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszerben jelszavát módosították!</p><p>Az új jelszava: <b>{newPassword}</b></p><p>Kérem, a jelszavát módosítsa a következő belépés alkalmával!</p>", modifiedUser);
                    }
                    catch (Exception)
                    {
                        mailWasSent = false;
                    }
                }
                return newPassword;
            }
            catch (Exception ex)
            {
                throw new DBException("Jelszó frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Jogosultsági csoport adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedGroup">Frissített adatokat tartalmazó jogosultsági csoport PermissionGroup példánya</param>
        public static void UpdateGroup(PermissionGroup modifiedGroup)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "UPDATE [Groups] SET [GName] = @gName, [GDescription] = @gDescription WHERE [GId] = @gId";
                cmd.Parameters.AddWithValue("@gName", modifiedGroup.GName);
                cmd.Parameters.AddWithValue("@gDescription", modifiedGroup.GDescription);
                cmd.Parameters.AddWithValue("@gId", modifiedGroup.GId);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [Permissions_Groups] WHERE [GId] = @gId;";
                cmd.Parameters.AddWithValue("@gId", modifiedGroup.GId);
                cmd.ExecuteNonQuery();
                foreach (Permission item in modifiedGroup.Permissions)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [Permissions_Groups] VALUES (@pId, @gId);";
                    cmd.Parameters.AddWithValue("@pId", item.PId);
                    cmd.Parameters.AddWithValue("@gId", modifiedGroup.GId);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Csoport adatainak frissítése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szervezeti egység adatainak frissítésére szolgáló metódus
        /// </summary>
        /// <param name="modifiedDepartment">Frissített adatokat tartalmazó szervezeti egység Department példánya</param>
        public static void UpdateDepartment(Department modifiedDepartment)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [Departments] SET [DName] = @dName, [DShortName] = @dShortName, [ManagerId] = @managerId, [SuperiorDId] = @superiorDId WHERE [DId] = @dId";
                cmd.Parameters.AddWithValue("@dName", modifiedDepartment.DName);
                cmd.Parameters.AddWithValue("@dShortName", modifiedDepartment.DShortName);
                cmd.Parameters.AddWithValue("@managerId", modifiedDepartment.ManagerId == 0 ? (object)DBNull.Value : modifiedDepartment.ManagerId);
                cmd.Parameters.AddWithValue("@superiorDId", modifiedDepartment.SuperiorDId == 0 ? (object)DBNull.Value : modifiedDepartment.SuperiorDId);
                cmd.Parameters.AddWithValue("@dId", modifiedDepartment.DId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBException("Szervezeti egység adatainak frissítése sikertelen!", ex.Message);
            }
        }
        #endregion
        #region Delete data
        /// <summary>
        /// Karbantartási naplóbejegyzés törlésére szolgáló metódus
        /// </summary>
        /// <param name="logId">Törlendő naplóbejegyzés azonosítója</param>
        public static void DeleteMaintenanceLog(int logId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "DELETE FROM [MaintenanceLogs_Hardwares] WHERE [LogId] = @logId;" +
                    "DELETE FROM [MaintenanceLogs_ItSystems] WHERE [LogId] = @logId;" +
                    "DELETE FROM [MaintenanceLogs] WHERE [LogId] = @logId;";
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Karbantartási naplóbejegyzés törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szoftver törlésére szolgáló metódus
        /// </summary>
        /// <param name="aId">Törlendő szoftver azonosítója</param>
        public static void DeleteSoftware(int aId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "DELETE FROM [ItAssets_ItSystems] WHERE [AId] = @aId;" +
                    "DELETE FROM [Softwares_Hardwares] WHERE [SoftAId] = @aId;" +
                    "DELETE FROM [Softwares] WHERE [AId] = @aId;" +
                    "DELETE FROM [ItAssets] WHERE [AId] = @aId;";
                cmd.Parameters.AddWithValue("@aId", aId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Szoftver törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Hardver törlésére szolgáló metódus
        /// </summary>
        /// <param name="aId">Törlendő hardver azonosítója</param>
        public static void DeleteHardware(int aId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "DELETE FROM [ItAssets_ItSystems] WHERE [AId] = @aId;" +
                    "DELETE FROM [MaintenanceLogs_Hardwares] WHERE [HardId] = @aId;" +
                    "DELETE FROM [Softwares_Hardwares] WHERE [HardAId] = @aId;" +
                    "DELETE FROM [IPv4Addresses] WHERE [NicId] = ANY(SELECT [NicId] FROM [NICs] WHERE [AId] = @aId);" +
                    "DELETE FROM [NICs] WHERE [AId] = @aId;" +
                    "DELETE FROM [DataStorageDevices] WHERE [AId] = @aId;" +
                    "DELETE FROM [ComputerDevices] WHERE [AId] = @aId;" +
                    "DELETE FROM [NetActiveDevices] WHERE [AId] = @aId;" +
                    "DELETE FROM [Hardwares] WHERE [AId] = @aId;" +
                    "DELETE FROM [ItAssets] WHERE [AId] = @aId;";
                cmd.Parameters.AddWithValue("@aId", aId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Hardver törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Rendszerjogosultság törlésére szolgáló metódus
        /// </summary>
        /// <param name="sysPId">Törlendő rendszerjogosultság azonosítója</param>
        public static void DeleteItSystemPermission(int sysPId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "DELETE FROM [ItSystemPermissions_Users] WHERE [SysPId] = @sysPId;" +
                    "DELETE FROM [ItSystemPermissions] WHERE [SysPId] = @sysPId;";
                cmd.Parameters.AddWithValue("@sysPId", sysPId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Rendszerjogosultság törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Felhasználó törlésére szolgáló metódus
        /// </summary>
        /// <param name="uId">Törlendő felhasználó azonosítója</param>
        public static void DeleteUser(int uId, bool finalDeletion = false)
        {
            try
            {
                AppConfiguration conf = GetConfiguration();
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                if (conf.RetentionDays == 0 || finalDeletion)
                {
                    cmd.CommandText = "DELETE FROM [Logs] WHERE [UId] = @uId;" +
                        "UPDATE [Hardwares] SET [UId] = @managerId WHERE [UId] = @uId;" +
                        "UPDATE [ItSystems] SET [AdminUser] = @managerId WHERE [AdminUser] = @uId;" +
                        "UPDATE [Departments] SET [ManagerId] = @managerId WHERE [ManagerId] = @uId;" +
                        "DELETE FROM [ItSystemPermissions_Users] WHERE [UId] = @uId;" +
                        "DELETE FROM [Groups_Users] WHERE [UId] = @uId;" +
                        "DELETE FROM [UserPasswords] WHERE [UId] = @uId;" +
                        "DELETE FROM [Users] WHERE [UId] = @uId";
                }
                else
                {
                    cmd.CommandText = "UPDATE [Departments] SET [ManagerId] = @managerId WHERE [ManagerId] = @uId;" +
                        "UPDATE [Hardwares] SET [UId] = @managerId WHERE [UId] = @uId;" +
                        "UPDATE [ItSystems] SET [AdminUser] = @managerId WHERE [AdminUser] = @uId;" +
                        "UPDATE [Users] SET [DeleteDate] = GETDATE() WHERE [UId] = @uId;";
                }
                cmd.Parameters.AddWithValue("@managerId", (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@uId", uId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Felhasználó törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Megőrzési időn túli adatok törlése
        /// </summary>
        public static void DeleteRetentedData()
        {
            try
            {
                AppConfiguration conf = GetConfiguration();
                List<int> deleteUsersId = new List<int>();
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "SELECT [UId], DATEDIFF(day, [DeleteDate], GETDATE()) AS [DateDiff] FROM [Users] WHERE [DeleteDate] IS NOT NULL";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader["DateDiff"] > (int)conf.RetentionDays)
                        {
                            deleteUsersId.Add((int)reader["UId"]);
                        }
                    }
                    reader.Close();
                }
                if (conf.RetentionDays > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM [Logs] WHERE DATEDIFF(day, [Date], GETDATE()) > @lockingPeriod;";
                    cmd.Parameters.AddWithValue("@lockingPeriod", (int)conf.RetentionDays);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                for (int i = 0; i < deleteUsersId.Count; i++)
                {
                    DeleteUser(deleteUsersId[i], true);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Felhasználó törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Csoport törlésére szolgáló metódus
        /// </summary>
        /// <param name="gId">Törlendő csoport azonosítója</param>
        public static void DeleteGroup(int gId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "DELETE FROM [Groups_Users] WHERE [GId] = @gId;" +
                    "DELETE FROM [Permissions_Groups] WHERE [GId] = @gId;" +
                    "DELETE FROM [Groups] WHERE [GId] = @gId";
                cmd.Parameters.AddWithValue("@gId", gId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Csoport törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Szervezeti egység törlésére szolgáló metódus
        /// </summary>
        /// <param name="dId">Törlendő szervezeti egység azonosítója</param>
        /// <param name="uDId">Opcionális paraméter, mellyel megadható, hogy a törölt szervezeti egység alá tartozó felhasználók melyik szervezeti egységbe kerüljenek</param>
        /// <param name="sDId">Opcionális paraméter, mellyel megadható, hogy a törölt szervezeti egység alá tartozó szervezeti egységek melyik szervezeti egység alá kerüljenek</param>
        public static void DeleteDepartment(int dId, int uDId = 0, int sDId = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "UPDATE [Users] SET [DId] = @uDId WHERE [DId] = @dId;" +
                    "UPDATE [ItAssets] SET [OwnerId] = @uDId WHERE [OwnerId] = @dId;" +
                    "UPDATE [ItSystems] SET [InnerDataOwner] = @sDId WHERE [InnerDataOwner] = @dId;" +
                    "UPDATE [Departments] SET [SuperiorDId] = @sDId WHERE [SuperiorDId] = @dId;" +
                    "DELETE FROM [Departments] WHERE [DId] = @dId";
                cmd.Parameters.AddWithValue("@dId", dId);
                cmd.Parameters.AddWithValue("@uDId", uDId == 0 ? (object)DBNull.Value : uDId);
                cmd.Parameters.AddWithValue("@sDId", sDId == 0 ? (object)DBNull.Value : sDId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Szervezeti egység törlése sikertelen!", ex.Message);
            }
        }
        /// <summary>
        /// Rendszer törlésére szolgáló metódus
        /// </summary>
        /// <param name="sId">Törlendő IT rendszer azonosítója</param>
        public static void DeleteItSystem(int sId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Transaction = conn.BeginTransaction();
                cmd.CommandText = "DELETE FROM [ItSystemPermissions_Users] WHERE [SysPId] = ANY(SELECT [SysPId] FROM [ItSystems] WHERE [SId] = @sId);" +
                    "DELETE FROM [ItAssets_ItSystems] WHERE [SId] = @sId;" +
                    "DELETE FROM [MaintenanceLogs_ItSystems] WHERE [ItSId] = @sId;" +
                    "DELETE FROM [ItSystemPermissions] WHERE [SId] = @sId;" +
                    "DELETE FROM [ItSystems] WHERE [SId] = @sId";
                cmd.Parameters.AddWithValue("@sId", sId);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DBException("Hiba a tranzakció lezárásában!", innerEx.Message);
                }
                throw new DBException("Rendszer törlése sikertelen!", ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
