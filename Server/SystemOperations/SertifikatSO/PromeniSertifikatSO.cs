using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class PromeniSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat sertifikat;
        internal Sertifikat Result { get; private set; }

        internal PromeniSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(sertifikat);

            var kriterijum = new Sertifikat { Id = sertifikat.Id };
            Result = broker.GetByCondition(kriterijum).OfType<Sertifikat>().FirstOrDefault();
        }
    }
}
