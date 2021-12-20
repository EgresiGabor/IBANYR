using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmDepartmentManager : Form
    {
        #region Private fields
        Department department;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal Department Department { get => department; set => department = value; }
        #endregion
        #region Constructors
        public FrmDepartmentManager()
        {
            InitializeComponent();
            tt = new ToolTip();
            tt.SetToolTip(txbDId, "A szervezeti egység azonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbDName, "A szervezeti egység nevének megadása kötelező,\nvalamint minimum 3 és maximum 150 karakter hosszú lehet!");
            tt.SetToolTip(txbDShortName, "A szervezeti egység rövid nevének megadása kötelező,\nvalamint minimum 2 és maximum 20 karakter hosszú lehet!");
            tt.SetToolTip(cmbManager, "A vezető kiválasztása opcionális.\nA rögzített felhasználók közül lehetséges választani.");
            tt.SetToolTip(cmbSuperiorD, "A felettes szervezeti egység kiválasztása opcionális.\nA rögzített szervezeti egységek közül lehetséges választani.");
            try
            {
                cmbManager.Items.Add(String.Empty);
                foreach (User item in DBManager.GetUsersList().Where(x=>x.DeleteDate == null).OrderBy(x=>x.UName).ToList())
                {
                    cmbManager.Items.Add(item);
                }

                cmbSuperiorD.Items.Add(String.Empty);
                foreach (Department item in Department.OrderByHierarchy(DBManager.GetDepartmentsList()))
                {
                    cmbSuperiorD.Items.Add(item);
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
        internal FrmDepartmentManager(Department department, bool display = false) : this()
        {
            this.department = department;
            txbDId.Text = department.DId.ToString();
            txbDName.Text = department.DName;
            txbDShortName.Text = department.DShortName;
            cmbSuperiorD.Items.Remove(department);
            try
            {
                if (department.ManagerId != 0)
                {
                    User manager = DBManager.GetUserById(department.ManagerId);
                    cmbManager.SelectedItem = manager;
                }
                if (department.SuperiorDId != 0)
                {
                    cmbSuperiorD.SelectedItem = DBManager.GetDepartmentById(department.SuperiorDId);
                }
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is TextBox;
                    if (item is TextBox txb)
                    {
                        txb.ReadOnly = true;
                    }
                }
                btnOk.Visible = false;
                btnCancel.Text = "Bezárás";
                this.ActiveControl = btnCancel;
            }
            else
            {
                btnOk.Text = "Módosítás";
            }
        }
        #endregion
        #region Component events
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (department == null)
                {
                    if (!DBManager.IsDNameExists(txbDName.Text.Trim()))
                    {
                        if (!DBManager.IsDShortNameExists(txbDShortName.Text.Trim()))
                        {
                            DBManager.CreateDepartment(new Department(txbDName.Text.Trim(), txbDShortName.Text.Trim(), cmbManager.SelectedIndex < 1 ? 0 : (cmbManager.SelectedItem as User).UId, cmbSuperiorD.SelectedIndex < 1 ? 0 : (cmbSuperiorD.SelectedItem as Department).DId));
                        }
                        else
                        {
                            MessageBox.Show("A rövid név egy már létező szervezeti egységhez van rendelve! Kérem adjon meg másikat!", "Szervezeti egység rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        MessageBox.Show("A név egy már létező szervezeti egységhez van rendelve! Kérem adjon meg másikat!", "Szervezeti egység rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    if (!DBManager.IsDNameExists(txbDName.Text.Trim(), department.DId))
                    {
                        department.DName = txbDName.Text.Trim();
                        if (!DBManager.IsDShortNameExists(txbDShortName.Text.Trim(), department.DId))
                        {
                            department.DShortName = txbDShortName.Text.Trim();
                            department.ManagerId = cmbManager.SelectedItem is User manager ? manager.UId : 0;
                            department.SuperiorDId = cmbSuperiorD.SelectedItem is Department dept ? dept.DId : 0;
                            DBManager.UpdateDepartment(department);
                        }
                        else
                        {
                            MessageBox.Show("A rövid név egy másik szervezeti egységhez van rendelve! Kérem adjon meg másikat!", "Szervezeti egység rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        MessageBox.Show("A név egy másik szervezeti egységhez van rendelve! Kérem adjon meg másikat!", "Szervezeti egység rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
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
        #endregion

    }
}
