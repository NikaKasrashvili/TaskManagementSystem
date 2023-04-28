namespace Application.BLL.Models.UserRoles
{
    public class GetAllUserRolesDto
    {
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }
}
