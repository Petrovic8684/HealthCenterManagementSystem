using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class PretraziDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza kriterijumi;
        internal List<Dijagnoza> Result { get; private set; }

        internal PretraziDijagnozaSO(Dijagnoza kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kriterijumi);
            Result = lista.OfType<Dijagnoza>().ToList();
        }
    }
}
