using Task = Infrastructure.DAL.Entities.Task;

namespace Application.BLL.Repositories
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
    }
}
