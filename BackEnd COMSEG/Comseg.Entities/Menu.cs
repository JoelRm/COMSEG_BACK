using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class Menu : EntityBase
    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        public string MenuName { get; set; }
        [Required]
        public bool MenuStatus { get; set; }
    }
}
