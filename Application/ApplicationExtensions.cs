using Application.BLL.Contracts.FileManagement;
using Application.BLL.Contracts.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.BLL;
public static class ApplicationExtensions
{
    /// <summary>
    /// configures Application layer services.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        //profiles
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services
        services.AddScoped<ITaskService, TaskServiceImpl>();
        services.AddScoped<IFileService, FileService>();


        return services;
    }
}

