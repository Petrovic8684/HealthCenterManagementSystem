namespace Server.Services
{
    internal interface IEntityService<T> 
        where T : class, IEntity, new()
    {
        T Create(T entity);
        T Read(T entity);
        T Update(T entity);
        T Delete(T entity);
        List<T> FetchListAll();
        List<T> FetchList(IEntity criterion);
    }
}
