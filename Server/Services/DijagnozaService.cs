using Common.Domain;
using Server.SystemOperations.DijagnozaSO;
using Server.SystemOperations.PacijentSO;

namespace Server.Services
{
    internal class DijagnozaService : IEntityService<Dijagnoza>
    {
        public Dijagnoza Kreiraj(Dijagnoza entity)
        {
            var so = new KreirajDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Dijagnoza Pretrazi(Dijagnoza entity)
        {
            var so = new PretraziDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Dijagnoza Promeni(Dijagnoza entity)
        {
            var so = new PromeniDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Dijagnoza Obrisi(Dijagnoza entity)
        {
            var so = new ObrisiDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Dijagnoza> VratiListuSvi()
        {
            var so = new VratiListuSviDijagnozaSO(new List<Dijagnoza>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Dijagnoza> VratiListu(IEntity criterion)
        {
            if (criterion is not Dijagnoza dijagnozaCriterion)
                throw new ArgumentException("Kriterijum mora biti tipa Dijagnoza.");

            var so = new VratiListuDijagnozaSO(dijagnozaCriterion, new List<Dijagnoza>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
