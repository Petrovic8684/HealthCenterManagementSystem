using Common.Communication;
using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Client.GuiController.Criteria
{
    internal abstract class CriteriaBuilderBase<T>
        where T : class, ICrudEntity, new()
    {
        private readonly List<Func<List<T>>> criteriaFetchers = new();
        protected abstract Operation GetAllOperation();

        protected bool HasCriteria => criteriaFetchers.Count > 0;

        protected List<List<T>> GetResults() => criteriaFetchers.Select(fetch => fetch()).ToList();

        protected void AddCriteriaFetcher(Func<List<T>> fetcher)
        {
            criteriaFetchers.Add(fetcher);
        }

        internal virtual List<T> Build()
        {
            if (!HasCriteria)
            {
                var response = Communication.Instance.SendRequestGetList<object, T>(null, GetAllOperation());
                return response.Result as List<T>;
            }

            var resultSets = GetResults();
            return resultSets.Aggregate((prev, next) => prev.Intersect(next, new EntityIdComparer()).ToList());
        }

        protected class EntityIdComparer : IEqualityComparer<T>
        {
            public bool Equals(T x, T y) => x.Id == y.Id;
            public int GetHashCode(T obj) => obj.Id.GetHashCode();
        }
    }
}
