using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using Client;

internal class SertifikatCriteriaBuilder : CriteriaBuilderBase<Sertifikat>
{
    internal SertifikatCriteriaBuilder WithOpis(string opis)
    {
        if (!string.IsNullOrWhiteSpace(opis))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Sertifikat { Opis = opis.Trim() };
                var response = Communication.Instance.SendRequestGetList<Sertifikat, Sertifikat>(
                    criterion, Operation.VratiListuSertifikatPoSertifikatu);
                return response.Result as List<Sertifikat>;
            });
        }
        return this;
    }

    protected override Operation GetAllOperation() => Operation.VratiListuSviSertifikat;
}
