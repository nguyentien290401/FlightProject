using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightAPI.Models
{
    public class DocumentFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string Url { get; set; } = string.Empty;
        public int UserID { get; set; }
        //public int DocumentID { get; set; }

        public User User { get; set; }
        //public Document Document { get; set; }
    }
}
