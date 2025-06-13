using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class ObrisiPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;

        internal ObrisiPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(pacijent);
        }
    }
}
