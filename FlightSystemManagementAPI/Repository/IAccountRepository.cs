using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightSystemManagementAPI.Repository
{
    public interface IAccountRepository
    {
        Task<Response> SignUpAsync(Register model, string role);
        Task<Response> SignInAsync(SignIn model);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;


        public AccountRepository(UserManager<IdentityUser> userManager,
            IConfiguration configuration, RoleManager<IdentityRole> roleManager, DataContext dataContext)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }
        public async Task<Response> SignInAsync(SignIn model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null)
            {
                return new Response { Message = "Email không đúng!", isSucess = false };
            }
            if (!passwordValid)
                return new Response { Message = "Mật khẩu không chính xác!", isSucess = false };

            var authClaims = new[]
            {
                new Claim("Email",model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),

            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));


            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token).ToLowerInvariant();

            return new Response
            {
                Message = tokenAsString,
                isSucess = true,
                ExpiredDate = token.ValidTo,
            };
        }

        public async Task<Response> SignUpAsync(Register model, string role)
        {
            if (model == null)
            {
                throw new NullReferenceException("Register model is null");
            }

            var userexist = await _userManager.FindByEmailAsync(model.Email);
            if (userexist != null)
            {
                return new Response { Message = "Người dùng đã tồn tại", isSucess = false };
            }

            if (model.Password != model.ConfirmPassword)
                return new Response { Message = "Xác nhận mật khẩu không giống với mật khẩu", isSucess = false };

            IdentityUser identityUser=new()
            {
                Email = model.Email,
                
                UserName = model.FirstName+ "" + model.LastName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(identityUser,model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);

                   
                    return new Response { Message = "Tạo tài khoản thành công", isSucess = true };
                }
                return new Response { Message = "Tạo tài khoản không thành công", isSucess = false, Errors = result.Errors.Select(e => e.Description) };
            }
            else
                return new Response { Message = "Role không tồn tại!", isSucess = false };

            
        }
    }
}
