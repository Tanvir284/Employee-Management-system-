using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("attendance")]
    public class Attendance
    {
        [Key]
        [Column("AttendanceId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }

        [Column("EmployeeID")]
        [MaxLength(50)]
        public string EmployeeId { get; set; } = null!;

        [Column("Date")]
        [MaxLength(50)]
        public string? Date { get; set; }

        [Column("CheckIn")]
        [MaxLength(50)]
        public string? CheckIn { get; set; }

        [Column("CheckOut")]
        [MaxLength(50)]
        public string? CheckOut { get; set; }

        [Column("Status")]
        [MaxLength(50)]
        public string? Status { get; set; }
    }
}
