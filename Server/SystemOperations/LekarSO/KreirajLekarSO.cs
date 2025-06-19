using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class KreirajLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;
        internal Lekar Result { get; private set; }


        internal KreirajLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            var blankEntity = new Lekar
            {
                Ime = "",
                Prezime = "",
                Email = "placeholder@example.com",
                Sifra = "",
                KorisnickoIme = "",
            };

            int id = broker.AddWithReturnId(blankEntity);
            Result = new Lekar { Id = id };
        }
    }
}
