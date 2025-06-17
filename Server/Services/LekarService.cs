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

            var lekar = so.Result;
            if (lekar == null)
                throw new UnauthorizedAccessException();

            if (!PasswordUtility.VerifyPassword(entity.Sifra, lekar.Sifra))
                throw new UnauthorizedAccessException("Pogrešna lozinka.");

            return lekar;
        }

        public Lekar Kreiraj(Lekar entity)
        {
            var so = new KreirajLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Pretrazi(Lekar entity)
        {
            var so = new PretraziLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Promeni(Lekar entity)
        {
            entity.Sifra = PasswordUtility.HashPassword(entity.Sifra);

            var so = new PromeniLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Lekar Obrisi(Lekar entity)
        {
            var so = new ObrisiLekarSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Lekar> VratiListuSvi()
        {
            var so = new VratiListuSviLekarSO(new List<Lekar>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Lekar> VratiListu(IEntity criterion)
        {
            var so = new VratiListuLekarSO(criterion, new List<Lekar>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
