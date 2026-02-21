using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("ID")]
        [MaxLength(50)]
        public string Id { get; set; } = null!;

        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Column("age")]
        [MaxLength(10)]
        public string? Age { get; set; }

        [Column("salary")]
        [MaxLength(50)]
        public string? Salary { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("num")]
        [MaxLength(50)]
        public string? Num { get; set; }

        [Column("DOB")]
        [MaxLength(50)]
        public string? Dob { get; set; }

        [Column("joindate")]
        [MaxLength(50)]
        public string? JoinDate { get; set; }

        [Column("address")]
        [MaxLength(200)]
        public string? Address { get; set; }

        [Column("shift")]
        [MaxLength(50)]
        public string? Shift { get; set; }

        [Column("gender")]
        [MaxLength(20)]
        public string? Gender { get; set; }
    }
}
