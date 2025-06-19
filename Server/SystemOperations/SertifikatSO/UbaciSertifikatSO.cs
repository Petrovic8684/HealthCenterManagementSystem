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
            var blankEntity = new Sertifikat
            {
                Opis = ""
            };

            int id = broker.AddWithReturnId(blankEntity);
            Result = new Sertifikat { Id = id };
        }
    }
}
