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

            var kriterijum = new Mesto { Id = mesto.Id };
            Result = broker.GetByCondition(kriterijum).OfType<Mesto>().FirstOrDefault();
        }
    }
}
