using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    internal partial class FrmSertifikat : Form, IForm<Sertifikat>
    {
        public FrmSertifikat()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Sertifikati.VratiListu();
            btnKreirajNovo.Click += (s, e) => FormManager.Instance.Open<FrmSertifikatCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Sertifikati.VratiListuSvi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Sertifikati.Pretrazi();
        }
    }
}
