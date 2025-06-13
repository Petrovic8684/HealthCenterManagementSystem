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

            btnZapamti.Click += (s, e) =>
            {
                if (Pacijent == null)
                    Controller.Instance.Pacijenti.Kreiraj();
                else
                    Controller.Instance.Pacijenti.Promeni();
            };

            btnObrisi.Click += (s, e) => Controller.Instance.Pacijenti.Obrisi();
            btnOdustani.Click += (s, e) => FormManager.Instance.Close<FrmPacijentCRUD>();

            ControlInitialisator.InitComboBox(
                cbMesta,
                Controller.Instance.Mesta.Pretrazi().Cast<Mesto>(),
                "Id",
                "Prikaz",
                new Mesto { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }

        public void PrikaziDetalje(Pacijent pacijent)
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
            bool validTextFields = FormValidator.ValidateTextFields(tbIme, tbPrezime, tbEmail);
            bool validComboBoxes = FormValidator.ValidateComboBoxes(cbMesta);
            return validTextFields && validComboBoxes;
        }
    }
}
