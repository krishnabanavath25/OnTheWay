using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
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
