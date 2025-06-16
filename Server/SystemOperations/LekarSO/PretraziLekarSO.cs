using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PretraziLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;
        internal Lekar Result { get; private set; }

        internal PretraziLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            var kriterijum = new Lekar { Id = lekar.Id };
            Result = broker.GetByCondition(kriterijum).OfType<Lekar>().FirstOrDefault();
        }
    }
}
