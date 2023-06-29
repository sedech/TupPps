
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

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create([FromBody] AccountWithoutRoleBe account)
        {
            return Ok(await _accountService.Create(account));
        }

        [HttpGet]
        [Route("getAccountById/{IdAccount}")]
        public async Task<IActionResult> GetById(int IdAccount)
        {
            return Ok(await _accountService.GetById(IdAccount));
        }


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


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AccountBe account)
        {
            return Ok(await _accountService.Update(account));
        }
    }
}
