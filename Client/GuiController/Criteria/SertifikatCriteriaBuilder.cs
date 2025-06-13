using Common.Domain;

namespace Client.GuiController.Criteria
{
    internal class SertifikatCriteriaBuilder : ICriteriaBuilder<Sertifikat>
    {
        private readonly Sertifikat kriterijumi = new Sertifikat();

        internal SertifikatCriteriaBuilder WithOpis(string opis)
        {
            if (!string.IsNullOrWhiteSpace(opis))
                kriterijumi.Opis = opis.Trim();
            return this;
        }

        public Sertifikat Build()
        {
            return kriterijumi;
        }
    }
}
