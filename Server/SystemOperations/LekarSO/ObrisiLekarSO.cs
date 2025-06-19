using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class ObrisiLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;
        internal Lekar Result { get; private set; }

        internal ObrisiLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = lekar;

            LeS criterion = new LeS
            {
                IdLekar = lekar.Id
            };

            List<LeS> lesLista = broker.GetByCondition(criterion).Cast<LeS>().ToList();

            foreach (LeS les in lesLista)
                broker.Delete(les);

            broker.Delete(lekar);
        }
    }
}
