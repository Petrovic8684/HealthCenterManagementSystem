using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class PretraziDijagnozaSO : SystemOperationBase
    {
        private readonly string kriterijumi;
        internal List<Dijagnoza> Result { get; private set; }

        internal PretraziDijagnozaSO(string kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(new Dijagnoza(), kriterijumi);
            Result = lista.OfType<Dijagnoza>().ToList();
        }
    }
}
