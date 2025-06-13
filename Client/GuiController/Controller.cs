using Client.GuiController.Services;

namespace Client.GuiController
{
    internal class Controller
    {
        private static Controller instance;
        internal static Controller Instance => instance ??= new Controller();

        internal readonly ZdravstveniKartonService ZdravstveniKartoni;
        internal readonly PacijentService Pacijenti;
        internal readonly LekarService Lekari;
        internal readonly DijagnozaService Dijagnoze;
        internal readonly MestoService Mesta;
        internal readonly SertifikatService Sertifikati;

        private Controller()
        {
            ZdravstveniKartoni = new ZdravstveniKartonService();
            Pacijenti = new PacijentService();
            Lekari = new LekarService();
            Dijagnoze = new DijagnozaService();
            Mesta = new MestoService();
            Sertifikati = new SertifikatService();
        }
    }
}
