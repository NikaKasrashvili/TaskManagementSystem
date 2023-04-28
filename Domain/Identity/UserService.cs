using Application.BLL.Contracts.Identity;
using Application.BLL.Exceptions;
using Application.BLL.Models.Users;
using AutoMapper;
using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Domain.Identity;
public class UserService : IUserService
{
    #region Constructor

    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    #endregion

    public async Task<bool> Delete(string Id)
    {
        var user = await _userManager.FindByIdAsync(Id);
        if (user == null)
            throw new NotFoundException(ErrMessages.NotFound);

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
            return true;

        throw new Exception($"{result.Errors.FirstOrDefault().Description}");
    }

    public async Task<List<UserResponse>> GetList()
    {
        var users = await _userManager.Users.ToListAsync();

        return _mapper.Map<List<UserResponse>>(users);
    }

    public async Task<UserResponse> GetById(string Id)
    {
        var user = await _userManager.FindByIdAsync(Id);
        if (user == null)
            throw new NotFoundException(ErrMessages.NotFound);

        return _mapper.Map<UserResponse>(user);

    }

    public async Task<UserResponse> Update(UserUpdateRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        if (user == null)
            throw new NotFoundException(ErrMessages.NotFound);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
            return _mapper.Map<UserResponse>(user);

        throw new Exception($"{result.Errors.FirstOrDefault().Description}");
    }
}

