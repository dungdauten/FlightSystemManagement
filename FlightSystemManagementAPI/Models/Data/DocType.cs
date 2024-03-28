using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class DocType
    {
        [Key]
        public int DocType_Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Note { get; set; } = string.Empty;

        public ICollection<Document>? Documents { get; set; }
        
    }
}
