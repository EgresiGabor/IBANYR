using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class UsersPanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<User> userList;
        #endregion
        #region Constructors
        internal UsersPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            userList = new List<User>();
            tt = new ToolTip();
            tt.SetToolTip(btnAddUser, "Új felhasználó rögzítése");
            tt.SetToolTip(btnDeleteUser, "Felhasználó törlése");
            tt.SetToolTip(btnEditUser, "Felhasználó adatainak szerkesztése");
            tt.SetToolTip(btnReadUser, "Felhasználó adatainak megtekintése");
            tt.SetToolTip(btnChangePassword, "Felhasználó jelszavának módosítása");
            tt.SetToolTip(btnUserItSystemPermission, "Felhasználó rendszerjogosultságainak kezelése");
            tt.SetToolTip(btnRefreshUsers, "Lista frissítése");
            tt.SetToolTip(txbUName, "Felhasználó neve részben vagy egészben.\nÜresen hagyva nincs hatása a szűrésre.\nMaximum 50 karakter hosszú szöveg adható meg.");
            tt.SetToolTip(dtpRegDateStart, "Annak az időintervallumnak az alsó határa amibe a regisztráció dátuma esik.");
            tt.SetToolTip(dtpRegDateEnd, "Annak az időintervallumnak a felső határa amibe a regisztráció dátuma esik.");
            tt.SetToolTip(cmbLocked, "Felhasználói fiók zárolva van-e.\nÜres érték esetén nincs hatása a szűrésre.");
            tt.SetToolTip(cmbUserGroup, "Felhasználó jogosultsági csoporttagsága.\nÜres érték esetén nincs hatása a szűrésre.");
            btnAddUser.Enabled = user.HasPermission("createUser");
            btnDeleteUser.Enabled = user.HasPermission("deleteUser");
            btnEditUser.Enabled = user.HasPermission("updateUser");
            btnChangePassword.Enabled = user.HasPermission("updateUser");
            RefreshUserDataGridView();
            dtpRegDateStart.MinDate = dtpRegDateEnd.MinDate = SqlDateTime.MinValue.Value;
            dtpRegDateStart.Checked = dtpRegDateEnd.Checked = false;
            cmbUserGroup.Items.Add(String.Empty);
            try
            {
                dtpRegDateStart.MaxDate = dtpRegDateEnd.MaxDate = DBManager.GetCurrentTime().Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                foreach (PermissionGroup item in DBManager.GetGroupsList())
                {
                    cmbUserGroup.Items.Add(item);
                }
                SystemLog.WriteLogEvent(user, EventType.listUsers);
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
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUserManager frm = new FrmUserManager();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SystemLog.WriteLogEvent(user, EventType.createUser, frm.User);
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
            RefreshUserDataGridView();
        }
        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0 && dgvUsers.SelectedCells[0].Value is int userId)
            {
                try
                {
                    User deleteUser = DBManager.GetUserById(userId);
                    if (user.Equals(deleteUser))
                    {
                        MessageBox.Show("Saját felhasználói fiók törlése nem lehetséges!", "Felhasználó törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (deleteUser.UId == 1)
                    {
                        MessageBox.Show("Az elsődleges adminisztrátori fiók törlése nem lehetséges!", "Felhasználó törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (deleteUser.DeleteDate != null)
                    {
                        MessageBox.Show("A kijelölt felhasználó már törölve van!", "Felhasználó törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (MessageBox.Show("Biztosan törli a kijelölt felhasználót?", "Felhasználó törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DBManager.DeleteUser(userId);
                        SystemLog.WriteLogEvent(user, EventType.deleteUser, deleteUser);
                        RefreshUserDataGridView();
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
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Felhasználó törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0 && dgvUsers.SelectedCells[0].Value is int userId)
            {

                try
                {
                    if ((DBManager.GetUserById(userId) as User).DeleteDate == null)
                    {
                        FrmUserManager frm = new FrmUserManager(DBManager.GetUserById(userId));
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            if (user.Equals(frm.User))
                            {
                                MessageBox.Show("A módosítások érvénybeléptetéséhez kérem, lépjen be újra!", "Saját adatok módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            SystemLog.WriteLogEvent(user, EventType.updateUser, frm.User);
                            RefreshUserDataGridView();
                        }
                    }
                    else
                    {
                        MessageBox.Show("A kijelölt felhasználó már törölve van, adatainak módosítása nem lehetséges!", "Felhasználó szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Felhasználó szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0 && dgvUsers.SelectedCells[0].Value is int userId)
            {
                if (user.UId != userId)
                {
                    if ((DBManager.GetUserById(userId) as User).DeleteDate == null)
                    {
                        if (MessageBox.Show("Biztosan módosítja a kijelölt felhasználó jelszavát?", "Jelszó módosítása...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                string newPassword = DBManager.UpdateUserPw(DBManager.GetUserById(userId), out bool mailWasSent);
                                SystemLog.WriteLogEvent(user, EventType.userPasswordChange, DBManager.GetUserById(userId));
                                MessageBox.Show($"Felhasználó jelszava módosításra került!{(!mailWasSent ? $"\n\rAz értesítő email elküldése sikertelen!\n\rAz új jelszó: {newPassword}" : "\n\rFelhasználó emailben értesítve!")}", "Jelszó módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshUserDataGridView();
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
                    }
                    else
                    {
                        MessageBox.Show("A kijelölt felhasználó már törölve van, jelszavának módosítása nem lehetséges!", "Jelszó módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (MessageBox.Show("Saját jelszavát csak a \"Jelszó módosítása\" funkció segítségével változtathatja meg!\n\rSzeretné használni a funkciót?", "Jelszó módosítása...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            FrmChangePassword frm = new FrmChangePassword(user);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                MessageBox.Show("Jelszó módosítása sikeres!", "Jelszómódosítás...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SystemLog.WriteLogEvent(user, EventType.ownPasswordChange);
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
                }
            }
            else
            {
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Jelszó módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0 && dgvUsers.SelectedCells[0].Value is int userId)
            {
                try
                {
                    FrmUserManager frm = new FrmUserManager(DBManager.GetUserById(userId), true);
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.readUser, DBManager.GetUserById(userId));
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
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Felhasználó adatainak megtekintése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshUsers_Click(object sender, EventArgs e)
        {
            RefreshUserDataGridView(true);
        }
        private void DtpRegDateStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRegDateEnd.Value < dtpRegDateStart.Value)
            {
                bool checkState = dtpRegDateEnd.Checked;
                dtpRegDateEnd.Value = dtpRegDateStart.Value;
                dtpRegDateEnd.Checked = checkState;
            }
        }
        private void DtpRegDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRegDateEnd.Value < dtpRegDateStart.Value)
            {
                bool checkState = dtpRegDateStart.Checked;
                dtpRegDateStart.Value = dtpRegDateEnd.Value;
                dtpRegDateStart.Checked = checkState;
            }
        }
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshUserDataGridView(true);
                SystemLog.WriteLogEvent(user, EventType.filterUsers);
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
            txbUName.Text = String.Empty;
            dtpRegDateStart.Checked = dtpRegDateEnd.Checked = false;
            cmbLocked.SelectedIndex = cmbUserGroup.SelectedIndex = -1;
            RefreshUserDataGridView();
        }
        private void BtnUserItSystemPermission_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0 && dgvUsers.SelectedCells[0].Value is int userId)
            {
                try
                {
                    FrmUserItSystemPermission frm;
                    if ((DBManager.GetUserById(userId) as User).DeleteDate == null && user.HasPermission("updateUser"))
                    {
                        frm = new FrmUserItSystemPermission(DBManager.GetUserById(userId));
                    }
                    else
                    {
                        frm = new FrmUserItSystemPermission(DBManager.GetUserById(userId), true);
                    }
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
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Felhasználó rendszerjogosultságainak kezelése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshUserDataGridView(bool filtered = false)
        {
            try
            {
                userList.Clear();
                if (!filtered)
                {
                    foreach (User item in DBManager.GetUsersList())
                    {
                        userList.Add(item);
                    }
                }
                else
                {
                    foreach (User item in DBManager.GetUsersList().Where(x =>
                    (x.UName.ToLower().Contains(txbUName.Text.Trim().ToLower())) &&
                    (dtpRegDateStart.Checked ? x.RegDate.CompareTo(dtpRegDateStart.Value.Date) >= 0 : true) &&
                    (dtpRegDateEnd.Checked ? x.RegDate.CompareTo(dtpRegDateEnd.Value.Date.AddDays(1).AddSeconds(-1)) <= 0 : true) &&
                    x.Locked == (cmbLocked.SelectedItem == null || String.IsNullOrEmpty(cmbLocked.SelectedItem.ToString().Trim()) ? x.Locked : (cmbLocked.SelectedItem.ToString().Trim() == "Igen")) && (cmbUserGroup.SelectedItem == null || String.IsNullOrEmpty(cmbUserGroup.SelectedItem.ToString().Trim()) || (x.Permissions.FindIndex(y => y.GName == (cmbUserGroup.SelectedItem as PermissionGroup).GName) != -1))).ToList())
                    {
                        userList.Add(item);
                    }
                }
                dgvUsers.DataSource = null;
                dgvUsers.AllowUserToAddRows = false;
                dgvUsers.Rows.Clear();
                dgvUsers.LoadDataToGridView<User>(userList);
                int deleteDateIndex = 0;
                while (dgvUsers.Columns[deleteDateIndex].Name != "DeleteDate")
                {
                    deleteDateIndex++;
                }
                for (int i = 0; i < dgvUsers.Rows.Count; i++)
                {
                    if (dgvUsers.Rows[i].Cells[deleteDateIndex].Value != null)
                    {
                        dgvUsers.Rows[i].DefaultCellStyle.BackColor = dgvUsers.BackgroundColor;
                        dgvUsers.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 160, 184);
                    }
                    else
                    {
                        dgvUsers.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(184, 219, 246);
                    }
                    dgvUsers.Rows[i].DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 63, 118);
                }
                lblNumberOfUsers.Text = $"Listázott felhasználók száma: {userList.Count}";
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
