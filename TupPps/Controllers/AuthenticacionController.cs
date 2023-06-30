using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BussnessEntities;
using System.Security.Cryptography;
using DataModels.Context;
using System.Linq;

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
        public IActionResult Login(AuthLogin loginModel)
        {
            var query = $"SELECT RoleId, Name, LastName, Email " +
                $"FROM Accounts " +
                $"WHERE Email = '{loginModel.Email}'";

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

        private static bool CompareHashes(string password, string hashedPassword)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = md5.ComputeHash(passwordBytes);
                string hashedPasswordToCompare = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return hashedPasswordToCompare == hashedPassword;
            }
        }

        private static AccountWithoutRoleBe AuthenticateAccount(string email, string password)
        {
            
            // Consultar la BD para verificar
            using (var db = new FerreTechContext())
            {
                var account = db.Accounts.FirstOrDefault(a => a.Email == email);
                if (account != null)
                {
                    // Comparar los hashes de las contraseñas
                    if (CompareHashes(password, account.Password))
                    {
                        return new AccountWithoutRoleBe
                        {
                            RoleId = account.RoleId,
                            Name = account.Name,
                            LastName = account.LastName,
                            Email = account.Email
                        };
                    }
                }
            }

            return null;
        }
    }
}
