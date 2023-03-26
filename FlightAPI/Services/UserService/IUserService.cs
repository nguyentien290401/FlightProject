using FlightAPI.Models;

namespace FlightAPI.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User>? GetUserProfile(int id);
        Task<List<User>>? AddUser(User user);
        Task<List<User>>? UpdateUser(int id, User user);
        Task<List<User>>? DeleteUser(int id);
    }
}
