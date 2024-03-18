using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    
    public class Register
    {
        public readonly RoleManager<IdentityRole> _roleManager;

       


        [Required(ErrorMessage = "Bắt buộc phải nhập email người dùng")]
        [MaxLength(40, ErrorMessage = "Tối đa 40 kí tự")]
        [EmailAddress]
        [Display(Name = "Email người dùng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Tối thiểu phải 5 kí tự"), MaxLength(20, ErrorMessage = "Tối đa chỉ được 20 kí tự")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        [Display(Name = "Xác nhận mật khẩu")]
        [MinLength(5, ErrorMessage = "Tối thiểu phải 5 kí tự"), MaxLength(20, ErrorMessage = "Tối đa chỉ được 20 kí tự")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bắt buộc phải nhập tên người dùng")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
        [Display(Name = "Tên người dùng")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string? role { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }


    }
}
