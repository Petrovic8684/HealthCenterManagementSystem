using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class UbaciSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;

        internal UbaciSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(sertifikat);
        }
    }
}
