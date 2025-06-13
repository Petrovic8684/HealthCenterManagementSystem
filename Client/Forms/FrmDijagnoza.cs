using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;

namespace Client
{
    internal partial class FrmDijagnoza : Form, IForm
    {
        public FrmDijagnoza()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Dijagnoze.Pretrazi();
            btnKreirajNovu.Click += (s, e) => FormManager.Instance.Open<FrmDijagnozaCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Dijagnoze.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Dijagnoze.PrikaziDetalje();
        }

        public string ConstructCriteria()
        {
            return new DijagnozaCriteriaBuilder()
                .WithNaziv(tbNaziv.Text)
                .WithOpis(tbOpis.Text)
                .Build().Criteria;
        }
    }
}
