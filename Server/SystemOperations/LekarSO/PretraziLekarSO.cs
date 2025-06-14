using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PretraziLekarSO : SystemOperationBase
    {
        private readonly Lekar kriterijumi;
        internal List<Lekar> Result { get; private set; }

        internal PretraziLekarSO(Lekar kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kriterijumi);
            Result = lista.OfType<Lekar>().ToList();
        }
    }
}
