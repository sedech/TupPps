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
        /*
         Se inserta el nuevo usuario en la base de datos y 
        se genera un token JWT (Json Web Token) para el usuario registrado. 
        El token JWT se devuelve como respuesta exitosa (200 OK).
         */
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

        /*
          Se autentica el usuario verificando las credenciales proporcionadas en la base de datos. 
        Si las credenciales son correctas, se genera un token JWT para el usuario autenticado 
        y se devuelve como respuesta exitosa (200 OK). 
        Si las credenciales son incorrectas, se devuelve una respuesta de error (401 Unauthorized).
         */
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

        /*
         esta propiedad genera un token JWT válido para un usuario específico y 
        lo devuelve como una cadena. El token puede ser utilizado para autenticar 
        y autorizar al usuario en las solicitudes posteriores a la API.
         */
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

        /*
         esta propiedad toma una contraseña sin cifrar, la convierte en un hash utilizando el algoritmo MD5 
        y luego compara el hash generado con una contraseña cifrada existente. 
        Si los hashes coinciden, esto implica que las contraseñas coinciden y 
        se devuelve true. Si los hashes no coinciden, se devuelve false. 
        Este método es comúnmente utilizado en escenarios de autenticación y 
        verificación de contraseñas. 
         */
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

        /*
         esta propiedad consulta la base de datos para buscar una cuenta de usuario con el correo electrónico proporcionado, 
        luego verifica si la contraseña coinciden comparando los hashes de las contraseñas. 
        Si la autenticación es exitosa, se devuelve un objeto AccountWithoutRoleBe con los detalles de la cuenta;
        de lo contrario, se devuelve null.
         */
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
