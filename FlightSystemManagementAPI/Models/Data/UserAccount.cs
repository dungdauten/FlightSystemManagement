using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class UserAccount : IdentityUser
    {

        

        [Required(ErrorMessage = "Bắt buộc phải nhập tên người dùng")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
        [Display(Name = "Tên người dùng")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập họ của người dùng")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
        [Display(Name = "Họ người dùng")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập email người dùng")]
        [MaxLength(40, ErrorMessage = "Tối đa 40 kí tự")]
        [Display(Name = "Email người dùng")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Tối thiểu phải 5 kí tự"), MaxLength(20, ErrorMessage = "Tối đa chỉ được 20 kí tự")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        [Display(Name = "Xác nhận mật khẩu")]
        
        [MinLength(5, ErrorMessage = "Tối thiểu phải 5 kí tự"), MaxLength(10, ErrorMessage = "Tối đa chỉ được 10 kí tự")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập độ tuổi của bạn")]
        [Range(18, 100, ErrorMessage = "18 tuổi trở lên mới được đăng kí đặt vé")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại của bạn"), RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(11)]
        [Display(Name = "Số điện thoại người dùng")]
        public string PhoneNumb { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập cccd của bạn"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "Cccd không hợp lệ")]
        [StringLength(11)]
        [Display(Name = "Căn cước người dùng")]
        public string CCCD { get; set; }
        public string role { get; set; }
    }
}
