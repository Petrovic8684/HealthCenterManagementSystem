using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class ObrisiLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;

        internal ObrisiLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            LeS kriterijum = new LeS
            {
                IdLekar = lekar.Id
            };

            List<LeS> lesLista = broker.GetByCondition(kriterijum).Cast<LeS>().ToList();

            foreach (LeS les in lesLista)
                broker.Delete(les);

            broker.Delete(lekar);
        }
    }
}
