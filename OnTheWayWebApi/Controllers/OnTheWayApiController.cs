using Application.Application.DTOs;
using Application.Application.Services;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace OnTheWayWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnTheWayApiController : ControllerBase
    {
        private readonly IFlightServices.IFilgthInfo _flightInfoServices;
        private readonly IFlightServices.IAirportInfo _airportInfoServices;
        private readonly IFlightServices.IBooking _bookingService;
        public OnTheWayApiController(IFlightServices.IFilgthInfo flightInfoServices, IFlightServices.IAirportInfo airportInfoServices, IFlightServices.IBooking bookingService)
        {
            _flightInfoServices = flightInfoServices;
            _airportInfoServices = airportInfoServices;
            _bookingService = bookingService;
        }
        //Flight Information
       
            [HttpGet]
            public async Task<ActionResult<IEnumerable<FlightDto.FlightInfoDto>>> GetAllFlightInfo()
            {
                var fltinfo = await _flightInfoServices.GetAllFltInfoAsync();
                return Ok(fltinfo);
            }
            [HttpGet("Flights.FlightInfo/{id}")]
            public async Task<ActionResult<FlightDto.FlightInfoDto>> GetFlightInfoById(int id)
            {
                var fltinfobyid = await _flightInfoServices.GetFltInfoByIdAsync(id);
                if (fltinfobyid == null)
                {
                    return NotFound();
                }
                return Ok(fltinfobyid);
            }
            [HttpPost]
            public async Task<ActionResult<int>> AddFlightInfo(FlightDto.FlightInfoDto flightInfo)
            {
                var result = await _flightInfoServices.CreateFltInfoAsync(flightInfo);
                return Ok(result);
            }
            [HttpPut("Flights.FlightInfo/{id}")]
            public async Task<ActionResult<int>> UpdateFlightINfo(int id, FlightDto.FlightInfoDto flightInfo)
            {
                if (id != flightInfo.Id)
                {
                    var result = await _flightInfoServices.UpdateFltInfoAsync(id, flightInfo);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
        [HttpDelete("Flights.FlightInfo/{id}")]
        public async Task<ActionResult<int>> DeleteFlightinfo(int id, FlightDto.FlightInfoDto finfo)
        {
            if (id != finfo.Id)
            {
                var result = await _flightInfoServices.DeleteFltInfoAsync(id, finfo);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }





        //Airport Informattion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto.AirportInfoDto>>> GetAllAirports()
        {
            var airports = await _airportInfoServices.GetAllAiportInfoAsync();
            return Ok(airports);
        }
        [HttpGet("Flights.AirportInfo/{id}")]
        public async Task<ActionResult<FlightDto.AirportInfoDto>> GetAirportById(int id)
        {
            var airportbyid = await _airportInfoServices.GetAiportInfoByIdAsync(id);
            return Ok(airportbyid);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddAirportInfo(FlightDto.AirportInfoDto airportInfo)
        {
            var result = await _airportInfoServices.CreateAiportInfoAsync(airportInfo);
            return Ok(result);
        }

        [HttpPut("Flights.AirportInfo/{id}")]
        public async Task<ActionResult<int>> UpdateAirportINfo(int id, FlightDto.AirportInfoDto airportInfo)
        {
            if (id != airportInfo.AirportId)
            {
                var result = await _airportInfoServices.UpdateAiportInfoAsync(id, airportInfo);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete("Flights.AirportInfo/{id}")]
        public async Task<ActionResult<int>> DeleteAirport(int id, FlightDto.AirportInfoDto airportInfo)
        {
            if (id != airportInfo.AirportId)
            {
                var result = await _airportInfoServices.UpdateAiportInfoAsync(id, airportInfo);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        //Booking 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto.BookingDto>>> GetAllBookings()
        {
            var bookingd = await _bookingService.GetAllBookingAsync();
            return Ok(bookingd);
        }
        [HttpGet("Flights.Booking/{id}")]
        public async Task<ActionResult<FlightDto.BookingDto>> GetBookingById(int id)
        {
            var bookingbyid = await _bookingService.GetBookingBYIdAsync(id);
            if (bookingbyid == null)
            {
                return NotFound();
            }
            return Ok(bookingbyid);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddBookings(FlightDto.BookingDto bookings)
        {
            var result = await _bookingService.CreateBookingAsync(bookings);
            return Ok(result);
        }
        [HttpPut("Flights.Booking/{id}")]
        public async Task<ActionResult<int>> UpdateBooking(int id, FlightDto.BookingDto booking)
        {
            if (id != booking.Id)
            {
                var result = await _bookingService.UpdateBookingAsync(id, booking);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete("Flights.Booking/{id}")]
        public async Task<ActionResult<int>> DeleteBooking(int id, FlightDto.BookingDto booking)
        {
            if (id != booking.Id)
            {
                var result = await _bookingService.DeleteBookingAsync(id, booking);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
