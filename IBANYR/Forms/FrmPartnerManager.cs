using System;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmPartnerManager : Form
    {
        #region Private fields
        Partner partner;
        int partnerId;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        public int PartnerId { get => partnerId; set => partnerId = value; }
        #endregion
        #region Constructors
        public FrmPartnerManager()
        {
            partner = null;
            InitializeComponent();
            tt = new ToolTip();
            tt.SetToolTip(txbPartId, "A partnerazonosító megadása/módosítása nem lehetséges!\nAz adatbázisszerver automatikusan generált értéke.");
            tt.SetToolTip(txbPartName, "A partner nevének megadása kötelező, mely maximum 150 karakter hosszú lehet!");
            tt.SetToolTip(txbTaxNumber, "A partner adószámának első 8 számjegyének (törzsszámának) megadása kötelező!");
        }
        internal FrmPartnerManager(Partner partner, bool display = false): this()
        {
            this.partner = partner;
            PartnerId = partner.PartId;
            txbPartId.Text = partner.PartId.ToString();
            txbPartName.Text = partner.PartName;
            txbTaxNumber.Text = partner.TaxNumber;
            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label || item is TextBox;
                    if (item is TextBox txb)
                    {
                        txb.ReadOnly = true;
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
                if (partner == null)
                {
                    partner = new Partner(txbPartName.Text.Trim(), txbTaxNumber.Text.Trim());
                    if (!DBManager.IsPartnerExists(partner))
                    {
                        DBManager.CreatePartner(partner, out int newPartnerId);
                        PartnerId = newPartnerId;
                    }
                    else
                    {
                        MessageBox.Show("Ezen a néven és/vagy törzsszámmal már van rögzítve partner!", "Partner rögzítése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    partner.PartName = txbPartName.Text.Trim();
                    partner.TaxNumber = txbTaxNumber.Text.Trim();
                    if (!DBManager.IsPartnerExists(partner, partner.PartId))
                    {
                        DBManager.UpdatePartner(partner, out int newContactId);
                    }
                    else
                    {
                        MessageBox.Show("Ezen a néven és/vagy törzsszámmal már van rögzítve partner!", "Partner rögzítése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
