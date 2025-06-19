using Common.Config;
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
            lekar.Sifra = PasswordUtility.HashPassword(lekar.Sifra);

            broker.Update(lekar);

            LeS criterionLeS = new LeS
            {
                IdLekar = lekar.Id
            };

            List<LeS> lesList = broker.GetByCondition(criterionLeS).Cast<LeS>().ToList();

            foreach (LeS les in lesList)
                broker.Delete(les);

            foreach (var sertifikat in lekar.Sertifikati)
            {
                LeS les = new LeS { IdLekar = lekar.Id, IdSertifikat = sertifikat.Id, DatumIzdavanja = DateTime.Now };
                broker.Add(les);
            }

            var criterion = new Lekar { Id = lekar.Id };
            Result = broker.GetByCondition(criterion).OfType<Lekar>().FirstOrDefault();
        }
    }
}
