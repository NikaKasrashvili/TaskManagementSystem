namespace Application.BLL.Models.Tasks
{
    public class TaskResponse
    {
        public string Id { get; set; } = null!;
        public string? Title { get; set; }
        public string? SmallDescription { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// Path of uploaded file or image
        /// </summary>
        public string? FilePath { get; set; }
        /// <summary>
        /// User which is responsible to make current task.
        /// </summary>
        public string UserId { get; set; } = null!;
    }
}
