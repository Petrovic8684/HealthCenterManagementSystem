using Client;
using Client.GuiController.Criteria;
using Common.Communication;
using Common.Domain;

public class MestoCriteriaBuilder : ICriteriaBuilder<Mesto>
{
    private readonly List<Func<List<Mesto>>> _criteriaFetchers = new();

    public MestoCriteriaBuilder WithNaziv(string naziv)
    {
        if (!string.IsNullOrWhiteSpace(naziv))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Mesto { Naziv = naziv.Trim() };
                var response = Communication.Instance.SendRequestList<Mesto, Mesto>(kriterijum, Operation.VratiListuMestoPoMestu);
                return response.Result as List<Mesto>;
            });
        }
        return this;
    }

    public MestoCriteriaBuilder WithPostanskiBroj(string postanskiBroj)
    {
        if (!string.IsNullOrWhiteSpace(postanskiBroj))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Mesto { PostanskiBroj = postanskiBroj.Trim() };
                var response = Communication.Instance.SendRequestList<Mesto, Mesto>(kriterijum, Operation.VratiListuMestoPoMestu);
                return response.Result as List<Mesto>;
            });
        }
        return this;
    }

    public List<Mesto> Build()
    {
        if (_criteriaFetchers.Count == 0)
        {
            var response = Communication.Instance.SendRequestList<object, Mesto>(null, Operation.VratiListuSviMesto);
            return response.Result as List<Mesto>;
        }

        var resultSets = _criteriaFetchers.Select(fetch => fetch()).ToList();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new MestoComparer()).ToList());
    }

    private class MestoComparer : IEqualityComparer<Mesto>
    {
        public bool Equals(Mesto x, Mesto y) => x.Id == y.Id;
        public int GetHashCode(Mesto obj) => obj.Id.GetHashCode();
    }
}
