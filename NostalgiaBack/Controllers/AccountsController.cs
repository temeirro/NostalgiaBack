using Core.DTOs.User;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NostalgiaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountService;

        public AccountsController(IAccountsService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            var token = await _accountService.Login(loginDTO);
            return Ok(new { token });
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(UserRegistrationDTO registrationDTO)
        {
            await _accountService.Registration(registrationDTO);
            return Ok();
        }
    }
}
