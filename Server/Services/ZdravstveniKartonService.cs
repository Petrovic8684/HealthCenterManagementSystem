using Common.Domain;
using Server.SystemOperations.ZdravstveniKartonSO;

namespace Server.Services
{
    internal class ZdravstveniKartonService : IEntityService<ZdravstveniKarton>
    {
        public void Kreiraj(ZdravstveniKarton zdravstveniKarton)
        {
            new KreirajZdravstveniKartonSO(zdravstveniKarton).ExecuteTemplate();
        }

        public List<ZdravstveniKarton> Pretrazi(ZdravstveniKarton kriterijum)
        {
            var so = new PretraziZdravstveniKartonSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(ZdravstveniKarton zdravstveniKarton)
        {
            new PromeniZdravstveniKartonSO(zdravstveniKarton).ExecuteTemplate();
        }

        public void Obrisi(ZdravstveniKarton zdravstveniKarton) { }
    }
}
