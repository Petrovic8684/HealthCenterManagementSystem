using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    internal partial class FrmSertifikat : Form
    {
        public FrmSertifikat()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Sertifikati.FetchList();
            btnKreirajNovi.Click += (s, e) => Controller.Instance.Sertifikati.Create();
            btnDetalji.Click += (s, e) => Controller.Instance.Sertifikati.Read();
        }
    }
}
