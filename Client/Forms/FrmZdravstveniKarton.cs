using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    internal partial class FrmZdravstveniKarton : Form, IForm<ZdravstveniKarton>
    {
        public FrmZdravstveniKarton()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.VratiListu();
            btnKreirajNovi.Click += (s, e) => FormManager.Instance.Open<FrmZdravstveniKartonCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.ZdravstveniKartoni.VratiListuSvi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.Pretrazi();

            ControlInitialisator.InitComboBox(
                cbDijagnoze,
                Controller.Instance.Dijagnoze.VratiListuSvi().Cast<Dijagnoza>(),
                "Id",
                "Prikaz",
                new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }
    }
}
