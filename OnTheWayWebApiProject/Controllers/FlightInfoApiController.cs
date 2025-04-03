using Application.Application.Services;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnTheWayWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightInfoApiController : GenericApiController<FlightInfo>
    {
        public FlightInfoApiController(IServices<FlightInfo> service) : base(service)
        {
        }
    }
}
