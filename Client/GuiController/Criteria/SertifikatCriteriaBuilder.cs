using Client;
using Client.GuiController.Criteria;
using Common.Communication;
using Common.Domain;

public class SertifikatCriteriaBuilder : ICriteriaBuilder<Sertifikat>
{
    private readonly List<Func<List<Sertifikat>>> _criteriaFetchers = new();

    public SertifikatCriteriaBuilder WithOpis(string opis)
    {
        if (!string.IsNullOrWhiteSpace(opis))
        {
            _criteriaFetchers.Add(() =>
            {
                var kriterijum = new Sertifikat { Opis = opis.Trim() };
                var response = Communication.Instance.SendRequestList<Sertifikat, Sertifikat>(kriterijum, Operation.VratiListuSertifikatPoSertifikatu);
                return response.Result as List<Sertifikat>;
            });
        }
        return this;
    }

    public List<Sertifikat> Build()
    {
        if (_criteriaFetchers.Count == 0)
        {
            var response = Communication.Instance.SendRequestList<object, Sertifikat>(null, Operation.VratiListuSviSertifikat);
            return response.Result as List<Sertifikat>;
        }

        var resultSets = _criteriaFetchers.Select(fetch => fetch()).ToList();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new SertifikatComparer()).ToList());
    }

    private class SertifikatComparer : IEqualityComparer<Sertifikat>
    {
        public bool Equals(Sertifikat x, Sertifikat y) => x.Id == y.Id;
        public int GetHashCode(Sertifikat obj) => obj.Id.GetHashCode();
    }
}
