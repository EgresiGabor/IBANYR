using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class DepartmentsPanel : UserControl
    {
        #region Private fields
        readonly User user;
        readonly ToolTip tt;
        List<Department> departmentList;
        #endregion
        #region Constructors
        internal DepartmentsPanel(User user)
        {
            InitializeComponent();
            this.user = user;
            departmentList = new List<Department>();
            tt = new ToolTip();
            tt.SetToolTip(btnAddDepartment, "Új szervezeti egység rögzítése");
            tt.SetToolTip(btnDeleteDepartment, "Szervezeti egység törlése");
            tt.SetToolTip(btnEditDepartment, "Szervezeti egység adatainak szerkesztése");
            tt.SetToolTip(btnReadDepartment, "Szervezeti egység adatainak megtekintése");
            tt.SetToolTip(btnRefreshDepartments, "Lista frissítése");
            btnAddDepartment.Enabled = user.HasPermission("createDepartment");
            btnDeleteDepartment.Enabled = user.HasPermission("deleteDepartment");
            btnEditDepartment.Enabled = user.HasPermission("updateDepartment");
            RefreshTreeView();
        }
        #endregion
        #region Component events
        private void BtnAddDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDepartmentManager frm = new FrmDepartmentManager();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SystemLog.WriteLogEvent(user, EventType.createDepartment, frm.Department);
                    RefreshTreeView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (trvDepartments.SelectedNode != null)
            {
                try
                {
                    if (MessageBox.Show("Biztosan törli a kijelölt szervezeti egységet?", "Szervezeti egység törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FrmDeleteDepartment frm = new FrmDeleteDepartment(int.Parse(trvDepartments.SelectedNode.Name));
                        SystemLog.WriteLogEvent(user, EventType.deleteDepartment, DBManager.GetDepartmentById(int.Parse(trvDepartments.SelectedNode.Name)));
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            DBManager.DeleteDepartment(int.Parse(trvDepartments.SelectedNode.Name), frm.UDId, frm.SDId);
                        }
                        else
                        {
                            DBManager.DeleteDepartment(int.Parse(trvDepartments.SelectedNode.Name));
                        }
                        RefreshTreeView();
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
                MessageBox.Show("Válasszon ki egy szervezeti egységet a funkció használatához!", "Szervezeti egység törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditDepartment_Click(object sender, EventArgs e)
        {
            if (trvDepartments.SelectedNode != null)
            {
                try
                {
                    FrmDepartmentManager frm = new FrmDepartmentManager(departmentList.Find(x => x.DId == int.Parse(trvDepartments.SelectedNode.Name)));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SystemLog.WriteLogEvent(user, EventType.updateDepartment, frm.Department);
                    }
                    RefreshTreeView();
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
                MessageBox.Show("Válasszon ki egy szervezeti egységet a funkció használatához!", "Szervezeti egység módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadDepartment_Click(object sender, EventArgs e)
        {
            if (trvDepartments.SelectedNode != null)
            {
                try
                {
                    SystemLog.WriteLogEvent(user, EventType.readDepartment, departmentList.Find(x => x.DId == int.Parse(trvDepartments.SelectedNode.Name)));
                    FrmDepartmentManager frm = new FrmDepartmentManager(departmentList.Find(x => x.DId == int.Parse(trvDepartments.SelectedNode.Name)), true);
                    frm.ShowDialog();
                    RefreshTreeView();
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
                MessageBox.Show("Válasszon ki egy szervezeti egységet a funkció használatához!", "Szervezeti egység adatai...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshDepartments_Click(object sender, EventArgs e)
        {
            RefreshTreeView();
        }
        private void TrvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvDepartments.SelectedNode != null)
            {
                try
                {
                    List<User> users = DBManager.GetUsersList(int.Parse(trvDepartments.SelectedNode.Name));
                    lsbDepartmentUsers.Items.Clear();
                    if (users.Count > 0)
                    {
                        foreach (User item in users.Where(x=>x.DeleteDate == null).OrderBy(x=>x.UName).ToList())
                        {
                            lsbDepartmentUsers.Items.Add(item);
                        }
                    }
                    else
                    {
                        lsbDepartmentUsers.Items.Add("Nincs felhasználó!");
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
        #endregion
        #region Methods and Functions
        private void RefreshTreeView()
        {
            try
            {
                trvDepartments.Nodes.Clear();
                departmentList.Clear();
                departmentList = DBManager.GetDepartmentsList();
                SystemLog.WriteLogEvent(user, EventType.listDepartments);
                ReplenishmentTreeView();
                trvDepartments.ExpandAll();
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
        private void ReplenishmentTreeView(int index = 0)
        {
            int i = 0;
            List<Department> list = departmentList.Where(x => x.SuperiorDId == index).ToList();
            while (i < list.Count)
            {
                if (index == 0)
                {
                    trvDepartments.Nodes.Add(list[i].DId.ToString(), list[i].ToString(), 0);
                    trvDepartments.Nodes[list[i].DId.ToString()].SelectedImageIndex = 0;
                }
                else
                {
                    TreeNode parent = trvDepartments.Nodes.Find(index.ToString(), true)[0];
                    parent.Nodes.Add(list[i].DId.ToString(), list[i].ToString(), 1);
                    parent.Nodes[list[i].DId.ToString()].SelectedImageIndex = 1;
                }
                ReplenishmentTreeView(list[i].DId);
                i++;
            }
        }
        #endregion
    }
}
