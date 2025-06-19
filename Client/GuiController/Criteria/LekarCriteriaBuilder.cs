using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using Client;

internal class LekarCriteriaBuilder : CriteriaBuilderBase<Lekar>
{
    internal LekarCriteriaBuilder WithIme(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Lekar { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestGetList<Lekar, Lekar>(criterion, Operation.VratiListuLekarPoLekaru);
                return response.Result as List<Lekar>;
            });
        }
        return this;
    }

    internal LekarCriteriaBuilder WithPrezime(string prezime)
    {
        if (!string.IsNullOrWhiteSpace(prezime))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Lekar { Prezime = prezime.Trim() };
                var response = Communication.Instance.SendRequestGetList<Lekar, Lekar>(criterion, Operation.VratiListuLekarPoLekaru);
                return response.Result as List<Lekar>;
            });
        }
        return this;
    }

    internal LekarCriteriaBuilder WithSertifikat(Sertifikat sertifikat)
    {
        if (sertifikat != null && sertifikat.Id != -1)
        {
            AddCriteriaFetcher(() =>
            {
                var response = Communication.Instance.SendRequestGetList<Sertifikat, Lekar>(sertifikat, Operation.VratiListuLekarPoSertifikatu);
                return response.Result as List<Lekar>;
            });
        }
        return this;
    }

    protected override Operation GetAllOperation() => Operation.VratiListuSviLekar;
}
