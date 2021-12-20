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
    public partial class ItSystemsPanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<ItSystem> systemList;
        #endregion
        #region Constructors
        internal ItSystemsPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            this.systemList = new List<ItSystem>();
            tt = new ToolTip();
            tt.SetToolTip(btnAddSystem, "Új rendszer rögzítése");
            tt.SetToolTip(btnDeleteSystem, "Rendszer törlése");
            tt.SetToolTip(btnEditSystem, "Rendszer adatainak szerkesztése");
            tt.SetToolTip(btnSystemPermissions, "Rendszerjogosultság kezelő megnyitása");
            tt.SetToolTip(btnReadSystem, "Rendszer adatainak megtekintése");
            tt.SetToolTip(btnExportToCsv, "Rendszerek exportálása");
            tt.SetToolTip(btnRefreshSystems, "Lista frissítése");
            tt.SetToolTip(txbSName, "Rendszer neve/rövid neve részben vagy egészben.\nÜresen hagyva nincs hatása a szűrésre.\nMaximum 50 karakter hosszú szöveg adható meg.");
            tt.SetToolTip(cmbLifeCycle, "Rendszer védelmi életciklusa.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbDataType, "Tárolt adatok típusa.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbDataOwnerDepartment, "Adatgazda szervezeti egység.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(numSecurityClass, "Biztonsági osztály szerinti szűrési paraméter.\nNulla érték esetén nincs hatása a szűrésre.");
            btnAddSystem.Enabled = user.HasPermission("createItSystem");
            btnDeleteSystem.Enabled = user.HasPermission("deleteItSystem");
            btnEditSystem.Enabled = user.HasPermission("updateItSystem");
            btnSystemPermissions.Enabled = user.HasPermission("readItSystemPermission");
            RefreshItSystemDataGridView();
            cmbLifeCycle.Items.Add(String.Empty);
            foreach (var item in Enum.GetValues(typeof(SystemLifeCycle)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList())
            {
                cmbLifeCycle.Items.Add(item);
            }
            cmbLifeCycle.DisplayMember = "Description";
            cmbLifeCycle.ValueMember = "value";
            cmbDataType.Items.Add(String.Empty);
            foreach (var item in Enum.GetValues(typeof(StoredDataType)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList())
            {
                cmbDataType.Items.Add(item);
            }
            cmbDataType.DisplayMember = "Description";
            cmbDataType.ValueMember = "value";
            cmbDataOwnerDepartment.Items.Add(String.Empty);
            try
            {
                foreach (Department item in Department.OrderByHierarchy(DBManager.GetDepartmentsList()))
                {
                    cmbDataOwnerDepartment.Items.Add(item);
                }

                SystemLog.WriteLogEvent(user, EventType.listItSystems);
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
        private void BtnAddSystem_Click(object sender, EventArgs e)
        {
            FrmItSystemManager frm = new FrmItSystemManager(user);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SystemLog.WriteLogEvent(user, EventType.createItSystem, frm.Sys);
                }
                catch (DBException ex)
                {
                    MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshItSystemDataGridView();
            }
        }
        private void BtnDeleteSystem_Click(object sender, EventArgs e)
        {
            if (dgvItSystems.SelectedCells.Count > 0 && dgvItSystems.SelectedCells[0].Value is int sysId)
            {
                try
                {
                    if (MessageBox.Show("Biztosan törli a kijelölt rendszert?", "Rendszer törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ItSystem deleteItSystem = DBManager.GetItSystemById(sysId);
                        DBManager.DeleteItSystem(sysId);
                        SystemLog.WriteLogEvent(user, EventType.deleteItSystem, deleteItSystem);
                        RefreshItSystemDataGridView();
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
                MessageBox.Show("Válasszon ki egy rendszert a funkció használatához!", "Rendszer törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditSystem_Click(object sender, EventArgs e)
        {
            if (dgvItSystems.SelectedCells.Count > 0 && dgvItSystems.SelectedCells[0].Value is int sysId)
            {
                try
                {
                    FrmItSystemManager frm = new FrmItSystemManager(user, DBManager.GetItSystemById(sysId));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SystemLog.WriteLogEvent(user, EventType.updateItSystem, frm.Sys);
                        RefreshItSystemDataGridView();
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
                MessageBox.Show("Válasszon ki egy rendszert a funkció használatához!", "Rendszer szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadSystem_Click(object sender, EventArgs e)
        {
            if (dgvItSystems.SelectedCells.Count > 0 && dgvItSystems.SelectedCells[0].Value is int sysId)
            {
                try
                {
                    FrmItSystemManager frm = new FrmItSystemManager(user, DBManager.GetItSystemById(sysId), true);
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.readItSystem, frm.Sys);
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
                MessageBox.Show("Válasszon ki egy rendszert a funkció használatához!", "Rendszer adatainak megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshSystems_Click(object sender, EventArgs e)
        {
            RefreshItSystemDataGridView(true);
        }
        private void BtnSystemPermissions_Click(object sender, EventArgs e)
        {
            if (dgvItSystems.SelectedCells.Count > 0 && dgvItSystems.SelectedCells[0].Value is int sysId)
            {
                try
                {
                    FrmItSystemPermissions frm = new FrmItSystemPermissions(user, DBManager.GetItSystemById(sysId));
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.listItSystemPermissions);
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
                MessageBox.Show("Válasszon ki egy rendszert a funkció használatához!", "Rendszer adatainak megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnExportToCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToCsv.ShowDialog() == DialogResult.OK)
                {
                    ItSystem.ExportToCsv(systemList, sfdExportToCsv.FileName);
                    SystemLog.WriteLogEvent(user, EventType.exportItSystems);
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
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshItSystemDataGridView(true);
                SystemLog.WriteLogEvent(user, EventType.filterItSystems);
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
            txbSName.Text = String.Empty;
            cmbLifeCycle.SelectedIndex = -1;
            cmbDataType.SelectedIndex = -1;
            numSecurityClass.Value = 0;
            cmbDataOwnerDepartment.SelectedIndex = -1;
            RefreshItSystemDataGridView();
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshItSystemDataGridView(bool filtered = false)
        {
            try
            {
                systemList.Clear();
                if (!filtered)
                {
                    foreach (ItSystem item in DBManager.GetItSystemsList())
                    {
                        systemList.Add(item);
                    }
                }
                else
                {
                    foreach (ItSystem item in DBManager.GetItSystemsList().Where(x =>
                    (x.SName.ToLower().Contains(txbSName.Text.Trim().ToLower()) || x.SShortName.ToLower().Contains(txbSName.Text.Trim().ToLower())) &&
                    (cmbLifeCycle.SelectedIndex <= 0 ? true : x.LifeCycle == (SystemLifeCycle)(cmbLifeCycle.SelectedIndex - 1)) &&
                    (cmbDataType.SelectedIndex <= 0 ? true : x.DataType == (StoredDataType)(cmbDataType.SelectedIndex - 1)) &&
                    (numSecurityClass.Value == 0 ? true : (x.SecurityClass == (byte)numSecurityClass.Value)) &&
                    (cmbDataOwnerDepartment.SelectedIndex <= 0 ? true : x.InnerDataOwner == (cmbDataOwnerDepartment.SelectedItem as Department).DId)
                    ).ToList())
                    {
                        systemList.Add(item);
                    }
                }
                dgvItSystems.DataSource = null;
                dgvItSystems.AllowUserToAddRows = false;
                dgvItSystems.Rows.Clear();
                dgvItSystems.LoadDataToGridView<ItSystem>(systemList);
                for (int i = 0; i < dgvItSystems.Rows.Count; i++)
                {
                    dgvItSystems.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                    dgvItSystems.Rows[i].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                }
                lblNumberOfItems.Text = $"Listázott rendszerek száma: {systemList.Count}";
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
    }
}
