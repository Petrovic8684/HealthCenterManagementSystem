using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class KreirajPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;

        internal KreirajPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(pacijent);
        }
    }
}
