using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmHardwareManager : Form
    {
        #region Private fields
        Hardware hardwareDevice;
        List<ItSystem> itSystems;
        List<ItSystem> hardwareItSystems;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal Hardware HardwareDevice { get => hardwareDevice; set => hardwareDevice = value; }
        #endregion
        #region Constructors
        internal FrmHardwareManager()
        {
            InitializeComponent();
            tt = new ToolTip();
            HardwareDevice = null;
            tt.SetToolTip(txbAId, "A hardverazonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbAName, "Hardver nevének megadása kötelező, és minimum 3 és maximum 50 karakter hosszú lehet!");
            tt.SetToolTip(dtpPurchaseDate, "Hardver beszerzési dátumának megadása kötelező!");
            tt.SetToolTip(cmbOwnerId, "Tulajdonos megadása opcionális.\nA már rögzített fő szervezeti egységek közül választhat!");
            tt.SetToolTip(cmbStatus, "Státusz megadás kötelező!\nRögzített értékek közül választhat.");
            tt.SetToolTip(dtpScrappingDate, "Selejtezve státuszú hardver selejtezési dátuma kötelezően megadandó!");
            tt.SetToolTip(cmbUId, "Hardver használója opcionálisan megadható.\nA rögzített felhasználók közül választhat.");
            tt.SetToolTip(txbPlace, "Hardver helye opcionálisan megadható.\nMaximum 50 karakter hosszú lehet.");
            tt.SetToolTip(txbSerialNumber, "A hardver sorozatszáma kötelezően megadandó érték, melynek maximális hossza 50 karakter lehet.");
            tt.SetToolTip(numWarrantyYears, "A hardverre nyújtott garanciaévek száma opcionálisan megadható, maximális értéke 255 lehet.");
            tt.SetToolTip(cmbCategory, "A hardver kategóriája kötelezően megadandó.\nSzabadon adható meg maximum 50 karakter hosszúságú új kategórianév, vagy szabadon választható valamely rögzített érték.");
            tt.SetToolTip(cmbHardwareType, "A hardver típusa kötelezően kiválasztandó.\nA választásnak megfelelően kitöltendőek a további hardveradatok.");
            tt.SetToolTip(chbPortable, "A mező kijelölésével állítja be, hogy a hardver hordozható.");
            tt.SetToolTip(chbVirtual, "A mező kijelölésével állítja be, hogy a hardver virtuális.");
            tt.SetToolTip(txbProcessor, "Opcionálisan megadható szöveges érték, mely maximum 50 karakter hosszú lehet.");
            tt.SetToolTip(numRam, "Az értéket MB-ban lehet megadni, melynek maximális értéke 1.000.000 lehet.");
            tt.SetToolTip(txbOtherComponent, "Az opcionálisan megadható szöveg maximum 200 karakter hosszú lehet.");
            tt.SetToolTip(numStorageCapacity, "Az értéket MB-ban lehet megadni, melynek maximális értéke 1.000.000.000 lehet.");
            tt.SetToolTip(chbEncrypted, "A mező kijelölésével állítja be, hogy az adattároló típusú hardver titkosított.");
            tt.SetToolTip(txbRecoveryKey, "A megadott kulcs titkosítva kerül letárolásra.\nA megadható kulcs maximális hossza 150 karakter.");
            tt.SetToolTip(btnCopyRecoveryKey, "Helyreállítási kulcs másolása");
            tt.SetToolTip(rtbDocLink, "Opcionálisan megadható szöveges érték, mely maximum 4000 karakter hosszú lehet.");
            tt.SetToolTip(rtbOtherDescription, "Opcionálisan megadható szöveges érték.");
            tt.SetToolTip(txbHostName, "A hoszt név megadása kötelező, és maximum 50 karakter hosszú lehet!");

            tt.SetToolTip(btnAddNIC, "Hálózati adapter hozzáadása");
            tt.SetToolTip(btnEditNIC, "Hálózati adapter adatainak módosítása");
            tt.SetToolTip(btnDeleteNIC, "Hálózati adapter törlése");
            tt.SetToolTip(btnReadNIC, "Hálózati adapter adatainak megtekintése");
            tt.SetToolTip(btnAddItSystem, "Rendszer hozzárendelése");
            tt.SetToolTip(btnRemoveItSystem, "Rendszer összekapcsolásának törlése");
            itSystems = new List<ItSystem>();
            hardwareItSystems = new List<ItSystem>();
            RefreshItSystemLists();
            try
            {
                cmbOwnerId.Items.Add(String.Empty);
                foreach (Department item in DBManager.GetDepartmentsList().Where(x=>x.SuperiorDId == 0).ToList())
                {
                    cmbOwnerId.Items.Add(item);
                }
                cmbUId.Items.Add(String.Empty);
                foreach (User item in DBManager.GetUsersList().Where(x=>x.DeleteDate == null).OrderBy(x=>x.UName).ToList())
                {
                    cmbUId.Items.Add(item);
                }
                foreach (string item in DBManager.GetHardwareCategories())
                {
                    cmbCategory.Items.Add(item);
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
            cmbHardwareType.DataSource = Enum.GetValues(typeof(HardwareType)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbHardwareType.DisplayMember = "Description";
            cmbHardwareType.ValueMember = "value";
            dtpPurchaseDate.MinDate = dtpScrappingDate.MinDate = SqlDateTime.MinValue.Value;
            dtpScrappingDate.Enabled = false;
        }
        internal FrmHardwareManager(Hardware hardwareDevice, bool display = false) : this()
        {
            HardwareDevice = hardwareDevice;
            txbAId.Text = HardwareDevice.AId.ToString();
            txbAName.Text = HardwareDevice.AName;
            dtpPurchaseDate.Value = HardwareDevice.PurchaseDate;
            cmbOwnerId.SelectedItem = HardwareDevice.Owner;
            cmbStatus.SelectedIndex = (int)HardwareDevice.Status;
            if (HardwareDevice.ScrappingDate != null)
            {
                dtpScrappingDate.Value = (DateTime)HardwareDevice.ScrappingDate;
            }
            try
            {
                if (HardwareDevice.UId != 0)
                {
                    cmbUId.SelectedItem = HardwareDevice.DeviceUser;
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
            txbPlace.Text = HardwareDevice.Place;
            txbSerialNumber.Text = HardwareDevice.SerialNumber;
            numWarrantyYears.Value = HardwareDevice.WarrantyYears;
            cmbCategory.SelectedItem = HardwareDevice.Category;
            cmbHardwareType.SelectedIndex = (int)HardwareDevice.HardwareType;
            cmbHardwareType.Enabled = false;
            chbPortable.Checked = HardwareDevice.Portable;
            chbVirtual.Checked = HardwareDevice.IsVirtual;
            chbVirtual.Enabled = chbPortable.Enabled = false;
            rtbDocLink.Text = HardwareDevice.DocLink;
            rtbOtherDescription.Text = HardwareDevice.OtherDescription;
            if (HardwareDevice is ComputerDevice comp)
            {
                txbProcessor.Text = comp.Processor;
                numRam.Value = comp.Ram;
                txbOtherComponent.Text = comp.OtherComponent;
                numStorageCapacity.Value = comp.StorageCapacity;
            }
            if (HardwareDevice is DataStorageDevice dsd)
            {
                numStorageCapacity.Value = dsd.StorageCapacity;
                chbEncrypted.Checked = dsd.Encrypted;
                txbRecoveryKey.Text = dsd.RecoveryKey != null ? Password.Decrypt(dsd.RecoveryKey) : String.Empty;
            }
            if (HardwareDevice is NetActiveDevice nad)
            {
                txbHostName.Text = nad.HostName;
                foreach (NIC item in nad.NicsList)
                {
                    lsbNICs.Items.Add(item);
                }
            }
            hardwareItSystems = HardwareDevice.ItSystems;
            RefreshItSystemLists();
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    if (item != grbNetworkDatas)
                    {
                        item.Enabled = item == btnCancel || item is Label || item == lsbNICs || item is RichTextBox || item is TextBox || item == btnReadNIC || item == lsbHardwareItSystems || item == lsbItSystems;
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
                    else
                    {
                        txbHostName.ReadOnly = true;
                        btnAddNIC.Enabled = btnDeleteNIC.Enabled = btnEditNIC.Enabled = false;
                    }
                }
                btnCopyRecoveryKey.Enabled = HardwareDevice is DataStorageDevice;
                btnOk.Visible = btnAddItSystem.Enabled = btnRemoveItSystem.Enabled = lsbItSystems.Enabled = false;
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
        }
        private void CmbUId_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbItSystems.SelectedIndex = -1;
            if (cmbUId.SelectedItem is User usr && usr.ItSystemPermissions.Count != 0)
            {
                for (int i = 0; i < lsbItSystems.Items.Count; i++)
                {
                    lsbItSystems.SetSelected(i, (cmbUId.SelectedItem as User).ItSystemPermissions.Where(x => x.SId == (lsbItSystems.Items[i] as ItSystem).SId).ToList().Count > 0);
                }
            }
        }
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpScrappingDate.Enabled = cmbStatus.SelectedIndex == (int)AssetState.discarded;
        }
        private void CmbHardwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((HardwareType)cmbHardwareType.SelectedIndex)
            {
                case HardwareType.dataStorage:
                    grbNetworkDatas.Enabled = false;
                    txbProcessor.Enabled = false;
                    numRam.Enabled = false;
                    txbOtherComponent.Enabled = false;
                    numStorageCapacity.Enabled = true;
                    chbEncrypted.Enabled = true;
                    txbRecoveryKey.Enabled = true;
                    btnCopyRecoveryKey.Enabled = true;
                    break;
                case HardwareType.computerDevice:
                    grbNetworkDatas.Enabled = true;
                    txbProcessor.Enabled = true;
                    numRam.Enabled = true;
                    txbOtherComponent.Enabled = true;
                    numStorageCapacity.Enabled = true;
                    chbEncrypted.Enabled = false;
                    txbRecoveryKey.Enabled = false;
                    btnCopyRecoveryKey.Enabled = false;
                    break;
                case HardwareType.otherNetActiveDevice:
                    grbNetworkDatas.Enabled = true;
                    txbProcessor.Enabled = false;
                    numRam.Enabled = false;
                    txbOtherComponent.Enabled = false;
                    numStorageCapacity.Enabled = false;
                    chbEncrypted.Enabled = false;
                    txbRecoveryKey.Enabled = false;
                    btnCopyRecoveryKey.Enabled = false;
                    break;
                case HardwareType.otherHardware:
                    grbNetworkDatas.Enabled = false;
                    txbProcessor.Enabled = false;
                    numRam.Enabled = false;
                    txbOtherComponent.Enabled = false;
                    numStorageCapacity.Enabled = false;
                    chbEncrypted.Enabled = false;
                    txbRecoveryKey.Enabled = false;
                    btnCopyRecoveryKey.Enabled = false;
                    break;
            }
        }
        private void BtnAddItSystem_Click(object sender, EventArgs e)
        {
            if (lsbItSystems.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbItSystems.SelectedItems)
                {
                    hardwareItSystems.Add((ItSystem)item);
                }
                RefreshItSystemLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki a hozzárendelni kívánt rendszert!", "Rendszer hozzárendelése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnRemoveItSystem_Click(object sender, EventArgs e)
        {
            if (lsbHardwareItSystems.SelectedIndices.Count > 0)
            {
                foreach (var item in lsbHardwareItSystems.SelectedItems)
                {
                    hardwareItSystems.Remove((ItSystem)item);
                }
                RefreshItSystemLists();
            }
            else
            {
                MessageBox.Show("Jelölje ki az eltávolítandó rendszert!", "Rendszer hozzárendelésének törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadNIC_Click(object sender, EventArgs e)
        {
            if (lsbNICs.SelectedIndex > -1)
            {
                FrmNicManager frm = new FrmNicManager(lsbNICs.SelectedItem as NIC, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva megjelenítendő hálózati adapter!", "Hálózati adapter adatainak megjelenítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditNIC_Click(object sender, EventArgs e)
        {
            if (lsbNICs.SelectedIndex > -1)
            {
                int index = lsbNICs.SelectedIndex;
                FrmNicManager frm = new FrmNicManager(lsbNICs.SelectedItem as NIC);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lsbNICs.Items.RemoveAt(index);
                    lsbNICs.Items.Insert(index, frm.NicDevice);
                    lsbNICs.SelectedIndex = index;
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva módosítandó hálózati adapter!", "Hálózati adapter adatainak módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnAddNIC_Click(object sender, EventArgs e)
        {
            FrmNicManager frm = new FrmNicManager();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lsbNICs.Items.Add(frm.NicDevice);
            }
        }
        private void BtnDeleteNIC_Click(object sender, EventArgs e)
        {
            if (lsbNICs.SelectedIndex > -1)
            {
                if (MessageBox.Show("Valóban törölni szeretné a kijelölt hálózati adaptert?", "Hálózati adapter törlése...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    lsbNICs.Items.RemoveAt(lsbNICs.SelectedIndex);
                    lsbNICs.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva törlendő hálózati adapter!", "Hálózati adapter törlése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (HardwareDevice == null)
                {
                    if (!DBManager.IsSerialNumberExists(txbSerialNumber.Text.Trim()))
                    {
                        switch ((HardwareType)cmbHardwareType.SelectedIndex)
                        {
                            case HardwareType.dataStorage:
                                HardwareDevice = new DataStorageDevice(
                                    (int)numStorageCapacity.Value,
                                    chbEncrypted.Checked,
                                    chbEncrypted.Checked ? txbRecoveryKey.Text.Trim() : null,
                                    cmbUId.SelectedIndex < 1 ? 0 : (cmbUId.SelectedItem as User).UId,
                                    txbPlace.Text.Trim(),
                                    txbSerialNumber.Text.Trim(),
                                    (byte)numWarrantyYears.Value,
                                    cmbCategory.SelectedIndex != -1 ? cmbCategory.SelectedItem.ToString() : cmbCategory.Text.Trim(),
                                    (HardwareType)cmbHardwareType.SelectedIndex,
                                    chbPortable.Checked,
                                    chbVirtual.Checked,
                                    txbAName.Text.Trim(),
                                    dtpPurchaseDate.Value,
                                    cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem,
                                    (AssetState)cmbStatus.SelectedIndex,
                                    rtbDocLink.Text.Trim(),
                                    dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null,
                                    rtbOtherDescription.Text.Trim());
                                foreach (ItSystem item in hardwareItSystems)
                                {
                                    HardwareDevice.AddItSystems(item);
                                }
                                break;
                            case HardwareType.computerDevice:
                                HardwareDevice = new ComputerDevice(
                                    txbProcessor.Text.Trim(),
                                    (int)numRam.Value,
                                    (int)numStorageCapacity.Value,
                                    txbOtherComponent.Text.Trim(),
                                    txbHostName.Text.Trim(),
                                    cmbUId.SelectedIndex < 1 ? 0 : (cmbUId.SelectedItem as User).UId,
                                    txbPlace.Text.Trim(),
                                    txbSerialNumber.Text.Trim(),
                                    (byte)numWarrantyYears.Value,
                                    cmbCategory.SelectedIndex != -1 ? cmbCategory.SelectedItem.ToString() : cmbCategory.Text.Trim(),
                                    (HardwareType)cmbHardwareType.SelectedIndex,
                                    chbPortable.Checked,
                                    chbVirtual.Checked,
                                    txbAName.Text.Trim(),
                                    dtpPurchaseDate.Value,
                                    cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem,
                                    (AssetState)cmbStatus.SelectedIndex,
                                    rtbDocLink.Text.Trim(),
                                    dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null,
                                    rtbOtherDescription.Text.Trim());
                                foreach (ItSystem item in hardwareItSystems)
                                {
                                    HardwareDevice.AddItSystems(item);
                                }
                                foreach (NIC item in lsbNICs.Items)
                                {
                                    (HardwareDevice as ComputerDevice).AddNIC(item);
                                }
                                break;
                            case HardwareType.otherNetActiveDevice:
                                HardwareDevice = new NetActiveDevice(
                                    txbHostName.Text.Trim(),
                                    cmbUId.SelectedIndex < 1 ? 0 : (cmbUId.SelectedItem as User).UId,
                                    txbPlace.Text.Trim(),
                                    txbSerialNumber.Text.Trim(),
                                    (byte)numWarrantyYears.Value,
                                    cmbCategory.SelectedIndex != -1 ? cmbCategory.SelectedItem.ToString() : cmbCategory.Text.Trim(),
                                    (HardwareType)cmbHardwareType.SelectedIndex,
                                    chbPortable.Checked,
                                    chbVirtual.Checked,
                                    txbAName.Text.Trim(),
                                    dtpPurchaseDate.Value,
                                    cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem,
                                    (AssetState)cmbStatus.SelectedIndex,
                                    rtbDocLink.Text.Trim(),
                                    dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null,
                                    rtbOtherDescription.Text.Trim());
                                foreach (ItSystem item in hardwareItSystems)
                                {
                                    HardwareDevice.AddItSystems(item);
                                }
                                foreach (NIC item in lsbNICs.Items)
                                {
                                    (HardwareDevice as NetActiveDevice).AddNIC(item);
                                }
                                break;
                            case HardwareType.otherHardware:
                                HardwareDevice = new Hardware(
                                    cmbUId.SelectedIndex < 1 ? 0 : (cmbUId.SelectedItem as User).UId,
                                    txbPlace.Text.Trim(),
                                    txbSerialNumber.Text.Trim(),
                                    (byte)numWarrantyYears.Value,
                                    cmbCategory.SelectedIndex != -1 ? cmbCategory.SelectedItem.ToString() : cmbCategory.Text.Trim(),
                                    (HardwareType)cmbHardwareType.SelectedIndex,
                                    chbPortable.Checked,
                                    chbVirtual.Checked,
                                    txbAName.Text.Trim(),
                                    dtpPurchaseDate.Value,
                                    cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem,
                                    (AssetState)cmbStatus.SelectedIndex,
                                    rtbDocLink.Text.Trim(),
                                    dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null,
                                    rtbOtherDescription.Text.Trim());
                                foreach (ItSystem item in hardwareItSystems)
                                {
                                    HardwareDevice.AddItSystems(item);
                                }
                                break;
                        }
                        DBManager.CreateHardware(HardwareDevice);
                    }
                    else
                    {
                        MessageBox.Show("Ezzel a sorozatszámmal már van rögzítve hardver! Kérem adjon meg másikat!", "Hardver rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    HardwareDevice.AName = txbAName.Text.Trim();
                    HardwareDevice.PurchaseDate = dtpPurchaseDate.Value;
                    HardwareDevice.Owner = cmbOwnerId.SelectedIndex < 1 ? null : (Department)cmbOwnerId.SelectedItem;
                    HardwareDevice.Status = (AssetState)cmbStatus.SelectedIndex;
                    HardwareDevice.ScrappingDate = dtpScrappingDate.Enabled ? (DateTime?)dtpScrappingDate.Value : null;
                    HardwareDevice.UId = cmbUId.SelectedIndex < 1 ? 0 : (cmbUId.SelectedItem as User).UId;
                    HardwareDevice.Place = txbPlace.Text.Trim();
                    HardwareDevice.WarrantyYears = (byte)numWarrantyYears.Value;
                    HardwareDevice.Category = cmbCategory.SelectedIndex != -1 ? cmbCategory.SelectedItem.ToString() : cmbCategory.Text.Trim();
                    HardwareDevice.DocLink = rtbDocLink.Text.Trim();
                    HardwareDevice.OtherDescription = rtbOtherDescription.Text.Trim();
                    if (HardwareDevice is DataStorageDevice dsd)
                    {
                        dsd.StorageCapacity = (int)numStorageCapacity.Value;
                        dsd.Encrypted = chbEncrypted.Checked;
                        dsd.RecoveryKey = chbEncrypted.Checked ? txbRecoveryKey.Text.Trim() : null;
                    }
                    else if (HardwareDevice is NetActiveDevice nad)
                    {
                        nad.HostName = txbHostName.Text.Trim();
                        nad.ClearNIC();
                        foreach (NIC item in lsbNICs.Items)
                        {
                            nad.AddNIC(item);
                        }
                        if (nad is ComputerDevice comp)
                        {
                            comp.Processor = txbProcessor.Text.Trim();
                            comp.Ram = (int)numRam.Value;
                            comp.StorageCapacity = (int)numStorageCapacity.Value;
                            comp.OtherComponent = txbOtherComponent.Text.Trim();
                        }
                    }
                    HardwareDevice.ClearItSystems();
                    foreach (ItSystem item in hardwareItSystems)
                    {
                        HardwareDevice.AddItSystems(item);
                    }
                    DBManager.UpdateHardware(HardwareDevice);
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
        private void BtnCopyRecoveryKey_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txbRecoveryKey.Text))
            {
                Clipboard.SetText(txbRecoveryKey.Text.Trim());
            }
        }
        #endregion
        #region Own Methods and Functions
        private void RefreshItSystemLists()
        {
            try
            {
                lsbHardwareItSystems.DataSource = lsbItSystems.DataSource = null;
                itSystems = hardwareItSystems.Count == 0 ? DBManager.GetItSystemsList() : DBManager.GetItSystemsList().Where(x => hardwareItSystems.FindIndex(y => y.SId == x.SId) == -1).ToList();
                lsbItSystems.DataSource = itSystems;
                lsbHardwareItSystems.DataSource = hardwareItSystems;
                btnAddItSystem.Enabled = lsbItSystems.Items.Count != 0;
                btnRemoveItSystem.Enabled = lsbHardwareItSystems.Items.Count != 0;
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
