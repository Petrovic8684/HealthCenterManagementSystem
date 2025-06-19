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
            int validLekarId = broker.GetFirstId(new Lekar());

            if (validLekarId == -1)
                throw new Exception("Mora postojati bar jedan lekar pre kreiranja zdravstvenog kartona.");

            int validPacijentId = broker.GetFirstId(new Pacijent());

            if (validPacijentId == -1)
                throw new Exception("Mora postojati bar jedan pacijent pre kreiranja zdravstvenog kartona.");

            var blankEntity = new ZdravstveniKarton
            {
                DatumOtvaranja = DateTime.Now.Date,
                Napomena = "",
                Lekar = new Lekar { Id = validLekarId },
                Pacijent = new Pacijent { Id = validPacijentId },
            };

            int id = broker.AddWithReturnId(blankEntity);
            Result = new ZdravstveniKarton { Id = id };
        }
    }
}
