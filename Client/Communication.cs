
using Common.Communication;
using Common.Config;
using Common.Domain;
using System.Net.Sockets;

namespace Client
{
    internal class Communication
    {

        private static Communication instance;
        internal static Communication Instance => instance ??= new Communication();

        private Communication() { }

        private Socket socket;
        private JsonNetworkSerializer serializer;

        internal void Connect()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ConfigManager.ServerIP, ConfigManager.ServerPort);
                serializer = new JsonNetworkSerializer(socket);
            }
            catch (SocketException)
            {
                MessageBox.Show("Došlo je do greške prilikom uspostavljanja konekcije sa serverom.", "Greška");
                return;
            }
        }

        internal void Disconnect()
        {
            try
            {
                if (socket != null && socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                socket = null;
                serializer = null;
            }
            catch (SocketException)
            {
                MessageBox.Show("Došlo je do greške prilikom prekidanja konekcije sa serverom.", "Greška");
            }
        }
        internal Response SendRequest<TRequest, TResponse>(TRequest argument, Operation operation)
            where TResponse : class, IEntity
        {
            var request = new Request
            {
                Argument = argument,
                Operation = operation
            };

            serializer.Send(request);

            var response = serializer.Receive<Response>();
            response.Result = serializer.ReadType<TResponse>(response.Result);
            return response;
        }

        internal Response SendRequestList<TRequest, TResponse>(TRequest argument, Operation operation)
            where TResponse : class, IEntity, new()
        {
            var request = new Request
            {
                Argument = argument,
                Operation = operation
            };

            serializer.Send(request);

            var response = serializer.Receive<Response>();
            response.Result = serializer.ReadType<List<TResponse>>(response.Result);
            return response;
        }
    }
}
