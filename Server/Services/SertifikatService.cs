using Common.Domain;
using Server.SystemOperations.SertifikatSO;
using Server.SystemOperations.ZdravstveniKartonSO;

namespace Server.Services
{
    internal class SertifikatService : IEntityService<Sertifikat>
    {
        public Sertifikat Create(Sertifikat entity)
        {
            var so = new UbaciSertifikatSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Sertifikat Read(Sertifikat entity)
        {
            var so = new PretraziSertifikatSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Sertifikat Update(Sertifikat entity)
        {
            var so = new PromeniSertifikatSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Sertifikat Delete(Sertifikat entity)
        {
            var so = new ObrisiSertifikatSO(entity);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Sertifikat> FetchListAll()
        {
            var so = new VratiListuSviSertifikatSO(new List<Sertifikat>());
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Sertifikat> FetchList(IEntity criterion)
        {
            if (criterion is not Sertifikat sertifikatCriterion)
                throw new ArgumentException("Kriterijum mora biti tipa Sertifikat.");

            var so = new VratiListuSertifikatSO(sertifikatCriterion, new List<Sertifikat>());
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
