using Application.BLL.Models.Tasks;

namespace Application.BLL.Contracts.Tasks
{
    public interface ITaskService
    {
        /// <summary>
        /// Creates Task for specified user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Task</returns>
        Task<TaskResponse> Create(CreateTaskRequest request);
        /// <summary>
        /// Updates Task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>Task</returns>
        Task<TaskResponse> Update(UpdateTaskRequest request);
        /// <summary>
        /// Deletes task
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        Task<bool> Delete(string id);
        /// <summary>
        /// Gets task by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Concrete Task</returns>
        Task<TaskResponse> GetById(string id);
        /// <summary>
        /// Gets list of Tasks.
        /// </summary>
        /// <returns></returns>
        Task<List<TaskResponse>> GetList();
    }
}
