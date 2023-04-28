using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Entities.Identity
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //nav props
        public ICollection<Task> Tasks { get; set; }

    }
}
