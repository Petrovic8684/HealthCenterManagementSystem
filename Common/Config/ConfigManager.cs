using System.Text.Json;

namespace Common.Config
{
    public static class ConfigManager
    {
        private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        private static Dictionary<string, string> settings;

        static ConfigManager()
        {
            LoadSettings();
        }

        private static void LoadSettings()
        {
            if (File.Exists(configFilePath))
            {
                var json = File.ReadAllText(configFilePath);
                settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
            }
            else
            {
                settings = new Dictionary<string, string>();
            }

            if (!settings.ContainsKey("ServerIP"))
                settings["ServerIP"] = "127.0.0.1";

            if (!settings.ContainsKey("ServerPort"))
                settings["ServerPort"] = "9998";

            if (!settings.ContainsKey("DbConnectionString"))
                settings["DbConnectionString"] = @"Data Source=DESKTOP-T72DE7B;Initial Catalog=ProSoft-SeminarskiRad;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

            SaveSettings();
        }

        private static void SaveSettings()
        {
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFilePath, json);
        }

        public static string DbConnectionString
        {
            get => settings.ContainsKey("DbConnectionString") ? settings["DbConnectionString"] : string.Empty;
            set
            {
                settings["DbConnectionString"] = value;
                SaveSettings();
            }
        }

        public static string ServerIP
        {
            get => settings.ContainsKey("ServerIP") ? settings["ServerIP"] : string.Empty;
            set
            {
                settings["ServerIP"] = value;
                SaveSettings();
            }
        }

        public static int ServerPort
        {
            get
            {
                if (settings.ContainsKey("ServerPort") && int.TryParse(settings["ServerPort"], out int port))
                    return port;
                return 0;
            }
            set
            {
                settings["ServerPort"] = value.ToString();
                SaveSettings();
            }
        }
    }
}
