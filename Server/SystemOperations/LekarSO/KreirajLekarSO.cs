using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class KreirajLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;

        internal KreirajLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            lekar.Id = broker.AddWithReturnId(lekar);

            foreach (var sertifikat in lekar.Sertifikati)
            {
                LeS les = new LeS
                {
                    IdLekar = lekar.Id,
                    IdSertifikat = sertifikat.Id,
                    DatumIzdavanja = DateTime.Now
                };

                broker.Add(les);
            }
        }
    }
}
