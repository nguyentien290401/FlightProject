using FlightAPI.DatabaseContext;
using FlightAPI.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace FlightAPI.Services.RoleService
{
    public class RoleService: IRoleService
    {
        private readonly FlightDbContext _dbContext;
        public RoleService(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>>? GetAllList()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            if (roles == null || roles.Count == 0)
                return null;

            return roles;
        }

        public async Task<Role>? GetRoleByID(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
                return null;

            return role;
        }
    }
}
