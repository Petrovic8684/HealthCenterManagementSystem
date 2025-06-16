namespace Server.Services
{
    internal interface IEntityService<T> 
        where T : class, IEntity, new()
    {
        T Kreiraj(T entity);
        T Pretrazi(T entity);
        T Promeni(T entity);
        T Obrisi(T entity);
        List<T> VratiListuSvi();
        List<T> VratiListu(IEntity criterion);
    }
}
