using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class PretraziSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat kriterijumi;
        internal List<Sertifikat> Result { get; private set; }

        internal PretraziSertifikatSO(Sertifikat kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kriterijumi);
            Result = lista.OfType<Sertifikat>().ToList();
        }
    }
}
