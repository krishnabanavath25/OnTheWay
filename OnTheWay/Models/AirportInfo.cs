using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnTheWayPrj.Models
{
    public class AirportInfo
    {
        [Key]
        [Column("AirportId")]
        public int Id { get; set; }
        public string? AirportName { get; set; }
        public string? AirportLocation { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
