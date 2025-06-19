using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using Client;

internal class PacijentCriteriaBuilder : CriteriaBuilderBase<Pacijent>
{
    internal PacijentCriteriaBuilder WithIme(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Pacijent { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestGetList<Pacijent, Pacijent>(criterion, Operation.VratiListuPacijentPoPacijentu);
                return response.Result as List<Pacijent>;
            });
        }
        return this;
    }

    internal PacijentCriteriaBuilder WithPrezime(string prezime)
    {
        if (!string.IsNullOrWhiteSpace(prezime))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Pacijent { Prezime = prezime.Trim() };
                var response = Communication.Instance.SendRequestGetList<Pacijent, Pacijent>(criterion, Operation.VratiListuPacijentPoPacijentu);
                return response.Result as List<Pacijent>;
            });
        }
        return this;
    }

    internal PacijentCriteriaBuilder WithMesto(Mesto mesto)
    {
        if (mesto != null && mesto.Id != -1)
        {
            AddCriteriaFetcher(() =>
            {
                var response = Communication.Instance.SendRequestGetList<Mesto, Pacijent>(mesto, Operation.VratiListuPacijentPoMestu);
                return response.Result as List<Pacijent>;
            });
        }
        return this;
    }

    protected override Operation GetAllOperation() => Operation.VratiListuSviPacijent;
}
