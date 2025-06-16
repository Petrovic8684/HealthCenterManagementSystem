using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class ObrisiDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;
        internal Dijagnoza Result { get; private set; }

        internal ObrisiDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = dijagnoza;
            broker.Delete(dijagnoza);
        }
    }
}
