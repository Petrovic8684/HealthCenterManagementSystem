using Common.Domain;
using Server.SystemOperations.PacijentSO;
using Server.SystemOperations.ZdravstveniKartonSO;

namespace Server.Services
{
    internal class PacijentService : IEntityService<Pacijent>
    {
        public Pacijent Kreiraj(Pacijent entity)
        {
            var so = new KreirajPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Pacijent Pretrazi(Pacijent entity)
        {
            var so = new PretraziPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Pacijent Promeni(Pacijent entity)
        {
            var so = new PromeniPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Pacijent Obrisi(Pacijent entity)
        {
            var so = new ObrisiPacijentSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Pacijent> VratiListuSvi()
        {
            var so = new VratiListuSviPacijentSO(new List<Pacijent>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Pacijent> VratiListu(IEntity criterion)
        {
            var so = new VratiListuPacijentSO(criterion, new List<Pacijent>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
