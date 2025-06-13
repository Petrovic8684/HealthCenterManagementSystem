using Client.GuiController;
using Common.Domain;

namespace Client
{
    public partial class FrmPacijentCRUD : Form
    {
        public Pacijent? Pacijent { get; set; }

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

            List<Mesto> mesta = Controller.Instance.Mesta.Pretrazi().Cast<Mesto>().ToList();

            mesta.Insert(0, new Mesto { Id = -1, Naziv = "-- Bez izbora --" });

            cbMesta.DataSource = mesta;
            cbMesta.ValueMember = "Id";
            cbMesta.DisplayMember = "Prikaz";
            cbMesta.SelectedIndex = 0;
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

        internal bool Validation()
        {
            tbIme.BackColor = Color.White;
            tbPrezime.BackColor = Color.White;
            tbEmail.BackColor = Color.White;
            cbMesta.BackColor = Color.White;

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

            if (cbMesta.SelectedIndex == 0)
            {
                cbMesta.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            return isValid;
        }
    }
}
