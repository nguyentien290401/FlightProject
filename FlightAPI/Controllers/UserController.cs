using FlightAPI.Models;
using FlightAPI.Services.UserService;
using FlightAPI.Services.UserService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // goi service
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDTO request)
        {
            var result = await _userService.Register(request);

            if (result == null) 
                return BadRequest("Register failed !");

            return Ok("Register sucessfully !");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserLoginDTO request)
        {
            var result = await _userService.Login(request);

            if (result == null)
                return BadRequest("Login failed !");

            return Ok(result);
        }

        [HttpPost("verify-email")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> VerifyEmail(string otp)
        {
            var result = await _userService.VerifyEmail(otp);

            if (result == null)
                return BadRequest("Email verification failed !");

            return Ok("Email sucessfully verified !");
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> ForgotPassword(string email)
        {
            var result = await _userService.ForgotPassword(email);

            if (result == null)
                return BadRequest("Can't find your email address.");

            return Ok("Now, you can change the password.");
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> ResetPassword(ResetPasswordDTO request)
        {
            var result = await _userService.ResetPassword(request);

            if (result == null)
                return BadRequest("Reset password failed !");

            return Ok("Reset password sucessfully !");
        }

        [HttpGet("get-all"), Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            // Trả về toàn bộ dữ liệu || OK là status code 200
            return await _userService.GetAllUser();
        }

        [HttpGet("get-by-id/{id}"), Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<User>> GetUserProfile(int id)
        {
            // Tìm User bằng id
            var result = await _userService.GetUserProfile(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {

            var result = await _userService.DeleteUser(id);
            if (result is null)
                return NotFound("user not found");

            return NoContent();
        }
    }
}
