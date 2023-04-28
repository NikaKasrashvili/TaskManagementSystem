using Application.BLL.Repositories;
using Infrastructure.DAL;
using Task = Infrastructure.DAL.Entities.Task;

namespace Domain.Repositories;
public class TaskRepository : GenericRepository<Task>, ITaskRepository
{
    #region Constructor

    private readonly ApplicationDbContext _dbContext;
    public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion
}

