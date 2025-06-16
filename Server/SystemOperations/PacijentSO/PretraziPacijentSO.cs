using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class PretraziPacijentSO : SystemOperationBase
    {
        private readonly Pacijent pacijent;
        internal Pacijent Result { get; private set; }

        internal PretraziPacijentSO(Pacijent pacijent)
        {
            this.pacijent = pacijent;
        }

        protected override void ExecuteConcreteOperation()
        {
            var kriterijum = new Pacijent { Id = pacijent.Id };
            Result = broker.GetByCondition(kriterijum).OfType<Pacijent>().FirstOrDefault();
        }
    }
}
