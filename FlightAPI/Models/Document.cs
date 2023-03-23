namespace FlightAPI.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
    }
}
