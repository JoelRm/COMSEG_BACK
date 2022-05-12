
using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class Unit : EntityBase
    {
        [Key]
        public int UnitId { get; set; }
        [Required]
        public string UnitCode { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public int Factor { get; set; }
        [Required]
        public bool UnitStatus { get; set; }
    }
}
