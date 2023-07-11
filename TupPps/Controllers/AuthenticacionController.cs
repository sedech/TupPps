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
using Microsoft.AspNetCore.Identity;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace TupPps.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticacionController : ControllerBase
    {
        private static readonly string SecretKey = "mi clave secretita";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        // inyeccion de independencia

        public AuthenticacionController(IConfiguration config, UserManager<IdentityUser> userManager)
        {
            _config = config;
            _userManager = userManager;

        }
        /*
         Se inserta el nuevo usuario en la base de datos y 
        se genera un token JWT (Json Web Token) para el usuario registrado. 
        El token JWT se devuelve como respuesta exitosa (200 OK).
         */
        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<string>> RegisterUser(AccountCreationDto user)
        {
            var newUser = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName,


            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                var userToToken = await _userManager.FindByEmailAsync(user.Email);

                if (userToToken == null)
                    return BadRequest();
                if (user.RoleId == 1)
                {
                    await _userManager.AddToRoleAsync(userToToken, "Admin");
                }

                if (user.RoleId == 2)
                {
                    await _userManager.AddToRoleAsync(userToToken, "Vendedor");
                }

                if (user.RoleId == 3)
                {
                    await _userManager.AddToRoleAsync(userToToken, "Cliente");
                }



                var roles = await _userManager.GetRolesAsync(userToToken);

                var jwt_signup = GenerateJwtToken(userToToken, roles);


                if (jwt_signup != null)
                {
                    return jwt_signup;
                }

            }
            return BadRequest(result);
        }

        /*
          Se autentica el usuario verificando las credenciales proporcionadas en la base de datos. 
        Si las credenciales son correctas, se genera un token JWT para el usuario autenticado 
        y se devuelve como respuesta exitosa (200 OK). 
        Si las credenciales son incorrectas, se devuelve una respuesta de error (401 Unauthorized).
         */
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<object>> Login(AuthLogin request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = GenerateJwtToken(user, roles);

            var userObject = new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            var response = new
            {
                Token = token,
                User = userObject
            };

            return Ok(response);
        }



        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet]
        [Route("accounts")]
        public async Task<ActionResult<IEnumerable<AccountCreationDto>>> GetAccounts([FromQuery] string id)
        {
            var users = await _userManager.Users.ToListAsync();

            var accounts = users.Select(u => new AccountCreationDto
            {
                //RoleId = u.RoleID, 
                UserName = u.UserName,
                //FirstName = u.FirstName,
                // LastName = u.LastName,
                Email = u.Email,
                Password = string.Empty // Omitir la contraseña 
            }).ToList();

            return Ok(accounts);
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete]
        [Route("accounts/{id}")]
        public async Task<ActionResult<string>> DeleteAccount([FromQuery] string id)
        {

            var account = await _userManager.FindByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(account);

            if (roles.Contains("Vendedor") || roles.Contains("Cliente"))
            {
                return BadRequest("No se cumple con los requisitos de borrarla");
            }

            // borrar si cumple los requisitos
            var result = await _userManager.DeleteAsync(account);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

       
        [ApiExplorerSettings(IgnoreApi = true)]
        public string GenerateJwtToken([FromBody] IdentityUser user, [FromQuery] ICollection<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),

            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Authentication:Issuer"],
                audience: _config["Authentication:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenDescriptor);

            return token;
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


    }
}