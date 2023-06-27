using EmartClient.Models;
using EMartClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EmartClient.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            LoginDto? product = new LoginDto();
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:7193/api/Login", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<LoginDto>(data);
                }
                
                return View(product);
            }

        }
    }
}
