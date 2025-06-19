using Common.Domain;
using Server.SystemOperations.ZdravstveniKartonSO;

namespace Server.Services
{
    internal class ZdravstveniKartonService : IEntityService<ZdravstveniKarton>
    {
        public ZdravstveniKarton Create(ZdravstveniKarton entity)
        {
            var so = new KreirajZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public ZdravstveniKarton Read(ZdravstveniKarton entity)
        {
            var so = new PretraziZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public ZdravstveniKarton Update(ZdravstveniKarton entity)
        {
            var so = new PromeniZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public ZdravstveniKarton Delete(ZdravstveniKarton entity) 
        {
            var so = new ObrisiZdravstveniKartonSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<ZdravstveniKarton> FetchListAll()
        {
            throw new NotImplementedException();
        }

        public List<ZdravstveniKarton> FetchList(IEntity criterion)
        {
            var so = new VratiListuZdravstveniKartonSO(criterion, new List<ZdravstveniKarton>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
