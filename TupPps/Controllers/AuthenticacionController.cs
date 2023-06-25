using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BussnessEntities;
using System.Security.Cryptography;

namespace TupPps.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticacionController : ControllerBase
    {
        private static readonly string SecretKey = "mi clave secretita";

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(AccountWithoutRoleBe user)
        {
            var query = $"INSERT INTO Users (RoleId, Name, LastName, Email, Password) " +
                $"VALUES ({user.RoleId}, '{user.Name}', '{user.LastName}', '{user.Email}', '{user.Password}')";

            // genera el token para el usuario registrado
            var jwtToken = GenerateJwtToken(user);

            return Ok(new { token = jwtToken });
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(AccountWithoutRoleWithUsersBe loginModel)
        {
            var query = $"SELECT RoleId, Name, LastName, Email " +
                $"FROM Accounts " +
                $"WHERE Email = '{loginModel.Email}' AND Password = '{loginModel.Password}'";

            // check account
            var account = AuthenticateAccount(loginModel.Email, loginModel.Password);

            if (account != null)
            {
                var jwtToken = GenerateJwtToken(account);
                return Ok(new { token = jwtToken });
            }

            return Unauthorized();
        }

        private static string GenerateJwtToken(AccountWithoutRoleBe account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(SecretKey);
            // Generar una clave secreta de 32 bytes (256 bits)
            byte[] keyBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            string secretKey = Encoding.ASCII.GetString(keyBytes);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, account.Email),
                    new Claim(ClaimTypes.Role, account.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static AccountWithoutRoleBe AuthenticateAccount(string email, string password)
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
