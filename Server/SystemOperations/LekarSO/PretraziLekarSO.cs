using Common.Domain;

namespace Server.SystemOperations.LekarSO
{
    internal class PretraziLekarSO : SystemOperationBase
    {
        private readonly string kriterijumi;
        internal List<Lekar> Result { get; private set; }

        internal PretraziLekarSO(string kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<Lekar> lista = broker.GetByCondition(new Lekar(), kriterijumi).OfType<Lekar>().ToList();

            foreach (Lekar lekar in lista)
            {
                List<IEntity> sertifikati = broker.GetByCondition(new Sertifikat(), $"idSertifikat IN (SELECT idSertifikat FROM les WHERE idLekar = {lekar.Id})");
                lekar.Sertifikati = sertifikati.Cast<Sertifikat>().ToList();
            }

            Result = lista;
        }
    }
}
