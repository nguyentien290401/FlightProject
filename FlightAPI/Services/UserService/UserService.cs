using FlightAPI.DatabaseContext;
using FlightAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FlightAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly FlightDbContext _dbContext;
        public UserService(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Fake User Data list
        // Tạo dữ liệu mẫu thay thế cho database
        private static List<User> users = new List<User>
        {
            new User {
                Id = 1,
                Username = "Admin",
                Email = "Admin@vietjetair.com",
                Password = "123456",
                Phone = "0123456789",
                RoleName = "ADMIN"
            },
            new User {
                Id = 2,
                Username = "GO Employee",
                Email = "Staff@vietjetair.com",
                Password = "123456",
                Phone = "0123456789",
                RoleName = "GO"
            },
            new User {
                Id = 3,
                Username = "Pilot",
                Email = "Pilot@vietjetair.com",
                Password = "123456",
                Phone = "0987654321",
                RoleName = "PILOT"
            },
            new User {
                Id = 4,
                Username = "Crew",
                Email = "Crew@vietjetair.com",
                Password = "123456",
                Phone = "0987654321",
                RoleName = "CREW"
            }
        };
        #endregion

        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User>? GetUserProfile(int id)
        {
            // Tìm User bằng id
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            // Nếu tìm không thấy thì return về lỗi
            if (user == null)
                return null;

            // Nếu tìm thấy thì return về user tìm thấy
            return user;
        }

        public async Task<List<User>>? AddUser(User user)
        {
            // dữ liệu mẫu đem Add thêm model user vào
            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            // trả về list users
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<User>>? UpdateUser(int id, User user)
        {
            if (id != user.Id)
                return null;

            // tìm user
            var oneUser = await _dbContext.Users.FindAsync(id);

            if (oneUser == null)
                return null;

            oneUser.Username = user.Username;
            oneUser.Email = user.Email;
            oneUser.Password = user.Password;
            oneUser.Phone = user.Phone;
            oneUser.RoleName = user.RoleName;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<User>>? DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
                return null;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Users.ToListAsync();
        }  
    }
}
