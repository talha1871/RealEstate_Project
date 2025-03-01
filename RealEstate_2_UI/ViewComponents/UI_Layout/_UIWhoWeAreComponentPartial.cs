using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_2_UI.Dtos.FeatureDtos;
using RealEstate_2_UI.Dtos.WhoWeAreDtos;
using System.Security.AccessControl;

namespace RealEstate_2_UI.ViewComponents.UI_Layout
{
    public class _UIWhoWeAreComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var jsonMes = await client.GetAsync("https://localhost:44387/api/WhoWeAre");
            if (jsonMes.IsSuccessStatusCode)
            {
                var jsonData = await jsonMes.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
