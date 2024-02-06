using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VendingMachine.Data;
using VendingMachine.DTOs;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IAuthRepository _authRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IRepository repository,IAuthRepository authRepository,
            SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
           _repository = repository;
            _authRepository = authRepository;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        //deposit
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(string userId, int amontOfMoney)
        {
            if (userId != User.FindFirstValue("userId") || User.FindFirstValue("Role") != "Buyer")
            {
                return Unauthorized();
            }

            var result = await _repository.deposit(amontOfMoney, userId);
            if (result == null)
            {
                return BadRequest("the amount of money should be 5,10,20 or 100");
            }
            return Ok(result);

        }
        //buy
        [HttpPost("buy/{productId}")]
        public async Task<IActionResult> Buy(string userId, int productId, int amountOdProduct)
        {
            if (userId != User.FindFirstValue("userId") || User.FindFirstValue("Role") != "Buyer")
                return Unauthorized();
            var user = await _authRepository.GetUserByIdAsync(userId);
            var result = await _repository.Buy(userId, amountOdProduct, productId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletAccount(string userId)
        {
            if(userId != User.FindFirstValue("userId"))
            {
                return Unauthorized();
            }
            var user=await _authRepository.GetUserByIdAsync(userId);
            _repository.Delete(user);
            if(await _repository.SaveAll())
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            return BadRequest();
        }


        //update user info
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateDetails(string userId,UserUpdateDTO userUpdateDTO)
        {
            if (userId != User.FindFirstValue("userId"))
            {
                return Unauthorized();
            }
            var user = await _authRepository.GetUserByIdAsync(userId);
            user.UserName = userUpdateDTO.Username;
            user.Email = userUpdateDTO.Email;
            if(await _repository.SaveAll())
            {
                return Ok("Updated successfully");
            }
            return BadRequest();
        }

        //Get user

        [HttpGet("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _authRepository.GetUserByIdAsync(userId);
            var role = await _authRepository.GetRole(user);
            var userToReturn =_mapper.Map<UserDetails>(user);
            userToReturn.Role = role;
            return Ok(userToReturn);
           
        }
    }
}
