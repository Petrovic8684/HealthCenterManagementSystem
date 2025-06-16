using Client;
using Client.GuiController.Criteria;
using Common.Communication;
using Common.Domain;

public class LekarCriteriaBuilder : ICriteriaBuilder<Lekar>
{
    private readonly List<Func<List<Lekar>>> _criteriaFetchers = new();

    public LekarCriteriaBuilder WithIme(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Lekar { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestList<Lekar, Lekar>(kriterijum, Operation.VratiListuLekarPoLekaru);
                return response.Result as List<Lekar>;
            });
        }
        return this;
    }

    public LekarCriteriaBuilder WithPrezime(string prezime)
    {
        if (!string.IsNullOrWhiteSpace(prezime))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Lekar { Prezime = prezime.Trim() };
                var response = Communication.Instance.SendRequestList<Lekar, Lekar>(kriterijum, Operation.VratiListuLekarPoLekaru);
                return response.Result as List<Lekar>;
            });
        }
        return this;
    }

    public LekarCriteriaBuilder WithSertifikat(Sertifikat sertifikat)
    {
        if (sertifikat != null && sertifikat.Id != -1)
        {
            _criteriaFetchers.Add(() =>
            {
                var response = Communication.Instance.SendRequestList<Sertifikat, Lekar>(sertifikat, Operation.VratiListuLekarPoSertifikatu);
                return response.Result as List<Lekar>;
            });
        }
        return this;
    }

    public List<Lekar> Build()
    {
        if (_criteriaFetchers.Count == 0)
        {
            var response = Communication.Instance.SendRequestList<object, Lekar>(null, Operation.VratiListuSviLekar);
            return response.Result as List<Lekar>;
        }

        var resultSets = _criteriaFetchers.Select(fetch => fetch()).ToList();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new LekarComparer()).ToList());
    }

    private class LekarComparer : IEqualityComparer<Lekar>
    {
        public bool Equals(Lekar x, Lekar y) => x.Id == y.Id;
        public int GetHashCode(Lekar obj) => obj.Id.GetHashCode();
    }
}
