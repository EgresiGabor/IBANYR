using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmSoftwareManager : Form
    {
        #region Private fields
        Software software;
        List<ItSystem> itSystems;
        List<ItSystem> softwareItSystems;
        List<Hardware> hardwares;
        List<Hardware> softwareHardwares;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal Software Software { get => software; set => software = value; }
        #endregion
        #region Constructors
        internal FrmSoftwareManager()
        {
            InitializeComponent();
            tt = new ToolTip();
            Software = null;
            tt.SetToolTip(txbAId, "Az eszközazonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbAName, "Szoftver nevének megadása kötelező, és minimum 3 és maximum 50 karakter hosszú lehet!");
            tt.SetToolTip(dtpPurchaseDate, "Szoftver beszerzési dátumának megadása kötelező!");
            tt.SetToolTip(cmbOwnerId, "Tulajdonos megadása opcionális.\nA már rögzített fő szervezeti egységek közül választhat!");
            tt.SetToolTip(cmbStatus, "Státusz megadás kötelező!\nRögzített értékek közül választhat.");
            tt.SetToolTip(dtpScrappingDate, "Selejtezve státuszú szoftver selejtezési dátuma kötelezően megadandó!");
            tt.SetToolTip(rtbOtherDescription, "Opcionálisan megadható szöveges érték.");
            tt.SetToolTip(cmbSoftwareProducer, "Szoftver gyártója opcionálisan megadható.\nSzabadon adható meg maximum 50 karakter hosszúságú új gyártónév,\nvagy szabadon választható valamely rögzített érték.");
            tt.SetToolTip(txbSoftwareDesc, "A szoftver leírása opcionálisan megadható.\nMaximum 200 karakter hosszú lehet.");
            tt.SetToolTip(numLicenseNumber, "A szoftverhez tartozó licenszszám opcionálisan megadható.\nMaximális értéke 1.000.000 lehet.");
            tt.SetToolTip(dtpLicenseDate, "A licensz érvényességi dátuma opcionálisan megadható,\nmely nem lehet korábbi a beszerzés dátumánál.");
            tt.SetToolTip(txbProductKey, "Opcionálisan megadható termékkulcs, mely titkosítva kerül tárolásra.\nMaximum 150 karakter hosszúságú lehet.");
            tt.SetToolTip(rtbDocLink, "Opcionálisan megadható szöveges érték, mely maximum 4000 karakter hosszú lehet.");

            tt.SetToolTip(btnAddComputerDevice, "Számítógép hozzárendelése");
            tt.SetToolTip(btnRemoveComputerDevice, "Számítógép összekapcsolásának törlése");
            tt.SetToolTip(btnAddItSystem, "Rendszer hozzárendelése");
            tt.SetToolTip(btnRemoveItSystem, "Rendszer összekapcsolásának törlése");
            tt.SetToolTip(btnCopyProductKey, "Termékkulcs másolása");
            itSystems = new List<ItSystem>();
            hardwares = new List<Hardware>();
            softwareItSystems = new List<ItSystem>();
            softwareHardwares = new List<Hardware>();
            RefreshItSystemLists();
            RefreshHardwareLists();
            try
            {
                cmbOwnerId.Items.Add(String.Empty);
                foreach (Department item in DBManager.GetDepartmentsList().Where(x=>x.SuperiorDId == 0).ToList())
                {
                    cmbOwnerId.Items.Add(item);
                }
                foreach (string item in DBManager.GetSoftwareProducers())
                {
                    cmbSoftwareProducer.Items.Add(item);
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
            cmbStatus.DataSource = Enum.GetValues(typeof(AssetState)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbStatus.DisplayMember = "Description";
            cmbStatus.ValueMember = "value";
            dtpPurchaseDate.MinDate = dtpScrappingDate.MinDate = dtpLicenseDate.MinDate = SqlDateTime.MinValue.Value;
            dtpScrappingDate.Enabled = dtpLicenseDate.Checked = false;
        }
        internal FrmSoftwareManager(Software software, bool display = false) : this()
        {
            Software = software;
            txbAId.Text = Software.AId.ToString();
            txbAName.Text = Software.AName;
            dtpPurchaseDate.Value = Software.PurchaseDate;
            cmbOwnerId.SelectedItem = Software.Owner;
            cmbStatus.SelectedIndex = (int)Software.Status;
            if (Software.ScrappingDate != null)
            {
                dtpScrappingDate.Value = (DateTime)Software.ScrappingDate;
            }
            rtbDocLink.Text = Software.DocLink;
            rtbOtherDescription.Text = Software.OtherDescription;
            cmbSoftwareProducer.SelectedItem = Software.SoftwareProducer;
            txbSoftwareDesc.Text = Software.SoftwareDesc;
            numLicenseNumber.Value = Software.SoftwareLicenseNum;
            if (Software.LicenseDate != null)
            {
                dtpLicenseDate.Checked = true;
                dtpLicenseDate.Value = (DateTime)Software.LicenseDate;
            }
            txbProductKey.Text = Software.ProductKey != null ? Password.Decrypt(Software.ProductKey) : String.Empty;
            try
            {
                foreach (int hardwareIndex in Software.HardwareIds)
                {
                    softwareHardwares.Add(DBManager.GetHardwareById(hardwareIndex));
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
            softwareItSystems = Software.ItSystems;
            RefreshItSystemLists();
            RefreshHardwareLists();
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is RichTextBox || item is TextBox || item == lsbSoftwareComputerDevices || item == lsbSoftwareItSystems || item == btnCopyProductKey;
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

                btnOk.Visible = btnAddItSystem.Enabled = btnRemoveItSystem.Enabled = btnAddComputerDevice.Enabled = btnRemoveComputerDevice.Enabled = lsbComputerDevices.Enabled = false;
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
        private void DtpPurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            dtpScrappingDate.MinDate = dtpPurchaseDate.Value;
            dtpLicenseDate.MinDate = dtpPurchaseDate.Value;
        }
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BtnAddItSystem_Click(object sender, EventArgs e)
        {
            if (lsbItSystems.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbItSystems.SelectedItems)
                {
                    softwareItSystems.Add((ItSystem)item);
                }
                RefreshItSystemLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzárendelni kívánt rendszert!", "Rendszer hozzárendelése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnAddComputerDevice_Click(object sender, EventArgs e)
        {
            if (lsbComputerDevices.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbComputerDevices.SelectedItems)
                {
                    softwareHardwares.Add((Hardware)item);
                }
                RefreshHardwareLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzárendelni kívánt eszközt!", "Eszköz hozzárendelése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemoveItSystem_Click(object sender, EventArgs e)
        {
            if (lsbSoftwareItSystems.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbSoftwareItSystems.SelectedItems)
                {
                    softwareItSystems.Remove((ItSystem)item);
                }
                RefreshItSystemLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó rendszert!", "Rendszer összekapcsolásának törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemoveComputerDevice_Click(object sender, EventArgs e)
        {
            if (lsbSoftwareComputerDevices.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbSoftwareComputerDevices.SelectedItems)
                {
                    softwareHardwares.Remove((Hardware)item);
                }
                RefreshHardwareLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó eszközt!", "Eszköz hozzárendelésének törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Software == null)
                {
                     Software = new Software(
                         cmbSoftwareProducer.SelectedIndex != -1 ? cmbSoftwareProducer.SelectedItem.ToString() : cmbSoftwareProducer.Text.Trim(),
                         txbSoftwareDesc.Text.Trim(),
                         (int)numLicenseNumber.Value,
                         dtpLicenseDate.Checked ? (DateTime?)dtpLicenseDate.Value : null,
                         txbProductKey.Text.Trim(),
                         txbAName.Text.Trim(),
                         dtpPurchaseDate.Value,
                         cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem,
                         (AssetState)cmbStatus.SelectedIndex,
                         rtbDocLink.Text.Trim(),
                         dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null,
                         rtbOtherDescription.Text.Trim());
                    foreach (ItSystem item in softwareItSystems)
                    {
                        Software.AddItSystems(item);
                    }
                    foreach (Hardware item in softwareHardwares)
                    {
                        Software.AddHardwareId(item.AId);
                    }
                    DBManager.CreateSoftware(Software);
                }
                else
                {
                    Software.AName = txbAName.Text.Trim();
                    Software.PurchaseDate = dtpPurchaseDate.Value;
                    Software.Owner = cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem;
                    Software.Status = (AssetState)cmbStatus.SelectedIndex;
                    Software.ScrappingDate = dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null;
                    Software.OtherDescription = rtbOtherDescription.Text.Trim();
                    Software.SoftwareProducer = cmbSoftwareProducer.SelectedIndex != -1 ? cmbSoftwareProducer.SelectedItem.ToString() : cmbSoftwareProducer.Text.Trim();
                    Software.SoftwareDesc = txbSoftwareDesc.Text.Trim();
                    Software.SoftwareLicenseNum = (int)numLicenseNumber.Value;
                    Software.LicenseDate = dtpLicenseDate.Checked ? (DateTime?)dtpLicenseDate.Value : null;
                    Software.ProductKey = txbProductKey.Text.Trim();
                    Software.DocLink = rtbDocLink.Text.Trim();
                    Software.ClearItSystems();
                    foreach (ItSystem item in softwareItSystems)
                    {
                        Software.AddItSystems(item);
                    }
                    Software.ClearHardwareIds();
                    foreach (Hardware item in softwareHardwares)
                    {
                        Software.AddHardwareId(item.AId);
                    }
                    DBManager.UpdateSoftware(Software);
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
        private void BtnCopyProductKey_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txbProductKey.Text))
            {
                Clipboard.SetText(txbProductKey.Text.Trim());
            }
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshItSystemLists()
        {
            try
            {
                lsbSoftwareItSystems.DataSource = lsbItSystems.DataSource = null;
                itSystems = softwareItSystems.Count == 0 ? DBManager.GetItSystemsList() : DBManager.GetItSystemsList().Where(x => softwareItSystems.FindIndex(y => y.SId == x.SId) == -1).ToList();
                lsbItSystems.DataSource = itSystems;
                lsbSoftwareItSystems.DataSource = softwareItSystems;
                btnAddItSystem.Enabled = lsbItSystems.Items.Count != 0;
                btnRemoveItSystem.Enabled = lsbSoftwareItSystems.Items.Count != 0;
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
        private void RefreshHardwareLists()
        {
            try
            {
                lsbSoftwareComputerDevices.DataSource = lsbComputerDevices.DataSource = null;
                hardwares = softwareHardwares.Count == 0 ? DBManager.GetHardwaresList().Where(x => x.HardwareType == HardwareType.computerDevice || x.HardwareType == HardwareType.otherNetActiveDevice).ToList() : DBManager.GetHardwaresList().Where(x => softwareHardwares.FindIndex(y => y.AId == x.AId) == -1 && (x.HardwareType == HardwareType.computerDevice || x.HardwareType == HardwareType.otherNetActiveDevice)).ToList();
                lsbComputerDevices.DataSource = hardwares;
                lsbSoftwareComputerDevices.DataSource = softwareHardwares;
                btnAddComputerDevice.Enabled = lsbComputerDevices.Items.Count != 0;
                btnRemoveComputerDevice.Enabled = lsbSoftwareComputerDevices.Items.Count != 0;
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

        private void CmbStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
