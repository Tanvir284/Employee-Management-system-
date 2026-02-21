using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("login")]
    public class Login
    {
        [Key]
        [Column("Id")]
        [MaxLength(50)]
        public string Id { get; set; } = null!;

        [Column("password")]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
        
        [Column("role")]
        [MaxLength(50)]
        public string? Role { get; set; }

        [Column("fullname")]
        [MaxLength(100)]
        public string? FullName { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }
    }
}
