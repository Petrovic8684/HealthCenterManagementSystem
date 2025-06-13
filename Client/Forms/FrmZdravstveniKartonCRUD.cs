using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmZdravstveniKartonCRUD : Form, ICrudForm<ZdravstveniKarton>
    {
        internal ZdravstveniKarton? ZdravstveniKarton { get; set; }

        public FrmZdravstveniKartonCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) =>
            {
                if (ZdravstveniKarton == null)
                    Controller.Instance.ZdravstveniKartoni.Kreiraj();
                else
                    Controller.Instance.ZdravstveniKartoni.Promeni();
            };

            btnOdustani.Click += (s, e) => FormManager.Instance.Close<FrmZdravstveniKartonCRUD>();

            ControlInitialisator.InitComboBox(
                cbDijagnoze,
                Controller.Instance.Dijagnoze.Pretrazi().Cast<Dijagnoza>(),
                "Id",
                "Prikaz",
                new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" }
            );

            ControlInitialisator.InitComboBox(
                cbLekari,
                Controller.Instance.Lekari.Pretrazi().Cast<Lekar>(),
                "Id",
                "Prikaz",
                new Lekar { Id = -1, Ime = "-- Bez izbora --" }
            );

            ControlInitialisator.InitComboBox(
                cbPacijenti,
                Controller.Instance.Pacijenti.Pretrazi().Cast<Pacijent>(),
                "Id",
                "Prikaz",
                new Pacijent { Id = -1, Ime = "-- Bez izbora --" }
            );


            btnPlus.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.DodajStavku();
            btnMinus.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.OduzmiStavku();
        }

        public void PrikaziDetalje(ZdravstveniKarton zdravstveniKarton)
        {
            ZdravstveniKarton = zdravstveniKarton;

            lblZdravstveniKartonId.Text = "Zdravstveni karton ID: " + zdravstveniKarton.Id.ToString();

            cbLekari.SelectedValue = zdravstveniKarton.Lekar.Id;
            cbPacijenti.SelectedValue = zdravstveniKarton.Pacijent.Id;
            tbNapomena.Text = zdravstveniKarton.Napomena;

            lbStavke.DataSource = zdravstveniKarton.Stavke;
        }

        public bool Validation()
        {
            bool validText = FormValidator.ValidateTextFields(tbNapomena);
            bool validCombos = FormValidator.ValidateComboBoxes(cbLekari, cbPacijenti);
            return validText && validCombos;
        }
    }
}
