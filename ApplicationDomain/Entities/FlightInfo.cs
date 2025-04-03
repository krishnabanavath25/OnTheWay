using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
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
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public AirportInfo? AirportInfo { get; set; }

        public int AirportInfoId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }



        //public class FlightInfo
        //{
        //    [Key]
        //    public int Id { get; set; }
        //    public string? FlightNumber { get; set; }
        //    public string? Airline { get; set; }
        //    public string? Departure { get; set; }
        //    public string? Arrival { get; set; }
        //    public DateTime DepartureTime { get; set; }
        //    public DateTime ArrivalTime { get; set; }
        //    public decimal Price { get; set; }
        //    public DateTime CreatedOn { get; set; }
        //    public DateTime UpdatedOn { get; set; }
        //    public bool Status { get; set; }
        //}

        //public class Booking
        //{
        //    [Key]
        //    public int Id { get; set; }
        //    public string? PassengerName { get; set; }
        //    public string? PassengerEmail { get; set; }
        //    public DateTime BookingDate { get; set; }
        //    public int FlightId { get; set; }
        //    public FlightInfo? FlightInfo { get; set; }
        //    public DateTime CreatedOn { get; set; }
        //    public DateTime UpdatedOn { get; set; }
        //    public bool Status { get; set; }
        //}
        //public class AirportInfo
        //{
        //    [Key]
        //    public int AirportId { get; set; }
        //    public string? AirportName { get; set; }
        //    public string? AirportLocation { get; set; }
        //    public string? ImagePath { get; set; }
        //    public DateTime CreatedOn { get; set; }
        //    public DateTime UpdatedOn { get; set; }
        //    public bool Status { get; set; }
        //}

    }
}
