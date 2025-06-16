using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class PretraziZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton zdravstveniKarton;
        internal ZdravstveniKarton Result { get; private set; }

        internal PretraziZdravstveniKartonSO(ZdravstveniKarton zdravstveniKarton)
        {
            this.zdravstveniKarton = zdravstveniKarton;
        }

        protected override void ExecuteConcreteOperation()
        {
            var kriterijum = new ZdravstveniKarton { Id = zdravstveniKarton.Id };
            Result = broker.GetByCondition(kriterijum).OfType<ZdravstveniKarton>().FirstOrDefault();
        }
    }
}
