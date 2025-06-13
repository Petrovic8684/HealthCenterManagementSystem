using Common.Domain;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class PromeniZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton zdravstveniKarton;

        internal PromeniZdravstveniKartonSO(ZdravstveniKarton zdravstveniKarton)
        {
            this.zdravstveniKarton = zdravstveniKarton;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(zdravstveniKarton);

            List<StavkaZdravstvenogKartona> stavke = broker.GetByCondition(new StavkaZdravstvenogKartona(), $"idZdravstveniKarton = {zdravstveniKarton.Id}").Cast<StavkaZdravstvenogKartona>().ToList();

            foreach (StavkaZdravstvenogKartona stavka in stavke)
                broker.Delete(stavka);

            foreach (StavkaZdravstvenogKartona stavka in zdravstveniKarton.Stavke)
                broker.Add(stavka);
        }
    }
}
