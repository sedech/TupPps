using BusnessService.IService;
using BusnessService.Service;
using BussnessEntities;
using DataModels.Entities;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> CreateAccount([FromBody] AccountBe account)
        {
            return Ok(await _accountService.Create(account));
        }

        [HttpGet]
        [Route("getAccount/{IdAccount}")]
        public async Task<IActionResult> GetProduct(int IdAccount)
        {

            return Ok(await _accountService.GetById(IdAccount));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountBe account)
        {
            return Ok(await _accountService.Update(account));
        }
    }
}
