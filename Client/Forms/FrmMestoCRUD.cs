using Client.GuiController;
using Common.Domain;

namespace Client
{
    public partial class FrmMestoCRUD : Form
    {
        public Mesto? Mesto { get; set; }

        public FrmMestoCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) =>
            {
                if (Mesto == null)
                    Controller.Instance.Mesta.Kreiraj();
                else
                    Controller.Instance.Mesta.Promeni();
            };

            btnObrisi.Click += (s, e) => Controller.Instance.Mesta.Obrisi();
            btnOdustani.Click += (s, e) => FormManager.Instance.Close<FrmMestoCRUD>();
        }

        public void PrikaziDetalje(Mesto mesto)
        {
            Mesto = mesto;

            lblMestoId.Text = "Mesto ID: " + mesto.Id.ToString();
            tbNaziv.Text = mesto.Naziv;
            tbPostanskiBroj.Text = mesto.PostanskiBroj;

            btnObrisi.Enabled = true;
        }

        internal bool Validation()
        {
            tbNaziv.BackColor = Color.White;
            tbPostanskiBroj.BackColor = Color.White;

            bool isValid = true;

            if (string.IsNullOrEmpty(tbNaziv.Text))
            {
                tbNaziv.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            if(string.IsNullOrEmpty(tbPostanskiBroj.Text))
            {
                tbPostanskiBroj.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            return isValid;
        }
    }
}
