using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmPacijent : Form
    {
        public FrmPacijent()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Pacijenti.FetchList();
            btnKreirajNovog.Click += (s, e) => Controller.Instance.Pacijenti.Create();
            btnDetalji.Click += (s, e) => Controller.Instance.Pacijenti.Read();

            ControlInitialisator.Instance.InitComboBox(
                cbMesta,
                Controller.Instance.Mesta.FetchListAll(false).Cast<Mesto>(),
                "Id",
                "DisplayValue",
                new Mesto { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }
    }
}
