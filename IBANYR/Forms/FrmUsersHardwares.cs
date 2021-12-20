using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmUsersHardwares : Form
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<Hardware> hardwareList;
        #endregion
        #region Constructors
        internal FrmUsersHardwares(User user)
        {
            InitializeComponent();
            this.user = user;
            this.hardwareList = new List<Hardware>();
            tt = new ToolTip();
            tt.SetToolTip(btnReadHardware, "Hardver adatainak megtekintése");
            tt.SetToolTip(btnMaintenanceLogs, "Hardver karbantartási bejegyzéseinek megtekintése");
            tt.SetToolTip(btnRefreshHardwares, "Lista frissítése");
            RefreshHardwareDataGridView();
        }
        #endregion
        #region Component events
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
                    DialogResult = DialogResult.None;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy hardvert a funkció használatához!", "Hardver adatainak megtekintése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    DialogResult = DialogResult.None;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy hardvert a funkció használatához!", "Hardver adatainak megtekintése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshHardwares_Click(object sender, EventArgs e)
        {
            RefreshHardwareDataGridView();
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshHardwareDataGridView()
        {
            try
            {
                hardwareList.Clear();
                foreach (Hardware item in DBManager.GetHardwaresList().Where(x=>x.DeviceUser != null && x.DeviceUser.Equals(user)))
                {
                    hardwareList.Add(item);
                }
                dgvHardwares.DataSource = null;
                dgvHardwares.AllowUserToAddRows = false;
                dgvHardwares.Rows.Clear();
                if (dgvHardwares.Columns.Count == 0)
                {
                    dgvHardwares.Columns.Add("AId", "#");
                    dgvHardwares.Columns.Add("AName", "Eszköz neve");
                    dgvHardwares.Columns.Add("PurchaseDate", "Beszerzés dátuma");
                    dgvHardwares.Columns.Add("Owner", "Eszköz tulajdonosa");
                    dgvHardwares.Columns.Add("Category", "Eszköz kategóriája");
                    dgvHardwares.Columns.Add("HardwareType", "Eszköz típusa");
                    dgvHardwares.Columns.Add("Status", "Státusz");
                    dgvHardwares.Columns.Add("DocLink", "Dokumentum hivatkozások");
                    dgvHardwares.Columns.Add("ScrappingDate", "Selejtezés dátuma");
                    dgvHardwares.Columns.Add("OtherDescription", "Egyéb megjegyzés");
                    dgvHardwares.Columns.Add("UserDepartment", "Felhasználó szervezeti egysége");
                    dgvHardwares.Columns.Add("DeviceUser", "Eszköz felhasználója");
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
                dgvHardwares.AllowUserToResizeColumns = true;
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
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
