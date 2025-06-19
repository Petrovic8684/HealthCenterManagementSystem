using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmMestoCRUD : Form, ICrudForm<Mesto>
    {
        internal Mesto? Mesto { get; set; }

        public FrmMestoCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) => Controller.Instance.Mesta.Save();
            btnObrisi.Click += (s, e) => Controller.Instance.Mesta.Delete();
            btnOdustani.Click += (s, e) =>
            {
                if (Mesto == null) Controller.Instance.Mesta.Delete();
                else FormManager.Instance.Close<FrmMestoCRUD>();
            };
        }

        public void ShowDetails(Mesto mesto)
        {
            Mesto = mesto;

            lblMestoId.Text = "Mesto ID: " + mesto.Id.ToString();
            tbNaziv.Text = mesto.Naziv;
            tbPostanskiBroj.Text = mesto.PostanskiBroj;

            btnObrisi.Enabled = true;
        }

        public bool Validation()
        {
            bool basicValid = FormValidator.Instance.ValidateTextFields(tbNaziv, tbPostanskiBroj);

            if (!basicValid)
                return false;

            FormValidator.Instance.ValidateWithRulesOrThrow(
                (tbPostanskiBroj, text => FormValidator.Instance.IsExactLength(text, 5), "Poštanski broj mora imati tačno 5 karaktera.")
            );

            return true;
        }
    }
}
