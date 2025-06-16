using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

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
                    Socket clientSocket = socket.Accept();
                    ClientHandler handler = new ClientHandler(clientSocket, this);
                    AddClient(handler);
                    Thread clientThread = new Thread(handler.HandleRequest);
                    clientThread.Start();
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
