using Client.Forms;
using Client.GuiController;
using Client.GuiController.Criteria;
using Common.Domain;

namespace Client
{
    internal partial class FrmLekar : Form, IForm<Lekar>
    {
        public FrmLekar()
        {
            InitializeComponent();

            btnPretrazi.Click += (s, e) => Controller.Instance.Lekari.Pretrazi();
            btnKreirajNovog.Click += (s, e) => FormManager.Instance.Open<FrmLekarCRUD>(f =>
            {
                f.FormClosed += (s, e) =>
                {
                    Controller.Instance.Lekari.Pretrazi();
                };
            });
            btnDetalji.Click += (s, e) => Controller.Instance.Lekari.PrikaziDetalje();

            ControlInitialisator.InitComboBox(
                cbSertifikati,
                Controller.Instance.Sertifikati.Pretrazi().Cast<Sertifikat>(),
                "Id",
                "Prikaz",
                new Sertifikat { Id = -1, Opis = "-- Bez izbora --" }
            );
        }

        public Lekar ConstructCriteria()
        {
            return new LekarCriteriaBuilder()
                .WithIme(tbIme.Text)
                .WithPrezime(tbPrezime.Text)
                .WithSertifikat((Sertifikat)cbSertifikati.SelectedItem)
                .Build();
        }
    }
}
