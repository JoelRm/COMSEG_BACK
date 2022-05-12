
using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class Role : EntityBase
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public bool RoleStatus { get; set; }
        [Required]
        public string RolePermissions { get; set; }
    }
}
