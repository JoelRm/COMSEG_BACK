
using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class Branch : EntityBase
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public bool BranchStatus { get; set; }
    }
}
