using FlightSystemManagementAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlightSystemManagement.Areas.Admin.Controllers
{
    [Area("admin")]
    public class FlightAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpclient;


        public FlightAdminController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpclient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7298/api/Flight");

            // Kiểm tra phản hồi từ Web API
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung phản hồi
                var responseData = await response.Content.ReadAsStringAsync();
                var flights = JsonConvert.DeserializeObject<List<FlightBooking>>(responseData);
                return View(flights);

            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
