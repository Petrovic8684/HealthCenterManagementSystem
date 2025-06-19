using Common.Domain;
using Sprache;

namespace Server.SystemOperations.DijagnozaSO
{
    internal class PromeniDijagnozaSO : SystemOperationBase
    {
        private readonly Dijagnoza dijagnoza;
        internal Dijagnoza Result { get; private set; }

        internal PromeniDijagnozaSO(Dijagnoza dijagnoza)
        {
            this.dijagnoza = dijagnoza;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(dijagnoza);

            var criterion = new Dijagnoza { Id = dijagnoza.Id };
            Result = broker.GetByCondition(criterion).OfType<Dijagnoza>().FirstOrDefault();
        }
    }
}
