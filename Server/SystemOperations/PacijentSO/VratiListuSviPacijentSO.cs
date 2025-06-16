using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.PacijentSO
{
    internal class VratiListuSviPacijentSO : SystemOperationBase
    {
        private List<Pacijent> list;
        internal List<Pacijent> Result { get; private set; }

        internal VratiListuSviPacijentSO(List<Pacijent> list)
        {
            this.list = list;
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(new Pacijent()).Cast<Pacijent>().ToList();
            Result = list;
        }
    }
}
