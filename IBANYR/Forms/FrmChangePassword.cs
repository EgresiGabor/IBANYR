using System;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmChangePassword : Form
    {
        #region Private fields
        readonly User user;
        #endregion
        #region Public properties
        internal User User { get => user; }
        #endregion
        #region Constructors
        internal FrmChangePassword(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        #endregion
        #region Component events
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txbOldPassword.Text.Trim()) && !String.IsNullOrEmpty(txbNewPassword.Text.Trim()) && !String.IsNullOrEmpty(txbNewPasswordAgain.Text.Trim()))
            {
                if (txbNewPassword.Text.Trim() == txbNewPasswordAgain.Text.Trim())
                {
                    try
                    {
                        DBManager.UpdateUserPw(User, txbOldPassword.Text.Trim(), txbNewPassword.Text.Trim());
                    }
                    catch (PwException ex)
                    {
                        MessageBox.Show(ex.OwnMessage, "Érvénytelen jelszó...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                    }
                    catch (DBException ex)
                    {
                        MessageBox.Show(ex.OriginalMessage, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    MessageBox.Show("Az új jelszó és az új jelszó újra mezők értékei nem egyeznek meg!", "Jelszómódosítás...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Valamennyi mezőt kötelező kitölteni!", "Jelszómódosítás...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
        #endregion
    }
}
