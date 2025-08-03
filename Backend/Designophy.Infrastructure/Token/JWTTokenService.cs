using Designophy.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Designophy.Infrastructure.Token
{
    public class JWTTokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public JWTTokenService(IConfiguration config)
        {
            _config = config;
        }

        public Task<string> CreateTokenAsync(User user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var keyBytes = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
            var expiration = DateTime.UtcNow.AddMinutes(
                int.Parse(jwtSettings["DurationInMinutes"])
            );

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return Task.FromResult(tokenString);
        }
    }
}
