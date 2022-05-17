using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class Mark : EntityBase
    {
        [Key]
        public int MarkId { get; set; }
        [Required]
        public string MarkName { get; set; }
        [Required]
        public bool MarkStatus { get; set; }

    }
}
