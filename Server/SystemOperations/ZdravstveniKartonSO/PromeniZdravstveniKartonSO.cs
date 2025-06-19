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

            StavkaZdravstvenogKartona criterionStavka = new StavkaZdravstvenogKartona();
            criterionStavka.ZdravstveniKarton.Id = zdravstveniKarton.Id;

            List<StavkaZdravstvenogKartona> list = broker.GetByCondition(criterionStavka).Cast<StavkaZdravstvenogKartona>().ToList();

            foreach (StavkaZdravstvenogKartona stavka in list)
                broker.Delete(stavka);

            foreach (StavkaZdravstvenogKartona stavka in zdravstveniKarton.Stavke)
            {
                stavka.ZdravstveniKarton.Id = zdravstveniKarton.Id;
                broker.Add(stavka);
            }

            var criterion = new ZdravstveniKarton { Id = zdravstveniKarton.Id };
            Result = broker.GetByCondition(criterion).OfType<ZdravstveniKarton>().FirstOrDefault();
        }
    }
}
