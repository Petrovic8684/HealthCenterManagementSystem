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
        private readonly Sertifikat kriterijumi;
        private List<Sertifikat> list;
        internal List<Sertifikat> Result { get; private set; }

        internal VratiListuSertifikatSO(Sertifikat kriterijumi, List<Sertifikat> list)
        {
            this.kriterijumi = kriterijumi;
            this.list = list;
            Result = new List<Sertifikat>();
        }

        protected override void ExecuteConcreteOperation()
        {
            list = broker.GetByCondition(kriterijumi).Cast<Sertifikat>().ToList();
            Result = list;
        }
    }
}
