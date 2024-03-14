using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class SignIn
    {

        [Required(ErrorMessage = "Vui lòng nhập email"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
