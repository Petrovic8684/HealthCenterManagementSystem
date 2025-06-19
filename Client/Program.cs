using Client.Forms;

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

            Communication.Instance.Connect(ConfigManager.ServerIP, ConfigManager.ServerPort);

            Application.Run(FormManager.Instance.Open<FrmMain>());
        }
    }
}
