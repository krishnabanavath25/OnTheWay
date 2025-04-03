using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OnTheWayPrj.Controllers
{
    public class FlightInfoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _env;

        public FlightInfoController(HttpClient httpClient, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:44365/api/FlightInfoApi");
            if (response.IsSuccessStatusCode)
            {
                var dataJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Application.Domain.Entities.FlightInfo>>(dataJson);
                return View(data);
            }
            return View(new List<Application.Domain.Entities.FlightInfo>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var airportResponse = await _httpClient.GetAsync("https://localhost:44365/api/AirportInfoApi");
            if (airportResponse.IsSuccessStatusCode)
            {

                var airportsJson = await airportResponse.Content.ReadAsStringAsync();


                ViewBag.Airports = JsonConvert.DeserializeObject<List<Application.Domain.Entities.AirportInfo>>(airportsJson);
            }
            else
            {

                ViewBag.Airports = new List<Application.Domain.Entities.AirportInfo>();
            }
            return View();
        }


        [HttpPost]
         public async Task<IActionResult> Create([FromForm] Application.Domain.Entities.FlightInfo flightInfo)
        {
            flightInfo.CreatedOn = DateTime.Now;
            flightInfo.Status = true;
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44365/api/FlightInfoApi/Create", flightInfo);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(flightInfo);
        }

        public async Task<IActionResult> Edit(Application.Domain.Entities.FlightInfo flight, int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/FlightInfoApi/{id}");
           
            if (response != null)
            {
                var data = JsonConvert.DeserializeObject<Application.Domain.Entities.FlightInfo>(response);
                var airportResponse = await _httpClient.GetAsync("https://localhost:44365/api/AirportInfoApi");
                if (airportResponse.IsSuccessStatusCode)
                {

                    var airportsJson = await airportResponse.Content.ReadAsStringAsync();


                    ViewBag.Airports = JsonConvert.DeserializeObject<List<Application.Domain.Entities.AirportInfo>>(airportsJson);
                }
                else
                {

                    ViewBag.Airports = new List<Application.Domain.Entities.AirportInfo>();
                }
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] Application.Domain.Entities.FlightInfo flightInfo)
        {

            flightInfo.UpdatedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44365/api/FlightInfoApi/{id}", flightInfo);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(flightInfo);
            
        }
        // Delete Action
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/FlightInfoApi/{id}");
            if (response != null)
            {
                var data = JsonConvert.DeserializeObject<Application.Domain.Entities.FlightInfo>(response);
                return View(data);
            }
            return View();

        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed([FromForm] Application.Domain.Entities.FlightInfo flightInfo, int id)
        {

            flightInfo.Status = false;
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44365/api/FlightInfoApi/{id}", flightInfo);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(flightInfo);
        }

    }
}
