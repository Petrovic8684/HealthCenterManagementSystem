using Common.Domain;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class PromeniZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton zdravstveniKarton;
        internal ZdravstveniKarton Result { get; private set; }

        internal PromeniZdravstveniKartonSO(ZdravstveniKarton zdravstveniKarton)
        {
            this.zdravstveniKarton = zdravstveniKarton;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(zdravstveniKarton);

            StavkaZdravstvenogKartona kriterijum = new StavkaZdravstvenogKartona();
            kriterijum.ZdravstveniKarton.Id = zdravstveniKarton.Id;

            List<StavkaZdravstvenogKartona> stavke = broker.GetByCondition(kriterijum).Cast<StavkaZdravstvenogKartona>().ToList();

            foreach (StavkaZdravstvenogKartona stavka in stavke)
                broker.Delete(stavka);

            foreach (StavkaZdravstvenogKartona stavka in zdravstveniKarton.Stavke)
            {
                stavka.ZdravstveniKarton.Id = zdravstveniKarton.Id;
                broker.Add(stavka);
            }

            var krit = new ZdravstveniKarton { Id = zdravstveniKarton.Id };
            Result = broker.GetByCondition(krit).OfType<ZdravstveniKarton>().FirstOrDefault();
        }
    }
}
