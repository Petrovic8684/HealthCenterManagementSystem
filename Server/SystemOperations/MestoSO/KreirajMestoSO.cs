using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class KreirajMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;

        internal KreirajMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(mesto);
        }
    }
}
