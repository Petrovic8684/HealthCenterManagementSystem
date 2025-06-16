using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.MestoSO
{
    internal class VratiListuSviMestoSO : SystemOperationBase
    {
        private List<Mesto> list;
        internal List<Mesto> Result { get; private set; }

        internal VratiListuSviMestoSO(List<Mesto> list)
        {
            this.list = list;
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
            Result = list;
        }
    }
}
