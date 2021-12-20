using System;
using System.Drawing;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmMain : Form
    {
        #region Private fields
        User user;
        ToolTip tt;
        UserControl mainPanel;
        int btnYLocationValue = 62;
        #endregion
        #region Constructors
        internal FrmMain(User user)
        {
            this.user = user;
            InitializeComponent();
            mainPanel = null;
            tt = new ToolTip();
            tt.SetToolTip(btnClose, "Kilépés a programból");
            tt.SetToolTip(btnPassword, "Jelszó módosítása");
            tt.SetToolTip(btnStartPage, "Kezdőlap megnyitása");
            tt.SetToolTip(btnConfiguration,"Beállítások szerkesztése");
            tt.SetToolTip(btnAbout, "Program névjegye");
            tt.SetToolTip(btnUsers, "Felhasználók kezelése");
            tt.SetToolTip(btnDepartments, "Szervezeti egységek kezelése");
            tt.SetToolTip(btnLogs, "Rendszernapló");
            tt.SetToolTip(btnHardwares, "Hardver leltár");
            tt.SetToolTip(btnSystems, "Rendszerek kezelése");
            tt.SetToolTip(btnSoftwares, "Szoftver leltár");
            tt.SetToolTip(btnMaintenance, "Karbantartási napló");
            lblUser.Text = user.UName;
            lblUser.Left = this.Width - 230 - lblUser.Width;
            btnPassword.Left = lblUser.Left - 45;
            btnAbout.Left = btnPassword.Left - 45;
            btnConfiguration.Left = btnAbout.Left - 45;
            btnConfiguration.Enabled = btnConfiguration.Visible = user.HasPermission("readConfig");
            MainButtonDisplay(btnSystems, "readItSystem");
            MainButtonDisplay(btnHardwares, "readHardware");
            MainButtonDisplay(btnSoftwares, "readSoftware");
            MainButtonDisplay(btnMaintenance, "readMaintenanceLog");
            MainButtonDisplay(btnUsers, "readUser");
            MainButtonDisplay(btnDepartments, "readDepartment");
            MainButtonDisplay(btnLogs, "readLog");
            tsiStartPage.Click += ToolStripItem_Click;
            tsiClose.Click += BtnClose_Click;
            MainButton_Click(btnStartPage, null);
        }
        #endregion
        #region Form events
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (user != null && MessageBox.Show("Valóban ki szeretne lépni a programból?", "Kilépés...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    SystemLog.WriteLogEvent(user, EventType.logout);
                    DBManager.CloseConnection();
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
        }
        #endregion
        #region Component events
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnPassword_Click(object sender, EventArgs e)
        {
            try
            {
                FrmChangePassword frm = new FrmChangePassword(user);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Jelszó módosítása sikeres!", "Jelszómódosítás...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SystemLog.WriteLogEvent(user, EventType.ownPasswordChange);
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
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            FrmAboutBox frm = new FrmAboutBox();
            frm.ShowDialog();
        }
        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                FrmConfiguration frm = new FrmConfiguration(user);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ToolStripItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem tsi)
            {
                this.Show();
                notifyIcon.Visible = false;
                WindowState = FormWindowState.Normal;
                Control btn = Controls.Find($"btn{tsi.Name.Substring(3)}", true)[0];
                MainButton_Click(btn, null);
            }
        }
        private void MainButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetPanelActivePosition(button);
                this.Controls.Remove(mainPanel);
                switch (button.Name)
                {
                    case "btnStartPage":
                        mainPanel = new StartPanel(user);
                        break;
                    case "btnUsers":
                        mainPanel = new UsersPanel(user);
                        break;
                    case "btnDepartments":
                        mainPanel = new DepartmentsPanel(user);
                        break;
                    case "btnLogs":
                        mainPanel = new LogsPanel(user);
                        break;
                    case "btnHardwares":
                        mainPanel = new HardwaresPanel(user);
                        break;
                    case "btnSystems":
                        mainPanel = new ItSystemsPanel(user);
                        break;
                    case "btnSoftwares":
                        mainPanel = new SoftwaresPanel(user);
                        break;
                    case "btnMaintenance":
                        mainPanel = new MaintenancePanel(user);
                        break;
                }
                mainPanel.Parent = this;
                mainPanel.Top = 40;
                mainPanel.Left = 210;
                mainPanel.Width = this.Width - 230;
                mainPanel.Height = this.Height - 85;
                mainPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                this.Controls.Add(mainPanel);
            }
        }
        private void MainButton_OnMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Font = new Font(button.Font.FontFamily, 14, FontStyle.Bold);
            }
        }
        private void MainButton_OnMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Font = new Font(button.Font.FontFamily, 12, FontStyle.Bold);
            }
        }
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }
        #endregion
        #region Own Methods and Functions
        private void SetPanelActivePosition(Button button)
        {
            panelActive.Top = button.Top;
            panelActive.Height = button.Height;
            lblTitle.Text = button.Text;
        }
        private void MainButtonDisplay(Button button, string permission)
        {
            if (user.HasPermission(permission))
            {
                button.Visible = button.Enabled = true;
                if (contextMenuStrip.Items.ContainsKey($"tsi{button.Name.Substring(3)}"))
                {
                    contextMenuStrip.Items[$"tsi{button.Name.Substring(3)}"].Enabled = contextMenuStrip.Items[$"tsi{button.Name.Substring(3)}"].Visible = true;
                    contextMenuStrip.Items[$"tsi{button.Name.Substring(3)}"].Click += ToolStripItem_Click;
                }
                button.Location = new Point(10, btnYLocationValue);
                button.Click += MainButton_Click;
                btnYLocationValue += button.Margin.Top + button.Margin.Bottom + button.Height;
                button.MouseEnter += MainButton_OnMouseEnter;
                button.MouseLeave += MainButton_OnMouseLeave;
            }
        }
        #endregion
    }
}
