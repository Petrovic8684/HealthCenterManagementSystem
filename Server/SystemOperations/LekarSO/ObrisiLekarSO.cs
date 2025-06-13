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
            List<LeS> lesLista = broker.GetByCondition(new LeS(), $"idLekar = {lekar.Id}").Cast<LeS>().ToList();

            foreach (LeS les in lesLista)
                broker.Delete(les);

            broker.Delete(lekar);
        }
    }
}
