using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmDijagnoza : Form
    {
        public FrmDijagnoza()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Dijagnoze.FetchList();
            btnKreirajNovu.Click += (s, e) => Controller.Instance.Dijagnoze.Create();
            btnDetalji.Click += (s, e) => Controller.Instance.Dijagnoze.Read();
        }
    }
}
