
using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class WareHouse : EntityBase
    {
        [Key]
        public int WareHouseId { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public string WareHouseName { get; set; }
        [Required]
        public string WareHouseDirection { get; set; }
        [Required]
        public bool WareHouseSatatus { get; set; }
    }
}
