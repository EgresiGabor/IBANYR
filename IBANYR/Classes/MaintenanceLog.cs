using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

namespace IBANYR
{
    enum MaintenanceType
    {
        [Description("Tervezett")]
        planned,
        [Description("Eseti")]
        occasional
    }
    enum MaintenanceMethod
    {
        [Description("Helyben")]
        inPlace,
        [Description("Távoli vezérléssel")]
        remoteAccess,
        [Description("Telephelyen kívüli")]
        withDelivery,
        [Description("Egyéb")]
        other
    }
    enum MaintenanceState
    {
        [Description("Tervben")]
        planned,
        [Description("Folyamatban")]
        inProgress,
        [Description("Lezárva")]
        closed
    }
    class MaintenanceLog: IToCsv
    {
        #region Private fields
        int logId;
        MaintenanceType mType;
        MaintenanceMethod mMethod;
        DateTime startDate;
        DateTime? endDate;
        string activitiesDesc;
        string docLink;
        string mName;
        List<int> affectedComponentsId;
        List<int> affectedItSystemsId;
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
        [DisplayName("Karbantartás típusa")]
        public MaintenanceType MType
        {
            get => mType;
            private set
            {
                if (Enum.IsDefined(typeof(MaintenanceType), value))
                {
                    mType = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott karbantartástípussal rendelkező bejegyzést lehet létrehozni!");
                }
            }
        }
        [DisplayName("Karbantartás módja")]
        public MaintenanceMethod MMethod
        {
            get => mMethod;
            private set
            {
                if (Enum.IsDefined(typeof(MaintenanceMethod), value))
                {
                    mMethod = value;
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott karbantartásmóddal rendelkező bejegyzést lehet létrehozni!");
                }
            }
        }
        [DisplayName("Karbantartás státusza")]
        public MaintenanceState Status
        {
            get
            {
                try
                {
                    if (startDate > DBManager.GetCurrentTime())
                    {
                        return MaintenanceState.planned;
                    }
                    else
                    {
                        if (endDate == null)
                        {
                            return MaintenanceState.inProgress;
                        }
                        else
                        {
                            return endDate < DBManager.GetCurrentTime() ? MaintenanceState.closed : MaintenanceState.inProgress;
                        }
                    }
                }
                catch (DBException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [DisplayName("Kezdés időpontja")]
        public DateTime StartDate
        {
            get => startDate;
            private set
            {
                if (value != null && value >= SqlDateTime.MinValue.Value)
                {
                    startDate = value;
                }
                else
                {
                    throw new ArgumentException("A karbantartás kezdő időpontja nem lehet null érték, valamint nem lehet korábbi dátum, mint 1753.01.01.!");
                }
            }
        }
        [DisplayName("Befejezés időpontja")]
        public DateTime? EndDate
        {
            get => endDate;
            set
            {
                if (value == null || (value != null && value >= startDate))
                {
                    endDate = value;
                }
                else
                {
                    throw new ArgumentException("A karbantartás záró időpontja nem lehet korábbi mint a kezdés időpontja!");
                }
            }
        }
        [DisplayName("Végzett tevékenység leírása")]
        public string ActivitiesDesc
        {
            get => activitiesDesc;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 1073741823)
                {
                    activitiesDesc = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A végzett tevékenység megadása kötelező, és nem haladhatja meg a 1.073.741.823 karaktert!");
                }
            }
        }
        [DisplayName("Dokumentum hivatkozások")]
        public string DocLink
        {
            get => docLink;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    docLink = null;
                }
                else if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 4000)
                {
                    docLink = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A dokumentum hivatkozások tartalma nem haladhatja meg a 4000 karaktert!");
                }
            }
        }
        [DisplayName("Karbantartást végző szervezet/személy")]
        public string MName
        {
            get => mName;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Trim().Length <= 300)
                {
                    mName = value.Trim();
                }
                else
                {
                    throw new ArgumentException("A karbantartást végző szervezet/személy megadása kötelező, és az adat tartalma nem haladhatja meg a 300 karaktert!");
                }
            }
        }
        internal List<int> AffectedComponentsId { get => affectedComponentsId.ToList(); private set => affectedComponentsId = value; }
        internal List<int> AffectedItSystemsId { get => affectedItSystemsId.ToList(); private set => affectedItSystemsId = value; }
        #endregion
        #region Constructors
        public MaintenanceLog(MaintenanceType mType, MaintenanceMethod mMethod, DateTime startDate, DateTime? endDate, string activitiesDesc, string docLink, string mName, int logId = -1)
        {
            if (logId != -1)
            {
                this.logId = logId;
            }
            MType = mType;
            MMethod = mMethod;
            StartDate = startDate;
            EndDate = endDate;
            ActivitiesDesc = activitiesDesc;
            DocLink = docLink;
            MName = mName;
            this.affectedComponentsId = new List<int>();
            this.affectedItSystemsId = new List<int>();
        }
        #endregion
        #region Methods and Functions
        /// <summary>
        /// Érintett rendszerelemek listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="componentId">A listához hozzáadandó rendszerelem azonosítója!</param>
        public void AddAffectedComponentsId(int componentId)
        {
            affectedComponentsId.Add(componentId);
        }
        /// <summary>
        /// Érintett rendszerelemek listájának ürítésére szolgáló metódus
        /// </summary>
        public void ClearAffectedComponentsId()
        {
            affectedComponentsId.Clear();
        }
        /// <summary>
        /// Érintett rendszerek listájának feltöltésére szolgáló metódus
        /// </summary>
        /// <param name="itSystemId">A listához hozzáadandó rendszer azonosítója!</param>
        public void AddAffectedItSystemsId(int itSystemId)
        {
            affectedItSystemsId.Add(itSystemId);
        }
        /// <summary>
        /// Érintett rendszerek listájának ürítésére szolgáló metódus
        /// </summary>
        public void ClearAffectedItSystemsId()
        {
            affectedItSystemsId.Clear();
        }
        /// <summary>
        /// A karbantartási bejegyzéseket tartalmazó lista CSV fájlba történő exportálására szolgáló statikus metódus
        /// </summary>
        /// <param name="list">Az exportálandó karbantartási bejegyzések listája</param>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        public static void ExportToCsv(List<MaintenanceLog> list, string path)
        {
            try
            {
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Karbantartás típusa;Karbantartás módja;Karbantartás státusza;Kezdés időpontja;Befejezés időpontja;Végzett tevékenység leírása;Dokumentum hivatkozások;Karbantartást végző szervezet/személy;Érintett hardverek azonosítószáma";
                file.WriteLine(header);
                file.Flush();
                foreach (MaintenanceLog item in list)
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
        /// A szűrési paramétereknek megfelelő karbantartási bejegyzéseket tartalmazó lista CSV fájlba történő exportálására szolgáló metódus
        /// </summary>
        /// <param name="path">Az exportálandó CSV fájl teljes elérési útja</param>
        /// <param name="affectedComponent">A karbantartási lista érintett hardver szerinti szűrési paramétere <see cref="Hardware"/> osztályú példányban megadva</param>
        /// <param name="affectedItSystem">A karbantartási lista érintett informatiaki rendszer szerinti szűrési paramétere <see cref="ItSystem"/> osztályú példányban megadva</param>
        /// <param name="type">A karbantartási lista karbantartás típusa szerinti szűrési paramétere null értéket felvenni képes <see cref="MaintenanceType"/> típusban megadva</param>
        /// <param name="method">A karbantartási lista karbantartás módja szerinti szűrési paramétere null értéket felvenni képes <see cref="MaintenanceMethod"/> típusban megadva</param>
        /// <param name="dateFrom">A karbantartási lista karbantartás kezdő időpontja szerinti szűrési paramétere null értéket felvenni képes <see cref="DateTime"/> típusban megadva</param>
        /// <param name="dateTo">A karbantartási lista karbantartás befejező időpontja szerinti szűrési paramétere null értéket felvenni képes <see cref="DateTime"/> típusban megadva</param>
        /// <param name="desc">A karbantartási lista végzett tevékenység szerinti szűrési paramétere. A megadott szöveget tartalmazó bejegyzések listázásra kerülnek.</param>
        /// <param name="name">A karbantartási lista karbantartást végző szerinti szűrési paramétere. Amennyiben a megadott szöveget tartlamazza a karbantartást végző szövegrész, akkor az adott bejegyzé listázásra kerül.</param>
        /// <param name="rowsPerPage">Opcionális paraméter, mellyel megadható, hogy maximálisan hány bejegyzés kerüljön CSV-be írásra az adatbázislekérdezések alaklmával. Alapértelmezett értéke 100</param>
        public static void ExportToCsv(string path, Hardware affectedComponent, ItSystem affectedItSystem, MaintenanceType? type, MaintenanceMethod? method, DateTime? dateFrom, DateTime? dateTo, string desc, string name, int rowsPerPage = 100)
        {
            try
            {
                if (dateFrom != null && dateTo != null && dateTo < dateFrom)
                {
                    throw new Exception("A szűrési feltételek nem megfelelőek! A vizsgált időszak befejezési dátuma korábbi, mint a kezdő dátum!");
                }
                StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
                string header = "#;Karbantartás típusa;Karbantartás módja;Karbantartás státusza;Kezdés időpontja;Befejezés időpontja;Végzett tevékenység leírása;Dokumentum hivatkozások;Karbantartást végző szervezet/személy;Érintett hardverek srozatszáma;Érintett rendszerek rövid neve";
                file.WriteLine(header);
                file.Flush();
                int exportedPage = 0;
                int allRowNum = 0;
                do
                {
                    exportedPage++;
                    foreach (MaintenanceLog item in DBManager.GetFilteredMaintenanceLogsList(rowsPerPage, exportedPage, affectedComponent, affectedItSystem, type, method, dateFrom, dateTo, desc, name, out allRowNum))
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
        /// A karbantartási bejegyzés CSV struktúra szerinti kinyerésére szolgáló funkció
        /// </summary>
        /// <returns>A karbantartási bejegyzés adatainak pontosvesszővel elválasztott szövegként való visszatérése</returns>
        public string ToCsv()
        {
            string serialNumbers = String.Empty;
            string itSystemsShortNames = String.Empty;
            try
            {
                for (int i = 0; i < affectedComponentsId.Count; i++)
                {
                    Hardware item = DBManager.GetHardwareById(affectedComponentsId[i]);
                    serialNumbers += i > 0 ? $"|{item.SerialNumber}" : item.SerialNumber;
                }
                for (int i = 0; i < affectedItSystemsId.Count; i++)
                {
                    ItSystem item = DBManager.GetItSystemById(affectedItSystemsId[i]);
                    itSystemsShortNames += i > 0 ? $"|{item.SShortName}" : item.SShortName;
                }
            }
            catch (DBException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return $"{LogId};" +
                $"{(Attribute.GetCustomAttribute(MType.GetType().GetField(MType.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};" +
                $"{(Attribute.GetCustomAttribute(MMethod.GetType().GetField(MMethod.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};" +
                $"{(Attribute.GetCustomAttribute(Status.GetType().GetField(Status.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description};" +
                $"{StartDate:yyyy.MM.dd. HH:mm};" +
                $"{(EndDate is DateTime end ? end.ToString("yyyy.MM.dd. HH:mm") : "")};" +
                $"{ActivitiesDesc.Replace(';', '|')};" +
                $"{(!String.IsNullOrEmpty(DocLink) ? DocLink.Replace(';', '|') : "")};" +
                $"{MName.Replace(';', '|')};" +
                $"{serialNumbers};{itSystemsShortNames}";
        }
        public override bool Equals(object obj)
        {
            return obj is MaintenanceLog log && log.LogId == this.LogId;
        }
        public override string ToString()
        {
            try
            {
                string systems = String.Empty;
                foreach (int item in AffectedItSystemsId)
                {
                    systems += DBManager.GetItSystemById(item).SShortName + "|";
                }
                return $"{LogId};{StartDate};{EndDate};{systems}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
