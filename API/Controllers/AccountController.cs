using Back.API.Controllers;
using Back.API.Errors;
using Back.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Back.Common.DTOs;

namespace E_COMMERSE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager,
         SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.UserName);
            if (user == null) 
                return Unauthorized(new ApiResponse(401));
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                 return Unauthorized(new ApiResponse(401));
            
            return new UserDTO
            {
                Email = user.Email,
                Token = "token",
                Address= user.Address.ToString(),
                FullName = user.UserName
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
                return BadRequest(new ApiResponse(400, "User with this email already exists"));
            
            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
           };
            
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) 
                return BadRequest(new ApiResponse(400));
            
            return new UserDTO
            {
                Email = user.Email,
                Token = "token",
                Address= user.Address.ToString(),
                FullName = user.UserName
            };
        }
    }
}