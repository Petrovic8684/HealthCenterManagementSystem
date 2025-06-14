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

            btnPretrazi.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.Pretrazi();
            btnKreirajNovi.Click += (s, e) => FormManager.Instance.Open<FrmZdravstveniKartonCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.ZdravstveniKartoni.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.ZdravstveniKartoni.PrikaziDetalje();

            ControlInitialisator.InitComboBox(
                cbDijagnoze,
                Controller.Instance.Dijagnoze.Pretrazi().Cast<Dijagnoza>(),
                "Id",
                "Prikaz",
                new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }

        public ZdravstveniKarton ConstructCriteria()
        {
            return new ZdravstveniKartonCriteriaBuilder()
                .WithDatumOtvaranjaAfter(mcOtvorenNakon.SelectionStart)
                .WithImeLekara(tbLekar.Text)
                .WithImePacijenta(tbPacijent.Text)
                .WithDijagnoza((Dijagnoza)cbDijagnoze.SelectedItem)
                .Build();
        }
    }
}
