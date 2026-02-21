using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("leave_requests")]
    public class LeaveRequest
    {
        [Key]
        [Column("LeaveId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveId { get; set; }

        [Column("EmployeeID")]
        [MaxLength(50)]
        public string EmployeeId { get; set; } = null!;

        [Column("LeaveType")]
        [MaxLength(100)]
        public string? LeaveType { get; set; }

        [Column("StartDate")]
        [MaxLength(50)]
        public string? StartDate { get; set; }

        [Column("EndDate")]
        [MaxLength(50)]
        public string? EndDate { get; set; }

        [Column("Reason")]
        [MaxLength(500)]
        public string? Reason { get; set; }

        [Column("Status")]
        [MaxLength(50)]
        public string? Status { get; set; }

        [Column("ApprovedBy")]
        [MaxLength(100)]
        public string? ApprovedBy { get; set; }

        [Column("ApprovedDate")]
        [MaxLength(50)]
        public string? ApprovedDate { get; set; }
    }
}
