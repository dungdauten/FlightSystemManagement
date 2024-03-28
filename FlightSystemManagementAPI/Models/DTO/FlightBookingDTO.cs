using FlightSystemManagementAPI.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystemManagementAPI.Models.DTO
{
    public class FlightBookingDTO
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [Display(Name ="Mã chuyến bay")]
        [StringLength(10)]
        public string FlightNo { get; set; }
        public string FromCity { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn địa điểm đến")]
        [Display(Name = "Địa điểm đến")]
        [StringLength(40)]
        public string ToCity { get; set; }

        [Display(Name = "Giờ khởi hành")]
        [DataType(DataType.Time)]
        public string DTime { get; set; }

        [Display(Name = "Ngày khởi hành")]
        [DataType(DataType.Date)]
        public string DDay { get; set; }
        public int PlaneId { get; set; }
        [Display(Name = "Loại vé ngồi")]
        [StringLength(10)]
        public string SeatType { get; set; }

    }
}
