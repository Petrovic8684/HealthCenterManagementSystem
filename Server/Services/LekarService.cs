using Common.Domain;
using Common.Config;
using Server.SystemOperations.LekarSO;
using Server.SystemOperations.PacijentSO;

namespace Server.Services
{
    internal class LekarService : IEntityService<Lekar>
    {
        internal Lekar Prijavi(Lekar entity)
        {
            var so = new PrijaviLekarSO(entity.KorisnickoIme, entity.Sifra);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Create(Lekar entity)
        {
            var so = new KreirajLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Read(Lekar entity)
        {
            var so = new PretraziLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Update(Lekar entity)
        {
            var so = new PromeniLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Delete(Lekar entity)
        {
            var so = new ObrisiLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Lekar> FetchListAll()
        {
            var so = new VratiListuSviLekarSO(new List<Lekar>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Lekar> FetchList(IEntity criterion)
        {
            var so = new VratiListuLekarSO(criterion, new List<Lekar>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
