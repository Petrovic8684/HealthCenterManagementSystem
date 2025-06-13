using Client.GuiController;
using Common.Domain;

namespace Client
{
    public partial class FrmSertifikatCRUD : Form
    {
        public Sertifikat? Sertifikat { get; set; }

        public FrmSertifikatCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) =>
            {
                if (Sertifikat == null)
                    Controller.Instance.Sertifikati.Kreiraj();
                else
                    Controller.Instance.Sertifikati.Promeni();
            };

            btnObrisi.Click += (s, e) => Controller.Instance.Sertifikati.Obrisi();
            btnOdustani.Click += (s, e) => FormManager.Instance.Close<FrmSertifikatCRUD>();
        }

        public void PrikaziDetalje(Sertifikat sertifikat)
        {
            Sertifikat = sertifikat;

            lblSertifikatId.Text = "Sertifikat ID: " + sertifikat.Id.ToString();
            tbOpis.Text = sertifikat.Opis;

            btnObrisi.Enabled = true;
        }

        internal bool Validation()
        {
            tbOpis.BackColor = Color.White;

            bool isValid = true;

            if (string.IsNullOrEmpty(tbOpis.Text))
            {
                tbOpis.BackColor = Color.FromArgb(255, 220, 220);
                isValid = false;
            }

            return isValid;
        }
    }
}
