using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    internal partial class FrmPacijent : Form, IForm<Pacijent>
    {
        public FrmPacijent()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Pacijenti.Pretrazi();
            btnKreirajNovog.Click += (s, e) => FormManager.Instance.Open<FrmPacijentCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Pacijenti.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Pacijenti.PrikaziDetalje();

            ControlInitialisator.InitComboBox(
                cbMesta,
                Controller.Instance.Mesta.Pretrazi().Cast<Mesto>(),
                "Id",
                "Prikaz",
                new Mesto { Id = -1, Naziv = "-- Bez izbora --" }
            );
        }

        public Pacijent ConstructCriteria()
        {
            return new PacijentCriteriaBuilder()
                .WithIme(tbIme.Text)
                .WithPrezime(tbPrezime.Text)
                .WithMesto((Mesto)cbMesta.SelectedItem)
                .Build();
        }
    }
}
