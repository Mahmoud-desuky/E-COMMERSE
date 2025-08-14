using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Back.Core.Entities.Identity;
using Back.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace Back.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices (this IServiceCollection services,IConfiguration config)
        {
            var builder=services.AddIdentityCore<User>();

            builder= new IdentityBuilder(builder.UserType, builder.Services);

            builder.AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            builder.AddSignInManager<SignInManager<User>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                    ValidIssuer = config["Token:Issuer"],
                    ValidateIssuer = true,
                };
            });
            return services; 
        }
      
    }
}