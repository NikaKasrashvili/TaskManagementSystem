using Application.BLL.Repositories;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Constructor

    private readonly ApplicationDbContext _dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion

    #region Methods

    public virtual async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<bool> Exists(string id)
    {
        var entity = await GetById(id);
        return entity != null;
    }

    public virtual async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(string id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    #endregion
};
