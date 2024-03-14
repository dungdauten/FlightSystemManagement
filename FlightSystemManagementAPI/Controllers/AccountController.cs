using Azure;
using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace FlightSystemManagementAPI.Controllers
{
    [Area("admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAccountRepository accountRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;
        public AccountController(IAccountRepository repo, IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            accountRepo = repo;
            
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("DangKi")]
        public async Task<IActionResult> DangKi([FromBody] Register model, string role) 
        {
            if (ModelState.IsValid)
            {
                var result = await accountRepo.SignUpAsync(model, role);

                if (result.isSucess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Tài khoản không hợp lệ");//status code 400  
        }

        [HttpPost("DangNhap")]
        public async Task<IActionResult> DangNhap([FromBody] SignIn model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRepo.SignInAsync(model);

                if (result.isSucess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest("Đăng nhập không hợp lệ");

        }
    }
}
