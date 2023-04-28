using Application.BLL.Models.Roles;
using Application.BLL.Models.UserRoles;

namespace Application.BLL.Contracts.Identity;
public interface IUserRoleService
{
    /// <summary>
    /// Gets all users with roles using identity userrole manager.
    /// </summary>
    /// <returns>List of users with roles</returns>
    Task<List<GetAllUserRolesDto>> GetList();
    /// <summary>
    /// Gets all users assigned to currnet role by Id.
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>List of users with concrete role</returns>
    Task<List<GetUsersByRoleIDdto>> GetById(string RoleId);
    /// <summary>
    /// Updates role of concrete user
    /// </summary>
    /// <param name="request"></param>
    /// <returns>boolean</returns>
    Task<bool> Update(UpdateUserRoleRequest request);
}

