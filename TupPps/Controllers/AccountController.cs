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
        public async Task<IActionResult> Create([FromBody] AccountBe account)
        {
            return Ok(await _accountService.Create(account));
        }

        [HttpGet]
        [Route("getAccount/{IdAccount}")]
        public async Task<IActionResult> GetById(int IdAccount)
        {
            return Ok(await _accountService.GetById(IdAccount));
        }

        [HttpGet]
        public async Task<IActionResult> Login(string userName, string userPass)
        {
            return Ok(await _accountService.Login(userName, userPass));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AccountBe account)
        {
            return Ok(await _accountService.Update(account));
        }
    }
}
