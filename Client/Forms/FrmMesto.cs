using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmMesto : Form
    {
        public FrmMesto()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Mesta.FetchList();
            btnKreirajNovo.Click += (s, e) => Controller.Instance.Mesta.Create();
            btnDetalji.Click += (s, e) => Controller.Instance.Mesta.Read();
        }
    }
}
