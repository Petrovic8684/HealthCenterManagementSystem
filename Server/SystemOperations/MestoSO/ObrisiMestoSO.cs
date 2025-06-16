using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class ObrisiMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;
        internal Mesto Result { get; private set; }


        internal ObrisiMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = mesto;
            broker.Delete(mesto);
        }
    }
}
