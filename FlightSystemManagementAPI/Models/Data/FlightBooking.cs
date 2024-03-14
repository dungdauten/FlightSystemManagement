using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystemManagementAPI.Models.Data
{
    public class FlightBooking
    {
        public int BookingId { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string DTime { get; set; }
        public string DDay { get; set; }
        [ForeignKey(nameof(PlaneInfo))]
        public int PlaneId { get; set; }
        public virtual PlaneInfo PlaneInfo { get; set; }
        public string SeatType { get; set; }
    }
}
