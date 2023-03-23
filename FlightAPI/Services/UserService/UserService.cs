using FlightAPI.Models;

namespace FlightAPI.Services.UserService
{
    public class UserService : IUserService
    {

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
        public List<User> AddUser(User user)
        {
            // dữ liệu mẫu đem Add thêm model user vào
            users.Add(user);

            // trả về list users
            return users;
        }

        public List<User>? DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
                return null;

            users.Remove(user);

            return users;
        }

        public List<User> GetAllUser()
        {
            return users;
        }

        public User? GetUserProfile(int id)
        {
            // Tìm User bằng id
            var user = users.Find(x => x.Id == id);

            // Nếu tìm không thấy thì return về lỗi
            if (user is null)
                return null;

            // Nếu tìm thấy thì return về user tìm thấy
            return user;
        }

        public List<User>? UpdateUser(int id, User user)
        {
            // tìm user
            var oneUser = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            oneUser.Username = user.Username;
            oneUser.Email = user.Email;
            oneUser.Password = user.Password;
            oneUser.Phone = user.Phone;
            oneUser.RoleName = user.RoleName;

            return users;
        }
    }
}
