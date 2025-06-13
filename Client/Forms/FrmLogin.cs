using Client.GuiController;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnPrijava.Click += (s, e) => Controller.Instance.Lekari.Prijavi();
            oProgramuToolStripMenuItem.Click += (s,e) => FormManager.Instance.Open<FrmOProgramu>();
        }

        internal bool Validation()
        {
            tbEmail.BackColor = Color.White;
            tbSifra.BackColor = Color.White;

            bool isValid = true;

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                tbEmail.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }
            if (string.IsNullOrEmpty(tbSifra.Text))
            {
                tbSifra.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            return isValid;
        }
    }
}
