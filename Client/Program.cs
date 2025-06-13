using Client.GuiController;

namespace Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormManager.Instance.Open<FrmLogin>();

            Communication.Instance.Connect();

            Application.Run(FormManager.Instance.Open<FrmMain>());
        }
    }
}
