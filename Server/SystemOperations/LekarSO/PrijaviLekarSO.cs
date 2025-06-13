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
            string condition = $"email = '{lekar.Email}' AND sifra = '{lekar.Sifra}'";
            List<IEntity> lista = broker.GetByCondition(lekar, condition);

            Result = lista.Cast<Lekar>().FirstOrDefault();

            if (Result == null)
                throw new UnauthorizedAccessException();
        }
    }
}
