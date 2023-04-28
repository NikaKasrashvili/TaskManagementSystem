namespace Application.BLL.Repositories;
/// <summary>
/// Generic interface of repository, that defines common database operations (CRUD).
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(string id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task<bool> Exists(string id);
    Task Update(T entity);
    Task Delete(T entity);
}

