using FlightSystemManagementAPI.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http;
using System.Text;

namespace FlightSystemManagement.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly HttpClient _httpclient;
        private readonly DataContext _dataContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(IHttpClientFactory httpClient, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment, HttpClient client, RoleManager<IdentityRole> roleManager, DataContext dataContext)
        {
            _userManager = userManager;
            _httpClientFactory = httpClient;
            _webHostEnvironment = webHostEnvironment;
            _httpclient = client;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model,string selectedRole)
        {
            IdentityUser identityUser = new()
            {
                Email = model.Email,
                UserName = model.FirstName + "" + model.LastName,
                SecurityStamp = Guid.NewGuid().ToString(),
                
            };

            var roles = await _roleManager.Roles.ToListAsync();
        

            if (await _roleManager.RoleExistsAsync(selectedRole))
            {
                var result = await _userManager.CreateAsync(identityUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, selectedRole);
                }
            }
            var jsonUser = JsonConvert.SerializeObject(identityUser);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var response = await _httpclient.PostAsync("https://localhost:7298/api/Account/DangKi", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Đăng ký thành công";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["Error"] = "Đăng ký không thành công";
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignIn signIn)
        {
            SignIn user = new SignIn
            {
                Email = signIn.Email,
                Password = signIn.Password

            };
            var jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var response = await _httpclient.PostAsync("https://localhost:7298/api/Account/DangNhap", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                TempData["Error"] = "Email hoặc Mật khẩu không đúng";
                return View(signIn);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {


            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7298/api/Account/Roles");

            if (response.IsSuccessStatusCode)
            {
                var roles = await response.Content.ReadFromJsonAsync<List<IdentityRole>>();
                if (roles.Any())
                {
                    ViewBag.Roles = new SelectList(_dataContext.Roles,"Roles","Roles");
                    return View(roles);
                }
                else
                {
                    TempData["Error"] = "Không có roles bạn muốn chọn";
                    return RedirectToAction("Error");
                }
            }
            return ViewBag.Roles;
        }


    }
}


