using Common.Domain;
using Server.SystemOperations.PacijentSO;
using Server.SystemOperations.ZdravstveniKartonSO;

namespace Server.Services
{
    internal class PacijentService : IEntityService<Pacijent>
    {
        public Pacijent Create(Pacijent entity)
        {
            var so = new KreirajPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Pacijent Read(Pacijent entity)
        {
            var so = new PretraziPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Pacijent Update(Pacijent entity)
        {
            var so = new PromeniPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Pacijent Delete(Pacijent entity)
        {
            var so = new ObrisiPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Pacijent> FetchListAll()
        {
            var so = new VratiListuSviPacijentSO(new List<Pacijent>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Pacijent> FetchList(IEntity criterion)
        {
            var so = new VratiListuPacijentSO(criterion, new List<Pacijent>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
