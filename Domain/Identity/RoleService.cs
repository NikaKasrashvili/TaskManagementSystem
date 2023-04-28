using Application.BLL.Contracts.Identity;
using Application.BLL.Exceptions;
using Application.BLL.Models.Roles;
using Infrastructure.DAL;
using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Data;
using System.Security.Claims;

namespace Domain.Identity
{
    public class RoleService : IRoleService
    {
        #region Constructor
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager) => _roleManager = roleManager;

        #endregion

        public async Task<bool> Delete(string Id)
        {
            var exRole = await _roleManager.FindByIdAsync(Id);
            if (exRole == null || exRole.IsDeleted)
                throw new NotFoundException(ErrMessages.NotFound);

            exRole.IsDeleted = true;

            var result = await _roleManager.UpdateAsync(exRole);

            if (result.Succeeded)
                return true;

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }

        public async Task<RoleResult> Create(CreateRoleRequest request)
        {
            if (await _roleManager.FindByNameAsync(request.Name) != null)
                throw new BadRequestException(ErrMessages.Exists);


            var role = new Role { Name = request.Name };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                var currentRole = await _roleManager.FindByNameAsync(request.Name);
                return new RoleResult()
                {
                    Id = currentRole.Id,
                    Name = currentRole.Name,
                };
            }

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");

        }

        public async Task<List<RoleResult>> GetList()
        {
            var allRoles = await _roleManager.Roles
                                                   .Where(x => !x.IsDeleted)
                                                   .Select(x => new RoleResult() { Id = x.Id, Name = x.Name })
                                                   .ToListAsync();

            return allRoles;
        }

        public async Task<RoleResult> GetById(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if (role == null || role.IsDeleted)
                throw new NotFoundException(ErrMessages.NotFound);


            return new RoleResult()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }

        public async Task<RoleResult> Update(UpdateRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
           
            if (role == null)
                throw new NotFoundException($"Role with this Id {request.Id} doesn't exist.");

            role.Name = request.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return new RoleResult
                {
                    Id = role.Id, 
                    Name = role.Name,
                };

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }

        public async Task<bool> Assign(AssingnClaimRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId);

            if (role == null)
                throw new NotFoundException($"Role with this Id {request.RoleId} doesn't exist.");

            var result = await _roleManager.AddClaimAsync(role, new Claim("Permission", request.Claim));

            if(result.Succeeded)
                return true;

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }
    }
}
