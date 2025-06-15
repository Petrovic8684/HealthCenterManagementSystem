using DotNetEnv;
using System.Net;

namespace Client
{
    internal static class ConfigManager
    {
        static ConfigManager()
        {
            Env.Load();
        }

        internal static string ServerIP
        {
            get
            {
                var ip = Env.GetString("SERVER_IP");
                if (string.IsNullOrWhiteSpace(ip))
                    throw new InvalidOperationException("SERVER_IP nije definisan u .env fajlu.");

                if (!IPAddress.TryParse(ip, out _))
                    throw new InvalidOperationException("SERVER_IP nije validna IP adresa u .env fajlu.");

                return ip;
            }
        }

        internal static int ServerPort
        {
            get
            {
                var portStr = Env.GetString("SERVER_PORT");
                if (string.IsNullOrWhiteSpace(portStr) || !int.TryParse(portStr, out int port) || port < 1 || port > 65535)
                    throw new InvalidOperationException("SERVER_PORT mora biti broj između 1 i 65535 u .env fajlu.");

                return port;
            }
        }
    }
}
