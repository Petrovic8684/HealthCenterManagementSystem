using Client.Forms;
using Client.GuiController;

namespace Client
{
    internal partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnPrijava.Click += (s, e) => Controller.Instance.Lekari.Prijavi();
            podešavanjaSoftverskogSistemaToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmPodesavanja>();
            oProgramuToolStripMenuItem.Click += (s,e) => FormManager.Instance.Open<FrmOProgramu>();
        }

        public bool Validation()
        {
            bool validText = FormValidator.ValidateTextFields(tbEmail, tbSifra);
            return validText;
        }
    }
}
