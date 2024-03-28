using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace FlightSystemManagementAPI.Models.Data
{
    public class PermissionGroups
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        
       public List<IdentityRole> Roles { get; set; }
    }
}
