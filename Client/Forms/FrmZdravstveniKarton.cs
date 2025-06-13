using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    public partial class FrmZdravstveniKarton : Form, ICriteriaForm
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

            List<Dijagnoza> dijagnoze = Controller.Instance.Dijagnoze.Pretrazi().Cast<Dijagnoza>().ToList();

            dijagnoze.Insert(0, new Dijagnoza { Id = -1, Naziv = "-- Bez izbora --" });

            cbDijagnoze.DataSource = dijagnoze;
            cbDijagnoze.ValueMember = "Id";
            cbDijagnoze.DisplayMember = "Prikaz";
            cbDijagnoze.SelectedIndex = 0;
        }

        public string ConstructCriteria()
        {
            return new ZdravstveniKartonCriteriaBuilder()
                .WithDatumOtvaranjaAfter(mcOtvorenNakon.SelectionStart)
                .WithImeLekara(tbLekar.Text)
                .WithImePacijenta(tbPacijent.Text)
                .WithDijagnoza((Dijagnoza)cbDijagnoze.SelectedItem)
                .Build().Criteria;
        }
    }
}
