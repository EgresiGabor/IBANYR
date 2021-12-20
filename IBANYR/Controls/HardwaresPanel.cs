using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class HardwaresPanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<Hardware> hardwareList;
        #endregion
        #region Constructors
        internal HardwaresPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            this.hardwareList = new List<Hardware>();
            tt = new ToolTip();
            tt.SetToolTip(btnAddHardware, "Új hardver rögzítése");
            tt.SetToolTip(btnDeleteHardware, "Hardver törlése");
            tt.SetToolTip(btnEditHardware, "Hardver adatainak szerkesztése");
            tt.SetToolTip(btnReadHardware, "Hardver adatainak megtekintése");
            tt.SetToolTip(btnMaintenanceLogs, "Hardver karbantartási bejegyzései");
            tt.SetToolTip(btnRefreshHardwares, "Lista frissítése");
            tt.SetToolTip(btnExportToCsv, "Hardverek exportálása");
            tt.SetToolTip(txbAName, "Hardver neve részben vagy egészben.\nÜresen hagyva nincs hatása a szűrésre.\nMaximum 50 karakter hosszú szöveg adható meg.");
            tt.SetToolTip(cmbCategory, "Hardver kategóriája szerinti szűrési feltétel.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbUId, "Hardvert használó személy szerinti szűrési feltétel.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbItSystem, "Kapcsolódó rendszer szerinti szűrési feltétel.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbPortable, "A hardver hordozatósága szerinti szűrési feltétel.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbOwnerId, "Hardvert tulajdonló szervezet szerinti szűrési feltétel.\nÜres érték esetén nincs hatása a szűrésre.");
            btnAddHardware.Enabled = user.HasPermission("createHardware");
            btnDeleteHardware.Enabled = user.HasPermission("deleteHardware");
            btnEditHardware.Enabled = user.HasPermission("updateHardware");
            cmbCategory.Items.Add(String.Empty);
            cmbUId.Items.Add(String.Empty);
            cmbItSystem.Items.Add(String.Empty);
            cmbOwnerId.Items.Add(String.Empty);
            RefreshHardwareDataGridView();
            try
            {
                foreach (string item in DBManager.GetHardwareCategories())
                {
                    cmbCategory.Items.Add(item);
                }
                foreach (User item in DBManager.GetUsersList().Where(x => x.DeleteDate == null).OrderBy(x=>x.UName).ToList())
                {
                    cmbUId.Items.Add(item);
                }
                foreach (ItSystem item in DBManager.GetItSystemsList().OrderBy(x => x.SShortName).ToList())
                {
                    cmbItSystem.Items.Add(item);
                }
                foreach (Department item in DBManager.GetItAssetOwners().OrderBy(x=>x.DName).ToList())
                {
                    cmbOwnerId.Items.Add(item);
                }
                SystemLog.WriteLogEvent(user, EventType.listHardwares);
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
        #endregion
        #region Component events
        private void BtnAddHardware_Click(object sender, EventArgs e)
        {
            FrmHardwareManager frm = new FrmHardwareManager();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SystemLog.WriteLogEvent(user, EventType.createHardware, frm.HardwareDevice);
                }
                catch (DBException ex)
                {
                    MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshHardwareCategoryComboBox();
                RefreshOwnerIdComboBox();
                RefreshHardwareDataGridView();
            }
        }
        private void BtnDeleteHardware_Click(object sender, EventArgs e)
        {
            if (dgvHardwares.SelectedCells.Count > 0 && int.TryParse(dgvHardwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    if (MessageBox.Show("Biztosan törli a kijelölt hardvert?", "Hardver törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DBManager.DeleteHardware(aId);
                        SystemLog.WriteLogEvent(user, EventType.deleteHardware, hardwareList.Find(x => x.AId == aId));
                        RefreshHardwareCategoryComboBox();
                        RefreshOwnerIdComboBox();
                        RefreshHardwareDataGridView();
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
                MessageBox.Show("Válasszon ki egy hardvert a funkció használatához!", "Hardver törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditHardware_Click(object sender, EventArgs e)
        {
            if (dgvHardwares.SelectedCells.Count > 0 && int.TryParse(dgvHardwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    FrmHardwareManager frm = new FrmHardwareManager(hardwareList.Find(x => x.AId == aId));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SystemLog.WriteLogEvent(user, EventType.updateHardware, frm.HardwareDevice);
                        RefreshHardwareCategoryComboBox();
                        RefreshOwnerIdComboBox();
                        RefreshHardwareDataGridView();
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
                MessageBox.Show($"Válasszon ki egy hardvert a funkció használatához!", "Hardver szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadHardware_Click(object sender, EventArgs e)
        {
            if (dgvHardwares.SelectedCells.Count > 0 && int.TryParse(dgvHardwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    FrmHardwareManager frm = new FrmHardwareManager(hardwareList.Find(x => x.AId == aId), true);
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.readHardware, hardwareList.Find(x => x.AId == aId));
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
                MessageBox.Show("Válasszon ki egy hardvert a funkció használatához!", "Hardver adatainak megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnMaintenanceLogs_Click(object sender, EventArgs e)
        {
            if (dgvHardwares.SelectedCells.Count > 0 && int.TryParse(dgvHardwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    FrmMaintenaceOfHardware frm = new FrmMaintenaceOfHardware(user, aId);
                    frm.ShowDialog();
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
                MessageBox.Show("Válasszon ki egy hardvert a funkció használatához!", "Hardver adatainak megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnExportToCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToCsv.ShowDialog() == DialogResult.OK)
                {
                    Hardware.ExportToCsv(hardwareList, sfdExportToCsv.FileName);
                    SystemLog.WriteLogEvent(user, EventType.exportHardwares);
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
        private void BtnRefreshHardwares_Click(object sender, EventArgs e)
        {
            RefreshHardwareDataGridView(true);
        }
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshHardwareDataGridView(true);
                SystemLog.WriteLogEvent(user, EventType.filterHardwares);
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
        private void BtnDeleteFilter_Click(object sender, EventArgs e)
        {
            txbAName.Text = String.Empty;
            cmbCategory.SelectedIndex = cmbItSystem.SelectedIndex = cmbOwnerId.SelectedIndex = cmbPortable.SelectedIndex = cmbUId.SelectedIndex = -1;
            RefreshHardwareDataGridView();
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshHardwareDataGridView(bool filtered = false)
        {
            try
            {
                hardwareList.Clear();
                if (!filtered)
                {
                    foreach (Hardware item in DBManager.GetHardwaresList())
                    {
                        hardwareList.Add(item);
                    }
                }
                else
                {
                    foreach (Hardware item in DBManager.GetHardwaresList().Where(x =>
                    x.AName.ToLower().Contains(txbAName.Text.Trim().ToLower()) &&
                    (cmbCategory.SelectedIndex < 1 ? true : x.Category == cmbCategory.SelectedItem.ToString()) &&
                    (cmbUId.SelectedIndex < 1 ? true : x.UId == (cmbUId.SelectedItem as User).UId) &&
                    (cmbPortable.SelectedIndex < 1 ? true : x.Portable == (cmbPortable.SelectedItem.ToString() == "Igen" ? true : false)) &&
                    (cmbItSystem.SelectedIndex < 1 ? true : x.ItSystems.Contains((ItSystem)cmbItSystem.SelectedItem)) &&
                    (cmbOwnerId.SelectedIndex < 1 ? true : x.Owner != null && x.Owner.Equals((Department)cmbOwnerId.SelectedItem))).ToList())
                    {
                        hardwareList.Add(item);
                    }
                }
                dgvHardwares.DataSource = null;
                dgvHardwares.AllowUserToAddRows = false;
                dgvHardwares.Rows.Clear();
                if (dgvHardwares.Columns.Count == 0)
                {
                    dgvHardwares.Columns.Add("AId", "#");
                    dgvHardwares.Columns.Add("AName", "Hardver neve");
                    dgvHardwares.Columns.Add("PurchaseDate", "Beszerzés dátuma");
                    dgvHardwares.Columns.Add("Owner", "Hardver tulajdonosa");
                    dgvHardwares.Columns.Add("Category", "Hardver kategóriája");
                    dgvHardwares.Columns.Add("HardwareType", "Hardver típusa");
                    dgvHardwares.Columns.Add("Status", "Státusz");
                    dgvHardwares.Columns.Add("DocLink", "Dokumentum hivatkozások");
                    dgvHardwares.Columns.Add("ScrappingDate", "Selejtezés dátuma");
                    dgvHardwares.Columns.Add("OtherDescription", "Egyéb megjegyzés");
                    dgvHardwares.Columns.Add("UserDepartment", "Felhasználó szervezeti egysége");
                    dgvHardwares.Columns.Add("DeviceUser", "Hardver felhasználója");
                    dgvHardwares.Columns.Add("Place", "Felhasználási hely");
                    dgvHardwares.Columns.Add("SerialNumber", "Sorozatszám");
                    dgvHardwares.Columns.Add("WarrantyYears", "Garanciaévek száma");
                    dgvHardwares.Columns.Add("Portable", "Hordozható-e");
                    dgvHardwares.Columns.Add("IsVirtual", "Virtuális-e");
                    dgvHardwares.Columns.Add("HostName", "Hosztnév");
                    dgvHardwares.Columns.Add("ItSystems", "Kapcsolódó rendszerek");
                    dgvHardwares.Columns.Add("NicsList", "Hálózati csatolók");
                    dgvHardwares.Columns.Add("ipv4Addresses", "Ip címek");
                    dgvHardwares.ColumnHeaderMouseDoubleClick += Dgv_ColumnHeaderMouseDoubleClick;
                }
                foreach (Hardware item in hardwareList)
                {
                    string[] row = {
                        item.AId.ToString(),
                        item.AName,
                        item.PurchaseDate.ToString("yyyy.MM.dd."),
                        item.Owner != null ? item.Owner.ToString() : "",
                        item.Category,// != null ? item.Category : "",
                        (Attribute.GetCustomAttribute(item.HardwareType.GetType().GetField(item.HardwareType.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                        (Attribute.GetCustomAttribute(item.Status.GetType().GetField(item.Status.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                        item.DocLink,// != null ? item.DocLink : "",
                        item.ScrappingDate is DateTime scd ? scd.ToString("yyyy.MM.dd.") : "",
                        item.OtherDescription,// != null ? item.OtherDescription : "",
                        item.UserDepartment != null ? item.UserDepartment.ToString() : "",
                        item.UId != 0 ? item.DeviceUser.ToString() : "",
                        item.Place,//item.Place != null ? item.Place : "",
                        item.SerialNumber,// != null ? item.SerialNumber : "",
                        item.WarrantyYears.ToString(),
                        item.Portable ? "Igen" : "Nem",
                        item.IsVirtual ? "Igen" : "Nem",
                        item is NetActiveDevice nad ? nad.HostName : "",
                        item.ItSystems.Count != 0 ? item.ItSystems.Select(i => i.SShortName).Aggregate((i, j) => i + ", " + j) : "",
                        item is NetActiveDevice && (item as NetActiveDevice).NicsList.Count != 0 ? (item as NetActiveDevice).NicsList.Select(x=>x.ToString()).Aggregate((x, y) => x + ", " + y) : "",
                        item is NetActiveDevice && (item as NetActiveDevice).NicsList.Count != 0 ? (item as NetActiveDevice).NicsList.Select(x=>x.GetIpv4String()).Aggregate((x, y) => x + ", " + y) : ""
                    };
                    dgvHardwares.Rows.Add(row);
                    switch ((AssetState)item.Status)
                    {
                        case AssetState.outOfOrder:
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 230, 150);
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                        case AssetState.forScrapping:
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 131, 156);
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                        case AssetState.discarded:
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.BackColor = dgvHardwares.BackgroundColor;
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 160, 184);
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                        case AssetState.inUse:
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                            dgvHardwares.Rows[dgvHardwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                    }
                }
                lblNumberOfItems.Text = $"Listázott hardverek száma: {hardwareList.Count}";
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
        private void RefreshHardwareCategoryComboBox()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add(String.Empty);
            try
            {
                foreach (string item in DBManager.GetHardwareCategories())
                {
                    cmbCategory.Items.Add(item);
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
        private void RefreshOwnerIdComboBox()
        {
            cmbOwnerId.Items.Clear();
            cmbOwnerId.Items.Add(String.Empty);
            try
            {
                foreach (Department item in DBManager.GetItAssetOwners().OrderBy(x => x.DName).ToList())
                {
                    cmbOwnerId.Items.Add(item);
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
        private void Dgv_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is DgvColumnPanel panel && panel.Name == "columnPanel")
                {
                    item.Dispose();
                }
            }
            new DgvColumnPanel(sender as DataGridView);
        }
        #endregion

    }
}
