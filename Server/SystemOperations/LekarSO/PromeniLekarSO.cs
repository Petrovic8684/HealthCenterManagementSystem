using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PromeniLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;
        internal Lekar Result { get; private set; }


        internal PromeniLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(lekar);

            LeS kriterijum = new LeS
            {
                IdLekar = lekar.Id
            };

            List<LeS> lesLista = broker.GetByCondition(kriterijum).Cast<LeS>().ToList();

            foreach (LeS les in lesLista)
                broker.Delete(les);

            foreach (var sertifikat in lekar.Sertifikati)
            {
                LeS les = new LeS { IdLekar = lekar.Id, IdSertifikat = sertifikat.Id, DatumIzdavanja = DateTime.Now };
                broker.Add(les);
            }

            var krit = new Lekar { Id = lekar.Id };
            Result = broker.GetByCondition(krit).OfType<Lekar>().FirstOrDefault();
        }
    }
}
