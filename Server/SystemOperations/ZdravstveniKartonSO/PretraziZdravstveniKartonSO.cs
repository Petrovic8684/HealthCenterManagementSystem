using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class PretraziZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton kriterijumi;
        internal List<ZdravstveniKarton> Result { get; private set; }

        internal PretraziZdravstveniKartonSO(ZdravstveniKarton kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kriterijumi);
            Result = lista.Cast<ZdravstveniKarton>().ToList();
        }
    }
}
