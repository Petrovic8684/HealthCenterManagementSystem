using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.LekarSO
{
    internal class VratiListuSviLekarSO : SystemOperationBase
    {
        private List<Lekar> list;
        internal List<Lekar> Result { get; private set; }

        internal VratiListuSviLekarSO(List<Lekar> list)
        {
            this.list = list;
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(new Lekar()).Cast<Lekar>().ToList();
            Result = list;
        }
    }
}
