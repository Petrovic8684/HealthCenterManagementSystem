using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmDijagnozaCRUD : Form, ICrudForm<Dijagnoza>
    {
        internal Dijagnoza? Dijagnoza{ get; set; }

        public FrmDijagnozaCRUD()
        {
            InitializeComponent();

            btnZapamti.Click += (s, e) => Controller.Instance.Dijagnoze.Save();
            btnObrisi.Click += (s, e) => Controller.Instance.Dijagnoze.Delete();
            btnOdustani.Click += (s, e) =>
            {
                if (Dijagnoza == null) Controller.Instance.Dijagnoze.Delete();
                else FormManager.Instance.Close<FrmDijagnozaCRUD>();
            };
        }

        public void ShowDetails(Dijagnoza dijagnoza)
        {
            Dijagnoza = dijagnoza;

            lblDijagnozaId.Text = "Dijagnoza ID: " + dijagnoza.Id.ToString();

            tbNaziv.Text = dijagnoza.Naziv;
            tbOpis.Text = dijagnoza.Opis;
            tbBazniSkor.Text = dijagnoza.BazniSkor.ToString();

            btnObrisi.Enabled = true;
        }

        public bool Validation() => FormValidator.Instance.ValidateTextFields(tbNaziv, tbOpis, tbBazniSkor);
    }
}
