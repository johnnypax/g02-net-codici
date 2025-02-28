namespace G02_07_EF_CF_OTM.Repositories
{
    public interface IRepoLettura<T>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
