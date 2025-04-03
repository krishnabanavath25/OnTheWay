namespace OnTheWayPrj.Models
{
    public class BookingInfo
    {
        public int Id { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerEmail { get; set; }
        public DateTime BookingDate { get; set; }
        public int FlightInfoId { get; set; }
        //public decimal Price { get; set; }
        public FlightInfo? FlightInfo { get; set; }
        public int AirportInfoId { get; set; }
        public AirportInfo? AirportInfo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }

        
    }
}
