using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.MestoSO
{
    internal class VratiListuMestoSO : SystemOperationBase
    {
        private readonly Mesto criteria;
        private List<Mesto> list;
        internal List<Mesto> Result { get; private set; }

        internal VratiListuMestoSO(Mesto criteria, List<Mesto> list)
        {
            this.criteria = criteria;
            this.list = list;
            Result = new List<Mesto>();
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(criteria).Cast<Mesto>().ToList();
            Result = list;
        }
    }
}
