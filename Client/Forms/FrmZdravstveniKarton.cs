using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    internal partial class FrmZdravstveniKarton : Form
    {
        public FrmZdravstveniKarton()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.FetchList();
            btnKreirajNovi.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.Create();
            btnDetalji.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.Read();

            ControlInitialisator.Instance.InitComboBox(
                cbDijagnoze,
                Controller.Instance.Dijagnoze.FetchListAll(false).Cast<Dijagnoza>(),
                "Id",
                "DisplayValue",
                new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }
    }
}
