using Microsoft.Build.Framework;

namespace FlightAPI.Services.DocumentService.DTO
{
    public class AddDocumentDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Note { get; set; } = string.Empty;

        [Required]
        public IFormFile FormFile { get; set; }

        [Required]
        public int FlightID { get; set; }

        [Required]
        public int Document_TypeID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int GroupID { get; set; }
    }
}
