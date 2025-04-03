namespace OnTheWayWebApiProject.Models
{
    public class BookingInfo
    {
        public string? PassengerName { get; set; }
        public string? PassengerEmail { get; set; }
        public DateTime BookingDate { get; set; }
        public int FlightId { get; set; }
        public FlightInfo? FlightInfo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
