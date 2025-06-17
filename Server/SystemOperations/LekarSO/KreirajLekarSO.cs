using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class KreirajLekarSO : SystemOperationBase
    {
        private readonly Lekar lekar;
        internal Lekar Result { get; private set; }


        internal KreirajLekarSO(Lekar lekar)
        {
            this.lekar = lekar;
        }

        protected override void ExecuteConcreteOperation()
        {
            /*lekar.Id = broker.AddWithReturnId(lekar);

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

            var kriterijum = new Lekar { Id = lekar.Id };
            Result = broker.GetByCondition(kriterijum).OfType<Lekar>().FirstOrDefault();*/

            var prazanLekar = new Lekar
            {
                Ime = "",
                Prezime = "",
                Email = "placeholder@example.com",
                Sifra = "",
                KorisnickoIme = "",
            };

            int id = broker.AddWithReturnId(prazanLekar);
            Result = new Lekar { Id = id };
        }
    }
}
