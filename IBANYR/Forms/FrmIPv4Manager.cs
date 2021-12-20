using System;
using System.Net;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmIPv4Manager : Form
    {
        #region Private fields
        IPv4Address ipConfiguration;
        #endregion
        #region Public properties
        internal IPv4Address IpConfiguration { get => ipConfiguration; set => ipConfiguration = value; }
        #endregion
        #region Constructors
        public FrmIPv4Manager()
        {
            InitializeComponent();
            ipConfiguration = null;
        }
        internal FrmIPv4Manager(IPv4Address ipConfiguration) : this()
        {
            IpConfiguration = ipConfiguration;
            txbIPv4.Text = IpConfiguration.Ipv4String;
            txbSubnetMask.Text = IpConfiguration.SubnetMaskString;
        }
        #endregion
        #region Component events
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (IpConfiguration == null)
            {
                try
                {
                    IpConfiguration = new IPv4Address(txbIPv4.Text.Trim(), txbSubnetMask.Text.Trim());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Figyelmeztetés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                try
                {
                    IPAddress ip, subnetMask;
                    if (IPAddress.TryParse(txbIPv4.Text, out ip))
                    {
                        IpConfiguration.Ipv4 = ip;
                    }
                    else
                    {
                        MessageBox.Show("Nem megfelelő formátum IP cím!", "Figyelmeztetés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                    }
                    if (IPAddress.TryParse(txbSubnetMask.Text, out subnetMask))
                    {
                        IpConfiguration.SubnetMask = subnetMask;
                    }
                    else
                    {
                        MessageBox.Show("Nem megfelelő formátum alhálózati maszk!", "Figyelmeztetés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }
        }
        #endregion
    }
}
