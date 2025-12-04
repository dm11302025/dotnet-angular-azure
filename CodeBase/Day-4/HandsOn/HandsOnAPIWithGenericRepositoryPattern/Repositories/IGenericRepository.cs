namespace HandsOnAPIWithGenericRepositoryPattern.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T Add(T entity);
        T? Update(T entity);
        bool Delete(int id);
    }
}
