using System;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmContactManager : Form
    {
        #region Private fields
        Partner partner;
        Contact contact;
        int contactId;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        public int ContactId { get => contactId; set => contactId = value; }
        #endregion
        #region Constructors
        internal FrmContactManager(Partner partner)
        {
            InitializeComponent();
            this.partner = partner;
            this.contact = null;
            tt = new ToolTip();
            tt.SetToolTip(txbContId, "A kapcsolattartó azonosítójának megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbContName, "A kapcsolattartó nevének megadása kötelező, és maximum 50 karakter hosszú lehet!");
            tt.SetToolTip(txbEmail, "Email cím megadása opcionális.\nMegadása esetén maximum 50 karakter hosszú lehet és meg kell,\nhogy feleljen az email címmekkel szemben támasztott formai követelményeknek.");
            tt.SetToolTip(mtbPhone, "Telefonszám megadása opcionális.\nMegadása esetén meg kell, hogy feleljen a magyar telefonszámokkal\nszemben támasztott formai előírásoknak.");
            tt.SetToolTip(txbAddress, "Levelezési cím megadása opcionális és maximum 200 karakter hosszú lehet.");
        }
        internal FrmContactManager(Partner partner, Contact contact, bool display = false):this(partner)
        {
            this.contact = contact;
            ContactId = contact.ContId;
            txbContId.Text = contact.ContId.ToString();
            txbContName.Text = contact.ContName;
            txbEmail.Text = contact.Email;
            mtbPhone.Text = contact.Phone;
            txbAddress.Text = contact.Address;
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is MaskedTextBox || item is TextBox || item is RichTextBox;
                    if (item is MaskedTextBox mtb)
                    {
                        mtb.ReadOnly = true;
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
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                mtbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string phoneWithoutMask = mtbPhone.Text.Trim();
                mtbPhone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                if (contact == null)
                {
                    contact = new Contact(txbContName.Text.Trim(), txbEmail.Text.Trim(), txbAddress.Text.Trim(), String.IsNullOrEmpty(phoneWithoutMask) ? null : mtbPhone.Text.Replace('_', ' ').Trim());
                    partner.AddContact(contact);
                    DBManager.UpdatePartner(partner, out int newContactId);
                    ContactId = newContactId;
                }
                else
                {
                    contact.ContName = txbContName.Text.Trim();
                    contact.Email = txbEmail.Text.Trim();
                    contact.Address = txbAddress.Text.Trim();
                    contact.Phone = String.IsNullOrEmpty(phoneWithoutMask) ? null : mtbPhone.Text.Replace('_', ' ').Trim();
                    DBManager.UpdatePartner(partner, out int newContactId);
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
