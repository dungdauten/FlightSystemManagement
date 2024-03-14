using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class AdminLogic
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Bắt buộc phải nhập tên")]
        [Display(Name = "User Name")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Bắt buộc phải nhập mật khẩu")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Tối thiểu phải 5 kí tự"), MaxLength(10, ErrorMessage = "Tối đa chỉ được 10 kí tự")]
        public string Password { get; set; }
    }
}
