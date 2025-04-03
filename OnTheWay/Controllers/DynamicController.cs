
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnTheWayWebApiProject.Models;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace OnTheWayPrj.Controllers
{
    public class DynamicController : Controller
    {

        //private readonly HttpClient _httpClient;

        //public DynamicController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //// Index Action
        //public async Task<IActionResult> Index(string entity)
        //{
        //    var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/{entity}");
        //    var data = JsonConvert.DeserializeObject(response, Type.GetType($"Application.Domain.Entities.{entity}, Application"));
        //    TempData["Data"] = JsonConvert.SerializeObject(data);
        //    return RedirectToAction("Index", entity);  // Redirect to the specific entity controller
        //}

        //// Create Action
        //public IActionResult Create(string entity)
        //{
        //    return RedirectToAction("Create", entity);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(string entity, object model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _httpClient.PostAsJsonAsync($"https://localhost:44365/api/{entity}", model);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index), new { entity });
        //        }
        //    }
        //    return View("Create", model);
        //}

        //// Edit Action
        //public async Task<IActionResult> Edit(string entity, int id)
        //{
        //    var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/{entity}/{id}");
        //    var model = JsonConvert.DeserializeObject(response, Type.GetType($"Application.Domain.Entities.{entity}, Application"));
        //    TempData["Data"] = JsonConvert.SerializeObject(model);
        //    return RedirectToAction("Edit", entity);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(string entity, object model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _httpClient.PutAsJsonAsync($"https://localhost:44365/api/{entity}", model);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index), new { entity });
        //        }
        //    }
        //    return View("Edit", model);
        //}

        //// Delete Action
        //public async Task<IActionResult> Delete(string entity, int id)
        //{
        //    var response = await _httpClient.GetStringAsync($"https://localhost:44365/api/{entity}/{id}");
        //    var model = JsonConvert.DeserializeObject(response, Type.GetType($"Application.Domain.Entities.{entity}, Application"));
        //    return View("Delete", model);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(string entity, int id)
        //{
        //    var response = await _httpClient.DeleteAsync($"https://localhost:44365/api/{entity}/{id}");
        //    return RedirectToAction(nameof(Index), new { entity });
        //}

































        //private readonly HttpClient _httpClient;

        //public DynamicAirportsController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //    _httpClient.BaseAddress = new Uri("https://localhost:44365/api/AirportInfoApi");
        //}
        //// GET: AirportInfo
        //public async Task<IActionResult> Index()
        //{
        //    var airportInfos = await _httpClient.GetFromJsonAsync<List<AirportInfoDto>>("AirportInfo");
        //    return View(airportInfos);
        //}

        //// GET: AirportInfo/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    var airportInfo = await _httpClient.GetFromJsonAsync<AirportInfoDto>($"AirportInfo/{id}");
        //    if (airportInfo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(airportInfo);
        //}

        //// GET: AirportInfo/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AirportInfo/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AirportId,AirportName,AirportLocation,ImagePath")] AirportInfoDto airportInfo)
        //{
        //    airportInfo.CreatedOn = DateTime.Now;
        //    airportInfo.Status = true;
        //    var files = Request.Form.Files;
        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //            // Set the ImagePath property of the bike object to the relative path of the uploaded image
        //            airportInfo.ImagePath = "/images/" + fileName;
        //        }
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _httpClient.PostAsJsonAsync("AirportInfo", airportInfo);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(airportInfo);
        //}

        //// GET: AirportInfo/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var airportInfo = await _httpClient.GetFromJsonAsync<AirportInfoDto>($"AirportInfo/{id}");
        //    if (airportInfo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(airportInfo);
        //}

        //// POST: AirportInfo/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AirportId,AirportName,AirportLocation,ImagePath")] AirportInfoDto airportInfo)
        //{
        //    airportInfo.UpdatedOn = DateTime.Now;
        //    if (id != airportInfo.AirportId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var response = await _httpClient.PutAsJsonAsync($"AirportInfo/{id}", airportInfo);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(airportInfo);
        //}

        //// GET: AirportInfo/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{

        //    var airportInfo = await _httpClient.GetFromJsonAsync<AirportInfoDto>($"AirportInfo/{id}");
        //    if (airportInfo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(airportInfo);
        //}

        //// POST: AirportInfo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id, AirportInfoDto airportInfo)
        //{
        //    airportInfo.UpdatedOn = DateTime.Now;
        //    if (id != airportInfo.AirportId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var response = await _httpClient.PutAsJsonAsync($"AirportInfo/{id}", airportInfo);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(airportInfo);
        //}
    }
    
}
