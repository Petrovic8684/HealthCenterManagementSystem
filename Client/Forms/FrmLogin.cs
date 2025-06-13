using Client.Forms;
using Client.GuiController;

namespace Client
{
    internal partial class FrmLogin : Form, IForm
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnPrijava.Click += (s, e) => Controller.Instance.Lekari.Prijavi();
            oProgramuToolStripMenuItem.Click += (s,e) => FormManager.Instance.Open<FrmOProgramu>();
        }

        public bool Validation()
        {
            bool validText = FormValidator.ValidateTextFields(tbEmail, tbSifra);
            return validText;
        }

        public string ConstructCriteria() { throw new NotImplementedException(); }
    }
}
