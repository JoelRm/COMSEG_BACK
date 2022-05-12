
using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public  class Line : EntityBase
    {
        [Key]
        public int LineId { get; set; }
        [Required]
        public string LineName { get; set; }    
        [Required]
        public bool LineStatus { get; set; }
    }
}
