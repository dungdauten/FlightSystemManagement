using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightSystemManagementAPI.Models.Data
{
    public class DocRoles
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int DocumentId { get; set; }
        [ForeignKey("Id")]
        public Document Document { get; set; }
    }
}
