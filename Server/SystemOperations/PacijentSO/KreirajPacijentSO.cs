using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class KreirajPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;
        internal Pacijent Result { get; private set; }


        internal KreirajPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            int validnoMestoId = broker.GetFirstId(new Mesto());

            if (validnoMestoId == -1)
                throw new Exception("Morate kreirati bar jedno mesto pre kreiranja pacijenta.");

            var prazanPacijent = new Pacijent
            {
                Ime = "",
                Prezime = "",
                Email = "placeholder@example.com",
                Mesto = new Mesto { Id = validnoMestoId }
            };

            int id = broker.AddWithReturnId(prazanPacijent);
            Result = new Pacijent { Id = id };
        }
    }
}
