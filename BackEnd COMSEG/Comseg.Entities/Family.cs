using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class Family : EntityBase
    {
        [Key]
        public int FamilyId { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public bool FamilyStatus { get; set; }
    }
}
