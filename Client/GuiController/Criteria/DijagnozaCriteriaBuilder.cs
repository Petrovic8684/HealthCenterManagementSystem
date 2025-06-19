using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using Client;

internal class DijagnozaCriteriaBuilder : CriteriaBuilderBase<Dijagnoza>
{
    internal DijagnozaCriteriaBuilder WithNaziv(string naziv)
    {
        if (!string.IsNullOrWhiteSpace(naziv))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Dijagnoza { Naziv = naziv.Trim() };
                var response = Communication.Instance.SendRequestGetList<Dijagnoza, Dijagnoza>(criterion, Operation.VratiListuDijagnozaPoDijagnozi);
                return response.Result as List<Dijagnoza>;
            });
        }
        return this;
    }

    internal DijagnozaCriteriaBuilder WithOpis(string opis)
    {
        if (!string.IsNullOrWhiteSpace(opis))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Dijagnoza { Opis = opis.Trim() };
                var response = Communication.Instance.SendRequestGetList<Dijagnoza, Dijagnoza>(criterion, Operation.VratiListuDijagnozaPoDijagnozi);
                return response.Result as List<Dijagnoza>;
            });
        }
        return this;
    }

    protected override Operation GetAllOperation() => Operation.VratiListuSviDijagnoza;
}
