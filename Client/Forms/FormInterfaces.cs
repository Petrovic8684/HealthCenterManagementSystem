using Common.Domain;

namespace Client.Forms
{
    internal interface IForm
    {
        string ConstructCriteria();
    }

    internal interface ICrudForm<T> where T : ICrudEntity, new()
    {
        public void PrikaziDetalje(T entitet);
        bool Validation();
    }
}
