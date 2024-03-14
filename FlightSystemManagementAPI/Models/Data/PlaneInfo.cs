using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class PlaneInfo
    {
        [Key]
        public int PlaneID { get; set; }
        public string APlaneName { get; set; }
        public int APlaneCapity { get; set; }
        public float Price { get; set; }
    }
}
