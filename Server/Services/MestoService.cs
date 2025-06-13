using Common.Domain;
using Server.SystemOperations.MestoSO;

namespace Server.Services
{
    internal class MestoService : IEntityService<Mesto>
    {
        public void Kreiraj(Mesto mesto)
        {
            new KreirajMestoSO(mesto).ExecuteTemplate();
        }

        public List<Mesto> Pretrazi(string kriterijum)
        {
            var so = new PretraziMestoSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(Mesto mesto)
        {
            new PromeniMestoSO(mesto).ExecuteTemplate();
        }

        public void Obrisi(Mesto mesto)
        {
            new ObrisiMestoSO(mesto).ExecuteTemplate();
        }
    }
}
