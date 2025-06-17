using System;
using Common.Domain;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class ObrisiZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton zdravstveniKarton;
        internal ZdravstveniKarton Result { get; private set; }

        internal ObrisiZdravstveniKartonSO(ZdravstveniKarton zdravstveniKarton)
        {
            this.zdravstveniKarton = zdravstveniKarton;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = zdravstveniKarton;

            StavkaZdravstvenogKartona kriterijum = new StavkaZdravstvenogKartona
            {
                ZdravstveniKarton = new ZdravstveniKarton { Id = zdravstveniKarton.Id }
            };

            List<StavkaZdravstvenogKartona> stavke = broker.GetByCondition(kriterijum).Cast<StavkaZdravstvenogKartona>().ToList();

            foreach (StavkaZdravstvenogKartona stavka in stavke)
                broker.Delete(stavka);

            broker.Delete(zdravstveniKarton);
        }
    }
}
