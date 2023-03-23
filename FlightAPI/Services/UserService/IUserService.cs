using FlightAPI.Models;

namespace FlightAPI.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User? GetUserProfile(int id);
        List<User>? AddUser(User user);
        List<User>? UpdateUser(int id, User user);
        List<User>? DeleteUser(int id);
    }
}
