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

            btnZapamti.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.Save();
            btnObrisi.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.Delete();
            btnOdustani.Click += (s, e) =>
            {
                if (ZdravstveniKarton == null) Controller.Instance.ZdravstveniKartoni.Delete();
                else FormManager.Instance.Close<FrmZdravstveniKartonCRUD>();
            };

            ControlInitialisator.Instance.InitComboBox(
                cbDijagnoze,
                Controller.Instance.Dijagnoze.FetchListAll(false).Cast<Dijagnoza>(),
                "Id",
                "DisplayValue",
                new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" }
            );

            ControlInitialisator.Instance.InitComboBox(
                cbLekari,
                Controller.Instance.Lekari.FetchListAll(false).Cast<Lekar>(),
                "Id",
                "DisplayValue",
                new Lekar { Id = -1, Ime = "-- Bez izbora --" }
            );

            ControlInitialisator.Instance.InitComboBox(
                cbPacijenti,
                Controller.Instance.Pacijenti.FetchListAll(false).Cast<Pacijent>(),
                "Id",
                "DisplayValue",
                new Pacijent { Id = -1, Ime = "-- Bez izbora --" }
            );


            btnPlus.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.AddStavka();
            btnMinus.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.RemoveStavka();
        }

        public void ShowDetails(ZdravstveniKarton zdravstveniKarton)
        {
            ZdravstveniKarton = zdravstveniKarton;

            lblZdravstveniKartonId.Text = "Zdravstveni karton ID: " + zdravstveniKarton.Id.ToString();

            cbLekari.SelectedValue = zdravstveniKarton.Lekar.Id;
            cbPacijenti.SelectedValue = zdravstveniKarton.Pacijent.Id;
            tbNapomena.Text = zdravstveniKarton.Napomena;

            lbStavke.DataSource = zdravstveniKarton.Stavke;

            btnObrisi.Enabled = true;
        }

        public bool Validation()
        {
            bool validText = FormValidator.Instance.ValidateTextFields(tbNapomena);
            bool validCombos = FormValidator.Instance.ValidateComboBoxes(cbLekari, cbPacijenti);

            return validText && validCombos;
        }
    }
}
