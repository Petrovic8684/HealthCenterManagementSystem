namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();

            btnTogglujStatus.Click += (s, e) => ToggleStatus();
            FormClosed += (s, e) => Quit();
        }

        private void ToggleStatus()
        {
            if (server == null)
            {
                server = new Server();

                btnTogglujStatus.Text = "Zaustavi server";
                btnTogglujStatus.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
                btnTogglujStatus.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192); 
                lblStatus.Text = "Status servera - pokrenut";

                server.Start();

                server.ClientsCountChanged += HandleClientCountChanged;

                return;
            }

            btnTogglujStatus.Text = "Pokreni server";
            btnTogglujStatus.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnTogglujStatus.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            lblStatus.Text = "Status servera - zaustavljen";

            server.Stop();

            server = null;
        }

        private void HandleClientCountChanged(int count)
        {
            if (this.IsDisposed) return;

            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    if (!this.IsDisposed)
                        lblBrojKlijenata.Text = $"Povezano klijenata - {count}";
                }));
            else
                lblBrojKlijenata.Text = $"Povezano klijenata - {count}";
        }


        private void Quit()
        {
            if (server != null)
            {
                server.ClientsCountChanged -= HandleClientCountChanged;
                server.Stop();
            }

            Application.Exit();
        }
    }
}
