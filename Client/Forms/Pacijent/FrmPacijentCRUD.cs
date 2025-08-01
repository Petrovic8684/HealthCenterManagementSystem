using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmPacijentCRUD : Form, ICrudForm<Pacijent>
    {
        internal Pacijent? Pacijent { get; set; }

        public FrmPacijentCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) => Controller.Instance.Pacijenti.Save();
            btnObrisi.Click += (s, e) => Controller.Instance.Pacijenti.Delete();
            btnOdustani.Click += (s, e) =>
            {
                if (Pacijent == null) Controller.Instance.Pacijenti.Delete();
                else FormManager.Instance.Close<FrmPacijentCRUD>();
            };

            ControlInitialisator.Instance.InitComboBox(
                cbMesta,
                Controller.Instance.Mesta.FetchListAll(false).Cast<Mesto>(),
                "Id",
                "DisplayValue",
                new Mesto { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }

        public void ShowDetails(Pacijent pacijent)
        {
            Pacijent = pacijent;

            lblPacijentId.Text = "Pacijent ID: " + pacijent.Id.ToString();

            tbIme.Text = pacijent.Ime;
            tbPrezime.Text = pacijent.Prezime;
            tbEmail.Text = pacijent.Email;

            cbMesta.SelectedValue = pacijent.Mesto.Id;

            btnObrisi.Enabled = true;
        }

        public bool Validation()
        {
            bool validTextFields = FormValidator.Instance.ValidateTextFields(tbIme, tbPrezime, tbEmail);
            bool validComboBoxes = FormValidator.Instance.ValidateComboBoxes(cbMesta);

            if (!validTextFields || !validComboBoxes)
                return false;

            FormValidator.Instance.ValidateWithRulesOrThrow(
                (tbEmail, FormValidator.Instance.IsValidEmail, "Email mora biti u validnom formatu (example@gmail.com).")
            );

            return true;
        }
    }
}
