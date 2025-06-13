using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class ObrisiMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;

        internal ObrisiMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(mesto);
        }
    }
}
