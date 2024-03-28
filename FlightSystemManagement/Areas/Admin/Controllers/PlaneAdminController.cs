using FlightSystemManagementAPI.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Numerics;
using System.Text;

namespace FlightSystemManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlaneAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpclient;


        public PlaneAdminController(IHttpClientFactory httpClientFactory,HttpClient httpClient)
        {
            _httpclient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7298/api/Plane");

            // Kiểm tra phản hồi từ Web API
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung phản hồi
                var responseData = await response.Content.ReadAsStringAsync();
                var planes = JsonConvert.DeserializeObject<List<PlaneInfo>>(responseData);
                return View(planes);

            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7298/api/Plane");

            // Kiểm tra phản hồi từ Web API
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung phản hồi
                var responseData = await response.Content.ReadAsStringAsync();
                var plane = JsonConvert.DeserializeObject<List<PlaneInfo>>(responseData);
                return View();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(PlaneInfo planemodel)
        {
            // Gửi yêu cầu POST đến API
            var response = await _httpclient.GetAsync("https://localhost:7298/api/Plane");
            var responseData = await response.Content.ReadAsStringAsync();
            var planes = JsonConvert.DeserializeObject<List<PlaneInfo>>(responseData);

            PlaneInfo plane = new PlaneInfo
            {
                APlaneName = planemodel.APlaneName,
                APlaneCapity = planemodel.APlaneCapity,
                Price = planemodel.Price,
            };
            var jsonPLane = JsonConvert.SerializeObject(plane);

            // Tạo nội dung yêu cầu HTTP
            var content = new StringContent(jsonPLane, Encoding.UTF8, "application/json");
            var responsepost = await _httpclient.PostAsync("https://localhost:7298/api/Plane/create", content);

            // Xử lý phản hồi từ API
            if (responsepost.IsSuccessStatusCode)
            {
                // Phản hồi thành công
                return RedirectToAction("Index");
            }
            else
            {
                // Xử lý lỗi
                var errorResponse = await responsepost.Content.ReadAsStringAsync();
                ModelState.AddModelError("", errorResponse);
                return View(plane);
            }
        }
        
        public async Task<IActionResult> Delete(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7298/api/Plane");
                var response = await client.DeleteAsync($"PLane/{Id}");
                
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index"); // Chuyển hướng đến trang danh sách sản phẩm
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", errorMessage);
                }
                return RedirectToAction("Index");
            }

        }
    }
}
