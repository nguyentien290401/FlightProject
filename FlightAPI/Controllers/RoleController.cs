using FlightAPI.Models;
using FlightAPI.Services.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [Route("api/role")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<List<Role>>>? GetAllList()
        {
            var result = await _roleService.GetAllList();
            if (result == null) 
                return NotFound("The list role is not found !");

            return Ok(result);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Role>>? GetRoleByID(int id)
        {
            var result = await _roleService.GetRoleByID(id);
            if (result == null)
                return null;

            return Ok(result);
        }
    }
}
