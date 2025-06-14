using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class PretraziPacijentSO : SystemOperationBase
    {
        private readonly Pacijent kriterijumi;
        internal List<Pacijent> Result { get; private set; }

        internal PretraziPacijentSO(Pacijent kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kriterijumi);
            Result = lista.OfType<Pacijent>().ToList();
        }
    }
}
