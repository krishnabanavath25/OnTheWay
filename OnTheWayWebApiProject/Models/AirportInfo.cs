using System.ComponentModel.DataAnnotations;

namespace OnTheWayWebApiProject.Models
{
    public class AirportInfo
    {
        [Key]
        public int AirportId { get; set; }
        public string? AirportName { get; set; }
        public string? AirportLocation { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
