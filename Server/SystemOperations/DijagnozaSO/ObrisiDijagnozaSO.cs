using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class ObrisiDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;

        internal ObrisiDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(dijagnoza);
        }
    }
}
