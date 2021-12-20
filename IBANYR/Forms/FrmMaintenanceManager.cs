using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmMaintenanceManager : Form
    {
        #region Private fields
        MaintenanceLog maintenance;
        List<Hardware> hardwares;
        List<Hardware> affectedComponents;
        List<ItSystem> itSystems;
        List<ItSystem> affectedItSystems;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal MaintenanceLog Maintenance { get => maintenance; set => maintenance = value; }
        #endregion
        #region Constructors
        public FrmMaintenanceManager()
        {
            InitializeComponent();
            tt = new ToolTip();
            maintenance = null;
            tt.SetToolTip(txbLogId, "A bejegyzésazonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(cmbMType, "Rögzített értékek közül választhat.");
            tt.SetToolTip(cmbMMethod, "Rögzített értékek közül választhat.");
            tt.SetToolTip(dtpStartDate, "A karbantartási tevékenység kezdő időpontja.");
            tt.SetToolTip(cmbStatus, "Rögzített értékek közül választhat.\n\"Folyamatban\" érték választása esetén a befejezés időpontja nem adható meg.");
            tt.SetToolTip(dtpEndDate, "A karbantartási tevékenység befejező időpontja.");
            tt.SetToolTip(rtbActivitiesDesc, "A karbantartási bejegyzéshez kötelezően megadandó a végzett tevékenység leírása.\nMaximális szöveghossz 1.073.741.823 karakter.");
            tt.SetToolTip(txbMName, "A karbantartási bejegyzés rögzítésekor kötelező megadni a karbantartást végző szervezet és/vagy személy/személyek megnevezését.\nA megadható szöveg maximális hossza 300 karakter.");
            tt.SetToolTip(rtbDocLink, "A karbantartáshoz kapcsolódó opcionálisan megadható dokumentumok hivatkozásai.\nSzöveges érték, mely maximum 4000 karakter hosszú.");
            tt.SetToolTip(btnAddHardware, "Hardver hozzárendelése");
            tt.SetToolTip(btnRemoveHardware, "Hardver hozzárendelésének törlése");
            tt.SetToolTip(btnAddItSystem, "Rendszer hozzárendelése");
            tt.SetToolTip(btnRemoveItSystem, "Rendszer összekapcsolásának törlése");
            itSystems = new List<ItSystem>();
            affectedItSystems = new List<ItSystem>();
            hardwares = new List<Hardware>();
            affectedComponents = new List<Hardware>();
            RefreshItSystemLists();
            RefreshHardwareLists();
            cmbMType.DataSource = Enum.GetValues(typeof(MaintenanceType)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbMType.DisplayMember = "Description";
            cmbMType.ValueMember = "value";
            cmbMMethod.DataSource = Enum.GetValues(typeof(MaintenanceMethod)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbMMethod.DisplayMember = "Description";
            cmbMMethod.ValueMember = "value";
            cmbStatus.DataSource = Enum.GetValues(typeof(MaintenanceState)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbStatus.DisplayMember = "Description";
            cmbStatus.ValueMember = "value";
            dtpStartDate.MinDate = dtpEndDate.MinDate = SqlDateTime.MinValue.Value;
        }
        internal FrmMaintenanceManager(Hardware hardware) : this()
        {
            affectedComponents.Add(hardware);
            RefreshHardwareLists();
        }
        internal FrmMaintenanceManager(MaintenanceLog maintenance, bool display = false) : this()
        {
            Maintenance = maintenance;
            txbLogId.Text = Maintenance.LogId.ToString();
            cmbMType.SelectedIndex = (int)Maintenance.MType;
            cmbMMethod.SelectedIndex = (int)Maintenance.MMethod;
            dtpStartDate.Value = Maintenance.StartDate;
            cmbStatus.SelectedIndex = (int)Maintenance.Status;
            if (Maintenance.EndDate != null)
            {
                dtpEndDate.Value = (DateTime)Maintenance.EndDate;
            }
            rtbActivitiesDesc.Text = Maintenance.ActivitiesDesc;
            txbMName.Text = Maintenance.MName;
            rtbDocLink.Text = Maintenance.DocLink;
            try
            {
                foreach (int hardwareIndex in Maintenance.AffectedComponentsId)
                {
                    affectedComponents.Add(DBManager.GetHardwareById(hardwareIndex));
                }
                foreach (int itSystemIndex in Maintenance.AffectedItSystemsId)
                {
                    affectedItSystems.Add(DBManager.GetItSystemById(itSystemIndex));
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
            RefreshItSystemLists();
            RefreshHardwareLists();
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is RichTextBox || item is TextBox || item == lsbAffectedComponents || item == lsbHardwares || item == lsbAffectedItSystems;
                    if (item is TextBox txb)
                    {
                        txb.ReadOnly = true;
                    }
                    else if (item is RichTextBox rtb)
                    {
                        rtb.ReadOnly = true;
                    }
                    else if (item is ListBox lsb)
                    {
                        lsb.SelectedIndex = -1;
                    }
                }

                btnOk.Visible = btnAddHardware.Enabled = btnRemoveHardware.Enabled = lsbHardwares.Enabled = btnAddItSystem.Enabled = btnRemoveItSystem.Enabled = lsbItSystems.Enabled = false;
                btnCancel.Text = "Bezárás";
                this.ActiveControl = btnCancel;
            }
            else
            {
                cmbMType.Enabled = cmbMMethod.Enabled = dtpStartDate.Enabled = false;
                btnOk.Text = "Módosítás";
            }
        }
        #endregion
        #region Component events
        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = cmbStatus.SelectedIndex == (int)MaintenanceState.closed || cmbStatus.SelectedIndex == (int)MaintenanceState.planned;
        }
        private void BtnAddHardware_Click(object sender, EventArgs e)
        {
            if (lsbHardwares.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbHardwares.SelectedItems)
                {
                    affectedComponents.Add((Hardware)item);
                }
                RefreshHardwareLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzárendelni kívánt hardvert!", "Hardver hozzárendelése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemoveHardware_Click(object sender, EventArgs e)
        {
            if (lsbAffectedComponents.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbAffectedComponents.SelectedItems)
                {
                    affectedComponents.Remove((Hardware)item);
                }
                RefreshHardwareLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó hardvert!", "Hardver összekapcsolásának törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnAddItSystem_Click(object sender, EventArgs e)
        {
            if (lsbItSystems.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbItSystems.SelectedItems)
                {
                    affectedItSystems.Add((ItSystem)item);
                }
                RefreshItSystemLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzárendelni kívánt rendszert!", "Rendszer hozzárendelése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemoveItSystem_Click(object sender, EventArgs e)
        {
            if (lsbAffectedItSystems.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbAffectedItSystems.SelectedItems)
                {
                    affectedItSystems.Remove((ItSystem)item);
                }
                RefreshItSystemLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó rendszert!", "Rendszer összekapcsolásának törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Maintenance == null)
                {
                    Maintenance = new MaintenanceLog(
                        (MaintenanceType)cmbMType.SelectedIndex,
                        (MaintenanceMethod)cmbMMethod.SelectedIndex,
                        dtpStartDate.Value,
                        dtpEndDate.Enabled ? (DateTime?)dtpEndDate.Value : null,
                        rtbActivitiesDesc.Text.Trim(),
                        rtbDocLink.Text.Trim(),
                        txbMName.Text.Trim());
                    foreach (Hardware item in affectedComponents)
                    {
                        Maintenance.AddAffectedComponentsId(item.AId);
                    }
                    foreach (ItSystem item in affectedItSystems)
                    {
                        Maintenance.AddAffectedItSystemsId(item.SId);
                    }

                    DBManager.CreateMaintenanceLog(Maintenance);
                }
                else
                {
                    Maintenance.EndDate = dtpEndDate.Enabled ? (DateTime?)dtpEndDate.Value : null;
                    Maintenance.ActivitiesDesc = rtbActivitiesDesc.Text.Trim();
                    Maintenance.DocLink = rtbDocLink.Text.Trim();
                    Maintenance.MName = txbMName.Text.Trim();

                    Maintenance.ClearAffectedComponentsId();
                    foreach (Hardware item in affectedComponents)
                    {
                        Maintenance.AddAffectedComponentsId(item.AId);
                    }
                    Maintenance.ClearAffectedItSystemsId();
                    foreach (ItSystem item in affectedItSystems)
                    {
                        Maintenance.AddAffectedItSystemsId(item.SId);
                    }

                    DBManager.UpdateMaintenanceLog(Maintenance);
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
        #region Own Methods and Functions
        private void RefreshHardwareLists()
        {
            try
            {
                lsbAffectedComponents.DataSource = lsbHardwares.DataSource = null;
                hardwares = affectedComponents.Count == 0 ? DBManager.GetHardwaresList() : DBManager.GetHardwaresList().Where(x => affectedComponents.FindIndex(y => y.AId == x.AId) == -1 && x.HardwareType == HardwareType.computerDevice).ToList();
                lsbHardwares.DataSource = hardwares;
                lsbAffectedComponents.DataSource = affectedComponents;
                btnAddHardware.Enabled = lsbHardwares.Items.Count != 0;
                btnRemoveHardware.Enabled = lsbAffectedComponents.Items.Count != 0;
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
        private void RefreshItSystemLists()
        {
            try
            {
                lsbAffectedItSystems.DataSource = lsbItSystems.DataSource = null;
                itSystems = affectedItSystems.Count == 0 ? DBManager.GetItSystemsList() : DBManager.GetItSystemsList().Where(x => affectedItSystems.FindIndex(y => y.SId == x.SId) == -1).ToList();
                lsbItSystems.DataSource = itSystems;
                lsbAffectedItSystems.DataSource = affectedItSystems;
                btnAddItSystem.Enabled = lsbItSystems.Items.Count != 0;
                btnRemoveItSystem.Enabled = lsbAffectedItSystems.Items.Count != 0;
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
