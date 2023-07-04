
using BusnessService.IService;
using BussnessEntities;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        /*
            Llama al método "Create" del servicio de cuenta (IAccountService) 
            para crear la cuenta y devuelve una respuesta exitosa (200 OK) 
            si el registro se realiza correctamente.
         */
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create([FromBody] AccountWithoutRoleBe account)
        {
            return Ok(await _accountService.Create(account));
        }

        /*
         Llama al método "GetById" del servicio de cuenta (IAccountService) 
        para obtener los detalles de la cuenta correspondiente al ID proporcionado 
        y devuelve una respuesta exitosa (200 OK) con los detalles de la cuenta.
         */
        [HttpGet]
        [Route("getAccountById/{IdAccount}")]
        public async Task<IActionResult> GetById(int IdAccount)
        {
            return Ok(await _accountService.GetById(IdAccount));
        }

        /*
         Llama al método "Login" del servicio de cuenta (IAccountService)
        para verificar las credenciales del usuario.Si las credenciales son correctas, 
        devuelve una respuesta exitosa (200 OK) con los detalles del usuario. 
        Si las credenciales son incorrectas, devuelve una respuesta de error (404 Not Found) 
        con un mensaje indicando que el usuario y/o la contraseña son incorrectos.
         */

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser(string Email, string Password)
        {
            var user = await _accountService.Login(Email, Password);
            if (user == null)
            {
                return NotFound("Usuario Y/O Contraseña incorrecto");
            }
            return Ok(user);
        }

        /*
         Llama al método "Update" del servicio de cuenta (IAccountService)
        para actualizar los detalles de la cuenta proporcionada y 
        devuelve una respuesta exitosa (200 OK) si la actualización se realiza correctamente.
         */

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AccountBe account)
        {
            return Ok(await _accountService.Update(account));
        }
    }
}
