namespace G02_07_EF_CF_OTM.Repositories
{
    public interface IRepoScrittura<T>
    {
        bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
