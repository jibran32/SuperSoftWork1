using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI_Supersoft.Helpers
{
    public class JwtTokenGenrator
    {
        private readonly string _jwtToken;
        public JwtTokenGenrator (string SecurityKey)
        {
            _jwtToken = SecurityKey;
        }
        public string GenerateJwtToken(string data, string pwd, TimeSpan expiration)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtToken));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, pwd),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("data", data),
            };

            var token = new JwtSecurityToken(
                issuer: "anyIssuers",
                audience: "anyAudience",
                claims: claims,
                expires: DateTime.UtcNow.Add(expiration),
                signingCredentials : credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return tokenString;
        }
    }
}
