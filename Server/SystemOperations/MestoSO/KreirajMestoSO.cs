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
            /*int id = broker.AddWithReturnId(mesto);

            var kriterijum = new Mesto { Id = id };
            Result = broker.GetByCondition(kriterijum).OfType<Mesto>().FirstOrDefault();*/

            var praznoMesto = new Mesto
            {
                Naziv = "",
                PostanskiBroj = "00000"
            };

            int id = broker.AddWithReturnId(praznoMesto);
            Result = new Mesto { Id = id };
        }
    }
}
