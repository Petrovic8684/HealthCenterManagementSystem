using Common.Domain;

namespace Client.GuiController.Criteria
{
    internal class DijagnozaCriteriaBuilder : ICriteriaBuilder<Dijagnoza>
    {
        private readonly Dijagnoza kriterijumi = new Dijagnoza();

        internal DijagnozaCriteriaBuilder WithNaziv(string naziv)
        {
            if (!string.IsNullOrWhiteSpace(naziv))
                kriterijumi.Naziv = naziv.Trim();
            return this;
        }

        internal DijagnozaCriteriaBuilder WithOpis(string opis)
        {
            if (!string.IsNullOrWhiteSpace(opis))
                kriterijumi.Opis = opis.Trim();
            return this;
        }

        public Dijagnoza Build()
        {
            return kriterijumi;
        }
    }
}
