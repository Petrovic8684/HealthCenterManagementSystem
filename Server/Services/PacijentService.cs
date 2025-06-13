using Common.Domain;
using Server.SystemOperations.PacijentSO;

namespace Server.Services
{
    internal class PacijentService : IEntityService<Pacijent>
    {
        public void Kreiraj(Pacijent pacijent)
        {
            new KreirajPacijentSO(pacijent).ExecuteTemplate();
        }

        public List<Pacijent> Pretrazi(string kriterijum)
        {
            var so = new PretraziPacijentSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(Pacijent pacijent)
        {
            new PromeniPacijentSO(pacijent).ExecuteTemplate();
        }

        public void Obrisi(Pacijent pacijent)
        {
            new ObrisiPacijentSO(pacijent).ExecuteTemplate();
        }
    }
}
