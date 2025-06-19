using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class VratiListuDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza criteria;
        private List<Dijagnoza> list;
        internal List<Dijagnoza> Result { get; private set; }

        internal VratiListuDijagnozaSO(Dijagnoza criteria, List<Dijagnoza> list)
        {
            this.criteria = criteria;
            this.list = list;
            Result = new List<Dijagnoza>();
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(criteria).Cast<Dijagnoza>().ToList();
            Result = list;
        }
    }
}
