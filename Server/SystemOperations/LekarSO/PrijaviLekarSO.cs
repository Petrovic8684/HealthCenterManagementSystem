using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PrijaviLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;
        internal Lekar Result { get; set; }

        internal PrijaviLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            Lekar kriterijum = new Lekar
            {
                Email = lekar.Email
            };

            List<IEntity> lista = broker.GetByCondition(kriterijum);

            Result = lista.Cast<Lekar>().FirstOrDefault();

            if (Result == null)
                throw new UnauthorizedAccessException();
        }
    }
}
