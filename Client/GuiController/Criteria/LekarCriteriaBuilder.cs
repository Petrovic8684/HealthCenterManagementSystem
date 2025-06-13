using Common.Domain;

namespace Client.GuiController.Criteria
{
    internal class LekarCriteriaBuilder : ICriteriaBuilder<Lekar>
    {
        private readonly Lekar kriterijumi = new Lekar();

        internal LekarCriteriaBuilder WithIme(string ime)
        {
            if (!string.IsNullOrWhiteSpace(ime))
                kriterijumi.Ime = ime.Trim();
            return this;
        }

        internal LekarCriteriaBuilder WithPrezime(string prezime)
        {
            if (!string.IsNullOrWhiteSpace(prezime))
                kriterijumi.Prezime = prezime.Trim();
            return this;
        }

        internal LekarCriteriaBuilder WithSertifikat(Sertifikat sertifikat)
        {
            if (sertifikat != null && sertifikat.Id != -1)
                kriterijumi.Sertifikati = new List<Sertifikat> { sertifikat };

            return this;
        }

        public Lekar Build()
        {
            return kriterijumi;
        }
    }
}
