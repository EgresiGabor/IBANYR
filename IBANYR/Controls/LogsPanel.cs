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
    public partial class LogsPanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<SystemLog> logList;
        int actualPageNumber;
        int maxRowNum;
        int allResultNum;
        #endregion
        #region Constructors
        internal LogsPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            logList = new List<SystemLog>();
            actualPageNumber = 1;
            maxRowNum = 100;
            tt = new ToolTip();
            tt.SetToolTip(btnExportLogsToCsv, "Naplóbejegyzések exportálása");
            tt.SetToolTip(btnRefreshLogs, "Lista frissítése");
            tt.SetToolTip(cmbUsers, "Eseményt kiváltó felhasználó kiválasztása");
            tt.SetToolTip(dtpLogDateStart, "Esemény dátumának alsó határa");
            tt.SetToolTip(dtpLogDateEnd, "Esemény dátumának felső határa");
            tt.SetToolTip(cmbEventFunctions, "Bejegyzéstípus kiválasztása");
            tt.SetToolTip(btnFirstPage, "Ugrás az első oldalra");
            tt.SetToolTip(btnPreviousPage, "Előző oldal");
            tt.SetToolTip(btnNextPage, "Következő oldal");
            tt.SetToolTip(btnLastPage, "Ugrás az utolsó oldalra");
            dtpLogDateStart.MinDate = dtpLogDateEnd.MinDate = SqlDateTime.MinValue.Value;
            dtpLogDateStart.Checked = dtpLogDateEnd.Checked = false;
            cmbUsers.Items.Add(String.Empty);
            try
            {
                dtpLogDateStart.MaxDate = dtpLogDateEnd.MaxDate = DBManager.GetCurrentTime().Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                foreach (User item in DBManager.GetUsersList())
                {
                    cmbUsers.Items.Add(item);
                }
                SystemLog.WriteLogEvent(user, EventType.listSystemLogs);
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbEventFunctions.Items.Add(String.Empty);
            foreach (var item in Enum.GetValues(typeof(EventType)).Cast<Enum>().Select(value => new {(Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,value}).OrderBy(item => item.value).ToList())
            {
                cmbEventFunctions.Items.Add(item);
            }
            cmbEventFunctions.DisplayMember = "Description";
            cmbEventFunctions.ValueMember = "value";
            ChangePage(null, null);
        }
        #endregion
        #region Component events
        private void DtpLogDateStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpLogDateEnd.Value.Date < dtpLogDateStart.Value.Date)
            {
                bool checkState = dtpLogDateEnd.Checked;
                dtpLogDateEnd.Value = dtpLogDateStart.Value;
                dtpLogDateEnd.Checked = checkState;
            }
        }
        private void DtpLogDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpLogDateEnd.Value.Date < dtpLogDateStart.Value.Date)
            {
                bool checkState = dtpLogDateStart.Checked;
                dtpLogDateStart.Value = dtpLogDateEnd.Value;
                dtpLogDateStart.Checked = checkState;
            }
        }
        private void BtnDeleteFilter_Click(object sender, EventArgs e)
        {
            cmbUsers.SelectedIndex = cmbEventFunctions .SelectedIndex = -1;
            dtpLogDateStart.Checked = dtpLogDateEnd.Checked = false;
            ChangePage(null, null);
        }
        private void BtnExportLogsToCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToCsv.ShowDialog() == DialogResult.OK)
                {
                    SystemLog.ExportToCsv(
                        sfdExportToCsv.FileName,
                        dtpLogDateStart.Checked ? (DateTime?)dtpLogDateStart.Value.Date : null,
                        dtpLogDateEnd.Checked ? (DateTime?)dtpLogDateEnd.Value.Date.AddDays(1).AddSeconds(-1) : null,
                        cmbUsers.SelectedIndex <= 0 ? 0 : (cmbUsers.SelectedItem as User).UId,
                        cmbEventFunctions.SelectedIndex >= 1 ? (EventType?)(cmbEventFunctions.SelectedIndex - 1) : null);
                    SystemLog.WriteLogEvent(user, EventType.exportSystemLogs);
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
        private void BtnRefreshLogs_Click(object sender, EventArgs e)
        {
            ChangePage(null, null);
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshLogDataGridView()
        {
            try
            {
                logList.Clear();
                foreach (SystemLog item in DBManager.GetFilteredLogsList(
                    maxRowNum,
                    actualPageNumber,
                    dtpLogDateStart.Checked ? (DateTime?)dtpLogDateStart.Value.Date : null,
                    dtpLogDateEnd.Checked ? (DateTime?)dtpLogDateEnd.Value.Date.AddDays(1).AddSeconds(-1) : null,
                    cmbUsers.SelectedIndex <= 0 ? 0 : (cmbUsers.SelectedItem as User).UId,
                    cmbEventFunctions.SelectedIndex >= 1 ? (EventType?)(cmbEventFunctions.SelectedIndex - 1) : null,
                    out allResultNum))
                {
                    logList.Add(item);
                }
                dgvLogs.DataSource = null;
                dgvLogs.AllowUserToAddRows = false;
                dgvLogs.Rows.Clear();
                dgvLogs.LoadDataToGridView<SystemLog>(logList);
                for (int i = 0; i < dgvLogs.Rows.Count; i++)
                {
                    dgvLogs.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                    dgvLogs.Rows[i].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                }
                lblNumberOfLogs.Text = $"Listázott bejegyzések száma: {allResultNum}";
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
            RefreshLogDataGridView();
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
