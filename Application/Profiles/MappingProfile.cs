using Application.BLL.Models.Tasks;
using Application.BLL.Models.Users;
using AutoMapper;
using Infrastructure.DAL.Entities.Identity;
using Task = Infrastructure.DAL.Entities.Task;

namespace Application.BLL.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Task, UpdateTaskRequest>().ReverseMap();
        CreateMap<Task, TaskResponse>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();
    }
}