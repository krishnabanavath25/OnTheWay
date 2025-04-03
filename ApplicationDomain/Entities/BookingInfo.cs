using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class BookingInfo
    {
        [Key]
        public int Id { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerEmail { get; set; }
        public DateTime BookingDate { get; set; }
        public FlightInfo? FlightInfo { get; set; }
        public int FlightInfoId { get; set; }
  
        public AirportInfo? AirportInfo { get; set; }

        public int AirportInfoId { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
