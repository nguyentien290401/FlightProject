using FlightAPI.Models;
using FlightAPI.Services.UserService.DTO;

namespace FlightAPI.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User>? GetUserProfile(int id);
        Task<List<User>>? DeleteUser(int id);
        Task<User>? Register(UserRegisterDTO request);
        Task<string>? Login(UserLoginDTO request);
        Task<User>? VerifyEmail(string otp);
        Task<User> ForgotPassword(string email);
        Task<User> ResetPassword(ResetPasswordDTO request);
    }
}
