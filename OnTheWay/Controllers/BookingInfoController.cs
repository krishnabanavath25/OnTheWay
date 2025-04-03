using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace OnTheWayPrj.Controllers
{
    public class BookingInfoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _env;

        public BookingInfoController(HttpClient httpClient, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:44365/api/BookingInfoApi");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<IEnumerable<BookingInfo>>();
                return View(data);
            }

            return View(new List<BookingInfo>());
            //var response = await _httpClient.GetAsync("https://localhost:44365/api/BookingInfoApi");
           
           
            //if (response.IsSuccessStatusCode)
            //{
               
            //        var data = await response.Content.ReadFromJsonAsync<IEnumerable<BookingInfo>>();
            //    foreach (var booking in data)
            //    {
            //        var flightId = booking.FlightInfoId;
            //        var airportId = booking.AirportInfoId;
            //        var flightdata = await _httpClient.GetAsync($"https://localhost:44365/api/FlightInfoApi/{flightId}");
            //        flightdata.EnsureSuccessStatusCode();
            //        var flightinfodata = await flightdata.Content.ReadFromJsonAsync<FlightInfo>();
            //        var airportdata = await _httpClient.GetAsync($"https://localhost:44365/api/AirportInfoApi/{airportId}");
            //        airportdata.EnsureSuccessStatusCode();
            //        var airportinfodata = await airportdata.Content.ReadFromJsonAsync<AirportInfo>();
            //        booking.FlightInfo = flightinfodata;
            //        booking.AirportInfo = airportinfodata;
            //    }

            //    return View(data);
            //}
            //return View(new List<Application.Domain.Entities.BookingInfo>());
            
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var flightResponse = await _httpClient.GetAsync("https://localhost:44365/api/FlightInfoApi");
            var airportResponse = await _httpClient.GetAsync("https://localhost:44365/api/AirportInfoApi");
            if (flightResponse.IsSuccessStatusCode && airportResponse.IsSuccessStatusCode)
            {
                var flightsJson = await flightResponse.Content.ReadAsStringAsync();
                var airportsJson = await airportResponse.Content.ReadAsStringAsync();

                ViewBag.Flights = JsonConvert.DeserializeObject<List<FlightInfo>>(flightsJson);
                ViewBag.Airports = JsonConvert.DeserializeObject<List<AirportInfo>>(airportsJson);
            }
            else
            {
                ViewBag.Flights = new List<FlightInfo>();
                ViewBag.Airports = new List<AirportInfo>();
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Application.Domain.Entities.BookingInfo bookingInfo)
        {
            bookingInfo.CreatedOn = DateTime.Now;
            bookingInfo.Status = true;
            ModelState.Remove("AirportInfo");
            ModelState.Remove("FlightInfo");
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44365/api/BookingInfoApi/Create", bookingInfo);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(bookingInfo);
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromForm] Application.Domain.Entities.BookingInfo bookinginfo, int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/BookingInfoApi/{id}");

            if (response != null)
            {
                var data = JsonConvert.DeserializeObject<Application.Domain.Entities.BookingInfo>(response);
                if (data != null)
                {
                    bookinginfo = data;
                    var flightId = data.FlightInfoId;
                    var airportId = data.AirportInfoId;
                    var flightdata = await _httpClient.GetAsync($"https://localhost:44365/api/FlightInfoApi/{flightId}");
                    flightdata.EnsureSuccessStatusCode();
                    var flightinfodata = await flightdata.Content.ReadFromJsonAsync<FlightInfo>();
                    var airportdata = await _httpClient.GetAsync($"https://localhost:44365/api/AirportInfoApi/{airportId}");
                    airportdata.EnsureSuccessStatusCode();
                    var airportinfodata = await airportdata.Content.ReadFromJsonAsync<AirportInfo>();
                    bookinginfo.FlightInfo = flightinfodata;
                    bookinginfo.AirportInfo = airportinfodata;
                    var flightResponse = await _httpClient.GetAsync("https://localhost:44365/api/FlightInfoApi");
                    var airportResponse = await _httpClient.GetAsync("https://localhost:44365/api/AirportInfoApi");
                    if (flightResponse.IsSuccessStatusCode && airportResponse.IsSuccessStatusCode)
                    {
                        var flightsJson = await flightResponse.Content.ReadAsStringAsync();
                        var airportsJson = await airportResponse.Content.ReadAsStringAsync();

                        ViewBag.Flights = JsonConvert.DeserializeObject<List<FlightInfo>>(flightsJson);
                        ViewBag.Airports = JsonConvert.DeserializeObject<List<AirportInfo>>(airportsJson);
                    }
                    else
                    {
                        ViewBag.Flights = new List<FlightInfo>();
                        ViewBag.Airports = new List<AirportInfo>();
                    }
                    return View(bookinginfo);
                }
            }
            //if (response == null)
            //{
            //    return NotFound(); // Return a 404 if no data is found
            //}

            //// Deserialize the BookingInfo object (with included related entities)
            //var bookinginfo = JsonConvert.DeserializeObject<Application.Domain.Entities.BookingInfo>(response);

            //// Extract flights and airports directly from the included entities
            //ViewBag.Flights = bookinginfo.FlightInfo != null ? new List<FlightInfo> { bookinginfo.FlightInfo } : new List<FlightInfo>();
            //ViewBag.Airports = bookinginfo.AirportInfo != null ? new List<AirportInfo> { bookinginfo.AirportInfo } : new List<AirportInfo>();

            //return View(bookinginfo);
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id,[FromForm] Application.Domain.Entities.BookingInfo bookingInfo)
        {
            bookingInfo.UpdatedOn = DateTime.Now;
            ModelState.Remove("AirportInfo");
            ModelState.Remove("FlightInfo");
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44365/api/BookingInfoApi/{id}", bookingInfo);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(bookingInfo);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/BookingInfoApi/{id}");
            if (response != null)
            {
                var data = JsonConvert.DeserializeObject<Application.Domain.Entities.BookingInfo>(response);
                return View(data);
            }
            return RedirectToAction("Index");

        }
        
        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var DeleteResponse = await _httpClient.DeleteAsync($"https://localhost:44365/api/BookingInfoApi/{id}");
            if (DeleteResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
            //var response = await _httpClient.GetAsync($"https://localhost:44365/api/BookingInfoApi/{id}");
            //if (!response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}

            //var bookingInfo = await response.Content.ReadFromJsonAsync<Application.Domain.Entities.BookingInfo>();
            //if (bookingInfo != null)
            //{
            //    bookingInfo.Status = false; // Perform soft delete by updating the status
            //    var updateResponse = await _httpClient.DeleteAsync($"https://localhost:44365/api/BookingInfoApi/{id}");
            //    if (updateResponse.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}

            //return View(bookingInfo);
        }


    }
}
