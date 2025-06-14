using Common.Domain;
using Common.Config;
using Server.SystemOperations.LekarSO;

namespace Server.Services
{
    internal class LekarService : IEntityService<Lekar>
    {
        internal Lekar Prijavi(Lekar lekar)
        {
            var so = new PrijaviLekarSO(lekar);
            so.ExecuteTemplate();

            var korisnik = so.Result;
            if (korisnik == null)
                throw new UnauthorizedAccessException();

            if (!PasswordUtility.VerifyPassword(lekar.Sifra, korisnik.Sifra))
                throw new UnauthorizedAccessException("Pogrešna lozinka.");

            return korisnik;
        }

        public void Kreiraj(Lekar lekar)
        {
            lekar.Sifra = PasswordUtility.HashPassword(lekar.Sifra);
            new KreirajLekarSO(lekar).ExecuteTemplate();
        }

        public List<Lekar> Pretrazi(Lekar kriterijum)
        {
            var so = new PretraziLekarSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(Lekar lekar)
        {
            new PromeniLekarSO(lekar).ExecuteTemplate();
        }

        public void Obrisi(Lekar lekar)
        {
            new ObrisiLekarSO(lekar).ExecuteTemplate();
        }
    }
}
