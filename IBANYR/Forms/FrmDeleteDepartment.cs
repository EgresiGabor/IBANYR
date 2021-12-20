using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmDeleteDepartment : Form
    {
        #region Private fields
        List<Department> departments;
        int uDId, sDId;
        #endregion
        #region Public properties
        public int UDId { get => uDId; }
        public int SDId { get => sDId; }
        #endregion
        #region Constructors
        internal FrmDeleteDepartment(int dId)
        {
            InitializeComponent();
            departments = new List<Department>();
            try
            {
                departments = DBManager.GetDepartmentsList().Where(x => x.DId != dId).ToList();
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
            cmbUsersD.Items.Add(String.Empty);
            cmbSuperiorD.Items.Add(String.Empty);
            foreach (Department item in departments)
            {
                cmbUsersD.Items.Add(item);
                cmbSuperiorD.Items.Add(item);
            }
        }
        #endregion
        #region Component events
        private void BtnOk_Click(object sender, EventArgs e)
        {
            uDId = cmbUsersD.SelectedIndex > 0 ? (cmbUsersD.SelectedItem as Department).DId : 0;
            sDId = cmbSuperiorD.SelectedIndex > 0 ? (cmbSuperiorD.SelectedItem as Department).DId : 0;
        }
        #endregion

    }
}
