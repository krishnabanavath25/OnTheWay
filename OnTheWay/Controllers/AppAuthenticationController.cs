//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using System.Text;

//namespace OnTheWay.Controllers
//{
//    public class AppAuthenticationController : Controller
//    {
//        private readonly HttpClient _httpClient;
//        public AuthenticationApiconsumeController(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult Login()
//        {
//            //return RedirectToAction("Index", "Home");
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Login(LoginModel login)
//        {
//            var requestContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
//            var response = await _httpClient.PostAsync("https://localhost:44354/api/Authenticate/login", requestContent);
//            if (response.IsSuccessStatusCode)
//            {
//                var responseContent = await response.Content.ReadAsStringAsync();
//                var user = JsonConvert.DeserializeObject<RegisterModel>(responseContent);
//                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.Username) },
//                           CookieAuthenticationDefaults.AuthenticationScheme);
//                var principal = new ClaimsPrincipal(identity);
//                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
//                // Set user name in session
//                HttpContext.Session.SetString("UserName", user.Username);

//                var userName = HttpContext.Session.GetString("UserName");
//                ViewBag.UserName = userName;

//                return RedirectToAction("Index", "Home");
//            }
//            else
//            {
//                var errorMessage = await response.Content.ReadAsStringAsync();
//                Console.WriteLine(errorMessage);
//                return StatusCode((int)response.StatusCode, "Error occurred while processing the request.");
//            }

//        }
//        public IActionResult LogOut()
//        {
//            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            var storedcookies = Request.Cookies.Keys;
//            foreach (var cookies in storedcookies)
//            {
//                Response.Cookies.Delete(cookies);
//            }
//            return RedirectToAction("Login");
//        }
//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Register(RegisterModel register)
//        {
//            var requestContent = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
//            var response = await _httpClient.PostAsync("https://localhost:44354/api/Authenticate/register", requestContent);
//            if (response.IsSuccessStatusCode)
//            {

//                return RedirectToAction("Login");
//            }
//            else
//            {
//                var errorMessage = await response.Content.ReadAsStringAsync();
//                Console.WriteLine(errorMessage);
//                return StatusCode((int)response.StatusCode, "Error occurred while processing the request.");
//            }

//        }
        
//    }
//}
