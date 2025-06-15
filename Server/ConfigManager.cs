using DotNetEnv;

namespace Server
{
    internal static class ConfigManager
    {
        static ConfigManager()
        {
            Env.Load();
        }

        internal static string DBConnectionString
        {
            get
            {
                var connStr = Env.GetString("DB_CONNECTION_STRING");
                if (string.IsNullOrEmpty(connStr))
                    throw new InvalidOperationException("DB_CONNECTION_STRING nije definisan u .env fajlu.");
                
                return connStr;
            }
        }

        internal static int Port
        {
            get
            {
                var portStr = Env.GetString("PORT");
                if (string.IsNullOrWhiteSpace(portStr) || !int.TryParse(portStr, out int port) || port < 1 || port > 65535)
                    throw new InvalidOperationException("PORT mora biti broj između 1 i 65535 u .env fajlu.");

                return port;
            }
        }
    }
}
