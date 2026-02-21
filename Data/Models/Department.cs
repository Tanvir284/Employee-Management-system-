using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [Column("DeptId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Column("HeadEmployeeID")]
        [MaxLength(50)]
        public string? HeadEmployeeId { get; set; }

        [Column("Description")]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Column("CreatedDate")]
        [MaxLength(50)]
        public string? CreatedDate { get; set; }
    }
}
