using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class UbaciSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;
        internal Sertifikat Result { get; private set; }

        internal UbaciSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            /*int id = broker.AddWithReturnId(sertifikat);

            var kriterijum = new Sertifikat { Id = id };
            Result = broker.GetByCondition(kriterijum).OfType<Sertifikat>().FirstOrDefault();*/

            var prazanSertifikat = new Sertifikat
            {
                Opis = ""
            };

            int id = broker.AddWithReturnId(prazanSertifikat);
            Result = new Sertifikat { Id = id };
        }
    }
}
