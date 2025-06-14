using Common.Domain;
using Server.SystemOperations.SertifikatSO;

namespace Server.Services
{
    internal class SertifikatService : IEntityService<Sertifikat>
    {
        public void Kreiraj(Sertifikat sertifikat)
        {
            new UbaciSertifikatSO(sertifikat).ExecuteTemplate();
        }

        public List<Sertifikat> Pretrazi(Sertifikat kriterijum)
        {
            var so = new PretraziSertifikatSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void Promeni(Sertifikat sertifikat)
        {
            new PromeniSertifikatSO(sertifikat).ExecuteTemplate();
        }

        public void Obrisi(Sertifikat sertifikat)
        {
            new ObrisiSertifikatSO(sertifikat).ExecuteTemplate();
        }
    }
}
