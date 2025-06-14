using Common.Domain;
using Server.SystemOperations.DijagnozaSO;

namespace Server.Services
{
    internal class DijagnozaService : IEntityService<Dijagnoza>
    {
        public void Kreiraj(Dijagnoza dijagnoza)
        {
            new KreirajDijagnozaSO(dijagnoza).ExecuteTemplate();
        }

        public List<Dijagnoza> Pretrazi(Dijagnoza kriterijum)
        {
            var so = new PretraziDijagnozaSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(Dijagnoza dijagnoza)
        {
            new PromeniDijagnozaSO(dijagnoza).ExecuteTemplate();
        }

        public void Obrisi(Dijagnoza dijagnoza)
        {
            new ObrisiDijagnozaSO(dijagnoza).ExecuteTemplate();
        }
    }
}
