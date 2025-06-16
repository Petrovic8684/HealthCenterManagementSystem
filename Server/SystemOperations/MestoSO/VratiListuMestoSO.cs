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
        private readonly Mesto kriterijumi;
        private List<Mesto> list;
        internal List<Mesto> Result { get; private set; }

        internal VratiListuMestoSO(Mesto kriterijumi, List<Mesto> list)
        {
            this.kriterijumi = kriterijumi;
            this.list = list;
            Result = new List<Mesto>();
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(kriterijumi).Cast<Mesto>().ToList();
            Result = list;
        }
    }
}
