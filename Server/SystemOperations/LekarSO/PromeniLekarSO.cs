using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PromeniLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;

        internal PromeniLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(lekar);

            List<LeS> lesLista = broker.GetByCondition(new LeS(), $"idLekar = {lekar.Id}").Cast<LeS>().ToList();

            foreach (LeS les in lesLista)
                broker.Delete(les);

            foreach (var sertifikat in lekar.Sertifikati)
            {
                LeS les = new LeS { IdLekar = lekar.Id, IdSertifikat = sertifikat.Id, DatumIzdavanja = DateTime.Now };
                broker.Add(les);
            }
        }
    }
}
