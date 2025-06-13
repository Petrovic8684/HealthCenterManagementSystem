using Client.GuiController;
using Common.Domain;

namespace Client
{
    public partial class FrmDijagnozaCRUD : Form
    {
        public Dijagnoza? Dijagnoza { get; set; }

        public FrmDijagnozaCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) =>
            {
                if (Dijagnoza == null)
                    Controller.Instance.Dijagnoze.Kreiraj();
                else
                    Controller.Instance.Dijagnoze.Promeni();
            };

            btnObrisi.Click += (s, e) => Controller.Instance.Dijagnoze.Obrisi();
            btnOdustani.Click += (s, e) => FormManager.Instance.Close<FrmDijagnozaCRUD>();
        }

        public void PrikaziDetalje(Dijagnoza dijagnoza)
        {
            Dijagnoza = dijagnoza;

            lblDijagnozaId.Text = "Dijagnoza ID: " + dijagnoza.Id.ToString();
            tbNaziv.Text = dijagnoza.Naziv;
            tbOpis.Text = dijagnoza.Opis;
            tbBazniSkor.Text = dijagnoza.BazniSkor.ToString();

            btnObrisi.Enabled = true;
        }

        internal bool Validation()
        {
            tbNaziv.BackColor = Color.White;
            tbOpis.BackColor = Color.White;
            tbBazniSkor.BackColor = Color.White;

            bool isValid = true;

            if (string.IsNullOrEmpty(tbNaziv.Text))
            {
                tbNaziv.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            if (string.IsNullOrEmpty(tbOpis.Text))
            {
                tbOpis.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            if (string.IsNullOrEmpty(tbBazniSkor.Text))
            {
                tbBazniSkor.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            return isValid;
        }
    }
}
