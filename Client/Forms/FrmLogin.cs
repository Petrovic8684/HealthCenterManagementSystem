using Client.Forms;
using Client.GuiController;

namespace Client
{
    internal partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnPrijava.Click += (s, e) => Controller.Instance.Lekari.Login();
            podešavanjaSoftverskogSistemaToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmPodesavanja>();
            oProgramuToolStripMenuItem.Click += (s,e) => FormManager.Instance.Open<FrmOProgramu>();
        }

        internal bool Validation() => FormValidator.Instance.ValidateTextFields(tbKorisnickoIme, tbSifra);
    }
}
