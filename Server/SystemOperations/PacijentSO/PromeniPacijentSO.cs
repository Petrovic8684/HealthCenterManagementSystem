using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class PromeniPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;
        internal Pacijent Result { get; private set; }

        internal PromeniPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(pacijent);

            var criterion = new Pacijent { Id = pacijent.Id };
            Result = broker.GetByCondition(criterion).OfType<Pacijent>().FirstOrDefault();
        }
    }
}
