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
                        r.Result = Controller.Instance.Dijagnoze.Kreiraj(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.KreirajLekar:
                        r.Result = Controller.Instance.Lekari.Kreiraj(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.KreirajMesto:
                        r.Result = Controller.Instance.Mesta.Kreiraj(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.KreirajPacijent:
                        r.Result = Controller.Instance.Pacijenti.Kreiraj(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.KreirajZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Kreiraj(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.ObrisiDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Obrisi(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.ObrisiLekar:
                        r.Result = Controller.Instance.Lekari.Obrisi(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.ObrisiMesto:
                        r.Result = Controller.Instance.Mesta.Obrisi(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.ObrisiPacijent:
                        r.Result = Controller.Instance.Pacijenti.Obrisi(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.ObrisiSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Obrisi(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.PretraziDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Pretrazi(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.PretraziLekar:
                        r.Result = Controller.Instance.Lekari.Pretrazi(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.PretraziMesto:
                        r.Result = Controller.Instance.Mesta.Pretrazi(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.PretraziPacijent:
                        r.Result = Controller.Instance.Pacijenti.Pretrazi(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.PretraziSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Pretrazi(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.PretraziZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Pretrazi(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.PrijaviLekar:
                        r.Result = Controller.Instance.Lekari.Prijavi(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.PromeniDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.Promeni(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.PromeniLekar:
                        r.Result = Controller.Instance.Lekari.Promeni(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.PromeniMesto:
                        r.Result = Controller.Instance.Mesta.Promeni(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.PromeniPacijent:
                        r.Result = Controller.Instance.Pacijenti.Promeni(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.PromeniSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Promeni(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.PromeniZdravstveniKarton:
                        r.Result = Controller.Instance.ZdravstveniKartoni.Promeni(serializer.ReadType<ZdravstveniKarton>(req.Argument));
                        break;

                    case Operation.UbaciSertifikat:
                        r.Result = Controller.Instance.Sertifikati.Kreiraj(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.VratiListuDijagnozaPoDijagnozi:
                        r.Result = Controller.Instance.Dijagnoze.VratiListu(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.VratiListuLekarPoLekaru:
                        r.Result = Controller.Instance.Lekari.VratiListu(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.VratiListuLekarPoSertifikatu:
                        r.Result = Controller.Instance.Lekari.VratiListu(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.VratiListuMestoPoMestu:
                        r.Result = Controller.Instance.Mesta.VratiListu(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.VratiListuPacijentPoMestu:
                        r.Result = Controller.Instance.Pacijenti.VratiListu(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.VratiListuPacijentPoPacijentu:
                        r.Result = Controller.Instance.Pacijenti.VratiListu(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.VratiListuSertifikatPoSertifikatu:
                        r.Result = Controller.Instance.Sertifikati.VratiListu(serializer.ReadType<Sertifikat>(req.Argument));
                        break;

                    case Operation.VratiListuSviDijagnoza:
                        r.Result = Controller.Instance.Dijagnoze.VratiListuSvi();
                        break;

                    case Operation.VratiListuSviLekar:
                        r.Result = Controller.Instance.Lekari.VratiListuSvi();
                        break;

                    case Operation.VratiListuSviMesto:
                        r.Result = Controller.Instance.Mesta.VratiListuSvi();
                        break;

                    case Operation.VratiListuSviPacijent:
                        r.Result = Controller.Instance.Pacijenti.VratiListuSvi();
                        break;

                    case Operation.VratiListuSviSertifikat:
                        r.Result = Controller.Instance.Sertifikati.VratiListuSvi();
                        break;

                    case Operation.VratiListuZdravstveniKartonPoDijagnozi:
                        r.Result = Controller.Instance.ZdravstveniKartoni.VratiListu(serializer.ReadType<Dijagnoza>(req.Argument));
                        break;

                    case Operation.VratiListuZdravstveniKartonPoLekaru:
                        r.Result = Controller.Instance.ZdravstveniKartoni.VratiListu(serializer.ReadType<Lekar>(req.Argument));
                        break;

                    case Operation.VratiListuZdravstveniKartonPoPacijentu:
                        r.Result = Controller.Instance.ZdravstveniKartoni.VratiListu(serializer.ReadType<Pacijent>(req.Argument));
                        break;

                    case Operation.VratiListuZdravstveniKartonPoZdravstvenomKartonu:
                        r.Result = Controller.Instance.ZdravstveniKartoni.VratiListu(serializer.ReadType<ZdravstveniKarton>(req.Argument));
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
