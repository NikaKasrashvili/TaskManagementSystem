using Application.BLL.Contracts.Identity;
using Application.BLL.Exceptions;
using Application.BLL.Models.UserRoles;
using Infrastructure.DAL;
using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Domain.Identity;
public class UserRoleService : IUserRoleService
{

    #region Constructor
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UserRoleService(ApplicationDbContext dbContext,
                            UserManager<User> userManager,
                            RoleManager<Role> roleManager)
    {
        _context = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    #endregion

    #region Methods

    public async Task<List<GetUsersByRoleIDdto>> GetById(string roleId)
    {
        var usersByRole = await (
        from u in _context.Users
        join ur in _context.UserRoles on u.Id equals ur.UserId
        join r in _context.Roles on ur.RoleId equals r.Id
        where r.Id == roleId
        select new GetUsersByRoleIDdto
        {
            UserId = u.Id,
            UserName = u.UserName,
            RoleName = r.Name,
        }).ToListAsync();

        if (usersByRole == null)
            throw new BadRequestException(ErrMessages.BadRequest);

        return usersByRole;
    }

    public async Task<List<GetAllUserRolesDto>> GetList()
    {
        var userRoles = await (
                   from u in _context.Users
                   join ur in _context.UserRoles on u.Id equals ur.UserId
                   join r in _context.Roles on ur.RoleId equals r.Id
                   select new GetAllUserRolesDto
                   {
                       UserId = ur.UserId,
                       RoleId = ur.RoleId,
                       UserName = u.UserName,
                       RoleName = r.Name
                   }).ToListAsync();

        if (userRoles == null)
            throw new BadRequestException(ErrMessages.BadRequest);

        return userRoles;

    }

    public async Task<bool> Update(UpdateUserRoleRequest request)
    {
        //check if user id and role Id is Correct
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException(ErrMessages.InvalidUserId);

        var role = await _roleManager.FindByIdAsync(request.RoleId);
        if (role == null)
            throw new NotFoundException(ErrMessages.InvalidRoleId);

        // get current role, than delete previous role from user and add current one.
        var currentRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
        await _userManager.RemoveFromRoleAsync(user, currentRole);
        var result = await _userManager.AddToRoleAsync(user, role.Name);

        if (result.Succeeded)
            return true;

        throw new Exception($"{result.Errors.FirstOrDefault().Description}");
    }

    #endregion
}

