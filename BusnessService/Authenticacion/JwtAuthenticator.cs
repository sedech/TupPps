using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BussnessEntities;


namespace BusnessService.Authenticacion
{
    public class JwtAuthenticator
    {
        private readonly string secretKey;

        public JwtAuthenticator(string secretKey)
        {
            this.secretKey = secretKey;
        }

        public string GenerateJwtToken(AccountWithoutRoleBe user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
               Subject = new ClaimsIdentity(new[]
               {
                   new Claim(ClaimTypes.Email, user.Email),
                   new Claim(ClaimTypes.Role, user.RoleId.ToString())
               }),
               Expires = DateTime.UtcNow.AddDays(30),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            
        }
    }
}
