using Common.Domain;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class PretraziDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;
        internal Dijagnoza Result { get; private set; }

        internal PretraziDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            var criterion = new Dijagnoza { Id = dijagnoza.Id };
            Result = broker.GetByCondition(criterion).OfType<Dijagnoza>().FirstOrDefault();
        }
    }
}
