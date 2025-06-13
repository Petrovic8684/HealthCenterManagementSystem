using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmSertifikatCRUD : Form, ICrudForm<Sertifikat>
    {
        internal Sertifikat? Sertifikat { get; set; }

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

        public bool Validation()
        {
            return FormValidator.ValidateTextFields(tbOpis);
        }
    }
}
