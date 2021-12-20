using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    public partial class FrmNicManager : Form
    {
        #region Private fields
        NIC nicDevice;
        readonly ToolTip tt;
        #endregion
        #region Public properties
        internal NIC NicDevice { get => nicDevice; set => nicDevice = value; }
        #endregion
        #region Constructors
        public FrmNicManager()
        {
            InitializeComponent();
            NicDevice = null;
            tt = new ToolTip();
            tt.SetToolTip(mtbMacAddress, "A MAC cím megadása kötelező!\nÜgyeljen a megfelelő kitöltésre!");
            tt.SetToolTip(cmbNICType, "Válasszon a felkínált lehetőségek közül!");
            tt.SetToolTip(cmbIPv4Addressing, "Válasszon a felkínált lehetőségek közül!");
            tt.SetToolTip(btnAddIPv4, "IP cím hozzáadása");
            tt.SetToolTip(btnEditIPv4, "IP cím beállítás módosítása");
            tt.SetToolTip(btnDeleteIPv4, "IP cím beállítás törlése");
            cmbNICType.DataSource = Enum.GetValues(typeof(NICType));
            cmbIPv4Addressing.DataSource = Enum.GetValues(typeof(IpAddressingType)).Cast<Enum>().Select(value => new { (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value }).OrderBy(item => item.value).ToList();
            cmbIPv4Addressing.DisplayMember = "Description";
            cmbIPv4Addressing.ValueMember = "value";
        }
        internal FrmNicManager(NIC nicDevice, bool display = false) : this()
        {
            NicDevice = nicDevice;
            mtbMacAddress.Text = nicDevice.MacAddressString;
            cmbNICType.SelectedItem = nicDevice.NicType;
            mtbMacAddress.Enabled = cmbNICType.Enabled = false;
            cmbIPv4Addressing.SelectedIndex = (int)nicDevice.Ipv4Addressing;
            if (cmbIPv4Addressing.SelectedIndex == (int)IpAddressingType.staticIp)
            {
                foreach (IPv4Address item in nicDevice.Ipv4Addresses)
                {
                    lsbIPv4.Items.Add(item);
                }
            }

            if (display)
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = item == btnCancel || item is Label;
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
        private void CmbIPv4Addressing_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((IpAddressingType)cmbIPv4Addressing.SelectedIndex)
            {
                case IpAddressingType.dhcp:
                    btnAddIPv4.Enabled = btnDeleteIPv4.Enabled = btnEditIPv4.Enabled = lsbIPv4.Enabled = false;
                    break;
                case IpAddressingType.staticIp:
                    btnAddIPv4.Enabled = btnDeleteIPv4.Enabled = btnEditIPv4.Enabled = lsbIPv4.Enabled = true;
                    break;
            }
        }
        private void BtnEditIPv4_Click(object sender, EventArgs e)
        {
            if (lsbIPv4.SelectedIndex > -1)
            {
                int index = lsbIPv4.SelectedIndex;
                FrmIPv4Manager frm = new FrmIPv4Manager(lsbIPv4.SelectedItem as IPv4Address);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool contains = false;
                    for (int i = 0; i < lsbIPv4.Items.Count; i++)
                    {
                        if (i != index && (lsbIPv4.Items[i] as IPv4Address).Equals(frm.IpConfiguration))
                        {
                            contains = true;
                        }
                    }
                    if (!contains)
                    {
                        lsbIPv4.Items[index] = frm.IpConfiguration;
                    }
                    else
                    {
                        MessageBox.Show("Módosítás nem lehetséges, mivel ilyen IP cím már rögzítve van ehhez a hálózati adapterhez!", "IP cím módosítása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva módosítandó IP cím beállítás!", "IP cím beállítás módosítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnAddIPv4_Click(object sender, EventArgs e)
        {
            FrmIPv4Manager frm = new FrmIPv4Manager();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (lsbIPv4.Items.Count == 0 || !lsbIPv4.Items.Contains(frm.IpConfiguration))
                {
                    lsbIPv4.Items.Add(frm.IpConfiguration);
                }
                else
                {
                    MessageBox.Show("Ez az IP cím már rögzítve van ehhez a hálózati adapterhez!", "IP cím hozzáadása...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void BtnDeleteIPv4_Click(object sender, EventArgs e)
        {
            if (lsbIPv4.SelectedIndex > -1)
            {
                if (MessageBox.Show("Biztosan törli a kijelölt IP címet?", "IP cím törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    lsbIPv4.Items.RemoveAt(lsbIPv4.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva törlendő IP cím!", "IP cím törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (NicDevice == null)
                {
                    NicDevice = new NIC(mtbMacAddress.Text, (NICType)cmbNICType.SelectedIndex, (IpAddressingType)cmbIPv4Addressing.SelectedIndex);
                    if (cmbIPv4Addressing.SelectedIndex == (int)IpAddressingType.staticIp)
                    {
                        foreach (IPv4Address item in lsbIPv4.Items)
                        {
                            NicDevice.AddIpv4(item);
                        }
                    }
                }
                else
                {
                    NicDevice.Ipv4Addressing = (IpAddressingType)cmbIPv4Addressing.SelectedIndex;
                    NicDevice.ClearIpv4();
                    if (cmbIPv4Addressing.SelectedIndex == (int)IpAddressingType.staticIp)
                    {
                        foreach (IPv4Address item in lsbIPv4.Items)
                        {
                            NicDevice.AddIpv4(item);
                        }
                    }
                }
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
        #endregion
        #region Methods and Functions
        #endregion
    }
}
