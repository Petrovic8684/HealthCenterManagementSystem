using Common.Domain;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class KreirajZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton zdravstveniKarton;

        internal KreirajZdravstveniKartonSO(ZdravstveniKarton zdravstveniKarton)
        {
            this.zdravstveniKarton = zdravstveniKarton;
        }

        protected override void ExecuteConcreteOperation()
        {
            int generatedId = broker.AddWithReturnId(zdravstveniKarton);
            zdravstveniKarton.Id = generatedId;

            foreach (var stavka in zdravstveniKarton.Stavke)
                stavka.ZdravstveniKarton.Id = generatedId;

            foreach (var stavka in zdravstveniKarton.Stavke)
                broker.Add(stavka);
        }
    }
}
