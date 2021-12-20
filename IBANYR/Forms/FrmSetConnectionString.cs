using System;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmSetConnectionString : Form
    {
        #region Private fields
        string connectionString;
        #endregion
        #region Public properties
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        #endregion
        #region Constructors
        public FrmSetConnectionString()
        {
            InitializeComponent();
        }
        #endregion
        #region Component events
        private void FrmSetConnectionString_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel && MessageBox.Show("Az adatbázis szerver kapcsolatának beállítása nélkül a program nem fog működni!\n\rBiztosan kilép a beállításból?", "Kilépés...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion
        #region Methods and functions
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txbDBUserName.Text.Trim()) && !String.IsNullOrEmpty(txbDBName.Text.Trim()) && !String.IsNullOrEmpty(txbDBServer.Text.Trim()) && !String.IsNullOrEmpty(txbDBPassword.Text.Trim()) && !String.IsNullOrEmpty(txbDBPasswordAgain.Text.Trim()))
            {
                if (txbDBPassword.Text.Trim() == txbDBPasswordAgain.Text.Trim())
                {
                    ConnectionString = $"Data Source={txbDBServer.Text.Trim()},{numPort.Value};Initial Catalog={txbDBName.Text.Trim()};User ID={txbDBUserName.Text.Trim()};Password={txbDBPassword.Text.Trim()}";
                }
                else
                {
                    MessageBox.Show("A jelszó és jelszó újra mező értéke nem egyezik meg!", "Adatbáziskapcsolat beállítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Valamennyi mező kitöltése kötelező!", "Adatbáziskapcsolat beállítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
