using FlightAPI.Models;

namespace FlightAPI.Services.DocumentFileService.DTO
{
    public class DocumentFileWithFormFile
    {
        public string FileName { get; set; } = string.Empty;
        public int UserID { get; set; }
       
        public IFormFile FormFile { get; set; }
    }
}
