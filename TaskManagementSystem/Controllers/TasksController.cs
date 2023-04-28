using Application.BLL.Contracts.Tasks;
using Application.BLL.Models.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    #region Controller

    private readonly ITaskService _service;
    public TasksController(ITaskService service) => _service = service;

    #endregion


    #region Actions

    [Authorize("Task Read")]
    [HttpGet]
    public async Task<IActionResult> TasksList()
    {
        var result = await _service.GetList();
        return Ok(result);
    }

    [Authorize("Task Read")]
    [HttpGet("{id}")]
    public async Task<IActionResult> TaskGetById(string id)
    {
        var result = await _service.GetById(id);
        return Ok(result);
    }

    [HttpPost()]
    [Authorize("Task Create")]
    public async Task<IActionResult> AddTask(CreateTaskRequest request)
    {
        var result = await _service.Create(request);
        return CreatedAtAction("TasksList", result);
    }

    [Authorize("Task Delete")]
    [HttpDelete]
    public async Task<IActionResult> DeleteTask(string id)
    {
        await _service.Delete(id);
        return NoContent();
    }

    [Authorize("Task Create")]
    [HttpPut]
    public async Task<IActionResult> UpdateTask(UpdateTaskRequest request)
    {
        var result = await _service.Update(request);
        return Ok(result);
    }

    #endregion
}

