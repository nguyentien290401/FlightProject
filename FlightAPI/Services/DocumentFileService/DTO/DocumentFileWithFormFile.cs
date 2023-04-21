using FlightAPI.Models;
using Microsoft.Build.Framework;

namespace FlightAPI.Services.DocumentFileService.DTO
{
    public class DocumentFileWithFormFile
    {
        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public int DocumentID { get; set; }

        [Required]         
        public IFormFile FormFile { get; set; }
    }
}
