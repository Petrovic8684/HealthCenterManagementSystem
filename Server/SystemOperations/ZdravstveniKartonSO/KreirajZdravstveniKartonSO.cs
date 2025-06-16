using Common.Domain;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class KreirajZdravstveniKartonSO : SystemOperationBase
    {
        private readonly ZdravstveniKarton zdravstveniKarton;
        internal ZdravstveniKarton Result { get; private set; }

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

            var kriterijum = new ZdravstveniKarton { Id = generatedId };
            Result = broker.GetByCondition(kriterijum).OfType<ZdravstveniKarton>().FirstOrDefault();
        }
    }
}
