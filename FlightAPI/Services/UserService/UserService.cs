using Azure;
using Azure.Core;
using FlightAPI.DatabaseContext;
using FlightAPI.Models;
using FlightAPI.Services.UserService.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FlightAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly FlightDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserService(FlightDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User>? Register(UserRegisterDTO request)
        {
            if (_dbContext.Users.Any(u => u.Email == request.Email))
                return null;

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            if ((request.Email.Substring(request.Email.Length - 14, 14)) != "vietjetair.com")
                return null;

            var user = new User
            {
                Username = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleID = request.RoleID,
                VerificationOTP = CreateRandomOTP()
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            #region Send OTP code to verify email
            
            //var senderEmail = new MailAddress("minhtien29042001@gmail.com", "Tiennnm@es.vn");
            //var receiverEmail = new MailAddress(user.Email, "Receiver");
            //var password = "Lovelive9";
            //var sub = "Verify Email Notification !";
            //var body = $"This is the OTP code: {user.VerificationToken} to verify your email.";
            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(senderEmail.Address, password)
            //};
            //using (var mess = new MailMessage(senderEmail, receiverEmail)
            //{
            //    Subject = sub,
            //    Body = body
            //})
            //{
            //    smtp.Send(mess);
            //}

            #endregion

            return user;
        }

        public async Task<string>? Login(UserLoginDTO request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            if (user.VerifiedAt == null)
                return null;

            string token = CreateToken(user);

            return token;
        }
      
        public async Task<User>? VerifyEmail(string otp)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.VerificationOTP == otp);

            if (user == null)
                return null;

            user.VerifiedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> ForgotPassword(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return null;

            user.PasswordResetOTP = CreateRandomOTP();
            user.ResetOTPExpires = DateTime.Now.AddMinutes(1);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> ResetPassword(ResetPasswordDTO request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.PasswordResetOTP == request.OTP);
            if (user == null || user.ResetOTPExpires < DateTime.Now)
                return null;

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetOTP = null;
            user.ResetOTPExpires = null;

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            var user = await _dbContext.Users./*Include(r => r.Role).*/ToListAsync();

            return user;
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
            oneUser.PasswordHash = user.PasswordHash;
            oneUser.Phone = user.Phone;
            

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

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>();

            if (user.RoleID == 1)
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            } 
            else if(user.RoleID == 2)
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.Role, "Staff"));
            }
            else if(user.RoleID == 3)
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.Role, "Pilot"));
            }
            else if (user.RoleID == 4)
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.Role, "Stewardess"));
            }
            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private string CreateRandomOTP()
        {
            Random random = new Random();
            var otp = random.Next(99999, 1000000);

            return otp.ToString();
        }

        //private string CreateRandomToken()
        //{
        //    return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        //}

    }
}
