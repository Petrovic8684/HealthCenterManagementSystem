using Client.Forms;
using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal partial class FrmLekar : Form, IForm<Lekar>
    {
        public FrmLekar()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Lekari.VratiListu();
            btnKreirajNovog.Click += (s, e) => FormManager.Instance.Open<FrmLekarCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Lekari.VratiListuSvi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Lekari.Pretrazi();

            ControlInitialisator.InitComboBox(
                cbSertifikati,
                Controller.Instance.Sertifikati.VratiListuSvi().Cast<Sertifikat>(),
                "Id",
                "Prikaz",
                new Sertifikat { Id = -1, Opis = "-- Bez izbora --" }
            );
        }
    }
}
