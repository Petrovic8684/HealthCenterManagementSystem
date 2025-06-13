using Common.Domain;

namespace Client.GuiController.Criteria
{
    internal class MestoCriteriaBuilder : ICriteriaBuilder<Mesto>
    {
        private readonly Mesto kriterijumi = new Mesto();

        internal MestoCriteriaBuilder WithNaziv(string naziv)
        {
            if (!string.IsNullOrWhiteSpace(naziv))
                kriterijumi.Naziv = naziv.Trim();
            return this;
        }

        internal MestoCriteriaBuilder WithPostanskiBroj(string postanskiBroj)
        {
            if (!string.IsNullOrWhiteSpace(postanskiBroj))
                kriterijumi.PostanskiBroj = postanskiBroj.Trim();
            return this;
        }

        public Mesto Build()
        {
            return kriterijumi;
        }
    }
}
