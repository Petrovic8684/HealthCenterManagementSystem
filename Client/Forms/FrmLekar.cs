using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    public partial class FrmLekar : Form, ICriteriaForm
    {
        public FrmLekar()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Lekari.Pretrazi();
            btnKreirajNovog.Click += (s, e) => FormManager.Instance.Open<FrmLekarCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Lekari.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Lekari.PrikaziDetalje();

            List<Sertifikat> sertifikati = Controller.Instance.Sertifikati.Pretrazi().Cast<Sertifikat>().ToList(); ;

            sertifikati.Insert(0, new Sertifikat { Id = -1, Opis = "-- Bez izbora --" });

            cbSertifikati.DataSource = sertifikati;
            cbSertifikati.ValueMember = "Id";
            cbSertifikati.DisplayMember = "Prikaz";
            cbSertifikati.SelectedIndex = 0;
        }

        public string ConstructCriteria()
        {
            return new LekarCriteriaBuilder()
                .WithIme(tbIme.Text)
                .WithPrezime(tbPrezime.Text)
                .WithSertifikat((Sertifikat)cbSertifikati.SelectedItem)
                .Build().Criteria;
        }
    }
}
