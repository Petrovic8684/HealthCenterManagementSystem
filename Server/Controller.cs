using Server.Services;

internal class Controller
{
    private static readonly Lazy<Controller> instance = new(() => new Controller());

    internal static Controller Instance => instance.Value;

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
