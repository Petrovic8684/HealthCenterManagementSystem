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
            int id = broker.AddWithReturnId(dijagnoza);

            var kriterijum = new Dijagnoza { Id = id };
            Result = broker.GetByCondition(kriterijum).OfType<Dijagnoza>().FirstOrDefault();
        }
    }
}
