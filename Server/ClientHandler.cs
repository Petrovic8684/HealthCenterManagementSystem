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
                    case Operation.None:
                        break;

                    case Operation.KreirajDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Create(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.KreirajLekar:
                        r.Result = Controller.Instance.Lekari.Create(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.KreirajMesto:
                        r.Result = Controller.Instance.Mesta.Create(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.KreirajPacijent:
                        r.Result = Controller.Instance.Pacijenti.Create(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.KreirajZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Create(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.ObrisiDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Delete(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.ObrisiLekar:
                        r.Result = Controller.Instance.Lekari.Delete(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.ObrisiMesto:
                        r.Result = Controller.Instance.Mesta.Delete(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.ObrisiPacijent:
                        r.Result = Controller.Instance.Pacijenti.Delete(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.ObrisiSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Delete(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.ObrisiZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Delete(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.PretraziDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Read(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.PretraziLekar:
                        r.Result = Controller.Instance.Lekari.Read(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.PretraziMesto:
                        r.Result = Controller.Instance.Mesta.Read(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.PretraziPacijent:
                        r.Result = Controller.Instance.Pacijenti.Read(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.PretraziSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Read(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.PretraziZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Read(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.PrijaviLekar:
                        r.Result = Controller.Instance.Lekari.Prijavi(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.PromeniDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Update(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.PromeniLekar:
                        r.Result = Controller.Instance.Lekari.Update(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.PromeniMesto:
                        r.Result = Controller.Instance.Mesta.Update(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.PromeniPacijent:
                        r.Result = Controller.Instance.Pacijenti.Update(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.PromeniSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Update(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.PromeniZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Update(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.UbaciSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Create(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.VratiListuDijagnozaPoDijagnozi:
                        r.Result = Controller.Instance.Dijagnoze.FetchList(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.VratiListuLekarPoLekaru:
                        r.Result = Controller.Instance.Lekari.FetchList(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.VratiListuLekarPoSertifikatu:
                        r.Result = Controller.Instance.Lekari.FetchList(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.VratiListuMestoPoMestu:
                        r.Result = Controller.Instance.Mesta.FetchList(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.VratiListuPacijentPoMestu:
                        r.Result = Controller.Instance.Pacijenti.FetchList(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.VratiListuPacijentPoPacijentu:
                        r.Result = Controller.Instance.Pacijenti.FetchList(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.VratiListuSertifikatPoSertifikatu:
                        r.Result = Controller.Instance.Sertifikati.FetchList(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.VratiListuSviDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.FetchListAll();
                        break;

                    case Operation.VratiListuSviLekar:
                        r.Result = Controller.Instance.Lekari.FetchListAll();
                        break;

                    case Operation.VratiListuSviMesto:
                        r.Result = Controller.Instance.Mesta.FetchListAll();
                        break;

                    case Operation.VratiListuSviPacijent:
                        r.Result = Controller.Instance.Pacijenti.FetchListAll();
                        break;

                    case Operation.VratiListuSviSertifikat:
                        r.Result = Controller.Instance.Sertifikati.FetchListAll();
                        break;

                    case Operation.VratiListuZdravstveniKartonPoDijagnozi:
                        r.Result = Controller.Instance.ZdravstveniKartoni.FetchList(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.VratiListuZdravstveniKartonPoLekaru:
                        r.Result = Controller.Instance.ZdravstveniKartoni.FetchList(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.VratiListuZdravstveniKartonPoPacijentu:
                        r.Result = Controller.Instance.ZdravstveniKartoni.FetchList(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.VratiListuZdravstveniKartonPoZdravstvenomKartonu:
                        r.Result = Controller.Instance.ZdravstveniKartoni.FetchList(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;
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
