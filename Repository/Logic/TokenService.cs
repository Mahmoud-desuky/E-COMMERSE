using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Back.Core.Entities.Identity;
using ECommerce.Repository.Interface;
using Microsoft.IdentityModel.Tokens;

namespace E_COMMERSE.API.Logic
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
            
        }
        public string CreateteToken(User user)
        {
            var Claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                
            };

            var credintionals = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
        
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credintionals,
                Issuer = _config["Token:Issuer"],
                Audience = _config["Token:Audience"]
            };
            var tokenHandler=new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}