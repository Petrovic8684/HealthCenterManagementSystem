using Client.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Client.Forms
{
    public partial class FrmPodesavanja : Form
    {
        public FrmPodesavanja()
        {
            InitializeComponent();

            tbIpAdresa.Text = ConfigManager.ServerIP;
            tbBrojPorta.Text = ConfigManager.ServerPort.ToString();

            btnPoveziSe.Click += (s, e) => PoveziSe();
        }

        private void PoveziSe()
        {
            if (!int.TryParse(tbBrojPorta.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Broj porta mora biti broj između 1 i 65535.");
                return;
            }

            if (!IPAddress.TryParse(tbIpAdresa.Text, out IPAddress ip))
            {
                MessageBox.Show("IP adresa nije validna.");
                return;
            }

            Communication.Instance.Disconnect();
            Communication.Instance.Connect(ip.ToString(), port);
        }
    }
}
