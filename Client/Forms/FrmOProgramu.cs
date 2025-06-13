using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmOProgramu : Form
    {
        public FrmOProgramu()
        {
            InitializeComponent();
            linkLblUndraw.Links.Add(0, linkLblUndraw.Text.Length, "https://undraw.co/");
        }

        private void linkLblUndraw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string url = e.Link.LinkData as string;
                if (!string.IsNullOrEmpty(url))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri otvaranju linka.", "Greška");
            }
        }
    }
}
