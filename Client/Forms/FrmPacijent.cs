using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmPacijent : Form, IForm<Pacijent>
    {
        public FrmPacijent()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Pacijenti.VratiListu();
            btnKreirajNovog.Click += (s, e) => FormManager.Instance.Open<FrmPacijentCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Pacijenti.VratiListuSvi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Pacijenti.Pretrazi();

            ControlInitialisator.InitComboBox(
                cbMesta,
                Controller.Instance.Mesta.VratiListuSvi().Cast<Mesto>(),
                "Id",
                "Prikaz",
                new Mesto { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }
    }
}
