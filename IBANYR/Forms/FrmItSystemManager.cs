using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmItSystemManager : Form
    {
        #region Private fields
        ItSystem sys;
        User user;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal ItSystem Sys { get => sys; set => sys = value; }
        #endregion
        #region Constructor
        internal FrmItSystemManager(User user)
        {
            InitializeComponent();
            this.user = user;
            tt = new ToolTip();
            tt.SetToolTip(txbSId, "A rendszerazonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbSName, "Rendszer megnevezésének megadása kötelező, és maximum 150 karakter hosszú lehet!");
            tt.SetToolTip(txbSShortName, "Rendszer rövid nevének megadása kötelező, és maximum 50 karakter hosszú lehet!");
            tt.SetToolTip(txbVersion, "Rendszer verziószámának megadása opcionális, maximum 20 karakter hosszú lehet!");
            tt.SetToolTip(numLicenseNumber, "Rendszer licenszszámának megadása opcionális, maximális érétk 1.000.000!");
            tt.SetToolTip(cmbLifeCycle, "Az informatikai rendszer védelmi életciklusának kiválasztása!");
            tt.SetToolTip(numConfidentiality, "Az informatika rendszer biztonsági osztályba sorolását meghatározó bizalmasság értéke,\nmely 1 és 5 közötti egész szám lehet.");
            tt.SetToolTip(numIntegrity, "Az informatika rendszer biztonsági osztályba sorolását meghatározó sértetlenség értéke,\nmely 1 és 5 közötti egész szám lehet.");
            tt.SetToolTip(numAvailability, "Az informatika rendszer biztonsági osztályba sorolását meghatározó sértetlenség értéke,\nmely 1 és 5 közötti egész szám lehet.");
            tt.SetToolTip(cmbDataType, "A rendszerben tárolt adatok típusaként válasszon a három lehetséges érték közül!");
            tt.SetToolTip(rtbSDescription, "Az informatikai rendszer leírásának megadása kötelező!");
            tt.SetToolTip(rtbInterfaceDesc, "Az informatikai rendszer más rendszerekkel való kapcsolódásának leírása opcionálisan megadandó!");
            tt.SetToolTip(cmbInnerDataOwner, "Az adatgazda megadása opcionális.\nA már rögzített szervezeti egységek közül választhat.");
            tt.SetToolTip(cmbAdminUser, "Az adminisztrátor megadása opcionális.\nA már rögzített felhasználók közül választhat.");
            tt.SetToolTip(numRpo, "Az RPO értékét órában kell megadni.\nMaximális értéke 255 lehet.");
            tt.SetToolTip(numRto, "Az RTO értékét órában kell megadni.\nMaximális értéke 255 lehet.");
            tt.SetToolTip(numCrt, "Az CRT értékét órában kell megadni.\nMaximális értéke 255 lehet, minimumát az RTO érétke határozza meg.");
            tt.SetToolTip(numErt, "Az ERT értékét órában kell megadni.\nMaximális értéke 255 lehet, minimumát a CRT érétke határozza meg.");
            tt.SetToolTip(rtbCriticalPeriod, "Az informatikai rendszer rendelkezésre állásának kritikus időszakának leírását kötelező megadni!\nAmennyiben nincs ilyen, annak jelölése is szükséges!");
            tt.SetToolTip(cmbProviderPartner, "Válasszon a már rögzített értékek közül!");
            tt.SetToolTip(cmbProviderContact, "Válasszon a már rögzített értékek közül!");
            tt.SetToolTip(cmbOperatorPartner, "Válasszon a már rögzített értékek közül!");
            tt.SetToolTip(cmbOperatorContact, "Válasszon a már rögzített értékek közül!");
            tt.SetToolTip(btnAddProviderPartner, "Új partner rögzítése");
            tt.SetToolTip(btnEditProviderPartner, "Szolgáltató partner adatainak módosítása");
            tt.SetToolTip(btnReadProviderPartner, "Szolgáltató partner adatainak megtekintése");
            tt.SetToolTip(btnAddProviderContact, "Új kapcsolattartó rögzítése");
            tt.SetToolTip(btnEditProviderContact, "Kapcsolattartó adatainak módosítása");
            tt.SetToolTip(btnReadProviderContact, "Kapcsolattartó adatainak megtekintése");
            tt.SetToolTip(btnAddOperatorPartner, "Új partner rögzítése");
            tt.SetToolTip(btnEditOperatorPartner, "Üzemeltető partner adatainak módosítása");
            tt.SetToolTip(btnReadOperatorPartner, "Üzemeltető partner adatainak megtekintése");
            tt.SetToolTip(btnAddOperatorContact, "Új kapcsolattartó rögzítése");
            tt.SetToolTip(btnEditOperatorContact, "Kapcsolattartó adatainak módosítása");
            tt.SetToolTip(btnReadOperatorContact, "Kapcsolattartó adatainak megtekintése");
            try
            {
                cmbInnerDataOwner.Items.Add(String.Empty);
                foreach (Department item in Department.OrderByHierarchy(DBManager.GetDepartmentsList()))
                {
                    cmbInnerDataOwner.Items.Add(item);
                }

                cmbAdminUser.Items.Add(String.Empty);
                foreach (User item in DBManager.GetUsersList().Where(x=>x.DeleteDate == null).OrderBy(x=>x.UName))
                {
                    cmbAdminUser.Items.Add(item);
                }
                RefreshPartnersAndContacts();
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
            cmbDataType.DataSource = Enum.GetValues(typeof(StoredDataType)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbDataType.DisplayMember = "Description";
            cmbDataType.ValueMember = "value";
            cmbLifeCycle.DataSource = Enum.GetValues(typeof(SystemLifeCycle)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbLifeCycle.DisplayMember = "Description";
            cmbLifeCycle.ValueMember = "value";
            btnAddOperatorPartner.Enabled = btnAddProviderPartner.Enabled = user.HasPermission("createPartner");
            btnEditProviderPartner.Enabled = btnEditOperatorPartner.Enabled = user.HasPermission("updatePartner");
            btnAddProviderContact.Enabled = btnAddOperatorContact.Enabled = user.HasPermission("createContact");
            btnEditOperatorContact.Enabled = btnEditProviderContact.Enabled = user.HasPermission("updateContact");
            btnReadOperatorContact.Enabled = btnReadProviderContact.Enabled = user.HasPermission("readContact");
            btnReadOperatorPartner.Enabled = btnReadProviderPartner.Enabled = user.HasPermission("readPartner");
        }
        internal FrmItSystemManager(User user, ItSystem sys, bool display = false):this(user)
        {
            this.Sys = sys;
            txbSId.Text = sys.SId.ToString();
            txbSName.Text = sys.SName;
            txbSShortName.Text = sys.SShortName;
            txbVersion.Text = sys.Version;
            numLicenseNumber.Value = sys.LicenseNumber;
            cmbLifeCycle.SelectedIndex = (int)sys.LifeCycle;
            numConfidentiality.Value = sys.Confidentiality;
            numIntegrity.Value = sys.Integrity;
            numAvailability.Value = sys.Availability;
            cmbDataType.SelectedIndex = (int)sys.DataType;
            rtbSDescription.Text = sys.SDescription;
            rtbInterfaceDesc.Text = sys.InterfaceDesc;
            try
            {
                if (sys.InnerDataOwner != 0)
                {
                    cmbInnerDataOwner.SelectedItem = DBManager.GetDepartmentById(sys.InnerDataOwner);
                }
                if (sys.AdminUser != 0)
                {
                    cmbAdminUser.SelectedItem = DBManager.GetUserById(sys.AdminUser);
                }
                if (sys.ProviderPartner != 0)
                {
                    cmbProviderPartner.SelectedItem = DBManager.GetPartnerById(sys.ProviderPartner);
                }
                if (sys.OperatorPartner != 0)
                {
                    cmbOperatorPartner.SelectedItem = DBManager.GetPartnerById(sys.OperatorPartner);
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
            if (sys.ProviderContact != 0)
            {
                cmbProviderContact.SelectedItem = (cmbProviderPartner.SelectedItem as Partner).Contacts.Where(x=>x.ContId== sys.ProviderContact).First();
            }
            if (sys.OperatorContact != 0)
            {
                cmbOperatorContact.SelectedItem = (cmbOperatorPartner.SelectedItem as Partner).Contacts.Where(x => x.ContId == sys.OperatorContact).First();
            }
            numRpo.Value = sys.Rpo;
            numRto.Value = sys.Rto;
            numCrt.Value = sys.Crt;
            numErt.Value = sys.Ert;
            rtbCriticalPeriod.Text = sys.CriticalPeriod;
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is GroupBox || item is TextBox || item is RichTextBox;
                    if (item is GroupBox grb)
                    {
                        foreach (Control grbItem in grb.Controls)
                        {
                            grbItem.Enabled = grbItem.Name.Contains("Read") || grbItem is Label;
                            if (grbItem is Button grbButton)
                            {
                                grbButton.Enabled = grbButton.Name.Contains("Read");
                            }
                        }
                    }
                    else if (item is TextBox txb)
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
        private void SecurityClass_ValueChanged(object sender, EventArgs e)
        {
            grbSecurityClass.Text = $"Biztonsági osztály: {new List<byte>() { (byte)numAvailability.Value, (byte)numConfidentiality.Value, (byte)numIntegrity.Value}.Max()}";
        }
        private void NumRto_ValueChanged(object sender, EventArgs e)
        {
            numCrt.Minimum = numRto.Value;
        }
        private void NumCrt_ValueChanged(object sender, EventArgs e)
        {
            numErt.Minimum = numCrt.Value;
        }
        private void CmbProviderPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProviderContact.Items.Clear();
            if (cmbProviderPartner.SelectedIndex > -1)
            {
                foreach (Contact item in (cmbProviderPartner.SelectedItem as Partner).Contacts.OrderBy(x=>x.ContName))
                {
                    cmbProviderContact.Items.Add(item);
                }
            }
        }
        private void CmbOperatorPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOperatorContact.Items.Clear();
            if (cmbOperatorPartner.SelectedIndex > -1)
            {
                foreach (Contact item in (cmbOperatorPartner.SelectedItem as Partner).Contacts.OrderBy(x => x.ContName))
                {
                    cmbOperatorContact.Items.Add(item);
                }
            }
        }
        private void BtnAddProviderPartner_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPartnerManager frm = new FrmPartnerManager();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPartnersAndContacts(true);
                        cmbProviderPartner.SelectedItem = DBManager.GetPartnerById(frm.PartnerId);
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
        private void BtnAddOperatorPartner_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPartnerManager frm = new FrmPartnerManager();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPartnersAndContacts(true);
                    cmbOperatorPartner.SelectedItem = DBManager.GetPartnerById(frm.PartnerId);
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
        private void BtnReadProviderPartner_Click(object sender, EventArgs e)
        {
            if (cmbProviderPartner.SelectedIndex > -1)
            {
                FrmPartnerManager frm = new FrmPartnerManager(cmbProviderPartner.SelectedItem as Partner, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva megjelenítendő partner!", "Partner adatainak megjelenítése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadOperatorPartner_Click(object sender, EventArgs e)
        {
            if (cmbOperatorPartner.SelectedIndex > -1)
            {
                FrmPartnerManager frm = new FrmPartnerManager(cmbOperatorPartner.SelectedItem as Partner, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva megjelenítendő partner!", "Partner adatainak megjelenítése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditProviderPartner_Click(object sender, EventArgs e)
        {
            if (cmbProviderPartner.SelectedIndex > -1)
            {
                try
                {
                    FrmPartnerManager frm = new FrmPartnerManager(cmbProviderPartner.SelectedItem as Partner);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshPartnersAndContacts(true);
                        cmbProviderPartner.SelectedItem = DBManager.GetPartnerById(frm.PartnerId);
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
                MessageBox.Show("Nincs kiválasztva szerkesztendő partner!", "Partner adatainak szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditOperatorPartner_Click(object sender, EventArgs e)
        {
            if (cmbOperatorPartner.SelectedIndex > -1)
            {
                try
                {
                    FrmPartnerManager frm = new FrmPartnerManager(cmbOperatorPartner.SelectedItem as Partner);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshPartnersAndContacts(true);
                        cmbOperatorPartner.SelectedItem = DBManager.GetPartnerById(frm.PartnerId);
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
                MessageBox.Show("Nincs kiválasztva szerkesztendő partner!", "Partner adatainak szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadProviderContact_Click(object sender, EventArgs e)
        {
            if (cmbProviderContact.SelectedIndex > -1)
            {
                FrmContactManager frm = new FrmContactManager(cmbProviderPartner.SelectedItem as Partner, cmbProviderContact.SelectedItem as Contact, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva megjelenítendő kapcsolattartó!", "Kapcsolattartó adatainak megjelenítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnReadOperatorContact_Click(object sender, EventArgs e)
        {
            if (cmbOperatorContact.SelectedIndex > -1)
            {
                FrmContactManager frm = new FrmContactManager(cmbOperatorPartner.SelectedItem as Partner, cmbOperatorContact.SelectedItem as Contact, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva megjelenítendő kapcsolattartó!", "Kapcsolattartó adatainak megjelenítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnAddProviderContact_Click(object sender, EventArgs e)
        {
            if (cmbProviderPartner.SelectedIndex > -1)
            {
                FrmContactManager frm = new FrmContactManager(cmbProviderPartner.SelectedItem as Partner);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPartnersAndContacts(true);
                    cmbProviderContact.SelectedItem = (cmbProviderPartner.SelectedItem as Partner).Contacts.Where(x => x.ContId == frm.ContactId).First();
                }
            }
            else
            {
                MessageBox.Show("Válassza ki a szolgáltatót a kapcsolattartó rögzítéséhez!", "Kapcsolattartó rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnAddOperatorContact_Click(object sender, EventArgs e)
        {
            if (cmbOperatorPartner.SelectedIndex > -1)
            {
                FrmContactManager frm = new FrmContactManager(cmbOperatorPartner.SelectedItem as Partner);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPartnersAndContacts(true);
                    cmbOperatorContact.SelectedItem = (cmbOperatorPartner.SelectedItem as Partner).Contacts.Where(x => x.ContId == frm.ContactId).First();

                }
            }
            else
            {
                MessageBox.Show("Válassza ki az üzemeltetőt a kapcsolattartó rögzítéséhez!", "Kapcsolattartó rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditProviderContact_Click(object sender, EventArgs e)
        {
            if (cmbProviderContact.SelectedIndex > -1)
            {
                FrmContactManager frm = new FrmContactManager(cmbProviderPartner.SelectedItem as Partner, cmbProviderContact.SelectedItem as Contact);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPartnersAndContacts(true);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva szerkesztendő kapcsolattartó!", "Kapcsolattartó adatainak szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnEditOperatorContact_Click(object sender, EventArgs e)
        {
            if (cmbOperatorContact.SelectedIndex > -1)
            {
                FrmContactManager frm = new FrmContactManager(cmbOperatorPartner.SelectedItem as Partner, cmbOperatorContact.SelectedItem as Contact);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPartnersAndContacts(true);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva szerkesztendő kapcsolattartó!", "Kapcsolattartó adatainak szerkesztése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sys == null)
                {
                    if (!DBManager.IsSNameExists(txbSName.Text.Trim()))
                    {
                        if (!DBManager.IsSShortNameExists(txbSShortName.Text.Trim()))
                        {
                            Sys = new ItSystem(txbSName.Text.Trim(), txbSShortName.Text.Trim(), txbVersion.Text.Trim(), (int)numLicenseNumber.Value, (SystemLifeCycle)cmbLifeCycle.SelectedIndex, (byte)numConfidentiality.Value, (byte)numIntegrity.Value, (byte)numAvailability.Value, (StoredDataType)cmbDataType.SelectedIndex, rtbSDescription.Text.Trim(), cmbInnerDataOwner.SelectedIndex < 1 ? 0 : (cmbInnerDataOwner.SelectedItem as Department).DId, cmbAdminUser.SelectedIndex < 1 ? 0 : (cmbAdminUser.SelectedItem as User).UId, rtbInterfaceDesc.Text.Trim(), cmbProviderPartner.SelectedIndex == -1 ? 0 : (cmbProviderPartner.SelectedItem as Partner).PartId, cmbProviderContact.SelectedIndex == -1 ? 0 : (cmbProviderContact.SelectedItem as Contact).ContId, cmbOperatorPartner.SelectedIndex == -1 ? 0 : (cmbOperatorPartner.SelectedItem as Partner).PartId, cmbOperatorContact.SelectedIndex == -1 ? 0 : (cmbOperatorContact.SelectedItem as Contact).ContId, (short)numRpo.Value, (short)numRto.Value, (short)numCrt.Value, (short)numErt.Value, rtbCriticalPeriod.Text.Trim());
                            DBManager.CreateItSystem(Sys);
                        }
                        else
                        {
                            MessageBox.Show("Ezzel a rövid névvel már van rögzítve rendszer! Kérem adjon meg másikat!", "Rendszer rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ezen a néven már van rögzítve rendszer! Kérem adjon meg másikat!", "Rendszer rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    if (!DBManager.IsSNameExists(txbSName.Text.Trim(), Sys.SId))
                    {
                        if (!DBManager.IsSShortNameExists(txbSShortName.Text.Trim(), Sys.SId))
                        {
                            Sys.SName = txbSName.Text.Trim();
                            Sys.SShortName = txbSShortName.Text.Trim();
                            Sys.Version = txbVersion.Text.Trim();
                            Sys.LicenseNumber = (int)numLicenseNumber.Value;
                            Sys.LifeCycle = (SystemLifeCycle)cmbLifeCycle.SelectedIndex;
                            Sys.Confidentiality = (byte)numConfidentiality.Value;
                            Sys.Integrity = (byte)numIntegrity.Value;
                            Sys.Availability = (byte)numAvailability.Value;
                            Sys.DataType = (StoredDataType)cmbDataType.SelectedIndex;
                            Sys.SDescription = rtbSDescription.Text.Trim();
                            Sys.InnerDataOwner = cmbInnerDataOwner.SelectedIndex < 1 ? 0 : (cmbInnerDataOwner.SelectedItem as Department).DId;
                            Sys.AdminUser = cmbAdminUser.SelectedIndex < 1 ? 0 : (cmbAdminUser.SelectedItem as User).UId;
                            Sys.InterfaceDesc = rtbInterfaceDesc.Text.Trim();
                            Sys.ProviderPartner = cmbProviderPartner.SelectedIndex == -1 ? 0 : (cmbProviderPartner.SelectedItem as Partner).PartId;
                            Sys.ProviderContact = cmbProviderContact.SelectedIndex == -1 ? 0 : (cmbProviderContact.SelectedItem as Contact).ContId;
                            Sys.OperatorPartner = cmbOperatorPartner.SelectedIndex == -1 ? 0 : (cmbOperatorPartner.SelectedItem as Partner).PartId;
                            Sys.OperatorContact = cmbOperatorContact.SelectedIndex == -1 ? 0 : (cmbOperatorContact.SelectedItem as Contact).ContId;
                            Sys.Rpo = (short)numRpo.Value;
                            Sys.Rto = (short)numRto.Value;
                            Sys.Crt = (short)numCrt.Value;
                            Sys.Ert = (short)numErt.Value;
                            Sys.CriticalPeriod = rtbCriticalPeriod.Text.Trim();
                            DBManager.UpdateItSystem(Sys);
                        }
                        else
                        {
                            MessageBox.Show("Ezzel a rövid névvel már van rögzítve rendszer! Kérem adjon meg másikat!", "Rendszer rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ezen a néven már van rögzítve rendszer! Kérem adjon meg másikat!", "Rendszer rögzítése...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #region Own Methods and Functions
        private void RefreshPartnersAndContacts(bool setSelection = false)
        {
            int selectedProviderPartnerId, selectedOperatorPartnerId, selectedProviderContactId, selectedOperatorContactId;
            selectedProviderPartnerId = selectedOperatorPartnerId = selectedProviderContactId = selectedOperatorContactId = 0;
            if (setSelection)
            {
                selectedProviderPartnerId = cmbProviderPartner.SelectedIndex > -1 && cmbProviderPartner.SelectedItem is Partner provPart ? provPart.PartId : 0;
                selectedOperatorPartnerId = cmbOperatorPartner.SelectedIndex > -1 && cmbOperatorPartner.SelectedItem is Partner opPart ? opPart.PartId : 0;
                selectedProviderContactId = cmbProviderContact.SelectedIndex > -1 && cmbProviderContact.SelectedItem is Contact provCont ? provCont.ContId : 0;
                selectedOperatorContactId = cmbOperatorContact.SelectedIndex > -1 && cmbOperatorContact.SelectedItem is Contact opCont ? opCont.ContId : 0;
            }
            cmbProviderPartner.Items.Clear();
            cmbOperatorPartner.Items.Clear();
            try
            {
                foreach (Partner item in DBManager.GetPartnersList().OrderBy(x => x.PartName))
                {
                    cmbProviderPartner.Items.Add(item);
                    cmbOperatorPartner.Items.Add(item);
                }
                if (selectedProviderPartnerId != 0)
                {
                    cmbProviderPartner.SelectedItem = DBManager.GetPartnerById(selectedProviderPartnerId);
                }
                if (selectedOperatorPartnerId != 0)
                {
                    cmbOperatorPartner.SelectedItem = DBManager.GetPartnerById(selectedOperatorPartnerId);
                }
                if (selectedProviderContactId != 0)
                {
                    cmbProviderContact.SelectedItem = (cmbProviderPartner.SelectedItem as Partner).Contacts.Where(x => x.ContId == selectedProviderContactId).First();
                }
                if (selectedOperatorContactId != 0)
                {
                    cmbOperatorContact.SelectedItem = (cmbOperatorPartner.SelectedItem as Partner).Contacts.Where(x => x.ContId == selectedOperatorContactId).First();
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
    }
}
