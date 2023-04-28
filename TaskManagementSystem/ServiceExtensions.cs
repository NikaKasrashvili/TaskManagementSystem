using Application.BLL;
using Application.BLL.Contracts.Identity;
using Application.BLL.Repositories;
using Domain.Identity;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.DAL;
using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared;
using System.Text;

namespace TaskManagementSystem.Api
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures Domain  and Infrastructure layer services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>services</returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // add cors
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                                          .AllowAnyMethod()
                                                                                          .AllowAnyHeader()));

            #region Swagger

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                         },
                         new List<string>()
                     }
                });
            });
            #endregion

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<HttpClient>();

            // add db context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            // add identity
            #region Identity

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            })
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();
            #endregion

            //add validation assembly
            services.AddValidatorsFromAssembly(typeof(ErrMessages).Assembly);
            services.AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly);
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
           
            
            //add authentication
            #region Authentication

            var authSettings = configuration.GetSection("AuthSettings");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = authSettings.GetValue<string>("Audience"),
                        ValidIssuer = authSettings.GetValue<string>("Issuer"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings.GetValue<string>("Key"))),
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromDays(1),
                    };
                });
            #endregion

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Task Create",
                    policy => policy.RequireClaim("Permission", "Task_Create"));
                options.AddPolicy("Task Read",
                    policy => policy.RequireClaim("Permission", "Task_Read"));
                options.AddPolicy("Task Delete",
                    policy => policy.RequireClaim("Permission", "Task_Delete"));
            });

            // domain service
            #region ServiceResolve

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            return services;
        }
    }
}
