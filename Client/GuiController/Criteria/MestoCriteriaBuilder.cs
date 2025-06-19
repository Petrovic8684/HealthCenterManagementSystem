using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using Client;

internal class MestoCriteriaBuilder : CriteriaBuilderBase<Mesto>
{
    internal MestoCriteriaBuilder WithNaziv(string naziv)
    {
        if (!string.IsNullOrWhiteSpace(naziv))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Mesto { Naziv = naziv.Trim() };
                var response = Communication.Instance.SendRequestGetList<Mesto, Mesto>(
                    criterion, Operation.VratiListuMestoPoMestu);
                return response.Result as List<Mesto>;
            });
        }
        return this;
    }

    internal MestoCriteriaBuilder WithPostanskiBroj(string postanskiBroj)
    {
        if (!string.IsNullOrWhiteSpace(postanskiBroj))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Mesto { PostanskiBroj = postanskiBroj.Trim() };
                var response = Communication.Instance.SendRequestGetList<Mesto, Mesto>(
                    criterion, Operation.VratiListuMestoPoMestu);
                return response.Result as List<Mesto>;
            });
        }
        return this;
    }

    protected override Operation GetAllOperation() => Operation.VratiListuSviMesto;
}
