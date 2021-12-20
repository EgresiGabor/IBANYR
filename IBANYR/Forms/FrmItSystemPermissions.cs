using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmItSystemPermissions : Form
    {
        #region Private fields
        readonly User user;
        ItSystem itSystem;
        readonly ToolTip tt;
        #endregion
        #region Constructors
        internal FrmItSystemPermissions(User user, ItSystem itSystem)
        {
            InitializeComponent();
            this.user = user;
            this.itSystem = itSystem;
            this.Text = $"{itSystem.SShortName} rendszerjogosultságai";
            tt = new ToolTip();
            tt.SetToolTip(btnAddPermission, "Új rendszerjogosultság rögzítése");
            tt.SetToolTip(btnDeletePermission, "Rendszerjogosultság törlése");
            tt.SetToolTip(btnEditPermission, "Rendszerjogosultság szerkesztése");
            tt.SetToolTip(btnReadPermission, "Rendszerjogosultság adatainak megtekintése");
            tt.SetToolTip(btnRefreshPermissions, "Lista frissítése");
            btnAddPermission.Enabled = user.HasPermission("createItSystemPermission");
            btnDeletePermission.Enabled = user.HasPermission("deleteItSystemPermission");
            btnEditPermission.Enabled = user.HasPermission("updateItSystemPermission");
            RefreshTreeView();
        }
        #endregion
        #region Component events
        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            try
            {
                FrmItSystemPermissionManager frm = new FrmItSystemPermissionManager(itSystem);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SystemLog.WriteLogEvent(user, EventType.createItSystemPermission, frm.SystemPermission);
                    RefreshTreeView();
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
        private void BtnDeletePermission_Click(object sender, EventArgs e)
        {
            if (trvPermissions.SelectedNode != null)
            {
                try
                {
                    if (MessageBox.Show("Biztosan törli a kijelölt rendszerjogosultságot?", "Rendszerjogosultság törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SystemLog.WriteLogEvent(user, EventType.deleteItSystemPermission, itSystem.ItSystemPermissions.Find(x => x.SysPId == int.Parse(trvPermissions.SelectedNode.Name)));
                        DBManager.DeleteItSystemPermission(int.Parse(trvPermissions.SelectedNode.Name));
                        RefreshTreeView();
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
                MessageBox.Show("Válasszon ki egy rendszerjogosultságot a funkció használatához!", "Rendszerjogosultság törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditPermission_Click(object sender, EventArgs e)
        {
            if (trvPermissions.SelectedNode != null)
            {
                try
                {
                    FrmItSystemPermissionManager frm = new FrmItSystemPermissionManager(itSystem, itSystem.ItSystemPermissions.Find(x => x.SysPId == int.Parse(trvPermissions.SelectedNode.Name)));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SystemLog.WriteLogEvent(user, EventType.updateItSystemPermission, frm.SystemPermission);
                    }
                    RefreshTreeView();
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
                MessageBox.Show("Válasszon ki egy szervezeti egységet a funkció használatához!", "Szervezeti egység módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadPermission_Click(object sender, EventArgs e)
        {
            if (trvPermissions.SelectedNode != null)
            {
                try
                {
                    FrmItSystemPermissionManager frm = new FrmItSystemPermissionManager(itSystem, itSystem.ItSystemPermissions.Find(x => x.SysPId == int.Parse(trvPermissions.SelectedNode.Name)), true);
                    frm.ShowDialog();
                    SystemLog.WriteLogEvent(user, EventType.readItSystemPermission, itSystem.ItSystemPermissions.Find(x => x.SysPId == int.Parse(trvPermissions.SelectedNode.Name)));
                    RefreshTreeView();
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
                MessageBox.Show("Válasszon ki egy jogosultságot a funkció használatához!", "Rendszerjogosultság adatai...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRefreshPermissions_Click(object sender, EventArgs e)
        {
            RefreshTreeView();
        }
        private void TrvPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvPermissions.SelectedNode != null)
            {
                try
                {
                    List<User> users = DBManager.GetItSystemPermissionById(int.Parse(trvPermissions.SelectedNode.Name)).GetItSystemPermissionUsers();
                    lsbUsersWithPermission.Items.Clear();
                    if (users.Count > 0)
                    {
                        foreach (User item in users.OrderBy(x => x.UName).ToList())
                        {
                            lsbUsersWithPermission.Items.Add(item);
                        }
                    }
                    else
                    {
                        lsbUsersWithPermission.Items.Add("Nincs felhasználó!");
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
        }
        #endregion
        #region Methods and Functions
        private void RefreshTreeView()
        {
            try
            {
                trvPermissions.Nodes.Clear();
                itSystem = DBManager.GetItSystemById(itSystem.SId);
                SystemLog.WriteLogEvent(user, EventType.listItSystemPermissions);
                ReplenishmentTreeView();
                trvPermissions.ExpandAll();
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
        private void ReplenishmentTreeView(int index = 0)
        {
            int i = 0;
            List<ItSystemPermission> list = itSystem.ItSystemPermissions.Where(x => x.SuperiorSysPId == index).ToList();
            while (i < list.Count)
            {
                if (index == 0)
                {
                    trvPermissions.Nodes.Add(list[i].SysPId.ToString(), list[i].ToString());
                }
                else
                {
                    TreeNode parent = trvPermissions.Nodes.Find(index.ToString(), true)[0];
                    parent.Nodes.Add(list[i].SysPId.ToString(), list[i].ToString());
                }
                ReplenishmentTreeView(list[i].SysPId);
                i++;
            }
        }
        #endregion
    }
}
