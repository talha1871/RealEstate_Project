using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Newtonsoft.Json;
using RealEstate_2_UI.Dtos.AgentDtos;

namespace RealEstate_2_UI.ViewComponents.UI_Layout
{
    public class _UIAgentsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIAgentsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var jsonMes = await client.GetAsync("https://localhost:44387/api/Employee");
            if (jsonMes.IsSuccessStatusCode)
            {
                var jsonData = await jsonMes.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAgentDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}



