using Client.GuiController;
using Common.Domain;

namespace Client
{
    public partial class FrmLekarCRUD : Form
    {
        public Lekar? Lekar { get; set; }

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

            List<Sertifikat> sertifikati = Controller.Instance.Sertifikati.Pretrazi().Cast<Sertifikat>().ToList();

            sertifikati.Insert(0, new Sertifikat { Id = -1, Opis = "-- Bez izbora --" });

            cbSertifikati.DataSource = sertifikati;
            cbSertifikati.ValueMember = "Id";
            cbSertifikati.DisplayMember = "Prikaz";
            cbSertifikati.SelectedIndex = 0;

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
            lbSertifikati.DataSource = lekar.Sertifikati;

            btnObrisi.Enabled = true;
        }

        internal bool Validation()
        {
            tbIme.BackColor = Color.White;
            tbPrezime.BackColor = Color.White;
            tbEmail.BackColor = Color.White;
            tbSifra.BackColor = Color.White;

            bool isValid = true;

            if (string.IsNullOrEmpty(tbIme.Text))
            {
                tbIme.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            if (string.IsNullOrEmpty(tbPrezime.Text))
            {
                tbPrezime.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

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
