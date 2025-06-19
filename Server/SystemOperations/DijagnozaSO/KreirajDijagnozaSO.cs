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
            var blankEntity = new Dijagnoza
            {
                Naziv = "",
                Opis = "",
                BazniSkor = 1
            };

            int id = broker.AddWithReturnId(blankEntity);
            Result = new Dijagnoza { Id = id };
        }
    }
}
