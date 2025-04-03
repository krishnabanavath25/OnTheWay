using Application.Domain.Entities;
using Application.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnTheWayPrj.Models;
using System.Net.Http;

namespace OnTheWayPrj.Controllers
{
    public class AirportInfoApiController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _env;

        public AirportInfoApiController(HttpClient httpClient, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _env = env;
        }

        // Index Action

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:44365/api/AirportInfoApi");
            if (response.IsSuccessStatusCode)
            {
                var dataJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Application.Domain.Entities.AirportInfo>>(dataJson);
                return View(data);
            }
            return View(new List<Application.Domain.Entities.AirportInfo>());
        }
        // Create Action
        [HttpGet]
        public IActionResult Create( )
        {
           
            
            //var model = new Application.Domain.Entities.AirportInfo();
            //return View(model);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Application.Domain.Entities.AirportInfo airportInfo,[FromForm] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Save image and generate file path
                //string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
                string fileName = Path.GetFileName(imageFile.FileName);
                string filePath = Path.Combine("wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                airportInfo.ImagePath = Path.Combine("images", fileName); // Relative path
                //airportInfo.ImagePath = fileName;
            }

            airportInfo.CreatedOn = DateTime.Now;
            airportInfo.Status = true;

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44365/api/AirportInfoApi/Create", airportInfo);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(airportInfo);
        }
       

        // Edit Action
        public async Task<IActionResult> Edit(Application.Domain.Entities.AirportInfo airportInfo, int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/AirportInfoApi/{id}");
            //var model = JsonConvert.DeserializeObject(response, Type.GetType($"Application.Domain.Entities.airportInfo, Application"));
            //TempData["Data"] = JsonConvert.SerializeObject(model);
            if (response != null)
            {
                var data = JsonConvert.DeserializeObject<Application.Domain.Entities.AirportInfo>(response);

                return View(data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[FromForm] Application.Domain.Entities.AirportInfo airportInfo,[FromForm] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Save image and generate file path
                //string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
                string fileName = Path.GetFileName(imageFile.FileName);
                string filePath = Path.Combine("wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                airportInfo.ImagePath = Path.Combine("images", fileName); // Relative path
                //airportInfo.ImagePath = fileName;
            }
            else
            {
                airportInfo.ImagePath = airportInfo.ImagePath;
                
            }

            airportInfo.UpdatedOn = DateTime.Now;
            ModelState.Remove("imageFile");
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44365/api/AirportInfoApi/{id}", airportInfo);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(airportInfo);
            //return View("Edit", model);
        }


        // Delete Action
        [HttpGet]
        public async Task<IActionResult> Delete( int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/AirportInfoApi/{id}");
            if (response != null)
            {
                var data = JsonConvert.DeserializeObject<Application.Domain.Entities.AirportInfo>(response);
                return View(data);
            }
            return View();
            
        }

        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed([FromForm] Application.Domain.Entities.AirportInfo airportInfo, int id)
        {

            airportInfo.Status = false;
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44365/api/AirportInfoApi/{id}", airportInfo);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(airportInfo);
        }

    }
}
