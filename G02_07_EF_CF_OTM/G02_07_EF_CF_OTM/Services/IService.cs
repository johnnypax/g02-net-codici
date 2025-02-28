namespace G02_07_EF_CF_OTM.Services
{
    public interface IService<T>
    {
        T? CercaPerCodice(string codice);
        IEnumerable<T> CercaTutti();
        bool Inserisci(T entity);
        bool Modifica(T entity);
        bool Elimina(T entity);
    }
}
