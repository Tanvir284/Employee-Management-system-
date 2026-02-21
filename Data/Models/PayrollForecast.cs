using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employeemanagment.Data.Models
{
    [Table("payroll_forecast")]
    public class PayrollForecast
    {
        [Key]
        [Column("ForecastId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForecastId { get; set; }

        [Column("EmployeeID")]
        [MaxLength(50)]
        public string EmployeeId { get; set; } = null!;

        [Column("Month")]
        [MaxLength(20)]
        public string? Month { get; set; }

        [Column("Year")]
        public int? Year { get; set; }

        [Column("BaseSalary")]
        public decimal? BaseSalary { get; set; }

        [Column("Bonus")]
        public decimal? Bonus { get; set; }

        [Column("Deductions")]
        public decimal? Deductions { get; set; }

        [Column("NetSalary")]
        public decimal? NetSalary { get; set; }

        [Column("ForecastDate")]
        [MaxLength(50)]
        public string? ForecastDate { get; set; }
    }
}
