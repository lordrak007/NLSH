using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace NoLockScreenHelper2
{
    public partial class NetworkEditorForm : Form
    {
        // pouzivam ip control https://code.google.com/archive/p/ipaddresscontrollib/downloads

        List<NetInfo> netinfos = new List<NetInfo>();
        List<ComboBoxItem> comboItems = new List<ComboBoxItem>();
        public NetworkEditorForm(Mode mod)
        {
            InitializeComponent();
            UpdateUI();

            if (mod == Mode.New)
            {
                // nacist data
                netinfos = Tools.GetNetworks();
                //netinfos.OrderBy(n => n.Gateway);
                var nigw = netinfos.FirstOrDefault(ni => ni.Gateway != null);
                
                foreach (NetInfo ni in netinfos)
                {
                    comboItems.Add(new ComboBoxItem(netinfos.IndexOf(ni), ni.ToString()));
                }
                comboBoxChooseNet.DataSource = comboItems;
                comboBoxChooseNet.SelectedIndex = 0;

                if (nigw != null)
                {
                    comboBoxChooseNet.SelectedIndex = netinfos.IndexOf(nigw);
                    fillNet(nigw.NetworkName, nigw.Gateway, nigw.IPAddress);
                }
                comboBoxChooseNet.SelectedIndexChanged += ComboBoxChooseNet_SelectedIndexChanged;
            }
            else if (mod == Mode.Edit)
            {
                comboBoxChooseNet.Visible = false;
                labelChooseNetLabel.Visible = false;
            }
        }

        internal void UpdateUI()
        {
            Text = Resources.Lng.NetEditFrmFormName;
            labelChooseNetLabel.Text = Resources.Lng.NetEditFrmLabelChooseNet;
            comboBoxChooseNet.Text = Resources.Lng.NetEditFrmComboBoxChooseNet;
            buttonOk.Text = Resources.Lng.NetEditFrmButtonOk;
            buttonCancel.Text = Resources.Lng.NetEditFrmButtonCancel;
            labelName.Text = Resources.Lng.NetEditFrmLabelName;
            labelNetworkName.Text = Resources.Lng.NetEditFrmLabelNetworkName;
            labelGateway.Text = Resources.Lng.NetEditFrmLabelGateway;
            labelIPAddress.Text = Resources.Lng.NetEditFrmLabelIPAddress;
        }

        private void ComboBoxChooseNet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            var ni = netinfos[cb.SelectedIndex];
            fillNet(ni.NetworkName, ni.Gateway, ni.IPAddress);
        }

        public enum Mode
        {
            New,
            Edit
        }

        public Network Network
        {
            get
            {
                return composeNet();
            }
            set
            {
                fillNet(value);
            }
        }

        private void fillNet(Network net)
        {
            textBoxName.Text = net.Name;
            textBoxNetworkName.Text = net.NetworkName;
            ipAddressControlGateway.IPAddress = net.Gateway;
            ipAddressControlIPAddress.IPAddress = net.IPAddress;
        }

        private void fillNet(string NetworkName, IPAddress Gateway, IPAddress IPAddress)
        {
            textBoxNetworkName.Text = NetworkName;
            ipAddressControlGateway.IPAddress = Gateway;
            ipAddressControlIPAddress.IPAddress = IPAddress;
        }

        private Network composeNet()
        {
            var net = new Network
            {
                Name = textBoxName.Text,
                NetworkName = textBoxNetworkName.Text,
                Gateway = ipAddressControlGateway.IPAddress.Equals(IPAddress.Parse("0.0.0.0")) ? null : ipAddressControlGateway.IPAddress,
                IPAddress = ipAddressControlIPAddress.IPAddress.Equals(IPAddress.Parse("0.0.0.0")) ? null : ipAddressControlIPAddress.IPAddress
            };
            return net;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
