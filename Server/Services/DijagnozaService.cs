using Common.Domain;
using Server.SystemOperations.DijagnozaSO;
using Server.SystemOperations.PacijentSO;

namespace Server.Services
{
    internal class DijagnozaService : IEntityService<Dijagnoza>
    {
        public Dijagnoza Create(Dijagnoza entity)
        {
            var so = new KreirajDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Dijagnoza Read(Dijagnoza entity)
        {
            var so = new PretraziDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Dijagnoza Update(Dijagnoza entity)
        {
            var so = new PromeniDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Dijagnoza Delete(Dijagnoza entity)
        {
            var so = new ObrisiDijagnozaSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Dijagnoza> FetchListAll()
        {
            var so = new VratiListuSviDijagnozaSO(new List<Dijagnoza>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Dijagnoza> FetchList(IEntity criterion)
        {
            if (criterion is not Dijagnoza dijagnozaCriterion)
                throw new ArgumentException("Kriterijum mora biti tipa Dijagnoza.");

            var so = new VratiListuDijagnozaSO(dijagnozaCriterion, new List<Dijagnoza>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
