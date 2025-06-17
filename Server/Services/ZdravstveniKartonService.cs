using Common.Domain;
using Server.SystemOperations.ZdravstveniKartonSO;

namespace Server.Services
{
    internal class ZdravstveniKartonService : IEntityService<ZdravstveniKarton>
    {
        public ZdravstveniKarton Kreiraj(ZdravstveniKarton entity)
        {
            var so = new KreirajZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public ZdravstveniKarton Pretrazi(ZdravstveniKarton entity)
        {
            var so = new PretraziZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public ZdravstveniKarton Promeni(ZdravstveniKarton entity)
        {
            var so = new PromeniZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public ZdravstveniKarton Obrisi(ZdravstveniKarton entity) 
        {
            var so = new ObrisiZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<ZdravstveniKarton> VratiListuSvi()
        {
            throw new NotImplementedException();
        }

        public List<ZdravstveniKarton> VratiListu(IEntity criterion)
        {
            var so = new VratiListuZdravstveniKartonSO(criterion, new List<ZdravstveniKarton>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
