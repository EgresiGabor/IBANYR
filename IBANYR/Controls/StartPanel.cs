using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class StartPanel : UserControl
    {
        #region Private fields
        readonly User user;
        List<User> userList;
        readonly ToolTip tt;
        #endregion
        #region Constructors
        internal StartPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            userList = new List<User>();
            tt = new ToolTip();
            tt.SetToolTip(btnReadUser, "Felhasználó adatainak megtekintése");
            tt.SetToolTip(btnUserItSystemPermission, "Felhasználó rendszerjogosultságai");
            tt.SetToolTip(btnRefreshUsers, "Lista frissítése");
            lblUserName.Text = user.UName;
            lblPost.Text = user.Post;
            lblEmail.Text = user.Email;
            lsvMaintenances.Columns.Add("#");
            lsvMaintenances.Columns.Add("Kezdő időpont");
            lsvMaintenances.Columns.Add("Záró időpont");
            lsvMaintenances.Columns.Add("Érintett rendszerek");

            if (user.UDepartment != null)
            {
                lblDepartment.Text = $"{user.UDepartment.DName} ({user.UDepartment.DShortName})";
            }
            if (!String.IsNullOrEmpty(user.Phone))
            {
                lblPhone.Text = user.Phone;
            }
            try
            {
                List<MaintenanceLog> logList = new List<MaintenanceLog>();
                DateTime now = DBManager.GetCurrentTime();
                foreach (ItSystem sys in user.GetUserItSystems())
                {
                    foreach (var item in DBManager.GetFilteredMaintenanceLogsList(100,1,null,sys,null,null,now,null,null,null,out int num))
                    {
                        if (!logList.Contains(item))
                        {
                            logList.Add(item);
                        }
                    }
                }
                foreach (MaintenanceLog item in logList.OrderBy(x=>x.StartDate))
                {
                    lsvMaintenances.Items.Add(new ListViewItem(item.ToString().Split(';')));
                }
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
            for (int i = 0; i < lsvMaintenances.Columns.Count; i++)
            {
                lsvMaintenances.Columns[i].Width = -2;
            }
            grbDepartmentUsers.Visible = userList.Count > 0;
        }
        #endregion
        #region Component events
        private void BtnOwnItSystemPermissions_Click(object sender, EventArgs e)
        {
            FrmUserItSystemPermission frm = new FrmUserItSystemPermission(user, true);
            frm.ShowDialog();
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
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Felhasználó adatainak megtekintése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnUserItSystemPermission_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedCells.Count > 0 && dgvUsers.SelectedCells[0].Value is int userId)
            {
                try
                {
                    FrmUserItSystemPermission frm = new FrmUserItSystemPermission(DBManager.GetUserById(userId), !user.HasPermission("updateUser"));
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
                MessageBox.Show("Válasszon ki egy felhasználót a funkció használatához!", "Felhasználó rendszerjogosultságainak kezelése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshUsers_Click(object sender, EventArgs e)
        {
            RefreshUserDataGridView();
        }
        private void BtnOwnHardwares_Click(object sender, EventArgs e)
        {
            FrmUsersHardwares frm = new FrmUsersHardwares(user);
            frm.ShowDialog();
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshUserDataGridView()
        {
            try
            {
                userList.Clear();
                userList = user.GetSubordinateUsers();
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
