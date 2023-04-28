using Microsoft.AspNetCore.Http;

namespace Application.BLL.Contracts.FileManagement
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
