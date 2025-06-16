using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class ObrisiPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;
        internal Pacijent Result { get; private set; }

        internal ObrisiPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = pacijent;
            broker.Delete(pacijent);
        }
    }
}
