using Application.Application.Services;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnTheWayWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingInfoApiController :GenericApiController<BookingInfo>
    {
        public BookingInfoApiController(IServices<BookingInfo> services):base(services) 
        {
           
        }
        [HttpGet]
        public override async Task<IEnumerable<BookingInfo>> GetAll([FromQuery] string[] includes)
        {
            if (includes == null || includes.Length == 0)
            {
                includes = new[] { "FlightInfo", "AirportInfo" };
            }

            return await base.GetAll(includes);
        }
        public override async Task<ActionResult<BookingInfo>> GetById(int id, [FromQuery] string[] includes)
        {
            if (includes == null || includes.Length == 0)
            {
                includes = new[] { "FlightInfo", "AirportInfo" };
            }
            
            return await base.GetById(id, includes);
        }
    }
}
