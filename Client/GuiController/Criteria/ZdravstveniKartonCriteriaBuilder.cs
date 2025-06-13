using Common.Domain;

namespace Client.GuiController.Criteria
{
    internal class ZdravstveniKartonCriteriaBuilder : ICriteriaBuilder<ZdravstveniKarton>
    {
        private readonly ZdravstveniKarton kriterijumi = new ZdravstveniKarton();

        internal ZdravstveniKartonCriteriaBuilder WithDatumOtvaranjaAfter(DateTime datum)
        {
            if (datum != DateTime.Today)
                kriterijumi.DatumOtvaranja = datum;
            return this;
        }

        internal ZdravstveniKartonCriteriaBuilder WithImeLekara(string ime)
        {
            if (!string.IsNullOrWhiteSpace(ime))
                kriterijumi.Lekar.Ime = ime.Trim();
            return this;
        }

        internal ZdravstveniKartonCriteriaBuilder WithImePacijenta(string ime)
        {
            if (!string.IsNullOrWhiteSpace(ime))
                kriterijumi.Pacijent.Ime = ime.Trim();
            return this;
        }

        internal ZdravstveniKartonCriteriaBuilder WithDijagnoza(Dijagnoza dijagnoza)
        {
            if (dijagnoza != null && dijagnoza.Id != -1)
            {
                StavkaZdravstvenogKartona stavka = new StavkaZdravstvenogKartona();
                stavka.Dijagnoza = dijagnoza;

                kriterijumi.Stavke = new List<StavkaZdravstvenogKartona>() { stavka };
            }

            return this;
        }

        public ZdravstveniKarton Build()
        {
            return kriterijumi;
        }
    }
}
