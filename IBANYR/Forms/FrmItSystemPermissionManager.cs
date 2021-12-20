using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmItSystemPermissionManager : Form
    {
        #region Private fields
        ItSystem itSystem;
        ItSystemPermission systemPermission;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal ItSystemPermission SystemPermission { get => systemPermission; set => systemPermission = value; }
        #endregion
        #region Constructors
        internal FrmItSystemPermissionManager(ItSystem itSystem)
        {
            InitializeComponent();
            this.itSystem = itSystem;
            tt = new ToolTip();
            tt.SetToolTip(txbSysPId, "A rendszerjogosultság azonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbSysPName, "Kötelezően megadandó érték, és maximum 50 karakter hosszú lehet.");
            tt.SetToolTip(rtbSysPDescription, "Opcionálisan megadható és maximum 4000 karakter hosszú lehet.");
            tt.SetToolTip(cmbSuperiorSysPermission, "A felettes rendszerjog kiválasztása opcionális.\nAz informatikai rendszerhez már rögzített rendszerjogok közül lehet választani.");
            cmbSuperiorSysPermission.Items.Add(String.Empty);
            foreach (ItSystemPermission item in itSystem.ItSystemPermissions)
            {
                cmbSuperiorSysPermission.Items.Add(item);
            }
        }
        internal FrmItSystemPermissionManager(ItSystem itSystem, ItSystemPermission systemPermission, bool display = false) : this(itSystem)
        {
            this.systemPermission = systemPermission;
            txbSysPId.Text = systemPermission.SysPId.ToString();
            txbSysPName.Text = systemPermission.SysPName;
            rtbSysPDescription.Text = systemPermission.SysPDescription;
            cmbSuperiorSysPermission.Items.Remove(systemPermission);
            if (systemPermission.SuperiorSysPId != 0)
            {
                cmbSuperiorSysPermission.SelectedItem = itSystem.ItSystemPermissions.Find(x => x.SysPId == systemPermission.SuperiorSysPId);
            }
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is TextBox || item is RichTextBox;
                    if (item is TextBox txb)
                    {
                        txb.ReadOnly = true;
                    }
                    else if (item is RichTextBox rtb)
                    {
                        rtb.ReadOnly = true;
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
                if (systemPermission == null)
                {
                    if (itSystem.ItSystemPermissions.Where(x=>x.SysPName == txbSysPName.Text.Trim()).ToList().Count == 0)
                    {
                        systemPermission = new ItSystemPermission(
                            txbSysPName.Text.Trim(),
                            rtbSysPDescription.Text.Trim(),
                            cmbSuperiorSysPermission.SelectedIndex < 1 ? 0 : (cmbSuperiorSysPermission.SelectedItem as ItSystemPermission).SysPId,
                            itSystem.SId
                            );
                        DBManager.CreateItSystemPermission(systemPermission);
                    }
                    else
                    {
                        MessageBox.Show("A rendszerhez már tartozik ezen a néven jogosultság! Kérem adjon meg másikat!", "Jogosultság rögzítése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    if (itSystem.ItSystemPermissions.Where(x => x.SysPName == txbSysPName.Text.Trim() && x.SysPId != systemPermission.SysPId).ToList().Count == 0)
                    {
                        systemPermission.SysPName = txbSysPName.Text.Trim();
                        systemPermission.SysPDescription = rtbSysPDescription.Text.Trim();
                        systemPermission.SuperiorSysPId = cmbSuperiorSysPermission.SelectedIndex < 1 ? 0 : (cmbSuperiorSysPermission.SelectedItem as ItSystemPermission).SysPId;
                        DBManager.UpdateItSystemPermission(systemPermission);
                    }
                    else
                    {
                        MessageBox.Show("A név egy másik jogosultsághoz van rendelve! Kérem adjon meg másikat!", "Jogosultság módosítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #endregion
    }
}
