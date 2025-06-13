using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    public partial class FrmSertifikat : Form, ICriteriaForm
    {
        public FrmSertifikat()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Sertifikati.Pretrazi();
            btnKreirajNovo.Click += (s, e) => FormManager.Instance.Open<FrmSertifikatCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Sertifikati.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Sertifikati.PrikaziDetalje();
        }

        public string ConstructCriteria()
        {
            return new SertifikatCriteriaBuilder()
                .WithOpis(tbOpis.Text)
                .Build().Criteria;
        }
    }
}
