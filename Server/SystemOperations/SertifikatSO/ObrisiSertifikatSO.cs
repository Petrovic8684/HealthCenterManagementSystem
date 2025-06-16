using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class ObrisiSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;
        internal Sertifikat Result { get; private set; }

        internal ObrisiSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = sertifikat;
            broker.Delete(sertifikat);
        }
    }
}
