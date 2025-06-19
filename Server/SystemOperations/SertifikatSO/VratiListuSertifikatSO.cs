using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.SertifikatSO
{
    internal class VratiListuSertifikatSO : SystemOperationBase
    {
        private readonly Sertifikat criteria;
        private List<Sertifikat> list;
        internal List<Sertifikat> Result { get; private set; }

        internal VratiListuSertifikatSO(Sertifikat criteria, List<Sertifikat> list)
        {
            this.criteria = criteria;
            this.list = list;
            Result = new List<Sertifikat>();
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(criteria).Cast<Sertifikat>().ToList();
            Result = list;
        }
    }
}
