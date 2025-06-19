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
            var blankEntity = new Mesto
            {
                Naziv = "",
                PostanskiBroj = "00000"
            };

            int id = broker.AddWithReturnId(blankEntity);
            Result = new Mesto { Id = id };
        }
    }
}
