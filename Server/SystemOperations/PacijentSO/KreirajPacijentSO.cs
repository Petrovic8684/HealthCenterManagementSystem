using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class KreirajPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;
        internal Pacijent Result { get; private set; }


        internal KreirajPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            int id = broker.AddWithReturnId(pacijent);

            var kriterijum = new Pacijent { Id = id };
            Result = broker.GetByCondition(kriterijum).OfType<Pacijent>().FirstOrDefault();
        }
    }
}
