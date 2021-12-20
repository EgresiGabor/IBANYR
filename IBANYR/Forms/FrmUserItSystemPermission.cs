using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmUserItSystemPermission : Form
    {
        #region Private fields
        User managedUser;
        bool display;
        #endregion
        #region Constructors
        internal FrmUserItSystemPermission(User managedUser, bool display = false)
        {
            InitializeComponent();
            this.managedUser = managedUser;
            this.display = display;
            this.Text = $"{managedUser.UName} rendszerjogosultságai";
            if (display)
            {
                btnOk.Enabled = btnOk.Visible = false;
                btnCancel.Text = "Bezárás";
                this.ActiveControl = btnCancel;
                trvItSystemPermissions.CheckBoxes = false;
                trvItSystemPermissions.ExpandAll();
            }
        }
        #endregion
        #region Form events
        private void FrmUserItSystemPermission_Load(object sender, EventArgs e)
        {
            try
            {
                List<ItSystem> list = !display ? DBManager.GetItSystemsList() : DBManager.GetItSystemsList().Where(x => x.ItSystemPermissions.Any(y => managedUser.ItSystemPermissions.Contains(y))).ToList();
                foreach (ItSystem item in list)
                {
                    trvItSystemPermissions.Nodes.Add($"SId-{item.SId}", item.SShortName, 0);
                    ReplenishmentTreeView(item);
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
        #region Component events
        private void TrvItSystemPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvItSystemPermissions.SelectedNode != null)
            {
                try
                {
                    if (trvItSystemPermissions.SelectedNode.Name.Contains("SId-"))
                    {
                        lblPermissionDescription.Text = $"{DBManager.GetItSystemById(int.Parse(trvItSystemPermissions.SelectedNode.Name.Substring(4))).SName}:";
                        rtbDescription.Text = DBManager.GetItSystemById(int.Parse(trvItSystemPermissions.SelectedNode.Name.Substring(4))).SDescription;
                    }
                    else
                    {
                        lblPermissionDescription.Text = $"{DBManager.GetItSystemPermissionById(int.Parse(trvItSystemPermissions.SelectedNode.Name)).SysPName}:";
                        rtbDescription.Text = DBManager.GetItSystemPermissionById(int.Parse(trvItSystemPermissions.SelectedNode.Name)).SysPDescription;
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
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                managedUser.ClearItSystemPermission();
                foreach (TreeNode item in CheckedNodes(trvItSystemPermissions))
                {
                    if (!item.Name.Contains("SId-"))
                    {
                        managedUser.AddItSystemPermission(DBManager.GetItSystemPermissionById(int.Parse(item.Name)));
                    }
                }
                DBManager.UpdateUser(managedUser);
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
        private List<TreeNode> CheckedNodes(TreeView trv)
        {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, trv.Nodes);
            return checked_nodes;
        }
        #endregion
        #region Methods and Functions
        private void ReplenishmentTreeView(ItSystem itSystem, int index = 0)
        {
            int i = 0;
            List<ItSystemPermission> list = !display ? itSystem.ItSystemPermissions.Where(x => x.SuperiorSysPId == index).ToList() : itSystem.ItSystemPermissions.Where(x => x.SuperiorSysPId == index && managedUser.ItSystemPermissions.Any(y => y.SysPId == x.SysPId)).ToList();
            while (i < list.Count)
            {
                TreeNode parent = index == 0 ? trvItSystemPermissions.Nodes.Find($"SId-{itSystem.SId.ToString()}", true)[0] : trvItSystemPermissions.Nodes.Find(index.ToString(), true)[0];
                parent.Nodes.Add(list[i].SysPId.ToString(), list[i].ToString(), 1);
                parent.Nodes[list[i].SysPId.ToString()].SelectedImageIndex = 1;
                if (managedUser.ItSystemPermissions.Contains(list[i]))
                {
                    parent.Nodes[list[i].SysPId.ToString()].Checked = true;
                }

                ReplenishmentTreeView(itSystem, list[i].SysPId);
                i++;
            }
        }
        private void FindCheckedNodes(List<TreeNode> checkedNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }
                FindCheckedNodes(checkedNodes, node.Nodes);
            }
        }
        private void TrvItSystemPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode tn in e.Node.Nodes)
            {
                tn.Checked = e.Node.Checked;
            }
            trvItSystemPermissions.AfterCheck -= TrvItSystemPermissions_AfterCheck;
            SetParentNodeChecked(e.Node);
            trvItSystemPermissions.AfterCheck += TrvItSystemPermissions_AfterCheck;
        }
        private void SetParentNodeChecked(TreeNode node)
        {
            if (node.Parent != null)
            {
                if (node.Parent.Checked && node.Parent.Checked != node.Checked)
                {
                    bool chk = false;
                    foreach (TreeNode item in node.Parent.Nodes)
                    {
                        if (item.Checked)
                        {
                            chk = true;
                        }
                    }
                    node.Parent.Checked = chk;
                }
                else
                {
                    node.Parent.Checked = node.Checked;
                }
                SetParentNodeChecked(node.Parent);
            }
        }
        #endregion
    }
}
