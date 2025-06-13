using Client.GuiController;
using Common.Domain;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class FrmZdravstveniKartonCRUD : Form
    {
        public ZdravstveniKarton? ZdravstveniKarton { get; set; }

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

            List<Dijagnoza> dijagnoze = Controller.Instance.Dijagnoze.Pretrazi().Cast<Dijagnoza>().ToList();

            dijagnoze.Insert(0, new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" });

            cbDijagnoze.DataSource = dijagnoze;
            cbDijagnoze.ValueMember = "Id";
            cbDijagnoze.DisplayMember = "Prikaz";
            cbDijagnoze.SelectedIndex = 0;

            List<Lekar> lekari = Controller.Instance.Lekari.Pretrazi().Cast<Lekar>().ToList();

            lekari.Insert(0, new Lekar { Id = -1, Ime = "-- Bez izbora --" });

            cbLekari.DataSource = lekari;
            cbLekari.ValueMember = "Id";
            cbLekari.DisplayMember = "Prikaz";
            cbLekari.SelectedIndex = 0;

            List<Pacijent> pacijenti = Controller.Instance.Pacijenti.Pretrazi().Cast<Pacijent>().ToList();

            pacijenti.Insert(0, new Pacijent { Id = -1, Ime = "-- Bez izbora --" });

            cbPacijenti.DataSource = pacijenti;
            cbPacijenti.ValueMember = "Id";
            cbPacijenti.DisplayMember = "Prikaz";
            cbPacijenti.SelectedIndex = 0;

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

        internal bool Validation()
        {
            cbLekari.BackColor = Color.White;
            cbPacijenti.BackColor = Color.White;
            tbNapomena.BackColor = Color.White;

            bool isValid = true;

            if (cbLekari.SelectedIndex == 0)
            {
                cbLekari.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            if (cbPacijenti.SelectedIndex == 0)
            {
                cbPacijenti.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            if (string.IsNullOrEmpty(tbNapomena.Text))
            {
                tbNapomena.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            return isValid;
        }
    }
}
