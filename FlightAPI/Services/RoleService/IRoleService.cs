using FlightAPI.Models;

namespace FlightAPI.Services.RoleService
{
    public interface IRoleService
    {
        Task<List<Role>>? GetAllList();
        Task<Role>? GetRoleByID(int id);
      
    }
}
