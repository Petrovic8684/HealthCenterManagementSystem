using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class PretraziSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;
        internal Sertifikat Result { get; private set; }

        internal PretraziSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            var criterion = new Sertifikat { Id = sertifikat.Id };
            Result = broker.GetByCondition(criterion).OfType<Sertifikat>().FirstOrDefault();
        }
    }
}
