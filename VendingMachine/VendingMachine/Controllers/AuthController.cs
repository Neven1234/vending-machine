using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;

        public AuthController(IAuthRepository  repository)
        {
            _repository = repository;
        }

        //Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            var result = await _repository.Register(user);
            return Ok(result);
        }

        //Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username,string password)
        {
            var result =await _repository.Login(username, password);
            return Ok(result);
        }
    }
}
