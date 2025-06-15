
using Client.Forms;
using Client.GuiController;
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

        internal void Connect(string ip, int port)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ip, port);
                serializer = new JsonNetworkSerializer(socket);

                MessageBox.Show("Konekcija sa serverom je uspešno uspostavljena.");
                FormManager.Instance.Close<FrmPodesavanja>();
            }
            catch (SocketException)
            {
                MessageBox.Show("Došlo je do greške prilikom uspostavljanja konekcije sa serverom.", "Greška");
                FormManager.Instance.Open<FrmPodesavanja>();
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
            try
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
            catch
            {
                throw new Exception("Verovatno je problem u konekciji sa serverom.");
            }
        }

        internal Response SendRequestList<TRequest, TResponse>(TRequest argument, Operation operation)
            where TResponse : class, IEntity, new()
        {
            try
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
            catch
            {
                throw new Exception("Verovatno je problem u konekciji sa serverom.");
            }
        }
    }
}
