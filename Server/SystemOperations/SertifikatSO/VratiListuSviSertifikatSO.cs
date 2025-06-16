using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.SertifikatSO
{
    internal class VratiListuSviSertifikatSO : SystemOperationBase
    {
        private List<Sertifikat> list;
        internal List<Sertifikat> Result { get; private set; }

        internal VratiListuSviSertifikatSO(List<Sertifikat> list)
        {
            this.list = list;
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetAll(new Sertifikat()).Cast<Sertifikat>().ToList();
            Result = list;
        }
    }
}
