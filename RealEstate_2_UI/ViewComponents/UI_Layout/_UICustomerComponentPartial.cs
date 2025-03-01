using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_2_UI.Dtos.CustomerDtos;

namespace RealEstate_2_UI.ViewComponents.UI_Layout
{
    public class _UICustomerComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UICustomerComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMess = await client.GetAsync("https://localhost:44387/api/Customer");
            if (responseMess.IsSuccessStatusCode)
            {
                var json = await responseMess.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(json);
                return View(values);
            }
            return View();
        }
    }
}
