using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmLogin : Form
    {
        #region Private fields
        User user;
        Dictionary<int, byte> loginAttemptsNum;
        Dictionary<int, DateTime> lastAttempts;
        #endregion
        #region Public properties
        internal User User { get => user;}
        #endregion
        #region Constructors
        internal FrmLogin()
        {
            InitializeComponent();
            loginAttemptsNum = new Dictionary<int, byte>();
            lastAttempts = new Dictionary<int, DateTime>();
        }
        #endregion
        #region Component events
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txbEmail.Text.Trim()) && !String.IsNullOrEmpty(txbPassword.Text.Trim()))
            {
                try
                {
                    user = DBManager.GetUserByEmail(txbEmail.Text.Trim());
                    if (user != null)
                    {
                        if (!user.Locked)
                        {
                            if (!user.IsPermanentLocked())
                            {
                                if (!DBManager.UserPasswordChecker(User, txbPassword.Text.Trim(), out int failedLoginNum))
                                {
                                    MessageBox.Show("Nem megfelelő felhasználónév vagy jelszó!", "Bejelentkezés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    if (failedLoginNum > 0)
                                    {
                                        if (loginAttemptsNum.ContainsKey(user.UId))
                                        {
                                            if (loginAttemptsNum[user.UId] < failedLoginNum - 1)
                                            {
                                                loginAttemptsNum[user.UId]++;
                                                lastAttempts[user.UId] = DBManager.GetCurrentTime();
                                            }
                                            else
                                            {
                                                user.PermanentLocked = DBManager.GetCurrentTime();
                                                DBManager.UpdateUser(user);
                                                loginAttemptsNum.Remove(user.UId);
                                                lastAttempts.Remove(user.UId);
                                                SystemLog.WriteLogEvent(User, EventType.userPermanentLock);
                                                MessageBox.Show($"Felhasználói fiókját zároltuk {DBManager.GetConfiguration().PermanentLockingPeriod} percre, mert túllépte a sikertelen próbálkozások számát!\n\rPróbáljon bejelentkezni később!", "Bejelentkezés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            loginAttemptsNum.Add(user.UId, 1);
                                            lastAttempts.Add(user.UId, DBManager.GetCurrentTime());
                                        }
                                    }
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Felhasználói fiókja {DBManager.GetConfiguration().PermanentLockingPeriod} percre zárolva van, mert túllépte a sikertelen próbálkozások számát!\n\rPróbáljon bejelentkezni később!", "Bejelentkezés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.DialogResult = DialogResult.Cancel;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Felhasználói fiókja zárolva van!\n\rTovábbi információért keresse az adminisztrátort!", "Bejelentkezés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem megfelelő email cím vagy jelszó!", "Bejelentkezés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                    }
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
                MessageBox.Show("Email cím és jelszó megadása kötelező!", "Bejelentkezés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
        #endregion
    }
}
