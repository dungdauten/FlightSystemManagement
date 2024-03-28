using Azure;
using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Models.DTO;
using FlightSystemManagementAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
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
        private readonly DataContext _dataContext;
        private IConfiguration _configuration;
        public AccountController(IAccountRepository repo, IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,DataContext dataContext)
        {
            accountRepo = repo;
            _dataContext = dataContext;
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


        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            IdentityRole[] rolesArr = _roleManager.Roles.ToArray();
            List<IdentityRole> rolesList = rolesArr.ToList();
            return Ok(rolesList);
        }
        
        [HttpGet("SearchRole/{id}")]
        public async Task<IActionResult> SearchRole(string id)
        {
            var role = await _dataContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
                return NotFound("Id Role không tồn tại!");
            return Ok(role);
        }
        [HttpGet("GetGroups")]
        public async Task<IActionResult> GetGroupPermission()
        {
            try
            {
                return Ok(await _dataContext.PermissionGroups.ToListAsync());
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroupPermission(PermissionGroups groupPermission)
        {
            // Kiểm tra valid của dữ liệu đầu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Thêm mới GroupPermission vào cơ sở dữ liệu
                _dataContext.PermissionGroups.Add(groupPermission);
                _dataContext.SaveChanges();

                return Ok("GroupPermission added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("AddRolesToGroup")]
        public async Task<IActionResult> AddRoleToGroup(int groupId, List<string> roleNames)
        {
            var group = await _dataContext.PermissionGroups.FindAsync(groupId);

            if (group != null)
            {
                var rolesToAdd = new List<IdentityRole>();

                foreach (var roleName in roleNames)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);

                    if (role != null)
                    {
                        rolesToAdd.Add(role);
                    }
                }

                foreach (var role in rolesToAdd)
                {
                    group.Roles.Add(new IdentityRole { Id = role.Id });
                }

                await _dataContext.SaveChangesAsync();

                // Roles successfully added to the group
                return Ok();
            }

            // Group not found
            return NotFound();
        }
    }
}
