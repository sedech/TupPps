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
using DataModels.Entities;

namespace TupPps.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticacionController : ControllerBase
    {
        private static readonly string SecretKey = "mi clave secretita";
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        // inyeccion de independencias

        public AuthenticacionController(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _config = config;
            _userManager = userManager;

        }
        /*
         se encarga de crear un nuevo usuario en la base de datos y 
        asignarle un rol específico según el valor del campo RoleId proporcionado.
         */
         

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<bool>> RegisterUser(AccountCreationDto user)
        {
            var newUser = new ApplicationUser()
            {
                RoleId = user.RoleId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
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

                return true;
               
            }

            return false;
            
        }

        /*
         permite a los usuarios iniciar sesión en el sistema. Si la autenticación es exitosa, 
        se genera un token de acceso JWT y se devuelve junto con los detalles del usuario. 
        El token JWT se utiliza para autorizar y realizar solicitudes posteriores que requieren autenticación
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
                RoleId = user.RoleId,
                FirstName = user.FirstName,
                LastName = user.LastName,
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

        /*
         se utiliza para obtener una lista de todas las cuentas de usuario registradas en el sistema
         solo los Admin tienen accesos
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet]
        [Route("AllAccounts")]
        public async Task<ActionResult<IEnumerable<AccountCreationDto>>> GetAllAccounts()
        {
            var users = await _userManager.Users.ToListAsync();

            var accounts = users.Select(u => new AccountCreationDto
            {
                
                RoleId = u.RoleId,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = string.Empty // Omitir la contraseña 
            }).ToList();

            return Ok(accounts);
        }


        /*
         se utiliza para obtener información detallada de una cuenta de usuario específica según su ID
         */

        [HttpGet]
        [Route("account")]
        public async Task<ActionResult<AccountCreationDto>> GetAccount([FromQuery] string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var account = new AccountCreationDto
            {
                
                RoleId = user.RoleId, 
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = string.Empty // Omitir la contraseña 
            };

            return Ok(account);
        }

        /*
         se utiliza para eliminar una cuenta de usuario específica en el sistema.
            solo los Admin tienen acceso 
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete]
        [Route("accounts/{id}")]
        public async Task<ActionResult<string>> DeleteAccount(string id)
        {

            var account = await _userManager.FindByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }
          
            
            var result = await _userManager.DeleteAsync(account);

            if (result.Succeeded)
            {
                return Ok(new { success = true, message = "La cuenta se eliminó correctamente." });
            }
            else
            {
                return Ok(new { success = false, message = "No se pudo eliminar la cuenta." });
            }
        }

        /*
         este método toma un usuario autenticado y una colección de roles, y genera un token JWT 
        que contiene la información del usuario y los roles. El token se utiliza para autenticar 
        y autorizar al usuario en solicitudes posteriores
         */

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GenerateJwtToken([FromBody] ApplicationUser user, [FromQuery] ICollection<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("RoleId", user.RoleId.ToString())

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
          verificacion de contraseña  (cifrada) utilizando el algoritmo MD5.
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