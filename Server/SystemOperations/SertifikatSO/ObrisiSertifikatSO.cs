using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class ObrisiSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;

        internal ObrisiSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(sertifikat);
        }
    }
}
