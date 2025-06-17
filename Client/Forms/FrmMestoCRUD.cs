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

            btnZapamti.Click += (s, e) => Controller.Instance.Mesta.Zapamti();
            btnObrisi.Click += (s, e) => Controller.Instance.Mesta.Obrisi();
            btnOdustani.Click += (s, e) =>
            {
                if (Mesto == null) Controller.Instance.Mesta.Obrisi();
                else FormManager.Instance.Close<FrmMestoCRUD>();
            };
        }

        public void PrikaziDetalje(Mesto mesto)
        {
            Mesto = mesto;

            lblMestoId.Text = "Mesto ID: " + mesto.Id.ToString();
            tbNaziv.Text = mesto.Naziv;
            tbPostanskiBroj.Text = mesto.PostanskiBroj;

            btnObrisi.Enabled = true;
        }

        public bool Validation()
        {
            return FormValidator.ValidateTextFields(tbNaziv, tbPostanskiBroj);
        }
    }
}
