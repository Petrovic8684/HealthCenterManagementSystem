using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmLekarCRUD : Form, ICrudForm<Lekar>
    {
        internal Lekar? Lekar { get; set; }

        public FrmLekarCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) =>
            {
                if (Lekar == null)
                    Controller.Instance.Lekari.Kreiraj();
                else
                    Controller.Instance.Lekari.Promeni();
            };

            btnObrisi.Click += (s, e) => Controller.Instance.Lekari.Obrisi();
            btnOdustani.Click += (s, e) => FormManager.Instance.Close<FrmLekarCRUD>();

            ControlInitialisator.InitComboBox(
                cbSertifikati,
                Controller.Instance.Sertifikati.VratiListuSvi().Cast<Sertifikat>(),
                "Id",
                "Prikaz",
                new Sertifikat { Id = -1, Opis = "-- Bez izbora --" }
            );

            btnPlus.Click += (s, e) => Controller.Instance.Lekari.DodajSertifikat();
            btnMinus.Click += (s, e) => Controller.Instance.Lekari.OduzmiSertifikat();
        }

        public void PrikaziDetalje(Lekar lekar)
        {
            Lekar = lekar;

            lblLekarId.Text = "Lekar ID: " + lekar.Id.ToString();

            tbIme.Text = lekar.Ime;
            tbPrezime.Text = lekar.Prezime;
            tbEmail.Text = lekar.Email;
            tbSifra.Text = lekar.Sifra;
            tbKorisnickoIme.Text = lekar.KorisnickoIme;
            lbSertifikati.DataSource = lekar.Sertifikati;

            btnObrisi.Enabled = true;
        }

        public bool Validation()
        {
            return FormValidator.ValidateTextFields(tbIme, tbPrezime, tbEmail, tbSifra);
        }
    }
}
