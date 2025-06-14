using System.Diagnostics;
using System.Net.Sockets;
using Common.Communication;
using Common.Domain;

namespace Server
{
    internal class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;
        private readonly Server server;

        internal ClientHandler(Socket socket, Server server)
        {
            this.socket = socket;
            this.server = server;
            serializer = new JsonNetworkSerializer(socket);
        }

        internal void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Request req = serializer.Receive<Request>();
                    Response r = ProcessRequest(req);
                    serializer.Send(r);
                }
            }
            catch (IOException)
            {
                Debug.WriteLine("Konekcija zatvorena od strane klijenta.");
            }
            catch (SocketException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
            }
            finally
            {
                CloseSocket();
                server.RemoveClient(this);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();
            try
            {
                switch (req.Operation)
                {
                    #region ZdravstveniKarton

                    case Operation.KreirajZdravstveniKarton:
                        Controller.Instance.ZdravstveniKartoni.Kreiraj(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;
                    case Operation.PretraziZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Pretrazi(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;
                    case Operation.PromeniZdravstveniKarton:
                        Controller.Instance.ZdravstveniKartoni.Promeni(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                        #endregion

                    #region Pacijent

                    case Operation.KreirajPacijent:
                        Controller.Instance.Pacijenti.Kreiraj(serializer.ReadType<Pacijent>(req.Argument));
                        break;
                    case Operation.PretraziPacijent:
                        r.Result = Controller.Instance.Pacijenti.Pretrazi(serializer.ReadType<Pacijent>(req.Argument));
                        break;
                    case Operation.PromeniPacijent:
                        Controller.Instance.Pacijenti.Promeni(serializer.ReadType<Pacijent>(req.Argument));
                        break;
                    case Operation.ObrisiPacijent:
                        Controller.Instance.Pacijenti.Obrisi(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    #endregion

                    #region Lekar
                    case Operation.PrijaviLekar:
                        r.Result = Controller.Instance.Lekari.Prijavi(serializer.ReadType<Lekar>(req.Argument));
                        break;
                    case Operation.KreirajLekar:
                        Controller.Instance.Lekari.Kreiraj(serializer.ReadType<Lekar>(req.Argument));
                        break;
                    case Operation.PretraziLekar:
                        r.Result = Controller.Instance.Lekari.Pretrazi(serializer.ReadType<Lekar>(req.Argument));
                        break;
                    case Operation.PromeniLekar:
                        Controller.Instance.Lekari.Promeni(serializer.ReadType<Lekar>(req.Argument));
                        break;
                    case Operation.ObrisiLekar:
                        Controller.Instance.Lekari.Obrisi(serializer.ReadType<Lekar>(req.Argument));
                        break;
                    #endregion

                    #region Dijagnoza

                    case Operation.KreirajDijagnoza:
                        Controller.Instance.Dijagnoze.Kreiraj(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;
                    case Operation.PretraziDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Pretrazi(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;
                    case Operation.PromeniDijagnoza:
                        Controller.Instance.Dijagnoze.Promeni(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;
                    case Operation.ObrisiDijagnoza:
                        Controller.Instance.Dijagnoze.Obrisi(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    #endregion

                    #region Mesto

                    case Operation.KreirajMesto:
                        Controller.Instance.Mesta.Kreiraj(serializer.ReadType<Mesto>(req.Argument));
                        break;
                    case Operation.PretraziMesto:
                        r.Result = Controller.Instance.Mesta.Pretrazi(serializer.ReadType<Mesto>(req.Argument));
                        break;
                    case Operation.PromeniMesto:
                        Controller.Instance.Mesta.Promeni(serializer.ReadType<Mesto>(req.Argument));
                        break;
                    case Operation.ObrisiMesto:
                        Controller.Instance.Mesta.Obrisi(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    #endregion

                    #region Sertifikat
                    case Operation.UbaciSertifikat:
                        Controller.Instance.Sertifikati.Kreiraj(serializer.ReadType<Sertifikat>(req.Argument));
                        break;
                    case Operation.PretraziSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Pretrazi(serializer.ReadType<Sertifikat>(req.Argument));
                        break;
                    case Operation.PromeniSertifikat:
                        Controller.Instance.Sertifikati.Promeni(serializer.ReadType<Sertifikat>(req.Argument));
                        break;
                    case Operation.ObrisiSertifikat:
                        Controller.Instance.Sertifikati.Obrisi(serializer.ReadType<Sertifikat>(req.Argument));
                        break;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                r.ExceptionMessage = ex.Message;
                r.ExceptionType = ex.GetType().FullName;
            }

            return r;
        }

        internal void CloseSocket()
        {
            socket.Close();
        }
    }
}
