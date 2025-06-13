using Common.Domain;
using Server.SystemOperations.LekarSO;

namespace Server.Services
{
    internal class LekarService : IEntityService<Lekar>
    {
        internal Lekar Prijavi(Lekar lekar)
        {
            var so = new PrijaviLekarSO(lekar);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Kreiraj(Lekar lekar)
        {
            new KreirajLekarSO(lekar).ExecuteTemplate();
        }

        public List<Lekar> Pretrazi(string kriterijum)
        {
            var so = new PretraziLekarSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(Lekar lekar)
        {
            new PromeniLekarSO(lekar).ExecuteTemplate();
        }

        public void Obrisi(Lekar lekar)
        {
            new ObrisiLekarSO(lekar).ExecuteTemplate();
        }
    }
}
