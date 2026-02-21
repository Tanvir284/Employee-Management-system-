using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("performance_reviews")]
    public class PerformanceReview
    {
        [Key]
        [Column("ReviewId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Column("EmployeeID")]
        [MaxLength(50)]
        public string EmployeeId { get; set; } = null!;

        [Column("ReviewDate")]
        [MaxLength(50)]
        public string? ReviewDate { get; set; }

        [Column("Rating")]
        public int? Rating { get; set; }

        [Column("Comments")]
        [MaxLength(500)]
        public string? Comments { get; set; }

        [Column("IncrementRecommended")]
        [MaxLength(10)]
        public string? IncrementRecommended { get; set; }

        [Column("IncrementPercent")]
        public decimal? IncrementPercent { get; set; }
    }
}
