
using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class SubMenu : EntityBase
    {
        [Key]
        public int SubMenuId { get; set; }
        [Required]
        public int MenuId { get; set; }
        [Required]
        public string SubMenuName  { get; set; }
        [Required]
        public string SubMenuPage { get; set; }
        [Required]
        public bool SubMenuStatus { get; set; }
    }
}
