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
            int validMestoId = broker.GetFirstId(new Mesto());

            if (validMestoId == -1)
                throw new Exception("Mora postojati bar jedno mesto pre kreiranja pacijenta.");

            var blankEntity = new Pacijent
            {
                Ime = "",
                Prezime = "",
                Email = "placeholder@example.com",
                Mesto = new Mesto { Id = validMestoId }
            };

            int id = broker.AddWithReturnId(blankEntity);
            Result = new Pacijent { Id = id };
        }
    }
}
