using Common.Domain;
using Server.SystemOperations.MestoSO;
using Server.SystemOperations.PacijentSO;

namespace Server.Services
{
    internal class MestoService : IEntityService<Mesto>
    {
        public Mesto Kreiraj(Mesto entity)
        {
            var so = new KreirajMestoSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Mesto Pretrazi(Mesto entity)
        {
            var so = new PretraziMestoSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Mesto Promeni(Mesto entity)
        {
            var so = new PromeniMestoSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Mesto Obrisi(Mesto entity)
        {
            var so = new ObrisiMestoSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Mesto> VratiListuSvi()
        {
            var so = new VratiListuSviMestoSO(new List<Mesto>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Mesto> VratiListu(IEntity criterion)
        {
            if (criterion is not Mesto mestoCriterion)
                throw new ArgumentException("Kriterijum mora biti tipa Mesto.");

            var so = new VratiListuMestoSO(mestoCriterion, new List<Mesto>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
