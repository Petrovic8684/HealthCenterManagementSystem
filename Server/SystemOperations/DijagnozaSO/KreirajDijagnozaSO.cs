using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class KreirajDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;
        internal Dijagnoza Result { get; private set; }

        internal KreirajDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            var praznaDijagnoza = new Dijagnoza
            {
                Naziv = "",
                Opis = "",
                BazniSkor = 1
            };

            int id = broker.AddWithReturnId(praznaDijagnoza);
            Result = new Dijagnoza { Id = id };
        }
    }
}
