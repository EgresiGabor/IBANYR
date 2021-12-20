using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmUserManager : Form
    {
        #region Private fields
        User user;
        List<PermissionGroup> groups;
        List<PermissionGroup> userGroups;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal User User { get => user; set => user = value; }
        #endregion
        #region Constructors
        public FrmUserManager()
        {
            InitializeComponent();
            tt = new ToolTip();
            tt.SetToolTip(txbUId, "A felhasználóazonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbUName, "A felhasználónév megadása kötelező,\nvalamint minimum 3 és maximum 50 karakter hosszú lehet!");
            tt.SetToolTip(txbPost, "A beosztás megadása opcionális.\nA szöveg hossza maximum 50 karakter lehet!");
            tt.SetToolTip(txbEmail, "A felhasználó email címének megadása kötelező, maximum 50 karakter hosszú lehet,\nés megfelelő formátumúnak kell lennie (pl.: user@usermail.hu)!");
            tt.SetToolTip(mtbPhone, "A telefonszám megadása opcionális, formátuma kötött,\nés maximum 9 számjegyből állhat!");
            tt.SetToolTip(cmbDepartment, "A felhasználó szervezeti egységének megadása opcionális.\nA nyilvántartó rendszerben már rögzített szervezeti egységek közül lehet választani.");
            tt.SetToolTip(chbULocked, "Megjelölése esetén a felhasználó fiókja zárolásra kerül!");
            tt.SetToolTip(btnAddGroup, "Jogosultsági csoport hozzáadása");
            tt.SetToolTip(btnRemoveGroup, "Jogosultsági csoport eltávolítása");
            groups = new List<PermissionGroup>();
            userGroups = new List<PermissionGroup>();
            RefreshGroupLists();
            try
            {
                cmbDepartment.Items.Add("");
                foreach (Department item in Department.OrderByHierarchy(DBManager.GetDepartmentsList()))
                {
                    cmbDepartment.Items.Add(item);
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
        internal FrmUserManager(User user, bool display = false) : this()
        {
            this.User = user;
            txbUId.Text = user.UId.ToString();
            txbUName.Text = user.UName;
            txbPost.Text = user.Post;
            txbEmail.Text = user.Email;
            mtbPhone.Text = user.Phone;
            if (user.UDepartment != null)
            {
                int cmIndex = cmbDepartment.Items.IndexOf(user.UDepartment);
                cmbDepartment.SelectedIndex = cmIndex;
            }
            chbULocked.Checked = user.Locked;
            userGroups = user.Permissions;
            RefreshGroupLists();
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is MaskedTextBox || item is TextBox;
                    if (item is MaskedTextBox mtb)
                    {
                        mtb.ReadOnly = true;
                    }
                    else if (item is TextBox txb)
                    {
                        txb.ReadOnly = true;
                    }
                }
                lsbGroups.Visible = btnAddGroup.Visible = btnRemoveGroup.Visible = btnOk.Visible = lblGroups.Visible = false;
                lsbUserGroup.SelectedIndex = -1;
                btnCancel.Text = "Bezárás";
                this.ActiveControl = btnCancel;
            }
            else
            {
                if (user.UId == 1)
                {
                    chbULocked.Enabled = lsbGroups.Visible = btnAddGroup.Visible = btnRemoveGroup.Visible = false;
                    lsbUserGroup.SelectedIndex = -1;
                    lsbUserGroup.Enabled = false;
                }
                btnOk.Text = "Módosítás";
            }
        }
        #endregion
        #region Component events
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                mtbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string phoneWithoutMask = mtbPhone.Text.Trim();
                mtbPhone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                if (User == null)
                {
                    if (!DBManager.IsEmailExists(txbEmail.Text.Trim()))
                    {
                        User = new User(txbUName.Text.Trim(), txbPost.Text.Trim(), txbEmail.Text.Trim(), String.IsNullOrEmpty(phoneWithoutMask) ? null : mtbPhone.Text.Replace('_',' ').Trim(), cmbDepartment.SelectedIndex > 0 ? (Department)cmbDepartment.SelectedItem : null, DBManager.GetCurrentTime(), null, chbULocked.Checked);
                        foreach (PermissionGroup item in userGroups)
                        {
                            User.AddPermission(item);
                        }
                        string newPassword = DBManager.CreateUser(User, out bool mailWasSent);
                        MessageBox.Show($"Felhasználót sikeresen regisztrálta!{(!mailWasSent ? $"\n\rRegisztrációs email elküldése sikertelen!\n\rA regisztrált felhasználó jelszava: {newPassword}" : "\n\rA felhasználó emailben értesítve!")}", "Felhasználó rögzítése", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Már létező email cím! Kérem adjon meg másikat!", "Felhasználó rögzítése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    if (!DBManager.IsEmailExists(txbEmail.Text.Trim(), User.UId))
                    {
                        User.UName = txbUName.Text.Trim();
                        User.Post = txbPost.Text.Trim();
                        User.Email = txbEmail.Text.Trim();
                        User.Phone = String.IsNullOrEmpty(phoneWithoutMask) ? null : mtbPhone.Text.Replace('_', ' ').Trim();
                        User.UDepartment = cmbDepartment.SelectedIndex > 0 ? (Department)cmbDepartment.SelectedItem : null;
                        User.Locked = chbULocked.Checked;
                        User.ClearPermission();
                        foreach (PermissionGroup item in userGroups)
                        {
                            User.AddPermission(item);
                        }
                        DBManager.UpdateUser(User);
                    }
                    else
                    {
                        MessageBox.Show($"Már létező email cím! Kérem adjon meg másikat!", "Felhasználó módosítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
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
        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            if (lsbGroups.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbGroups.SelectedItems)
                {
                    userGroups.Add((PermissionGroup)item);
                }
                RefreshGroupLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzáadni kívánt jogosultsági csoportot!", "Jogosultsági csoport hozzáadása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (lsbUserGroup.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbUserGroup.SelectedItems)
                {
                    userGroups.Remove((PermissionGroup)item);
                }
                RefreshGroupLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó jogosultsági csoportot!", "Jogosultsági csoport eltávolítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LsbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbGroups.SelectedIndex != -1)
            {
                lsbUserGroup.SelectedIndex = -1;
            }
        }
        private void LsbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbUserGroup.SelectedIndex != -1)
            {
                lsbGroups.SelectedIndex = -1;
            }
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshGroupLists()
        {
            try
            {
                lsbUserGroup.DataSource = lsbGroups.DataSource = null;
                groups = userGroups.Count == 0 ? DBManager.GetGroupsList() : DBManager.GetGroupsList().Where(x => userGroups.FindIndex(y => y.GId == x.GId) == -1).ToList();
                lsbGroups.DataSource = groups;
                lsbUserGroup.DataSource = userGroups;
                btnAddGroup.Enabled = lsbGroups.Items.Count != 0;
                btnRemoveGroup.Enabled = lsbUserGroup.Items.Count != 0;
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
        #endregion
    }
}
