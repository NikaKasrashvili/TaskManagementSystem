using Application.BLL.Contracts.Identity;
using Application.BLL.Models.UserRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Api.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]/")]
[ApiController]
public class UserRolesController : ControllerBase
{
    #region Constructor

    private readonly IUserRoleService _service;

    public UserRolesController(IUserRoleService service)
    {
        _service = service;
    }

    #endregion

    #region Actions

    [HttpGet]
    public async Task<IActionResult> GetAllUserRoles()
    {
        var result = await _service.GetList();
        return Ok(result);
    }

    [HttpGet("user-by-roleId {id}")]
    public async Task<IActionResult> GetUsersByRoleId(string id)
    {
        var result = await _service.GetById(id);
        return Ok(result);
    }

    [HttpPut("role-of-user")]
    public async Task<IActionResult> UpdateUserRole(UpdateUserRoleRequest request)
    {
        var result = await _service.Update(request);
        return Ok(result);
    }

    #endregion

}

