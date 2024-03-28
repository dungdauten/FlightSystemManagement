using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên file")]
        public string Name { get; set; } = string.Empty;
        /*[Required(ErrorMessage = "Nhập file")]
        public IFormFile File { get; set; }*/
        public string? Note { get; set; } = string.Empty;
        [Required]
        public int FlightId { get; set; }
        /*[ForeignKey("BookingId")]
        public FlightBooking Flight { get; set; }*/
        [Required]
        public int TypeId { get; set; }
        /*[ForeignKey("DocType_Id")]
        public DocType Type { get; set; }*/
        /*[Required]
        public List<DocRoles>? RoleNameList { get; set; }*/

    }
}
