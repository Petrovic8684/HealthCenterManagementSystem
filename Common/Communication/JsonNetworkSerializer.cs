using System.Net.Sockets;
using System.Text.Json;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
        private readonly Socket socket;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }

        public T Receive<T>()
        {
            string json = reader.ReadLine();
            if (json == null)
            {
                throw new IOException("Konekcija je zatvorena ili nisu poslati podaci.");
            }
            return JsonSerializer.Deserialize<T>(json);
        }


        public T ReadType<T>(object data) where T : class
        {
            return data == null ? null : JsonSerializer.Deserialize<T>((JsonElement)data);
        }

        public void Close()
        {
            stream.Close();
            reader.Close();
            writer.Close();
        }
    }
}
