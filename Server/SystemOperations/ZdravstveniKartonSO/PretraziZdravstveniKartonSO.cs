using Common.Domain;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class PretraziZdravstveniKartonSO : SystemOperationBase
    {
        private readonly string kriterijumi;
        internal List<ZdravstveniKarton> Result { get; private set; }

        internal PretraziZdravstveniKartonSO(string kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<ZdravstveniKarton> lista = broker.GetByCondition(new ZdravstveniKarton(), kriterijumi).OfType<ZdravstveniKarton>().ToList();

            foreach (ZdravstveniKarton karton in lista)
            {
                List<StavkaZdravstvenogKartona> stavke = broker.GetByCondition(new StavkaZdravstvenogKartona(), $"idZdravstveniKarton IN (SELECT idZdravstveniKarton FROM stavkaZdravstvenogKartona WHERE idZdravstveniKarton = {karton.Id})").Cast<StavkaZdravstvenogKartona>().ToList(); ;

                foreach(StavkaZdravstvenogKartona stavka in  stavke)
                {
                    Dijagnoza dijagnoza = (Dijagnoza)broker.GetByCondition(new Dijagnoza(), $"idDijagnoza = {stavka.Dijagnoza.Id}")[0];
                    stavka.Dijagnoza = dijagnoza;
                }
                karton.Stavke = stavke;

                Lekar lekar = (Lekar)broker.GetByCondition(new Lekar(), $"idLekar = {karton.Lekar.Id}")[0];
                karton.Lekar = lekar;

                Pacijent pacijent = (Pacijent)broker.GetByCondition(new Pacijent(), $"idPacijent = {karton.Pacijent.Id}")[0];
                karton.Pacijent = pacijent;
            }

            Result = lista;
        }
    }
}
