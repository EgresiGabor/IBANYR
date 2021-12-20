using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class MaintenancePanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<MaintenanceLog> maintenanceLogList;
        int actualPageNumber;
        int maxRowNum;
        int allResultNum;
        #endregion
        #region Constructors
        internal MaintenancePanel(User user)
        {
            InitializeComponent();
            this.user = user;
            maintenanceLogList = new List<MaintenanceLog>();
            actualPageNumber = 1;
            maxRowNum = 100;
            tt = new ToolTip();
            tt.SetToolTip(btnAddMaintenanceLog, "Karbantartási naplóbejegyzés rögzítése");
            tt.SetToolTip(btnDeleteMaintenanceLog, "Karbantartási naplóbejegyzés törlése");
            tt.SetToolTip(btnEditMaintenanceLog, "Karbantartási naplóbejegyzés módosítása");
            tt.SetToolTip(btnExportMaintenanceLogsToCsv, "Karbantartási napló exportálása");
            tt.SetToolTip(btnReadMaintenanceLog, "Karbantartási naplóbejegyzés megtekintése");
            tt.SetToolTip(btnRefreshMaintenanceLogs, "Lista frissítése");
            tt.SetToolTip(txbMName, "Karbantartást végző személy vagy szervezet neve részben, vagy egészben.\nMaximum 50 karakter hosszú szöveg adható meg a kis- és nagybetűk figyelmen kívűl hagyásával.");
            tt.SetToolTip(cmbMType, "Karbantartás típusa szerinti szűrés.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbMMethod, "Karbantartás módja szerinti szűrés.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(dtpStartDate, "Karbantartás kezdő időpontjának alsó határa.");
            tt.SetToolTip(dtpEndDate, "Karbantartás befejezésének időpontjának felső határa.");
            tt.SetToolTip(txbActivitiesDesc, "Karbantartáskor végzett tevékenység részben, vagy egyészben.\nMaximum 50 karakter hosszú szöveg adható meg a kis- és nagybetűk figyelmen kívűl hagyásával.");
            tt.SetToolTip(btnFirstPage, "Ugrás az első oldalra");
            tt.SetToolTip(btnPreviousPage, "Előző oldal");
            tt.SetToolTip(btnNextPage, "Következő oldal");
            tt.SetToolTip(btnLastPage, "Ugrás az utolsó oldalra");
            dtpStartDate.MinDate = dtpEndDate.MinDate = SqlDateTime.MinValue.Value;
            dtpStartDate.Checked = dtpEndDate.Checked = false;
            cmbMType.Items.Add(String.Empty);
            foreach (var item in Enum.GetValues(typeof(MaintenanceType)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList())
            {
                cmbMType.Items.Add(item);
            }
            cmbMType.DisplayMember = "Description";
            cmbMType.ValueMember = "value";
            cmbMMethod.Items.Add(String.Empty);
            foreach (var item in Enum.GetValues(typeof(MaintenanceMethod)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList())
            {
                cmbMMethod.Items.Add(item);
            }
            cmbMMethod.DisplayMember = "Description";
            cmbMMethod.ValueMember = "value";
            ChangePage(null, null);
            btnAddMaintenanceLog.Enabled = user.HasPermission("createMaintenanceLog");
            btnEditMaintenanceLog.Enabled = user.HasPermission("updateMaintenanceLog");
            btnDeleteMaintenanceLog.Enabled = user.HasPermission("deleteMaintenanceLog");
        }
        #endregion
        #region Component events
        private void BtnAddMaintenanceLog_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaintenanceManager frm = new FrmMaintenanceManager();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SystemLog.WriteLogEvent(user, EventType.createMaintenanceLog, frm.Maintenance);
                    if (DBManager.GetConfiguration().EnableEmail && frm.Maintenance.AffectedItSystemsId.Count > 0 && MessageBox.Show($"Szeretné email-ben értesíteni {(frm.Maintenance.Status == MaintenanceState.closed ? "a karbantartás befejezéséről" : "a karbantartásról/üzemzavarról")} az érintett rendszer/-ek felhasználóit?", "Email küldése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string subject = $"Értesítés {(frm.Maintenance.Status == MaintenanceState.closed ? "karbantartás befejezéséről" : "karbantartásról")}";
                        for (int i = 0; i < frm.Maintenance.AffectedItSystemsId.Count; i++)
                        {
                            ItSystem sys = DBManager.GetItSystemById(frm.Maintenance.AffectedItSystemsId[i]);
                            List<User> addresse = sys.GetItSystemUsers();
                            string message = $"<p>A(z) <i>\"{sys.SName}\"</i> {(frm.Maintenance.MType == MaintenanceType.occasional ? "eseti" : "tervezett")} karbantartása ";
                            if (frm.Maintenance.Status == MaintenanceState.closed)
                            {
                                message += $"<b>{frm.Maintenance.EndDate}</b> időpontban befejeződött.</p><p>A rendszerben történő munka zavartalanul folytatható!</p>";
                            }
                            else if (frm.Maintenance.Status == MaintenanceState.planned)
                            {
                                message += $"várható az alábbi időintervallumban:</p><p><b>{frm.Maintenance.StartDate} - {frm.Maintenance.EndDate}</b></p><p>Kérem, vegye figyelembe munkavégzése során, hogy a karbantartás ideje alatt részleges/teljes üzemkiesés fordulhat elő!</p>";
                            }
                            else if (frm.Maintenance.Status == MaintenanceState.inProgress)
                            {
                                message += $"folyamatban van.</p><p>A karbantartás befejezéséről a későbbiekben tájékoztatjuk.</p><p>Kérem, vegye figyelembe munkavégzése során, hogy a karbantartás ideje alatt részleges/teljes üzemkiesés fordulhat elő!</p>";
                            }
                            foreach (User item in addresse)
                            {
                                EmailSender.SendEmail(subject, message, item);
                            }
                        }
                    }
                }
                ChangePage(null, null);
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnDeleteMaintenanceLog_Click(object sender, EventArgs e)
        {
            if (dgvMaintenanceLogs.SelectedCells.Count > 0 && int.TryParse(dgvMaintenanceLogs.SelectedCells[0].Value.ToString(), out int logId))
            {
                try
                {
                    if (MessageBox.Show("Biztosan törli a kijelölt bejegyzést?", "Karbantartási naplóbejegyzés törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DBManager.DeleteMaintenanceLog(logId);
                        SystemLog.WriteLogEvent(user, EventType.deleteMaintenanceLog, maintenanceLogList.Find(x => x.LogId == logId));
                        ChangePage(null, null);
                    }
                }
                catch (DBException ex)
                {
                    MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy bejegyzést a funkció használatához!", "Karbantartási naplóbejegyzés törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditMaintenanceLog_Click(object sender, EventArgs e)
        {
            if (dgvMaintenanceLogs.SelectedCells.Count > 0 && int.TryParse(dgvMaintenanceLogs.SelectedCells[0].Value.ToString(), out int logId))
            {
                try
                {
                    FrmMaintenanceManager frm = new FrmMaintenanceManager(maintenanceLogList.Find(x => x.LogId == logId));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SystemLog.WriteLogEvent(user, EventType.updateMaintenanceLog, frm.Maintenance);
                        if (DBManager.GetConfiguration().EnableEmail && frm.Maintenance.AffectedItSystemsId.Count > 0 && MessageBox.Show($"Szeretné email-ben értesíteni {(frm.Maintenance.Status == MaintenanceState.closed ? "a karbantartás befejezéséről" : "a karbantartásról/üzemzavarról")} az érintett rendszer/-ek felhasználóit?", "Email küldése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string subject = $"Értesítés {(frm.Maintenance.Status == MaintenanceState.closed ? "karbantartás befejezéséről" : "karbantartásról")}";
                            for (int i = 0; i < frm.Maintenance.AffectedItSystemsId.Count; i++)
                            {
                                ItSystem sys = DBManager.GetItSystemById(frm.Maintenance.AffectedItSystemsId[i]);
                                List<User> addresse = sys.GetItSystemUsers();
                                string message = $"<p>A(z) <i>\"{sys.SName}\"</i> {(frm.Maintenance.MType == MaintenanceType.occasional ? "eseti" : "tervezett")} karbantartása ";
                                if (frm.Maintenance.Status == MaintenanceState.closed)
                                {
                                    message += $"<b>{frm.Maintenance.EndDate}</b> időpontban befejeződött.</p><p>A rendszerben történő munka zavartalanul folytatható!</p>";
                                }
                                else if (frm.Maintenance.Status == MaintenanceState.planned)
                                {
                                    message += $"várható az alábbi időintervallumban:</p><p><b>{frm.Maintenance.StartDate} - {frm.Maintenance.EndDate}</b></p><p>Kérem, vegye figyelembe munkavégzése során, hogy a karbantartás ideje alatt részleges/teljes üzemkiesés fordulhat elő!</p>";
                                }
                                else if (frm.Maintenance.Status == MaintenanceState.inProgress)
                                {
                                    message += $"folyamatban van.</p><p>A karbantartás befejezéséről a későbbiekben tájékoztatjuk.</p><p>Kérem, vegye figyelembe munkavégzése során, hogy a karbantartás ideje alatt részleges/teljes üzemkiesés fordulhat elő!</p>";
                                }
                                foreach (User item in addresse)
                                {
                                    EmailSender.SendEmail(subject, message, item);
                                }
                            }
                        }
                        ChangePage(null, null);
                    }

                }
                catch (DBException ex)
                {
                    MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy bejegyzést a funkció használatához!", "Karbantartási naplóbejegyzés szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadMaintenanceLog_Click(object sender, EventArgs e)
        {
            if (dgvMaintenanceLogs.SelectedCells.Count > 0 && int.TryParse(dgvMaintenanceLogs.SelectedCells[0].Value.ToString(), out int logId))
            {
                try
                {
                    FrmMaintenanceManager frm = new FrmMaintenanceManager(maintenanceLogList.Find(x => x.LogId == logId), true);
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.readMaintenanceLog, maintenanceLogList.Find(x => x.LogId == logId));
                }
                catch (DBException ex)
                {
                    MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy bejegyzést a funkció használatához!", "Karbantartási naplóbejegyzés megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnExportMaintenanceLogsToCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToCsv.ShowDialog() == DialogResult.OK)
                {
                    MaintenanceLog.ExportToCsv(
                        sfdExportToCsv.FileName,
                        null,
                        null,
                        cmbMType.SelectedIndex >= 1 ? (MaintenanceType?)(cmbMType.SelectedIndex - 1) : null,
                        cmbMMethod.SelectedIndex >= 1 ? (MaintenanceMethod?)(cmbMMethod.SelectedIndex - 1) : null,
                        dtpStartDate.Checked ? (DateTime?)dtpStartDate.Value.Date : null,
                        dtpEndDate.Checked ? (DateTime?)dtpEndDate.Value.Date : null,
                        txbActivitiesDesc.Text.Trim(),
                        txbMName.Text.Trim());
                    SystemLog.WriteLogEvent(user, EventType.exportMaintenanceLogs);
                    if (MessageBox.Show("Exportálás befejeződött!\n\rSzeretné megnyitni az elkészült fájlt?", "Exportálás...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(sfdExportToCsv.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnRefreshMaintenanceLogs_Click(object sender, EventArgs e)
        {
            ChangePage(null, null);
        }
        private void BtnDeleteFilterMaintenance_Click(object sender, EventArgs e)
        {
            cmbMMethod.SelectedIndex = cmbMType.SelectedIndex = -1;
            dtpStartDate.Checked = dtpEndDate.Checked = false;
            txbMName.Text = txbActivitiesDesc.Text = String.Empty;
            ChangePage(null, null);
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshMaintenanceLogDataGridView()
        {
            try
            {
                maintenanceLogList.Clear();
                foreach (MaintenanceLog item in DBManager.GetFilteredMaintenanceLogsList(
                    maxRowNum,
                    actualPageNumber,
                    null,
                    null,
                    cmbMType.SelectedIndex >= 1 ? (MaintenanceType?)(cmbMType.SelectedIndex - 1) : null,
                    cmbMMethod.SelectedIndex >= 1 ? (MaintenanceMethod?)(cmbMMethod.SelectedIndex - 1) : null,
                    dtpStartDate.Checked ? (DateTime?)dtpStartDate.Value.Date : null,
                    dtpEndDate.Checked ? (DateTime?)dtpEndDate.Value.Date : null,
                    txbActivitiesDesc.Text.Trim(),
                    txbMName.Text.Trim(),
                    out allResultNum))
                {
                    maintenanceLogList.Add(item);
                }
                dgvMaintenanceLogs.DataSource = null;
                dgvMaintenanceLogs.AllowUserToAddRows = false;
                dgvMaintenanceLogs.Rows.Clear();
                dgvMaintenanceLogs.LoadDataToGridView<MaintenanceLog>(maintenanceLogList);
                for (int i = 0; i < dgvMaintenanceLogs.Rows.Count; i++)
                {
                    dgvMaintenanceLogs.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                    dgvMaintenanceLogs.Rows[i].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                }
                lblNumberOfMaintenanceLogs.Text = $"Listázott bejegyzések száma: {allResultNum}";
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangePage(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "btnFirstPage":
                        actualPageNumber = 1;
                        break;
                    case "btnPreviousPage":
                        actualPageNumber--;
                        break;
                    case "btnNextPage":
                        actualPageNumber++;
                        break;
                    case "btnLastPage":
                        actualPageNumber = (int)Math.Ceiling(allResultNum * 1.0 / maxRowNum);
                        break;
                    default:
                        actualPageNumber = 1;
                        break;
                }
            }
            RefreshMaintenanceLogDataGridView();
            foreach (Control item in pnlDgvFooter.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = ((item == btnFirstPage || item == btnPreviousPage) && actualPageNumber > 1) || ((item == btnNextPage || item == btnLastPage) && actualPageNumber < Math.Ceiling(allResultNum * 1.0 / maxRowNum));
                }
            }
            lblPageNumber.Text = $"{actualPageNumber}/{(Math.Ceiling(allResultNum * 1.0 / maxRowNum) == 0 ? 1 : Math.Ceiling(allResultNum * 1.0 / maxRowNum))} oldal";
        }
        #endregion
    }
}
