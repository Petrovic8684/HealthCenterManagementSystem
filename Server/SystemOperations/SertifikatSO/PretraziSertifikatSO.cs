using Common.Domain;

namespace Server.SystemOperations.SertifikatSO
{
    internal class PretraziSertifikatSO : SystemOperationBase
    {
        private readonly string kriterijumi;
        internal List<Sertifikat> Result { get; private set; }

        internal PretraziSertifikatSO(string kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(new Sertifikat(), kriterijumi);
            Result = lista.OfType<Sertifikat>().ToList();
        }
    }
}
