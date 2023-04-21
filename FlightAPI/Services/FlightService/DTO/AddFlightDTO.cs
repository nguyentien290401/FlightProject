
using Microsoft.Build.Framework;

namespace FlightAPI.Services.FlightService.DTO
{
    public class AddFlightDTO
    {
        [Required]
        public string FlightCode { get; set; } = string.Empty;

        [Required]
        public string LocationFrom { get; set; } = string.Empty;

        [Required]
        public string LocationTo { get; set; } = string.Empty;

        [Required]
        public DateTime DepartureDate { get; set; }
    }
}
