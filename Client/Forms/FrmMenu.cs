using Client.Forms;

namespace Client
{
    internal partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();

            btnOdjava.Click += (s, e) => { 
                Session.Instance.Clear();
                FormManager.Instance.Open<FrmLogin>();
                FormManager.Instance.Close<FrmMenu>();
            };

            lblDobrodosli.Text = "Dobro došli, " + Session.Instance.CurrentLekar.Ime;

            zdravstveniKartonToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmZdravstveniKarton>();
            lekarToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmLekar>();
            pacijentToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmPacijent>();
            dijagnozaToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmDijagnoza>();
            mestoToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmMesto>();
            sertifikatToolStripMenuItem.Click += (s, e) => FormManager.Instance.Open<FrmSertifikat>();
        }
    }
}
