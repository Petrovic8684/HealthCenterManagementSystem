using Client;
using Client.GuiController.Criteria;
using Common.Communication;
using Common.Domain;

public class PacijentCriteriaBuilder : ICriteriaBuilder<Pacijent>
{
    private readonly List<Func<List<Pacijent>>> _criteriaFetchers = new();

    public PacijentCriteriaBuilder WithIme(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Pacijent { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestList<Pacijent, Pacijent>(kriterijum, Operation.VratiListuPacijentPoPacijentu);
                return response.Result as List<Pacijent>;
            });
        }
        return this;
    }

    public PacijentCriteriaBuilder WithPrezime(string prezime)
    {
        if (!string.IsNullOrWhiteSpace(prezime))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Pacijent { Prezime = prezime.Trim() };
                var response = Communication.Instance.SendRequestList<Pacijent, Pacijent>(kriterijum, Operation.VratiListuPacijentPoPacijentu);
                return response.Result as List<Pacijent>;
            });
        }
        return this;
    }

    public PacijentCriteriaBuilder WithMesto(Mesto mesto)
    {
        if (mesto != null && mesto.Id != -1)
        {
            _criteriaFetchers.Add(() =>
            {
                var response = Communication.Instance.SendRequestList<Mesto, Pacijent>(mesto, Operation.VratiListuPacijentPoMestu);
                return response.Result as List<Pacijent>;
            });
        }
        return this;
    }


    public List<Pacijent> Build()
    {
        if (_criteriaFetchers.Count == 0)
        {
            var response = Communication.Instance.SendRequestList<object, Pacijent>(null, Operation.VratiListuSviPacijent);
            return response.Result as List<Pacijent>;
        }

        var resultSets = _criteriaFetchers.Select(fetch => fetch()).ToList();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new PacijentComparer()).ToList());
    }

    private class PacijentComparer : IEqualityComparer<Pacijent>
    {
        public bool Equals(Pacijent x, Pacijent y) => x.Id == y.Id;
        public int GetHashCode(Pacijent obj) => obj.Id.GetHashCode();
    }
}
