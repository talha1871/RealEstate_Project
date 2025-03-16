using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace RealEstate_2_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region 1) Aktif Kategori
            var client = _httpClientFactory.CreateClient();
            var responseMess = await client.GetAsync("https://localhost:44387/api/Statistics/ActiveCategoryCount");
            var jsonData= await responseMess.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion


            #region 2) Aktif Çalışan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var jsonMessage2 = await client2.GetAsync("https://localhost:44387/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await jsonMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion



            #region 3) Kategori Sayısı
            var client3 = _httpClientFactory.CreateClient();
            var jsonMess3 = await client3.GetAsync("https://localhost:44387/api/Statistics/CategoryCount");
            if (jsonMess3.IsSuccessStatusCode)
            {
                var jsonData3 = await jsonMess3.Content.ReadAsStringAsync();
                ViewBag.categoryCount = jsonData3;
            }
            #endregion


            #region 4) Pasif Kategori Sayısı
            var client4 = _httpClientFactory.CreateClient();
            var jsonMess4 = await client4.GetAsync("https://localhost:44387/api/Statistics/PassiveCategoryCount");
            var jsonData4 = await jsonMess4.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData4;
            #endregion


            #region 5) Toplam Ürün Sayısı
            var client5 = _httpClientFactory.CreateClient();
            var jsonMess5 = await client5.GetAsync("https://localhost:44387/api/Statistics/TotalProductCount");
            var jsonData5 = await jsonMess5.Content.ReadAsStringAsync();
            ViewBag.totalProductCount = jsonData5;

            #endregion

            #region 6)Daire Sayısı
            var client6 = _httpClientFactory.CreateClient();
            var jsonMess6 = await client6.GetAsync("https://localhost:44387/api/Statistics/ApartmentCount");
            var jsonData6 = await jsonMess6.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData6;
            #endregion

            #region 7) Şehir Sayısı
            var client7= _httpClientFactory.CreateClient();
            var jsonMess7 = await client7.GetAsync("https://localhost:44387/api/Statistics/DifferentCityCount");
            var jsonData7 = await jsonMess7.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData7;
            #endregion

            #region 8) Ortalama Oda Sayısı
            var client8 = _httpClientFactory.CreateClient();
            var jsonMess8 = await client8.GetAsync("https://localhost:44387/api/Statistics/AverageRoomCount");
            var jsonData8 = await jsonMess8.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData8;
            #endregion



            #region 9) Kiraya Göre Ortalama Ev Fiyatı
            var client9 = _httpClientFactory.CreateClient();
            var responseMess9 = await client9.GetAsync("https://localhost:44387/api/Statistics/AverageProductPriceByRent");
            var jsonData9 = await responseMess9.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData9;
            #endregion


            #region 10) Satış Fiyatına Göre Ortalama Ev Fiyatı
            var client10 = _httpClientFactory.CreateClient();
            var jsonMessage10 = await client10.GetAsync("https://localhost:44387/api/Statistics/AverageProductPriceBySale");
            var jsonData10 = await jsonMessage10.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData10;
            #endregion



            #region 11) Maksimum Ürün Sayısına Göre Kategori Adı
            var client11 = _httpClientFactory.CreateClient();
            var jsonMess11 = await client11.GetAsync("https://localhost:44387/api/Statistics/CategoryNameByMaxProductCount");
            if (jsonMess11.IsSuccessStatusCode)
            {
                var jsonData11 = await jsonMess11.Content.ReadAsStringAsync();
                ViewBag.categoryNameByMaxProductCount = jsonData11;
            }
            #endregion


            #region 12) Maksimum Ürün Sayısına Göre Şehir Adı
            var client12 = _httpClientFactory.CreateClient();
            var jsonMess12 = await client12.GetAsync("https://localhost:44387/api/Statistics/CityNameByMaxProductCount");
            var jsonData12 = await jsonMess12.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData12;
            #endregion


            #region 13) Maksimum Ürün Sayısına Göre Çalışan Adı
            var client13 = _httpClientFactory.CreateClient();
            var jsonMess13 = await client13.GetAsync("https://localhost:44387/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData13 = await jsonMess13.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData13;

            #endregion

            #region 14) Son Eklenen Ürünün Fiyatı
            var client14 = _httpClientFactory.CreateClient();
            var jsonMess14 = await client14.GetAsync("https://localhost:44387/api/Statistics/LastProductPrice");
            var jsonData14 = await jsonMess14.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = jsonData14;
            #endregion

            #region 15) En Yeni Konut
            var client15 = _httpClientFactory.CreateClient();
            var jsonMess15 = await client15.GetAsync("https://localhost:44387/api/Statistics/TheNewestBuilding");
            var jsonData15 = await jsonMess15.Content.ReadAsStringAsync();
            ViewBag.theNewestBuilding = jsonData15;
            #endregion

            #region 16) En Eski Konut
            var client16 = _httpClientFactory.CreateClient();
            var jsonMess16 = await client16.GetAsync("https://localhost:44387/api/Statistics/TheOldestBuilding");
            var jsonData16 = await jsonMess16.Content.ReadAsStringAsync();
            ViewBag.theOldestBuilding = jsonData16;
            #endregion

            return View();
            





        }
    }
}
