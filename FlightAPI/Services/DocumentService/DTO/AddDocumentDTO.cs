namespace FlightAPI.Services.DocumentService.DTO
{
    public class AddDocumentDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;

        public int FlightID { get; set; }
    }
}
