using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class VratiListuDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza kriterijumi;
        private List<Dijagnoza> list;
        internal List<Dijagnoza> Result { get; private set; }

        internal VratiListuDijagnozaSO(Dijagnoza kriterijumi, List<Dijagnoza> list)
        {
            this.kriterijumi = kriterijumi;
            this.list = list;
            Result = new List<Dijagnoza>();
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(kriterijumi).Cast<Dijagnoza>().ToList();
            Result = list;
        }
    }
}
