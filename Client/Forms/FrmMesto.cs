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
            btnKreirajNovo.Click += (s, e) => Controller.Instance.Mesta.Kreiraj();
            btnDetalji.Click += (s, e) => Controller.Instance.Mesta.Pretrazi();
        }
    }
}
