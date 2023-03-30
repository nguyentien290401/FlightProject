using FlightAPI.Models;
using FlightAPI.Services.UserService;
using FlightAPI.Services.UserService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [Route("api/user")]

    //localhost:3000/api/User/1

    [ApiController]
    public class UserController : ControllerBase
    {
        // goi service
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDTO request)
        {
            var result = await _userService.Register(request);

            if (result == null) 
                return BadRequest("Register failed !");

            return Ok("Register sucessfully !");
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDTO request)
        {
            var result = await _userService.Login(request);

            if (result == null)
                return BadRequest("Login failed !");

            return Ok($"Welcome back, {result.Username}! :)");
        }

        [HttpPost("verify-email")]
        public async Task<ActionResult<User>> VerifyEmail(string token)
        {
            var result = await _userService.VerifyEmail(token);

            if (result == null)
                return BadRequest("Email verification failed !");

            return Ok("Email sucessfully verified !");
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<User>> ForgotPassword(string email)
        {
            var result = await _userService.ForgotPassword(email);

            if (result == null)
                return BadRequest("Can't find your email address.");

            return Ok("Now, you can change the password.");
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<User>> ResetPassword(ResetPasswordDTO request)
        {
            var result = await _userService.ResetPassword(request);

            if (result == null)
                return BadRequest("Reset password failed !");

            return Ok("Reset password sucessfully !");
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            // Trả về toàn bộ dữ liệu || OK là status code 200
            return await _userService.GetAllUser();
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<User>> GetUserProfile(int id)
        {
            // Tìm User bằng id
            var result = await _userService.GetUserProfile(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            // dữ liệu mẫu đem Add thêm model user vào
            var result = await _userService.AddUser(user);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User user)
        {
            // tìm user
            var result = await _userService.UpdateUser(id, user);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {

            var result = await _userService.DeleteUser(id);
            if (result is null)
                return NotFound("user not found");

            return NoContent();
        }
    }
}
