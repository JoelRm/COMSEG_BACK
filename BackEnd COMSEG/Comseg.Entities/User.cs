using System.ComponentModel.DataAnnotations;

namespace Comseg.Entities
{
    public class User : EntityBase
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? AdmitionDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string UserLogin { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public bool UserStatus { get; set; }

    }
}
