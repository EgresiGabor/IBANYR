using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmConfiguration : Form
    {
        #region Private fields
        User user;
        AppConfiguration conf;
        ToolTip tt;
        #endregion
        #region Constructors
        internal FrmConfiguration(User user)
        {
            InitializeComponent();
            this.user = user;
            tt = new ToolTip();
            tt.SetToolTip(numPwValidityPeriod, "A jelszavak érvényességi ideje napokban megadva.\n- Maximálisan rögzíthető érték 365 nap.\n- Ha az értéke 0, akkor a jelszó érvényessége nem jár le.");
            tt.SetToolTip(numPwLength, "A jelszó minimálisan elvárt karakterhossza.\n- Minimális értéke 5.\n- Maximálisan rögzíthető érték 50 lehet.");
            tt.SetToolTip(cmbPwComplexity, "Kiválasztható, hogy a felhasználói jelszavaknak\nmilyen bonyolultsági szabályoknak kell megfelelniük.");
            tt.SetToolTip(numFailedLoginNum, "A lehetséges sikertelen belépési próbálkozások száma megadja,\nhogy a rendszer hány sikertelen belépési kísérlet után tiltsa le\n ideiglenesen az adott felhasználói fiókot.\n- Maximálisan értéke 20 lehet.\n- Ha az értéke 0, akkor ez a fajta védelem inaktív.");
            tt.SetToolTip(numPermanentLockingPeriod, "Beállítható, hogy a hibás bejelentkezések miatt zárolt felhasználó\nideiglenes zárolása hány perc után szűnjön meg.\nMaximálisan megadható érték 180.");
            tt.SetToolTip(numRetentionDays, "Beállítható, hogy a törölt felhasználó adatai, illetve a hozzá tartozó naplóbejegyzések\nhány napig őrződjenek meg a törlés időpontjától kezdődően.\n A beállítható maximális érték 20 év, azaz 7305 nap lehet.\n- Ha az értéke 0, akkor a felhasználó törlésével egyidejűleg törlése kerülnek a hozzá kapcsolódó naplóbejegyzések is.");
            tt.SetToolTip(chbEnableEmail, "Megjelölésével beállítható, hogy a rendszer tudjon email értesítéseket küldeni.");
            tt.SetToolTip(txbSmtpServer, "Az email küldéséhez szükséges SMTP server címét meg kell adni.");
            tt.SetToolTip(numPort, "Az email küldéséhez használni kívánt SMTP portszám megadására szolgál. Alapértelmezett érték: 25");
            tt.SetToolTip(txbEmailAddress, "Megadható a levelező eredeti címétől eltérő alias email cím.");
            tt.SetToolTip(chbEnableSSL, "Az SSL használatához be kell jelölni a jelölőnégyzetet, amennyiben szüksége.");
            tt.SetToolTip(txbSmtpUserName, "Az SMTP szerveren beállított felhasználónév (email cím).");
            tt.SetToolTip(txbSmtpPassword, "Az SMTP szerveren beállított jelszó megadása.");
            tt.SetToolTip(txbSmtpPasswordAgain, "Az SMTP szerveren beállított jelszó megadása újra.");
            tt.SetToolTip(chbTestMail, "Amennyiben az email küldéshez szükséges adatok helyesen megadásra kerültek,\nakkor a jelölőnégyzet aktiválásával a \"Beállítások frissítése\" gomb megnyomásával a rendszer tesztüzenetet küld a felhasználónak.");
            tt.SetToolTip(btnUserGroups, "A gomb megnyomásával megjelenik a felhasználói csoportok kezelésére szolgáló ablak.");
            tt.SetToolTip(btnUpdateConfigurations, "A gomb megnyomásával az aktuális beállítások mentésre kerülnek.");

            btnUserGroups.Enabled = user.HasPermission("readGroup");
            cmbPwComplexity.DataSource = Enum.GetValues(typeof(PasswordComplexity)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbPwComplexity.DisplayMember = "Description";
            cmbPwComplexity.ValueMember = "value";
            try
            {
                this.conf = DBManager.GetConfiguration();
                cmbPwComplexity.SelectedIndex = (int)conf.PwComplexity;
                numPwValidityPeriod.Value = conf.PwValidityPeriod;
                numPwLength.Value = conf.PwLength;
                numFailedLoginNum.Value = conf.FailedLoginNum;
                numPermanentLockingPeriod.Value = conf.PermanentLockingPeriod;
                numRetentionDays.Value = conf.RetentionDays;
                chbEnableEmail.Checked = conf.EnableEmail;
                txbSmtpServer.Text = conf.SmtpServer;
                numPort.Value = conf.Port;
                chbEnableSSL.Checked = conf.EnableSSL;
                txbEmailAddress.Text = conf.EmailAddress;
                if (!String.IsNullOrEmpty(conf.SmtpUserName))
                {
                    txbSmtpUserName.Text = Password.Decrypt(conf.SmtpUserName);
                }
                if (!String.IsNullOrEmpty(conf.SmtpPassword))
                {
                    txbSmtpPassword.Text = txbSmtpPasswordAgain.Text = Password.Decrypt(conf.SmtpPassword);
                }
                foreach (Control item in this.Controls)
                {
                    item.Enabled = user.HasPermission("updateConfig");
                }
                if (user.HasPermission("updateConfig"))
                {
                    ChbEnableEmail_CheckedChanged(null, null);
                }
                SystemLog.WriteLogEvent(user, EventType.readConfigutaion);
            }
            catch (DBException ex)
            {
                MessageBox.Show(ex.OriginalMessage + "\n\rA konfiguráció megtekintése/módosítása nem lehetséges!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Component events
        private void ChbEnableEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbEnableEmail.Checked)
            {
                chbTestMail.Checked = false;
            }
            chbTestMail.Checked = grbEmail.Enabled = chbEnableEmail.Checked;
        }
        private void BtnUserGroups_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGroupManager frm = new FrmGroupManager(user);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnUpdateConfigurations_Click(object sender, EventArgs e)
        {
            if (conf != null)
            {
                try
                {
                    if (user.HasPermission("updateConfig"))
                    {
                        conf.PwValidityPeriod = (short)numPwValidityPeriod.Value;
                        conf.PwLength = (byte)numPwLength.Value;
                        conf.PwComplexity = (PasswordComplexity)cmbPwComplexity.SelectedIndex;
                        conf.FailedLoginNum = (byte)numFailedLoginNum.Value;
                        conf.PermanentLockingPeriod = (byte)numPermanentLockingPeriod.Value;
                        conf.RetentionDays = (short)numRetentionDays.Value;
                        conf.EnableEmail = chbEnableEmail.Checked;
                        conf.SmtpServer = txbSmtpServer.Text.Trim();
                        conf.Port = (int)numPort.Value;
                        conf.EnableSSL = chbEnableSSL.Checked;
                        conf.EmailAddress = txbEmailAddress.Text.Trim();
                        if (conf.EnableEmail)
                        {
                            if (!String.IsNullOrEmpty(txbSmtpUserName.Text.Trim()) && !String.IsNullOrEmpty(txbSmtpPassword.Text.Trim()))
                            {
                                if (txbSmtpPassword.Text.Trim() == txbSmtpPasswordAgain.Text.Trim())
                                {
                                    conf.SmtpUserName = txbSmtpUserName.Text.Trim();
                                    conf.SmtpPassword = txbSmtpPassword.Text.Trim();
                                    DBManager.UpdateConfiguration(conf);
                                    bool testMailFaild = false;
                                    if (chbTestMail.Checked)
                                    {
                                        try
                                        {
                                            EmailSender.SendEmail("Teszt email!", "<p>Ezt az üzenetet az <i>\"Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer\"</i> küldte a beállítások tesztelése céljából.</p>", user);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Sikertelen teszt email küldés!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            testMailFaild = true;
                                        }
                                    }
                                    if (MessageBox.Show(!testMailFaild ? "Az email beállítások ellenőrzése céljából a rendszer tesztüzenetet küldött az Ön email címére. Kérem, ellenőrizze!" : "A beállításokat sikeresen módosította!", "Sikeres módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Az SMTP jelszó és jelszó újra mező értéke nem egyezik meg!", "Módosítás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email küldés engedélyezése esetén a felhasználónév és jelszó megadása kötelező!", "Módosítás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            DBManager.UpdateConfiguration(conf);
                            SystemLog.WriteLogEvent(user, EventType.updateConfiguration);
                            if (MessageBox.Show("A beállításokat sikeresen módosította!", "Sikeres módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nincs jogosultsága a beállítások módosítására!", "Hiányzó jogosultság", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Figyelmeztetés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        #endregion
    }
}
