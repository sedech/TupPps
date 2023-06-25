using BusnessService.Authenticacion;
using Microsoft.AspNetCore.Http;
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
        private readonly JwtAuthenticator authenticator;

        public AuthenticacionController()
        {
            var secretKey = "mi clave secretita";
            authenticator = new JwtAuthenticator(secretKey);
        }

        [HttpPost("signup")]
        public IActionResult Signup(AccountWithoutRoleBe user)
        {
            var query = $"INSERT INTO Users (RoleId, Name, LastName, Email, Password) " +
                $"VALUES ({user.RoleId}, '{user.Name}', '{user.LastName}', '{user.Email}', '{user.Password}')";

            // genera el token para el usuario registrado
            var jwtToken = authenticator.GenerateJwtToken(user);

            return Ok(new { token = jwtToken });
        }

        [HttpPost("login")]
        public IActionResult Login(AccountWithoutRoleWithUsersBe loginModel)
        {
            var query = $"SELECT RoleId, Name, LastName, Email " +
                $"FROM Users " +
                $"WHERE Email = '{loginModel.Email}' AND Password = '{loginModel.Password}'";

            // check user
            var user = AuthenticateUser(loginModel.Email, loginModel.Password);

            if (user != null) 
            {
              
                var jwtToken = authenticator.GenerateJwtToken(user);

                return Ok(new { token = jwtToken });
            }

            return Unauthorized();
        }

         // hace falta implementar eso 
         private AccountWithoutRoleBe AuthenticateUser(string email, string password)
         {
            if (email == "tup@utn.com.ar" || password == "2023")
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
