using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class PretraziMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;
        internal Mesto Result { get; private set; }

        internal PretraziMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            var criterion = new Mesto { Id = mesto.Id };
            Result = broker.GetByCondition(criterion).OfType<Mesto>().FirstOrDefault();
        }
    }
}
