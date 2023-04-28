using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Entities.Identity
{
    public class Role : IdentityRole
    {
        public bool IsDeleted { get; set; }
    }
}
