using System.ComponentModel.DataAnnotations;

namespace OnTheWayWebApiProject.Models
{
    public class FlightInfo
    {
        [Key]
        public int Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? Airline { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
