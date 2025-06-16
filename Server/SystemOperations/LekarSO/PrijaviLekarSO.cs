using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PrijaviLekarSO : SystemOperationBase
    {
        private readonly string korisnickoIme;
        private readonly string sifra;
        internal Lekar Result { get; set; }

        internal PrijaviLekarSO(string korisnickoIme, string sifra)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteConcreteOperation()
        {
            Lekar kriterijum = new Lekar
            {
                KorisnickoIme = korisnickoIme
            };

            List<IEntity> lista = broker.GetByCondition(kriterijum);

            Result = lista.Cast<Lekar>().FirstOrDefault();

            if (Result == null)
                throw new UnauthorizedAccessException();
        }
    }
}
