using Application.BLL.Contracts.Identity;
using Application.BLL.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService authService)
    {
        _service = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthRequest request)
    {
        var result = await _service.Login(request);

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var result = await _service.Register(request);

        return Ok(result);
    }
}

