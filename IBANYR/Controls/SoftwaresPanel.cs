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
    public partial class SoftwaresPanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<Software> softwareList;
        #endregion
        #region Constructors
        internal SoftwaresPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            this.softwareList = new List<Software>();
            tt = new ToolTip();
            tt.SetToolTip(btnAddSoftware, "Új szoftver rögzítése");
            tt.SetToolTip(btnDeleteSoftware, "Szoftver törlése");
            tt.SetToolTip(btnEditSoftware, "Szoftver adatainak szerkesztése");
            tt.SetToolTip(btnReadSoftware, "Szoftver adatainak megtekintése");
            tt.SetToolTip(btnExportSoftwaresToCsv, "Szoftverek exportálása");
            tt.SetToolTip(btnRefreshSoftwares, "Lista frissítése");
            tt.SetToolTip(txbSoftAName, "Szoftver neve részben vagy egészben.\nÜresen hagyva nincs hatása a szűrésre.\nMaximum 50 karakter hosszú szöveg adható meg.");
            tt.SetToolTip(cmbSoftwareProducer, "Szoftver gyártója.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbSoftwareItSystem, "Kapcsolódó rendszer.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbNetworkDeviceId, "Kapcsolódó számítógép eszköz.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbSoftwareOwnerId, "Szoftvert tulajdonló szervezet.\nÜres érték esetén nincs hatása a szűrésre.");
            btnAddSoftware.Enabled = user.HasPermission("createSoftware");
            btnDeleteSoftware.Enabled = user.HasPermission("deleteSoftware");
            btnEditSoftware.Enabled = user.HasPermission("updateSoftware");
            RefreshSoftwareDataGridView();
            cmbSoftwareProducer.Items.Add(String.Empty);
            cmbSoftwareOwnerId.Items.Add(String.Empty);
            cmbSoftwareItSystem.Items.Add(String.Empty);
            cmbNetworkDeviceId.Items.Add(String.Empty);
            try
            {
                foreach (string item in DBManager.GetSoftwareProducers())
                {
                    cmbSoftwareProducer.Items.Add(item);
                }
                foreach (ItSystem item in DBManager.GetItSystemsList().OrderBy(x => x.SShortName).ToList())
                {
                    cmbSoftwareItSystem.Items.Add(item);
                }
                foreach (Department item in DBManager.GetItAssetOwners().OrderBy(x => x.DName).ToList())
                {
                    cmbSoftwareOwnerId.Items.Add(item);
                }
                foreach (Hardware item in DBManager.GetHardwaresList())
                {
                    if (item is NetActiveDevice comp)
                    {
                        cmbNetworkDeviceId.Items.Add(comp);
                    }
                }
                SystemLog.WriteLogEvent(user, EventType.listSoftwares);
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
        private void BtnAddSoftware_Click(object sender, EventArgs e)
        {
            FrmSoftwareManager frm = new FrmSoftwareManager();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SystemLog.WriteLogEvent(user, EventType.createSoftware, frm.Software);
                }
                catch (DBException ex)
                {
                    MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshSoftwareProducerComboBox();
                RefreshOwnerIdComboBox();
                RefreshSoftwareDataGridView();
            }
        }
        private void BtnDeleteSoftware_Click(object sender, EventArgs e)
        {
            if (dgvSoftwares.SelectedCells.Count > 0 && int.TryParse(dgvSoftwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    if (MessageBox.Show("Biztosan törli a kijelölt szoftvert?", "Szoftver törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DBManager.DeleteSoftware(aId);
                        SystemLog.WriteLogEvent(user, EventType.deleteSoftware, softwareList.Find(x => x.AId == aId));
                        RefreshSoftwareProducerComboBox();
                        RefreshOwnerIdComboBox();
                        RefreshSoftwareDataGridView();
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
                MessageBox.Show("Válasszon ki egy szoftvert a funkció használatához!", "Szoftver törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditSoftware_Click(object sender, EventArgs e)
        {
            if (dgvSoftwares.SelectedCells.Count > 0 && int.TryParse(dgvSoftwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    FrmSoftwareManager frm = new FrmSoftwareManager(softwareList.Find(x => x.AId == aId));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SystemLog.WriteLogEvent(user, EventType.updateSoftware, frm.Software);
                        RefreshSoftwareProducerComboBox();
                        RefreshOwnerIdComboBox();
                        RefreshSoftwareDataGridView();
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
                MessageBox.Show("Válasszon ki egy szoftvert a funkció használatához!", "Szoftver szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadSoftware_Click(object sender, EventArgs e)
        {
            if (dgvSoftwares.SelectedCells.Count > 0 && int.TryParse(dgvSoftwares.SelectedCells[0].Value.ToString(), out int aId))
            {
                try
                {
                    FrmSoftwareManager frm = new FrmSoftwareManager(softwareList.Find(x => x.AId == aId), true);
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.readSoftware, softwareList.Find(x => x.AId == aId));
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
                MessageBox.Show("Válasszon ki egy szoftvert a funkció használatához!", "Szoftver adatainak megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnExportSoftwaresToCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToCsv.ShowDialog() == DialogResult.OK)
                {
                    Software.ExportToCsv(softwareList, sfdExportToCsv.FileName);
                    SystemLog.WriteLogEvent(user, EventType.exportSoftwares);
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
        private void BtnRefreshSoftwares_Click(object sender, EventArgs e)
        {
            RefreshSoftwareDataGridView(true);
        }
        private void BtnFilterSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshSoftwareDataGridView(true);
                SystemLog.WriteLogEvent(user, EventType.filterSoftwares);
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
        private void BtnDeleteFilterSoftware_Click(object sender, EventArgs e)
        {
            txbSoftAName.Text = String.Empty;
            cmbNetworkDeviceId.SelectedIndex = cmbSoftwareItSystem.SelectedIndex = cmbSoftwareOwnerId.SelectedIndex = cmbSoftwareProducer.SelectedIndex = -1;
            RefreshSoftwareDataGridView();
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshSoftwareDataGridView(bool filtered = false)
        {
            try
            {
                softwareList.Clear();
                if (!filtered)
                {
                    foreach (Software item in DBManager.GetSoftwaresList())
                    {
                        softwareList.Add(item);
                    }
                }
                else
                {
                    foreach (Software item in DBManager.GetSoftwaresList().Where(x =>
                    x.AName.ToLower().Contains(txbSoftAName.Text.Trim().ToLower()) &&
                    (cmbSoftwareProducer.SelectedIndex < 1 ? true : x.SoftwareProducer == cmbSoftwareProducer.SelectedItem.ToString()) &&
                    (cmbNetworkDeviceId.SelectedIndex < 1 ? true : x.HardwareIds.Contains((cmbNetworkDeviceId.SelectedItem as Hardware).AId)) &&
                    (cmbSoftwareItSystem.SelectedIndex < 1 ? true : x.ItSystems.Contains((ItSystem)cmbSoftwareItSystem.SelectedItem)) &&
                    (cmbSoftwareOwnerId.SelectedIndex < 1 ? true : x.Owner != null && x.Owner.Equals((Department)cmbSoftwareOwnerId.SelectedItem))).ToList())
                    {
                        softwareList.Add(item);
                    }
                }
                dgvSoftwares.DataSource = null;
                dgvSoftwares.AllowUserToAddRows = false;
                dgvSoftwares.Rows.Clear();
                if (dgvSoftwares.Columns.Count == 0)
                {
                    dgvSoftwares.Columns.Add("AId", "#");
                    dgvSoftwares.Columns.Add("AName", "Szoftver neve");
                    dgvSoftwares.Columns.Add("PurchaseDate", "Beszerzés dátuma");
                    dgvSoftwares.Columns.Add("Owner", "Szoftver tulajdonosa");
                    dgvSoftwares.Columns.Add("Status", "Státusz");
                    dgvSoftwares.Columns.Add("SoftwareProducer", "Gyártó");
                    dgvSoftwares.Columns.Add("SoftwareDesc", "Szoftver leírása, funkciója");
                    dgvSoftwares.Columns.Add("SoftwareLicenseNum", "Licenszszám");
                    dgvSoftwares.Columns.Add("LicenseDate", "Licensz érvényességi dátuma");
                    dgvSoftwares.Columns.Add("DocLink", "Dokumentum hivatkozások");
                    dgvSoftwares.Columns.Add("ScrappingDate", "Selejtezés dátuma");
                    dgvSoftwares.Columns.Add("OtherDescription", "Egyéb megjegyzés");
                    dgvSoftwares.Columns.Add("ItSystems", "Kapcsolódó rendszerek");
                    dgvSoftwares.ColumnHeaderMouseDoubleClick += Dgv_ColumnHeaderMouseDoubleClick;
                }
                foreach (Software item in softwareList)
                {
                    string[] row = {
                        item.AId.ToString(),
                        item.AName,
                        item.PurchaseDate.ToString("yyyy.MM.dd."),
                        item.Owner != null ? item.Owner.ToString() : "",
                        (Attribute.GetCustomAttribute(item.Status.GetType().GetField(item.Status.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                        item.SoftwareProducer,
                        item.SoftwareDesc,
                        item.SoftwareLicenseNum.ToString(),
                        item.LicenseDate is DateTime sld ? sld.ToString("yyyy.MM.dd.") : "",
                        item.DocLink,
                        item.ScrappingDate is DateTime scd ? scd.ToString("yyyy.MM.dd.") : "",
                        item.OtherDescription,
                        item.ItSystems.Count != 0 ? item.ItSystems.Select(i => i.SShortName).Aggregate((i, j) => i + ", " + j) : ""
                    };
                    dgvSoftwares.Rows.Add(row);
                    switch ((AssetState)item.Status)
                    {
                        case AssetState.outOfOrder:
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 230, 150);
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                        case AssetState.forScrapping:
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 131, 156);
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                        case AssetState.discarded:
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.BackColor = dgvSoftwares.BackgroundColor;
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 160, 184);
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                        case AssetState.inUse:
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                            dgvSoftwares.Rows[dgvSoftwares.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                            break;
                    }
                }
                lblNumberOfSoftwares.Text = $"Listázott szoftverek száma: {softwareList.Count}";
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
        private void RefreshSoftwareProducerComboBox()
        {
            cmbSoftwareProducer.Items.Clear();
            cmbSoftwareProducer.Items.Add(String.Empty);
            try
            {
                foreach (string item in DBManager.GetSoftwareProducers())
                {
                    cmbSoftwareProducer.Items.Add(item);
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
            cmbSoftwareOwnerId.Items.Clear();
            cmbSoftwareOwnerId.Items.Add(String.Empty);
            try
            {
                foreach (Department item in DBManager.GetItAssetOwners().OrderBy(x => x.DName).ToList())
                {
                    cmbSoftwareOwnerId.Items.Add(item);
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
