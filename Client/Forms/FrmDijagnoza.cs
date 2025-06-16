using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmDijagnoza : Form, IForm<Dijagnoza>
    {
        public FrmDijagnoza()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Dijagnoze.VratiListu();
            btnKreirajNovu.Click += (s, e) => FormManager.Instance.Open<FrmDijagnozaCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Dijagnoze.VratiListuSvi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Dijagnoze.Pretrazi();
        }
    }
}
