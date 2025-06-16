using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class KreirajMestoSO : SystemOperationBase
    {
        private readonly Mesto mesto;
        internal Mesto Result { get; private set; }

        internal KreirajMestoSO(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            int id = broker.AddWithReturnId(mesto);

            var kriterijum = new Mesto { Id = id };
            Result = broker.GetByCondition(kriterijum).OfType<Mesto>().FirstOrDefault();
        }
    }
}
