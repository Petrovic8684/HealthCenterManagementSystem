using Common.Domain;

namespace Client.Forms
{
    internal interface ICrudForm<T> where T : ICrudEntity, new()
    {
        void ShowDetails(T entitet);
        bool Validation();
    }
}
