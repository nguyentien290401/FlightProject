using FlightAPI.Models;
using FlightAPI.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [Route("api/[controller]")]

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

        [HttpGet]
        public ActionResult<List<User>> GetAllUser()
        {
            // Trả về toàn bộ dữ liệu || OK là status code 200
            return _userService.GetAllUser();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserProfile(int id)
        {
            // Tìm User bằng id
            var result = _userService.GetUserProfile(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<List<User>> AddUser(User user)
        {
            // dữ liệu mẫu đem Add thêm model user vào
            var result = _userService.AddUser(user);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<List<User>> UpdateUser(int id, User request)
        {
            // tìm user
            var result = _userService.UpdateUser(id, request);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<User>> DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }
    }
}
