using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    public partial class FrmMesto : Form, ICriteriaForm
    {
        public FrmMesto()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Mesta.Pretrazi();
            btnKreirajNovo.Click += (s, e) => FormManager.Instance.Open<FrmMestoCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Mesta.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Mesta.PrikaziDetalje();
        }

        public string ConstructCriteria()
        {
            return new MestoCriteriaBuilder()
                .WithNaziv(tbNaziv.Text)
                .WithPostanskiBroj(tbPostanskiBroj.Text)
                .Build().Criteria;
        }
    }
}
