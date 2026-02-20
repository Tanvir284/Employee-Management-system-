namespace Employeemanagment.Models
{
    public class EmployeeProfile
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string Shift { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }
}
