using Application.BLL.Models.Roles;

namespace Application.BLL.Contracts.Identity
{
    public interface IRoleService
    {
        /// <summary>
        /// Gets all roles using identity role manager.
        /// </summary>
        /// <returns>List of roles</returns>
        Task<List<RoleResult>> GetList();
        /// <summary>
        /// Gets current role by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Single Role</returns>
        Task<RoleResult> GetById(string Id);
        Task<RoleResult> Create(CreateRoleRequest request);
        Task<RoleResult> Update(UpdateRoleRequest request);
        Task<bool> Delete(string Id);
        /// <summary>
        /// Assignes claims to the role
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>bool</returns>
        Task<bool> Assign(AssingnClaimRequest request);
    }
}
