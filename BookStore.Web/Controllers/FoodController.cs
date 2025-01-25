using BookStore.Domain.Models.Domain;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class FoodController : Controller
    {
        public FoodController() {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5255/api/api/GetAllFoods";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Food>>().Result;
            return View(data);
        }
    }
}
