using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

namespace IBANYR
{
    enum EventType
    {
        [Description("Bejelentkezés")]
        login,
        [Description("Kijelentkezés")]
        logout,
        [Description("Felhasználó létrehozása")]
        createUser,
        [Description("Felhasználó megtekintése")]
        readUser,
        [Description("Felhasználók listázása")]
        listUsers,
        [Description("Felhasználók szűrése")]
        filterUsers,
        [Description("Felhasználó módosítása")]
        updateUser,
        [Description("Felhasználó törlése")]
        deleteUser,
        [Description("Saját jelszó módosítása")]
        ownPasswordChange,
        [Description("Felhasználó jelszavának módosítása")]
        userPasswordChange,
        [Description("Felhasználó ideiglenes zárolása")]
        userPermanentLock,
        [Description("Jogosultsági csoport létrehozása")]
        createGroup,
        [Description("Jogosultsági csoport megtekintése")]
        readGroup,
        [Description("Jogosultsági csoportok listázása")]
        listGroups,
        [Description("Jogosultsági csoport módosítása")]
        updateGroup,
        [Description("Jogosultsági csoport törlése")]
        deleteGroup,
        [Description("Konfiguráció megtekintése")]
        readConfigutaion,
        [Description("Konfiguráció módosítása")]
        updateConfiguration,
        [Description("Szervezeti egység létrehozása")]
        createDepartment,
        [Description("Szervezeti egység megtekintése")]
        readDepartment,
        [Description("Szervezeti egységek listázása")]
        listDepartments,
        [Description("Szervezeti egység módosítása")]
        updateDepartment,
        [Description("Szervezeti egység törlése")]
        deleteDepartment,
        [Description("Naplóbejegyzések listázása")]
        listSystemLogs,
        [Description("Naplóbejegyzések exportálása")]
        exportSystemLogs,
        [Description("Rendszer létrehozása")]
        createItSystem,
        [Description("Rendszer megtekintése")]
        readItSystem,
        [Description("Rendszerek listázása")]
        listItSystems,
        [Description("Rendszerek szűrése")]
        filterItSystems,
        [Description("Rendszer módosítása")]
        updateItSystem,
        [Description("Rendszer törlése")]
        deleteItSystem,
        [Description("Rendszerek exportálása")]
        exportItSystems,
        [Description("Rendszerjogosultság létrehozása")]
        createItSystemPermission,
        [Description("Rendszerjogosultság megtekintése")]
        readItSystemPermission,
        [Description("Rendszerekjogosultságok listázása")]
        listItSystemPermissions,
        [Description("Rendszerjogosultság módosítása")]
        updateItSystemPermission,
        [Description("Rendszerjogosultság törlése")]
        deleteItSystemPermission,
        [Description("Hardver létrehozása")]
        createHardware,
        [Description("Hardver megtekintése")]
        readHardware,
        [Description("Hardverek listázása")]
        listHardwares,
        [Description("Hardverek szűrése")]
        filterHardwares,
        [Description("Hardver módosítása")]
        updateHardware,
        [Description("Hardver törlése")]
        deleteHardware,
        [Description("Hardverek exportálása")]
        exportHardwares,
        [Description("Szoftver létrehozása")]
        createSoftware,
        [Description("Szoftver megtekintése")]
        readSoftware,
        [Description("Szoftverek listázása")]
        listSoftwares,
        [Description("Szoftverek szűrése")]
        filterSoftwares,
        [Description("Szoftver módosítása")]
        updateSoftware,
        [Description("Szoftver törlése")]
        deleteSoftware,
        [Description("Szoftverek exportálása")]
        exportSoftwares,
        [Description("Karbantartási naplóbejegyzés létrehozása")]
        createMaintenanceLog,
        [Description("Karbantartási naplóbejegyzés megtekintése")]
        readMaintenanceLog,
        [Description("Karbantartási napló listázása")]
        listMaintenanceLogs,
        [Description("Karbantartási naplóbejegyzések szűrése")]
        filterMaintenanceLogs,
        [Description("Karbantartási naplóbejegyzés módosítása")]
        updateMaintenanceLog,
        [Description("Karbantartási naplóbejegyzés törlése")]
        deleteMaintenanceLog,
        [Description("Karbantartási napló exportálása")]
        exportMaintenanceLogs

    }
    class SystemLog : IToCsv
    {
        #region Private fields
        int logId;
        User user;
        EventType type;
        string eventDesc;
        DateTime logDate;
        #endregion
        #region Public properties
        [DisplayName("#")]
        public int LogId
        {
            get => logId;
            private set
            {
                if (logId == -1)
                {
                    logId = value;
                }
                else
                {
                    throw new InvalidOperationException("A bejegyzés azonosítójának módosítása nem lehetséges!");
                }
            }
        }
        [DisplayName("Felhasználónév")]
        public User User { get => user; private set => user = value; }
        internal EventType Type
        {
            get => type;
            private set
            {
                if (Enum.IsDefined(typeof(EventType), value))
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott esménytípussal rendelkező bejegyzést lehet létrehozni!");
                }
            }
        }
        [DisplayName("Esemény leírása")]
        public string EventDesc { get => eventDesc; private set => eventDesc = value; }
        [DisplayName("Esemény időpontja")]
        public DateTime LogDate
        {
            get => logDate; 
            private set
            {
                if (value != null && value >= SqlDateTime.MinValue.Value)
                {
                    logDate = value;
                }
                else
                {
                    throw new ArgumentException("A bejegyzés dátuma nem lehet null érték, valamint nem lehet korábbi dátum, mint 1753.01.01.!");
                }
            }
        }
        #endregion
        #region Constructors
        internal SystemLog(User user, string eventDesc, EventType type, DateTime logDate, int logId = -1)
        {
            if (logId != -1)
            {
                this.logId = logId;
            }
            LogDate = logDate;
            User = user;
            EventDesc = eventDesc;
            Type = type;
            LogDate = logDate;
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Naplóbejegyzés rögzítésére szolgáló metódus
        /// </summary>
        /// <param name="user">Azon felhasználó <see cref="User"/> példánya, aki a naplózandó eseményt végrehajtotta</param>
        /// <param name="ev">A rögzítendő esemény típusa </param>
        /// <param name="obj">Opcionális paraméter. Azon objektum egy példánya, amin a tevékenységet végrehajtották</param>
        public static void WriteLogEvent(User user, EventType ev, object obj = null)
        {
            try
            {
                string eventDesc = String.Empty;
                switch (ev)
                {
                    case EventType.login:
                        eventDesc = "Felhasználó bejelentkezett a rendszerbe!";
                        break;
                    case EventType.logout:
                        eventDesc = "Felhasználó kilépett a rendszerből!";
                        break;
                    case EventType.createUser:
                        eventDesc = obj != null && obj is User ? $"\"{(obj as User).UName}\" nevű felhasználó rögzítésre került a rendszerbe!" : "Új felhasználó rögzítésre került a rendszerbe!";
                        break;
                    case EventType.readUser:
                        eventDesc = obj != null && obj is User ? $"\"{(obj as User).UName}\" nevű felhasználó adatainak megtekintése!" : "Felhasználó adatainak megtekintése!";
                        break;
                    case EventType.listUsers:
                        eventDesc = "Felhasználók listázása!";
                        break;
                    case EventType.filterUsers:
                        eventDesc = "Felhasználók szűrése!";
                        break;
                    case EventType.updateUser:
                        eventDesc = obj != null && obj is User ? $"\"{(obj as User).UName}\" nevű felhasználó adatainak frissítése!" : "Felhasználó adatainak frissítése!";
                        break;
                    case EventType.deleteUser:
                        eventDesc = obj != null && obj is User ? $"\"{(obj as User).UName}\" nevű felhasználó törlése!" : "Felhasználó törlése!";
                        break;
                    case EventType.ownPasswordChange:
                        eventDesc = "Felhasználó módosította jelszavát!";
                        break;
                    case EventType.userPasswordChange:
                        eventDesc = obj != null && obj is User ? $"\"{(obj as User).UName}\" nevű felhasználó jelszavának módosítása!" : "Felhasználó jelszavának módosítása!";
                        break;
                    case EventType.userPermanentLock:
                        eventDesc = "Felhasználó ideiglenesen zárolásra került, túl sok helytelen bejelentkezési kísérlet miatt!";
                        break;
                    case EventType.createGroup:
                        eventDesc = obj != null && obj is PermissionGroup ? $"\"{(obj as PermissionGroup).GName}\" nevű jogosultsági csoport rögzítése!" : "Jogosultsági csoport rögzítése!";
                        break;
                    case EventType.readGroup:
                        eventDesc = obj != null && obj is PermissionGroup ? $"\"{(obj as PermissionGroup).GName}\" nevű jogosultsági csoport adatainak megtekintése!" : "Jogosultsági csoport adatainak megtekintése!";
                        break;
                    case EventType.listGroups:
                        eventDesc = "Jogosultsági csoportok listázása!";
                        break;
                    case EventType.updateGroup:
                        eventDesc = obj != null && obj is PermissionGroup ? $"\"{(obj as PermissionGroup).GName}\" nevű jogosultsági csoport frissítése!" : "Jogosultsági csoport frissítése!";
                        break;
                    case EventType.deleteGroup:
                        eventDesc = obj != null && obj is PermissionGroup ? $"\"{(obj as PermissionGroup).GName}\" nevű jogosultsági csoport törlése!" : "Jogosultsági csoport törlése!";
                        break;
                    case EventType.readConfigutaion:
                        eventDesc = "Konfigurációs adatok megtekintése!";
                        break;
                    case EventType.updateConfiguration:
                        eventDesc = "Konfigurációs adatok frissítése!";
                        break;
                    case EventType.createDepartment:
                        eventDesc = obj != null && obj is Department ? $"\"{(obj as Department).DName}\" nevű szervezeti egység rögzítése!" : "Szervezeti egység rögzítése!";
                        break;
                    case EventType.readDepartment:
                        eventDesc = obj != null && obj is Department ? $"\"{(obj as Department).DName}\" nevű szervezeti egység adatainak megtekintése!" : "Szervezeti egység adatainak megtekintése!";
                        break;
                    case EventType.listDepartments:
                        eventDesc = obj != null && obj is Department ? $"\"{(obj as Department).DName}\" nevű szervezeti egység adatainak megtekintése!" : "Szervezeti egység adatainak megtekintése!";
                        break;
                    case EventType.updateDepartment:
                        eventDesc = obj != null && obj is Department ? $"\"{(obj as Department).DName}\" nevű szervezeti egység adatainak frissítése!" : "Szervezeti egység adatainak frissítése!";
                        break;
                    case EventType.deleteDepartment:
                        eventDesc = obj != null && obj is Department ? $"\"{(obj as Department).DName}\" nevű szervezeti egység törlése!" : "Szervezeti egység törlése!";
                        break;
                    case EventType.listSystemLogs:
                        eventDesc = "Naplóbejegyzések listázása!";
                        break;
                    case EventType.exportSystemLogs:
                        eventDesc = "Naplóbejegyzések exportálása!";
                        break;
                    case EventType.createItSystem:
                        eventDesc = obj != null && obj is ItSystem ? $"\"{(obj as ItSystem).SShortName}\" megnevezésű IT rendszer rögzítésre került!" : "Új IT rendszer rögzítésre került!";
                        break;
                    case EventType.readItSystem:
                        eventDesc = obj != null && obj is ItSystem ? $"\"{(obj as ItSystem).SShortName}\" megnevezésű IT rendszer adatainak megtekintése!" : "IT rendszer adatainak megtekintése!";
                        break;
                    case EventType.listItSystems:
                        eventDesc = "IT rendszerek listázása!";
                        break;
                    case EventType.filterItSystems:
                        eventDesc = "IT rendszerek szűrése!";
                        break;
                    case EventType.updateItSystem:
                        eventDesc = obj != null && obj is ItSystem ? $"\"{(obj as ItSystem).SShortName}\" megnevezésű IT rendszer adatainak frissítése!" : "IT rendszer adatainak frissítése!";
                        break;
                    case EventType.deleteItSystem:
                        eventDesc = obj != null && obj is ItSystem ? $"\"{(obj as ItSystem).SShortName}\" megnevezésű IT rendszer törlése!" : "IT rendszer törlése!";
                        break;
                    case EventType.exportItSystems:
                        eventDesc = "Rendszerek exportálása!";
                        break;
                    case EventType.createItSystemPermission:
                        eventDesc = obj != null && obj is ItSystemPermission ? $"\"{DBManager.GetItSystemById((obj as ItSystemPermission).SId).SShortName}\" megnevezésű rendszerhez tartozó \"{(obj as ItSystemPermission).SysPName}\" jogosultság rögzítésre került!" : "Új rendszerjogosultság rögzítésre került!";
                        break;
                    case EventType.readItSystemPermission:
                        eventDesc = obj != null && obj is ItSystemPermission ? $"\"{DBManager.GetItSystemById((obj as ItSystemPermission).SId).SShortName}\" megnevezésű rendszerhez tartozó \"{(obj as ItSystemPermission).SysPName}\" jogosultság adatainak megtekintése!" : "Rendszerjogosultság adatainak megtekintése!";
                        break;
                    case EventType.listItSystemPermissions:
                        eventDesc = "Rendszerjogosultságok listázása!";
                        break;
                    case EventType.updateItSystemPermission:
                        eventDesc = obj != null && obj is ItSystemPermission ? $"\"{DBManager.GetItSystemById((obj as ItSystemPermission).SId).SShortName}\" megnevezésű rendszerhez tartozó \"{(obj as ItSystemPermission).SysPName}\" jogosultság adatainak frissítése!" : "Rendszerjogosultság adatainak frissítése!";
                        break;
                    case EventType.deleteItSystemPermission:
                        eventDesc = obj != null && obj is ItSystemPermission ? $"\"{DBManager.GetItSystemById((obj as ItSystemPermission).SId).SShortName}\" megnevezésű rendszerhez tartozó \"{(obj as ItSystemPermission).SysPName}\" jogosultság törlése!" : "Rendszerjogosultság törlése!";
                        break;
                    case EventType.createHardware:
                        eventDesc = obj != null && obj is Hardware ? $"\"{(obj as Hardware).SerialNumber}\" sorozatszámú hardver rögzítésre került!" : "Új hardver rögzítésre került!";
                        break;
                    case EventType.readHardware:
                        eventDesc = obj != null && obj is Hardware ? $"\"{(obj as Hardware).SerialNumber}\" sorozatszámú hardver adatainak megtekintése!" : "Hardver adatainak megtekintése!";
                        break;
                    case EventType.listHardwares:
                        eventDesc = "Hardverek listázása!";
                        break;
                    case EventType.filterHardwares:
                        eventDesc = "Hardverek szűrése!";
                        break;
                    case EventType.updateHardware:
                        eventDesc = obj != null && obj is Hardware ? $"\"{(obj as Hardware).SerialNumber}\" sorozatszámú hardver adatainak frissítése!" : "Hardver adatainak frissítése!";
                        break;
                    case EventType.deleteHardware:
                        eventDesc = obj != null && obj is Hardware ? $"\"{(obj as Hardware).SerialNumber}\" sorozatszámú hardver törlése!" : "Hardver törlése!";
                        break;
                    case EventType.exportHardwares:
                        eventDesc = "Hardverek exportálása!";
                        break;
                    case EventType.createSoftware:
                        eventDesc = obj != null && obj is Software ? $"\"{(obj as Software).AName}\" szoftver rögzítésre került!" : "Új szoftver rögzítésre került!";
                        break;
                    case EventType.readSoftware:
                        eventDesc = obj != null && obj is Software ? $"\"{(obj as Software).AId}\" azonosítószámú szoftver adatainak megtekintése!" : "Szoftver adatainak megtekintése!";
                        break;
                    case EventType.listSoftwares:
                        eventDesc = "Szoftverek listázása!";
                        break;
                    case EventType.filterSoftwares:
                        eventDesc = "Szoftverek szűrése!";
                        break;
                    case EventType.updateSoftware:
                        eventDesc = obj != null && obj is Software ? $"\"{(obj as Software).AId}\" azonosítószámú szoftver adatainak frissítése!" : "Szoftver adatainak frissítése!";
                        break;
                    case EventType.deleteSoftware:
                        eventDesc = obj != null && obj is Software ? $"\"{(obj as Software).AId}\" azonosítószámú szoftver törlése!" : "Szoftver törlése!";
                        break;
                    case EventType.exportSoftwares:
                        eventDesc = "Szoftverek exportálása!";
                        break;
                    case EventType.createMaintenanceLog:
                        eventDesc = obj != null && obj is MaintenanceLog ? $"Új karbantartási naplóbejegyzés került rögzítésre {(obj as MaintenanceLog).StartDate} kezdő időponttal!" : "Új karbantartási naplóbejegyzés rögzítésre került!";
                        break;
                    case EventType.readMaintenanceLog:
                        eventDesc = obj != null && obj is MaintenanceLog ? $"\"{(obj as MaintenanceLog).LogId}\" azonosítószámú karbantartási naplóbejegyzés megtekintése!" : "Karbantartási naplóbejegyzés megtekintése!";
                        break;
                    case EventType.listMaintenanceLogs:
                        eventDesc = "Karbantartási naplóbejegyzések listázása!";
                        break;
                    case EventType.filterMaintenanceLogs:
                        eventDesc = "Karbantartási napló szűrése!";
                        break;
                    case EventType.updateMaintenanceLog:
                        eventDesc = obj != null && obj is MaintenanceLog ? $"\"{(obj as MaintenanceLog).LogId}\" azonosítószámú karbantartási naplóbejegyzés frissítése!" : "Karbantartási naplóbejegyzés frissítése!";
                        break;
                    case EventType.deleteMaintenanceLog:
                        eventDesc = obj != null && obj is MaintenanceLog ? $"\"{(obj as MaintenanceLog).LogId}\" azonosítószámú karbantartási naplóbejegyzés törlése!" : "Karbantartási naplóbejegyzés törlése!";
                        break;
                    case EventType.exportMaintenanceLogs:
                        eventDesc = "Karbantartási napló exportálása!";
                        break;
                }
                DBManager.CreateLog(user.UId, ev, eventDesc);
                DBManager.DeleteRetentedData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Naplóbejegyzéseket tartalmazó lista CSV fájlba történő exportálására szolgáló statikus metódus
        /// </summary>
        /// <param name="list">Az exportálandó bejegyzések listája</param>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        public static void ExportToCsv(List<SystemLog> list, string path)
        {
            try
            {
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Felhasználónév;Felhasználó email címe;Esemény kategóriája;Esemény leírása;Esemény időpontja";
                file.WriteLine(header);
                file.Flush();
                foreach (SystemLog item in list)
                {
                    file.WriteLine(item.ToCsv());
                    file.Flush();
                }
                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A paraméterek szerint szűrt naplóbejegyzések listájának CSV fájlba történő exportálására szolgáló statikus metódus
        /// </summary>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        /// <param name="dateFrom">Azon legkorábbi időpont <see cref="DateTime"/> típusban megadva, amelyet már a lista tartalmaz. Null érték megadása esetén nincs hatása a szűrésre.</param>
        /// <param name="dateTo">Azon legkésőbbi időpont <see cref="DateTime"/> típusban megadva, amelyet még a lista tartalmaz. Null érték megadása esetén nincs hatása a szűrésre.</param>
        /// <param name="uId">Felhasználó azonosítója, melyre szűrni szeretnénk a naplóbejegyzéseket. Null érték megadása esetén nincs hatása a szűrésre.</param>
        /// <param name="evType">Azon esemény típusa <see cref="EventType"/> típusban megadva melyre szűrni szeretnénk a naplóbejegyzéseket. Null érték megadása esetén nincs hatása a szűrésre.</param>
        /// <param name="rowsPerPage">Opcionális paraméter, mellyel megadható, hogy maximálisan hány bejegyzés kerüljön CSV-be írásra az adatbázislekérdezések alaklmával. Alapértelmezett értéke 100</param>
        public static void ExportToCsv(string path, DateTime? dateFrom, DateTime? dateTo, int uId, EventType? evType, int rowsPerPage = 100)
        {
            try
            {
                if (dateFrom != null && dateTo != null && dateTo < dateFrom)
                {
                    throw new Exception("A szűrési feltételek nem megfelelőek! A vizsgált időszak befejezési dátuma korábbi, mint a kezdő dátum!");
                }
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Felhasználónév;Felhasználó email címe;Esemény kategóriája;Esemény leírása;Esemény időpontja";
                file.WriteLine(header);
                file.Flush();
                int exportedPage = 0;
                int allRowNum = 0;
                do
                {
                    exportedPage++;
                    foreach (SystemLog item in DBManager.GetFilteredLogsList(rowsPerPage, exportedPage, dateFrom, dateTo, uId, evType, out allRowNum))
                    {
                        file.WriteLine(item.ToCsv());
                        file.Flush();
                    }
                } while (exportedPage < Math.Ceiling(allRowNum * 1.0 / rowsPerPage));
                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A naplóbejegyzés CSV struktúra szerinti kinyerésére szolgáló funkció
        /// </summary>
        /// <returns>A naplóbejegyzés adatainak pontosvesszővel elválasztott szövegként való visszatérése</returns>
        public string ToCsv()
        {
            return $"{LogId};{User.UName};{User.Email};{(Attribute.GetCustomAttribute(Type.GetType().GetField(Type.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};{EventDesc};{LogDate}";
        }
        #endregion
    }
}
