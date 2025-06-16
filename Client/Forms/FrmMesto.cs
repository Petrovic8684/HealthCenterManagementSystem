using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmMesto : Form, IForm<Mesto>
    {
        public FrmMesto()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Mesta.VratiListu();
            btnKreirajNovo.Click += (s, e) => FormManager.Instance.Open<FrmMestoCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Mesta.VratiListuSvi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Mesta.Pretrazi();
        }
    }
}
