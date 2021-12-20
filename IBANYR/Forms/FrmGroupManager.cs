using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmGroupManager : Form
    {
        #region Private fields
        User user;
        List<PermissionGroup> groupList;
        List<Permission> permissions;
        List<Permission> groupPermissions;
        readonly ToolTip tt;
        #endregion
        #region Constructors
        internal FrmGroupManager(User user)
        {
            InitializeComponent();
            this.user = user;
            groupList = new List<PermissionGroup>();
            permissions = new List<Permission>();
            groupPermissions = new List<Permission>();
            tt = new ToolTip();
            tt.SetToolTip(btnAddGroup, "Új csoport rögzítése");
            tt.SetToolTip(btnDeleteGroup, "Csoport törlése");
            tt.SetToolTip(btnEditGroup, "Csoport adatainak szerkesztése");
            tt.SetToolTip(btnRefreshGroups, "Lista frissítése");
            tt.SetToolTip(btnAddPermission, "Jogosultság hozzáadása");
            tt.SetToolTip(btnRemovePermission, "Jogosultság eltávolítása");
            tt.SetToolTip(txbGName, "A csoportnév megadása kötelező, valamint minimum 3 és maximum 25 karakter hosszú lehet!");
            tt.SetToolTip(rtbGDiscription, "A leírás nem lehet üres, és hossza nem haladhatja meg a 4000 karaktert!");
            btnAddGroup.Enabled = user.HasPermission("createGroup");
            btnDeleteGroup.Enabled = user.HasPermission("deleteGroup");
            btnEditGroup.Enabled = user.HasPermission("updateGroup");
            RefreshGroupDataGridView();
            DisplayGroupDatasheet();
        }
        #endregion
        #region Component events
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sender as Button).Text == "Rögzítés")
                {
                    if (!DBManager.IsGNameExists(txbGName.Text.Trim()))
                    {
                        PermissionGroup newGroup = new PermissionGroup(txbGName.Text.Trim(), rtbGDiscription.Text.Trim());
                        foreach (Permission item in groupPermissions)
                        {
                            newGroup.AddPermission(item);
                        }
                        DBManager.CreateGroup(newGroup);
                        SystemLog.WriteLogEvent(user, EventType.createGroup, newGroup);
                        RefreshGroupDataGridView();
                        DisplayGroupDatasheet();
                    }
                    else
                    {
                        MessageBox.Show("Már létező csoportnév! Kérem adjon meg másikat!", "Csoport rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if ((sender as Button).Text == "Módosítás")
                {
                    if (!DBManager.IsGNameExists(txbGName.Text.Trim(), (int)dgvGroups.SelectedCells[0].Value))
                    {
                        PermissionGroup modifiedGroup = new PermissionGroup(txbGName.Text.Trim(), rtbGDiscription.Text.Trim(), (int)dgvGroups.SelectedCells[0].Value);
                        foreach (Permission item in groupPermissions)
                        {
                            modifiedGroup.AddPermission(item);
                        }
                        DBManager.UpdateGroup(modifiedGroup);
                        SystemLog.WriteLogEvent(user, EventType.updateGroup, modifiedGroup);
                        RefreshGroupDataGridView();
                        DisplayGroupDatasheet();
                    }
                    else
                    {
                        MessageBox.Show("Már létező csoportnév! Kérem adjon meg másikat!", "Csoport rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Figyelmeztetés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            groupPermissions.Clear();
            txbGName.Text = rtbGDiscription.Text = String.Empty;
            grbEditor.Text = "Új csoport rögzítése";
            btnOk.Text = "Rögzítés";
            RefreshPermissionLists();
            DisplayGroupDatasheet(true);
            btnRemovePermission.Enabled = false;
        }
        private void BtnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedCells != null && dgvGroups.SelectedCells[0].Value is int dgvGId)
            {
                try
                {
                    if (dgvGId == 1)
                    {
                        MessageBox.Show("Az elsődleges adminisztrátori jogosultsági csoport törlése nem lehetséges?", "Csoport törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (MessageBox.Show("Biztosan törli a kijelölt csoportot?", "Csoport törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SystemLog.WriteLogEvent(user, EventType.deleteGroup);
                        DBManager.DeleteGroup(dgvGId);
                        RefreshGroupDataGridView();
                    }
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
                MessageBox.Show("Válasszon ki egy csoportot a funkció használatához!", "Csoport szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedCells != null && dgvGroups.SelectedCells[0].Value is int changeIndex)
            {
                if (changeIndex == 1)
                {
                    MessageBox.Show("Az elsődleges adminisztrátori jogosultsági csoport módosítása nem lehetséges?", "Csoport módosítása..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    grbEditor.Text = "Csoport módosítása";
                    btnOk.Text = "Módosítás";
                    RefreshPermissionLists();
                    DisplayGroupDatasheet(true);
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy csoportot a funkció használatához!", "Csoport szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshGroups_Click(object sender, EventArgs e)
        {
            RefreshGroupDataGridView();
        }
        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            if (lsbPermissions.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbPermissions.SelectedItems)
                {
                    groupPermissions.Add((Permission)item);
                }
                RefreshPermissionLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzáadni kívánt jogosultságot!", "Jogosultság hozzáadása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemovePermission_Click(object sender, EventArgs e)
        {
            if (lsbGroupPermissions.SelectedIndices.Count > 0)
            {
                foreach (Permission item in lsbGroupPermissions.SelectedItems)
                {
                    groupPermissions.Remove(item);
                }
                RefreshPermissionLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó jogosultságot!", "Jogosultság eltávolítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LsbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbPermissions.SelectedIndex != -1)
            {
                lsbGroupPermissions.SelectedIndex = -1;
            }
        }
        private void LsbGroupPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbGroupPermissions.SelectedIndex != -1)
            {
                lsbPermissions.SelectedIndex = -1;
            }
        }
        private void DgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedCells.Count > 0 && dgvGroups.SelectedCells[0].Value is int dgvGId)
            {
                txbGName.Text = groupList.Where(x => x.GId == dgvGId).First().GName;
                rtbGDiscription.Text = groupList.Where(x => x.GId == dgvGId).First().GDescription;
                groupPermissions = groupList.Where(x => x.GId == dgvGId).First().Permissions;
                grbEditor.Text = "Csoport adatlapja";
                RefreshPermissionLists();
                DisplayGroupDatasheet();
            }
        }
        private void LsbPermissions_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListBox lsb && lsb.SelectedItems.Count > -1)
            {
                string message = String.Empty;
                foreach (Permission item in lsb.SelectedItems)
                {
                    message += $"\"{item.PName}\" jog leírása:\n\r{item.PDescription}\n\r\n\r";
                }
                MessageBox.Show(message, "Kiválasztott jog/-ok leírása", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshGroupDataGridView()
        {
            try
            {
                groupList.Clear();
                foreach (PermissionGroup item in DBManager.GetGroupsList())
                {
                    groupList.Add(item);
                }
                dgvGroups.DataSource = null;
                dgvGroups.AllowUserToAddRows = false;
                dgvGroups.Rows.Clear();
                dgvGroups.LoadDataToGridView<PermissionGroup>(groupList);
                for (int i = 0; i < dgvGroups.Rows.Count; i++)
                {
                    dgvGroups.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                    dgvGroups.Rows[i].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
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
        private void RefreshPermissionLists()
        {
            try
            {
                lsbGroupPermissions.DataSource = lsbPermissions.DataSource = null;
                permissions.Clear();
                if (groupPermissions == null || groupPermissions.Count == 0)
                {
                    permissions = DBManager.GetPermissionsList();
                }
                else
                {
                    foreach (Permission item in DBManager.GetPermissionsList())
                    {
                        if (groupPermissions.FindIndex(y => y.PId == item.PId) == -1)
                        {
                            permissions.Add(item);
                        }
                    }
                }

                lsbPermissions.DataSource = permissions;
                lsbGroupPermissions.DataSource = groupPermissions;
                btnAddPermission.Enabled = lsbPermissions.Items.Count != 0;
                btnRemovePermission.Enabled = lsbGroupPermissions.Items.Count != 0;
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
        private void DisplayGroupDatasheet(bool editable = false)
        {
            foreach (Control item in grbEditor.Controls)
            {
                if (item is TextBox tb)
                {
                    tb.ReadOnly = !editable;
                }
                else if (item is RichTextBox rtb)
                {
                    rtb.ReadOnly = !editable;
                }
                else if (item is Button btn)
                {
                    btn.Enabled = btn.Visible = editable;
                }
                else if (item.Name == "lblPermissions" || item.Name == "lsbPermissions")
                {
                    item.Visible = editable;
                }
                else if (item.Name == "lsbGroupPermissions")
                {
                    (item as ListBox).ClearSelected();
                }
            }
        }
        #endregion
    }
}
