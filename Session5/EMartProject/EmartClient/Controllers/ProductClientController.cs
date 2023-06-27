using EmartClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EmartClient.Controllers
{
    public class ProductClientController : Controller
    {
        //GetAsync-----Sent Get Request
        //PostAsync-----Send Post Request
        //PutAsync------Send Put Request
        //DeleteAsync---- send Delete Request

        public async Task<ActionResult> GetAll()
        {
            //create a List To hold Values sent from API
            List<Productdto> all = new List<Productdto>();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:7193/api/Product"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    all = JsonConvert.DeserializeObject<List<Productdto>>(data);
                }
                return View(all);
            }

        }
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            Productdto product = new Productdto();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7193/api/Product/id?id={id}"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Productdto>(data);
                }
                return View(product);
            }

        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Productdto productdto)
        {
            Productdto? product = new Productdto();
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productdto), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:7193/api/Product", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Productdto>(data);
                }
                return RedirectToAction("GetAll");
            }

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7193/api/Product?id={id}"))
                {
                    return RedirectToAction("GetAll");
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            Productdto product = new Productdto();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7193/api/Product/{id}"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Productdto>(data);
                }
                return View(product);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(Productdto product)
        {
            using (var httpClient = new HttpClient())
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync($"https://localhost:7193/api/Product", jsonContent))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Productdto>(data);


                    return View(product);
                }
            }
        }



    }
}




