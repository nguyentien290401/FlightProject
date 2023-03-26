using FlightAPI.Models;
using FlightAPI.Services.UserService;
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
