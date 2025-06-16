using Common.Domain;
using DBBroker;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class VratiListuSviDijagnozaSO : SystemOperationBase
    {
        private List<Dijagnoza> list;
        internal List<Dijagnoza> Result { get; private set; }

        internal VratiListuSviDijagnozaSO(List<Dijagnoza> list)
        {
            this.list = list;
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetAll(new Dijagnoza()).Cast<Dijagnoza>().ToList();
            Result = list;
        }
    }
}
