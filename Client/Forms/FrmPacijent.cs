using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    public partial class FrmPacijent : Form, ICriteriaForm
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

            List<Mesto> mesta = Controller.Instance.Mesta.Pretrazi().Cast<Mesto>().ToList();

            mesta.Insert(0, new Mesto { Id = -1, Naziv = "-- Bez izbora --" });

            cbMesta.DataSource = mesta;
            cbMesta.ValueMember = "Id";
            cbMesta.DisplayMember = "Prikaz";
            cbMesta.SelectedIndex = 0;
        }

        public string ConstructCriteria()
        {
            return new PacijentCriteriaBuilder()
                .WithIme(tbIme.Text)
                .WithPrezime(tbPrezime.Text)
                .WithMesto((Mesto)cbMesta.SelectedItem)
                .Build().Criteria;
        }
    }
}
