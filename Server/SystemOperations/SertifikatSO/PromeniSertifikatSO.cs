using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class PromeniSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;

        internal PromeniSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(sertifikat);
        }
    }
}
