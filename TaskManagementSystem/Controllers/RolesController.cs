using Application.BLL.Contracts.Identity;
using Application.BLL.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Api.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleService _service;
    public RolesController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> RolesList()
    {
        var result = await _service.GetList();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RoleGetById(string id)
    {
        var result = await _service.GetById(id);
        return Ok(result);
    }

    [HttpPost()]
    public async Task<IActionResult> AddRole(CreateRoleRequest request)
    {
        var result = await _service.Create(request);
        return CreatedAtAction("RolesList", result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole(string id)
    {
        await _service.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
    {
        var result = await _service.Update(request);
        return Ok(result);
    }


    [HttpPost("AssignPermissions")]
    public async Task<IActionResult> AssignPermissions(AssingnClaimRequest request)
    {
        var result = await _service.Assign(request);
        return Ok(result);
    }

}

