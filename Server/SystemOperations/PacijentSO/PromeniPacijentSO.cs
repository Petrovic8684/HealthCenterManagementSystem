using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class PromeniPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;

        internal PromeniPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(pacijent);
        }
    }
}
