using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_2_UI.Dtos.CategoryDtos;
using RealEstate_2_UI.Dtos.ProductDtos;
using System.Text;

namespace RealEstate_2_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var jsonMess = await client.GetAsync("https://localhost:44387/api/Product/ProductwithCategory");
            if (jsonMess.IsSuccessStatusCode)
            {
                var jsonData = await jsonMess.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44387/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;

            return View();
        }

        //[HttpPost]

        //public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var JsonData = JsonConvert.SerializeObject(createProductDto);
        //    StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        //    var responseMess = await client.PostAsync("https://localhost:44387/api/Categories", stringContent);
        //    if (responseMess.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
