using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class PromeniMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;
        internal Mesto Result { get; private set; }

        internal PromeniMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(mesto);

            var criterion = new Mesto { Id = mesto.Id };
            Result = broker.GetByCondition(criterion).OfType<Mesto>().FirstOrDefault();
        }
    }
}
