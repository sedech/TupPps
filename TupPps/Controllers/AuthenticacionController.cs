using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BussnessEntities;

namespace TupPps.Controllers
{
    [ApiController]
    [Route("api/[auth]")]
    public class AuthenticacionController : ControllerBase
    {
        private static readonly string SecretKey = "mi clave secretita";

        [HttpPost("api/auth/signup")]
        public IActionResult Signup(AccountWithoutRoleBe user)
        {
            var query = $"INSERT INTO Users (RoleId, Name, LastName, Email, Password) " +
                $"VALUES ({user.RoleId}, '{user.Name}', '{user.LastName}', '{user.Email}', '{user.Password}')";

            // genera el token para el usuario registrado
            var jwtToken = GenerateJwtToken(user);

            return Ok(new { token = jwtToken });
        }

        [HttpPost("api/auth/login")]
        public IActionResult Login(AccountWithoutRoleWithUsersBe loginModel)
        {
            var query = $"SELECT RoleId, Name, LastName, Email " +
                $"FROM Users " +
                $"WHERE Email = '{loginModel.Email}' AND Password = '{loginModel.Password}'";

            // check user
            var user = AuthenticateUser(loginModel.Email, loginModel.Password);

            if (user != null)
            {
                var jwtToken = GenerateJwtToken(user);
                return Ok(new { token = jwtToken });
            }

            return Unauthorized();
        }

        private static string GenerateJwtToken(AccountWithoutRoleBe user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static AccountWithoutRoleBe AuthenticateUser(string email, string password)
        {
            if (email == "tup@utn.com.ar" && password == "2023")
            {
                return new AccountWithoutRoleBe
                {
                    RoleId = 1,
                    Name = "Tup",
                    LastName = "Ros",
                    Email = email,
                };
            }

            return null;
        }
    }
}
