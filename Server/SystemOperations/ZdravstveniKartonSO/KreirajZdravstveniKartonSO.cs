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
            /*int generatedId = broker.AddWithReturnId(zdravstveniKarton);
            zdravstveniKarton.Id = generatedId;

            foreach (var stavka in zdravstveniKarton.Stavke)
                stavka.ZdravstveniKarton.Id = generatedId;

            foreach (var stavka in zdravstveniKarton.Stavke)
                broker.Add(stavka);

            var kriterijum = new ZdravstveniKarton { Id = generatedId };
            Result = broker.GetByCondition(kriterijum).OfType<ZdravstveniKarton>().FirstOrDefault();*/

            int validanLekarId = broker.GetFirstId(new Lekar());

            if (validanLekarId == -1)
                throw new Exception("Morate kreirati bar jedng lekara pre kreiranja zdravstvenog kartona.");

            int validanPacijentId = broker.GetFirstId(new Pacijent());

            if (validanPacijentId == -1)
                throw new Exception("Morate kreirati bar jedng pacijenta pre kreiranja zdravstvenog kartona.");

            var prazanZdravstveniKarton = new ZdravstveniKarton
            {
                DatumOtvaranja = DateTime.Now.Date,
                Napomena = "",
                Lekar = new Lekar { Id = validanLekarId },
                Pacijent = new Pacijent { Id = validanPacijentId },
            };

            int id = broker.AddWithReturnId(prazanZdravstveniKarton);
            Result = new ZdravstveniKarton { Id = id };
        }
    }
}
