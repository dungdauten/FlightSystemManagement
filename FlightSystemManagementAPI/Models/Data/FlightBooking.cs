using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystemManagementAPI.Models.Data
{
    public class FlightBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string FlightNo { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string DTime { get; set; }
        public string DDay { get; set; }
        [ForeignKey(nameof(PlaneInfo))]
        public int PlaneId { get; set; }
        public string SeatType { get; set; }
    }
}
