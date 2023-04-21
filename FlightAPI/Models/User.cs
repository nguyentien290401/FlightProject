using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

        public string? VerificationOTP { get; set; }
        public DateTime? VerifiedAt { get; set; }

        public string? PasswordResetOTP { get; set; }
        public DateTime? ResetOTPExpires { get; set; }

        public int RoleID { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }

        [JsonIgnore]
        public List<Document> Document { get; set; }

        [JsonIgnore]
        public List<DocumentFile> DocumentFiles { get; set; }
    }
}
