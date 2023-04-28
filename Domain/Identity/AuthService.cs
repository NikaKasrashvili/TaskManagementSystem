using Application.BLL.Contracts.Identity;
using Application.BLL.Exceptions;
using Application.BLL.Models.Auth;
using Infrastructure.DAL;
using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared;
using Shared.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Identity
{
    public class AuthService : IAuthService
    {
        #region Constructor

        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbContext _context;
        public AuthService(
            IConfiguration configuration,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ApplicationDbContext context
            )
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<AuthResponse> Register(RegistrationRequest request)
        {
            //check if user already exists.
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
                throw new Exception($"Username '{request.UserName}' already exists.");

            //check email
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
                throw new Exception($"ServiceEmail {request.Email} already exists.");


            var roleName = await GetRoleName(request.RoleId);

            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true
            };


            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                //Assign role to the user.
                await _userManager.AddToRoleAsync(user, roleName);

                var currentUser = await _userManager.FindByEmailAsync(user.Email);

                return new AuthResponse()
                {
                    Id = currentUser.Id,
                    UserName = currentUser.UserName,
                    Email = currentUser.Email,
                };
            }

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }

        public async Task<AuthResult> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new NotFoundException($"Username with this '{request.Email}' not found.");

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
                throw new BadRequestException(ErrMessages.InvalidPassword);

            return new AuthResult()
            {
                IsSuccess = true,
                AccessToken = await GenerateAccessToken(user),
                SuccessMassage = "logged-in successfully"
            };
        }


        #endregion

        #region PrivateMethods

        /// <summary>
        /// Private method, that checks if role exists or not in Db and return role name.<br/>
        /// If it doesn't exist, default role name is <b>"BasicUser"</b>.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> GetRoleName(string? roleId)
        {
            string roleName;

            if (roleId != null)
            {
                var role = await _roleManager.FindByIdAsync(roleId);

                if (role == null || role.IsDeleted)
                    throw new Exception("Invalid Role Id");

                roleName = role.Name;
            }
            else roleName = RoleConsts.BasicUser;

            return roleName;
        }

        /// <summary>
        /// Generates new token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>token as string</returns>
        private async Task<string> GenerateAccessToken(User user)
        {

            var role = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roleClaims = from ur in _context.UserRoles
                             where ur.UserId == user.Id
                             join r in _context.Roles on ur.RoleId equals r.Id
                             join rc in _context.RoleClaims on r.Id equals rc.RoleId
                             select rc;

            var claims = new List<Claim>(userClaims)
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role.FirstOrDefault())
            };

            foreach (var roleClaim in roleClaims)
            {
                claims.Add(new Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
            }

            var token = new JwtSecurityToken(
                       issuer: _configuration.GetValue<string>("AuthSettings:Issuer"),
                       audience: _configuration.GetValue<string>("AuthSettings:Audience"),
                       expires: DateTime.UtcNow.AddMinutes(15),
                       claims: claims,
                       signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
