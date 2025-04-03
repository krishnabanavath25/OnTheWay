using Application.Application.Services;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnTheWayWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportInfoApiController : GenericApiController<AirportInfo>
    {
        public AirportInfoApiController(IServices<AirportInfo> services) : base(services)
        { 

        }
    }
}
