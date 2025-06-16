using Client;
using Client.GuiController.Criteria;
using Common.Communication;
using Common.Domain;

public class DijagnozaCriteriaBuilder : ICriteriaBuilder<Dijagnoza>
{
    private readonly List<Func<List<Dijagnoza>>> _criteriaFetchers = new();
    private readonly List<string> _aktivniKriterijumi = new();

    public DijagnozaCriteriaBuilder WithNaziv(string naziv)
    {
        if (!string.IsNullOrWhiteSpace(naziv))
        {
            _aktivniKriterijumi.Add("Naziv");
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Dijagnoza { Naziv = naziv.Trim() };
                var response = Communication.Instance.SendRequestList<Dijagnoza, Dijagnoza>(kriterijum, Operation.VratiListuDijagnozaPoDijagnozi);
                return response.Result as List<Dijagnoza>;
            });
        }
        return this;
    }

    public DijagnozaCriteriaBuilder WithOpis(string opis)
    {
        if (!string.IsNullOrWhiteSpace(opis))
        {
            _aktivniKriterijumi.Add("Opis");
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Dijagnoza { Opis = opis.Trim() };
                var response = Communication.Instance.SendRequestList<Dijagnoza, Dijagnoza>(kriterijum, Operation.VratiListuDijagnozaPoDijagnozi);
                return response.Result as List<Dijagnoza>;
            });
        }
        return this;
    }

    public List<Dijagnoza> Build()
    {
        if (_criteriaFetchers.Count == 0)
        {
            var response = Communication.Instance.SendRequestList<object, Dijagnoza>(null, Operation.VratiListuSviDijagnoza);
            return response.Result as List<Dijagnoza>;
        }

        var resultSets = _criteriaFetchers.Select(fetch => fetch()).ToList();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new DijagnozaComparer()).ToList());
    }

    private class DijagnozaComparer : IEqualityComparer<Dijagnoza>
    {
        public bool Equals(Dijagnoza x, Dijagnoza y) => x.Id == y.Id;
        public int GetHashCode(Dijagnoza obj) => obj.Id.GetHashCode();
    }
}
