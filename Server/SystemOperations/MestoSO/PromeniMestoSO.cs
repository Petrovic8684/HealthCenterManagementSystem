using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class PromeniMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;

        internal PromeniMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(mesto);
        }
    }
}
