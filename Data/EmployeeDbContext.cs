using Microsoft.EntityFrameworkCore;
using Employeemanagment.Data.Models;

namespace Employeemanagment.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<PerformanceReview> PerformanceReviews { get; set; } = null!;
        public DbSet<PayrollForecast> PayrollForecasts { get; set; } = null!;
        public DbSet<OffboardedEmployee> OffboardedEmployees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigHelper.GetConnectionString());
            }
        }
    }
}
