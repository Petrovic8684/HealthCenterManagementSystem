using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmLekar : Form
    {
        public FrmLekar()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Lekari.FetchList();
            btnKreirajNovog.Click += (s, e) => Controller.Instance.Lekari.Create();
            btnDetalji.Click += (s, e) => Controller.Instance.Lekari.Read();

            ControlInitialisator.Instance.InitComboBox(
                cbSertifikati,
                Controller.Instance.Sertifikati.FetchListAll(false).Cast<Sertifikat>(),
                "Id",
                "DisplayValue",
                new Sertifikat { Id = -1, Opis = "-- Bez izbora --" }
            );
        }
    }
}
