using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("offboarded_employees")]
    public class OffboardedEmployee
    {
        [Key]
        [Column("OffboardId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OffboardId { get; set; }

        [Column("ID")]
        [MaxLength(50)]
        public string OriginalId { get; set; } = null!;

        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("salary")]
        [MaxLength(50)]
        public string? Salary { get; set; }

        [Column("shift")]
        [MaxLength(50)]
        public string? Shift { get; set; }

        [Column("OffboardDate")]
        [MaxLength(50)]
        public string? OffboardDate { get; set; }

        [Column("OffboardReason")]
        [MaxLength(255)]
        public string? OffboardReason { get; set; }

        [Column("age")]
        [MaxLength(50)]
        public string? Age { get; set; }

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

        [Column("gender")]
        [MaxLength(50)]
        public string? Gender { get; set; }

        [Column("ExitNotes")]
        public string? ExitNotes { get; set; }
    }
}
