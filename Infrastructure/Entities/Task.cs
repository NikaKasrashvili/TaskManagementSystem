using Infrastructure.DAL.Entities.Identity;

namespace Infrastructure.DAL.Entities;

public class Task : BaseDomainEntity<string>
{
    public string? Title { get; set; }
    public string? SmallDescription { get; set; }
    public string? Description { get; set; }
    /// <summary>
    /// Path of uploaded file or image
    /// </summary>
    public string? FilePath { get; set; }
    //nav props
    /// <summary>
    /// User which is responsible to make current task.
    /// </summary>
    public string UserId { get; set; } = null!;
    public User User { get; set; }
}

