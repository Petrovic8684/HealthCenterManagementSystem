using Common.Domain;

namespace Client.GuiController.Criteria
{
    internal class PacijentCriteriaBuilder : ICriteriaBuilder<Pacijent>
    {
        private readonly Pacijent kriterijumi = new Pacijent();

        internal PacijentCriteriaBuilder WithIme(string ime)
        {
            if (!string.IsNullOrWhiteSpace(ime))
                kriterijumi.Ime = ime.Trim();
            return this;
        }

        internal PacijentCriteriaBuilder WithPrezime(string prezime)
        {
            if (!string.IsNullOrWhiteSpace(prezime))
                kriterijumi.Prezime = prezime.Trim();
            return this;
        }

        internal PacijentCriteriaBuilder WithMesto(Mesto mesto)
        {
            if (mesto != null && mesto.Id != -1)
                kriterijumi.Mesto = mesto;

            return this;
        }

        public Pacijent Build()
        {
            return kriterijumi;
        }
    }
}
