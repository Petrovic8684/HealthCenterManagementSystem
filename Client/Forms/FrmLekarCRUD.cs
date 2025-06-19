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

            btnZapamti.Click += (s, e) => Controller.Instance.Lekari.Save();
            btnObrisi.Click += (s, e) => Controller.Instance.Lekari.Delete();
            btnOdustani.Click += (s, e) =>
            {
                if (Lekar == null) Controller.Instance.Lekari.Delete();
                else FormManager.Instance.Close<FrmLekarCRUD>();
            };

            ControlInitialisator.Instance.InitComboBox(
                cbSertifikati,
                Controller.Instance.Sertifikati.FetchListAll(false).Cast<Sertifikat>(),
                "Id",
                "DisplayValue",
                new Sertifikat { Id = -1, Opis = "-- Bez izbora --" }
            );

            btnPlus.Click += (s, e) => Controller.Instance.Lekari.AddSertifikat();
            btnMinus.Click += (s, e) => Controller.Instance.Lekari.RemoveSertifikat();
        }

        public void ShowDetails(Lekar lekar)
        {
            Lekar = lekar;

            lblLekarId.Text = "Lekar ID: " + lekar.Id.ToString();

            tbIme.Text = lekar.Ime;
            tbPrezime.Text = lekar.Prezime;
            tbEmail.Text = lekar.Email;
            tbSifra.Text = "";
            tbKorisnickoIme.Text = lekar.KorisnickoIme;
            lbSertifikati.DataSource = lekar.Sertifikati;

            btnObrisi.Enabled = true;
        }

        public bool Validation()
        {
            bool basicValid = FormValidator.Instance.ValidateTextFields(tbIme, tbPrezime);

            if (!basicValid)
                return false;

            FormValidator.Instance.ValidateWithRulesOrThrow(
                (tbEmail, FormValidator.Instance.IsValidEmail, "Email mora biti u validnom formatu (example@gmail.com)."),
                (tbSifra, text => FormValidator.Instance.HasMinLength(text, 6), "Šifra mora imati najmanje 6 karaktera.")
            );

            return true;
        }
    }
}
