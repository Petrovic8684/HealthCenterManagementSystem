using Client;
using Client.GuiController.Criteria;
using Common.Communication;
using Common.Domain;

public class ZdravstveniKartonCriteriaBuilder : ICriteriaBuilder<ZdravstveniKarton>
{
    private readonly List<Func<List<ZdravstveniKarton>>> _criteriaFetchers = new();

    public ZdravstveniKartonCriteriaBuilder WithDatumOtvaranjaAfter(DateTime datum)
    {
        if (datum != DateTime.Today)
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new ZdravstveniKarton { DatumOtvaranja = datum };
                var response = Communication.Instance.SendRequestList<ZdravstveniKarton, ZdravstveniKarton>(kriterijum, Operation.VratiListuZdravstveniKartonPoZdravstvenomKartonu);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    public ZdravstveniKartonCriteriaBuilder WithImeLekara(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Lekar { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestList<Lekar, ZdravstveniKarton>(kriterijum, Operation.VratiListuZdravstveniKartonPoLekaru);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    public ZdravstveniKartonCriteriaBuilder WithImePacijenta(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Pacijent { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestList<Pacijent, ZdravstveniKarton>(kriterijum, Operation.VratiListuZdravstveniKartonPoPacijentu);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    public ZdravstveniKartonCriteriaBuilder WithDijagnoza(Dijagnoza dijagnoza)
    {
        if (dijagnoza != null && dijagnoza.Id != -1)
        {
            _criteriaFetchers.Add(() =>
            {
                var response = Communication.Instance.SendRequestList<Dijagnoza, ZdravstveniKarton>(dijagnoza, Operation.VratiListuZdravstveniKartonPoDijagnozi);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    public List<ZdravstveniKarton> Build()
    {
        if (_criteriaFetchers.Count == 0)
            throw new Exception("Izaberite bar jedan kriterijum pretrage.");

        var resultSets = _criteriaFetchers.Select(fetch => fetch()).ToList();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new ZdravstveniKartonComparer()).ToList());
    }

    private class ZdravstveniKartonComparer : IEqualityComparer<ZdravstveniKarton>
    {
        public bool Equals(ZdravstveniKarton x, ZdravstveniKarton y) => x.Id == y.Id;
        public int GetHashCode(ZdravstveniKarton obj) => obj.Id.GetHashCode();
    }
}
