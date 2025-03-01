using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_2_UI.Dtos.FeatureDtos;

namespace RealEstate_2_UI.ViewComponents.UI_Layout
{
    public class _UIFeaturesComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIFeaturesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMess = await client.GetAsync("https://localhost:44387/api/Feature");
            if (responseMess.IsSuccessStatusCode)
            {
                var json = await responseMess.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(json);
                return View(values);
            }
            return View();
        }
        
    }
}
