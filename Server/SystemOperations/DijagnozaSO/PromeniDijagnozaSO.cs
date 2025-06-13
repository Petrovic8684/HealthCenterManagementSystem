using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class PromeniDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;

        internal PromeniDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(dijagnoza);
        }
    }
}
