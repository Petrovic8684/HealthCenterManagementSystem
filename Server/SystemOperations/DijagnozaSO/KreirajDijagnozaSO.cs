using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class KreirajDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;

        internal KreirajDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(dijagnoza);
        }
    }
}
