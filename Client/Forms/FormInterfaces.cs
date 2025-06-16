using Common.Domain;

namespace Client.Forms
{
    internal interface IForm<T> where T : IEntity, new()
    {
        //List<T> ConstructCriteria();
    }

    internal interface ICrudForm<T> where T : ICrudEntity, new()
    {
        public void PrikaziDetalje(T entitet);
        bool Validation();
    }
}
