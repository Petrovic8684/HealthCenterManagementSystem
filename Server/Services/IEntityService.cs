namespace Server.Services
{
    internal interface IEntityService<T> where T : class, IEntity
    {
        void Kreiraj(T entitet);
        List<T> Pretrazi(T kriterijum);
        void Promeni(T entitet);
        void Obrisi(T entitet);
    }
}
