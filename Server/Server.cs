using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Common.Config;

namespace Server
{
    internal class Server
    {
        private Socket socket;
        private List<ClientHandler> handlers = new List<ClientHandler>();

        internal event Action<int>? ClientsCountChanged;

        private void OnClientsCountChanged()
        {
            ClientsCountChanged?.Invoke(handlers.Count);
        }

        internal Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        internal void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, ConfigManager.Port);

            socket.Bind(endPoint);
            socket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.Start();
        }

        internal void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSoket, this);
                    AddClient(handler);
                    Thread klijentskaNit = new Thread(handler.HandleRequest);
                    klijentskaNit.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        internal void Stop()
        {
            List<ClientHandler> copy = new List<ClientHandler>(handlers); 
            foreach (ClientHandler handler in copy)
            {
                handler.CloseSocket();
            }
            handlers.Clear();
            socket.Close();
        }
        private object _lock = new object();

        internal void AddClient(ClientHandler clientHandler)
        {
            lock (_lock)
            {
                handlers.Add(clientHandler);
                OnClientsCountChanged();
            }
        }

        internal void RemoveClient(ClientHandler clientHandler)
        {
            lock (_lock)
            {
                handlers.Remove(clientHandler);
                OnClientsCountChanged();
            }
        }
    }
}
