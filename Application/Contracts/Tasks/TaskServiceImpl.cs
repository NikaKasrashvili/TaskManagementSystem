using Application.BLL.Exceptions;
using Application.BLL.Models.Tasks;
using Application.BLL.Repositories;
using AutoMapper;
using Shared;
using Task = Infrastructure.DAL.Entities.Task;

namespace Application.BLL.Contracts.Tasks;
public class TaskServiceImpl : ITaskService
{
    #region Constructor

    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;
    public TaskServiceImpl(ITaskRepository taskRepository, IMapper mapper)
    {
        _repository = taskRepository;
        _mapper = mapper;
    }

    #endregion

    #region commands

    public async Task<TaskResponse> Create(CreateTaskRequest request)
    {
        //TODO check if user exists and if not throw exception

        var task = new Task()
        {
            Id = IdGenerator.Generate(),
            Title = request.Title,
            SmallDescription = request.SmallDescription,
            Description = request.Description,
            FilePath = request.FilePath,
            UserId = request.UserId,
            DateCreatedOn = DateTime.UtcNow,
        };

        await _repository.Add(task);
        return _mapper.Map<TaskResponse>(task);

    }

    public async Task<bool> Delete(string id)
    {
        var task = await _repository.GetById(id);
        if (task == null)
            throw new BadRequestException(ErrMessages.InvalidId);

        await _repository.Delete(task);
        return true;
    }

    public async Task<TaskResponse> Update(UpdateTaskRequest request)
    {
        //TODO check if user exists and if not throw exception

        var task = await _repository.GetById(request.Id);
        if (task == null)
            throw new NotFoundException(ErrMessages.NotFound);

        task.Title = request.Title;
        task.SmallDescription = request.SmallDescription;
        task.Description = request.Description;
        task.FilePath = request.FilePath;
        task.UserId = request.UserId;

        await _repository.Update(task);

        return _mapper.Map<TaskResponse>(task); ;
    }

    #endregion

    #region queries

    public async Task<TaskResponse> GetById(string id)
    {
        var task = await _repository.GetById(id);

        if (task == null)
            throw new NotFoundException(ErrMessages.NotFound);

        return _mapper.Map<TaskResponse>(task);
    }

    public async Task<List<TaskResponse>> GetList()
    {
        var tasks = await _repository.GetAll();
        if (tasks == null)
            throw new NotFoundException(ErrMessages.NotFound);

        return _mapper.Map<List<TaskResponse>>(tasks);
    }

    #endregion

}
