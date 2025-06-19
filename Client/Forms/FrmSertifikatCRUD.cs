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

            btnZapamti.Click += (s, e) => Controller.Instance.Sertifikati.Save();
            btnObrisi.Click += (s, e) => Controller.Instance.Sertifikati.Delete();
            btnOdustani.Click += (s, e) =>
            {
                if (Sertifikat == null) Controller.Instance.Sertifikati.Delete();
                else FormManager.Instance.Close<FrmSertifikatCRUD>();
            };
        }

        public void ShowDetails(Sertifikat sertifikat)
        {
            Sertifikat = sertifikat;

            lblSertifikatId.Text = "Sertifikat ID: " + sertifikat.Id.ToString();
            tbOpis.Text = sertifikat.Opis;

            btnObrisi.Enabled = true;
        }

        public bool Validation() => FormValidator.Instance.ValidateTextFields(tbOpis);
    }
}
