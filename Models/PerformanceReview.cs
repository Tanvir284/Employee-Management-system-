namespace Employeemanagment.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Goals { get; set; } = string.Empty;
        public string ManagerComments { get; set; } = string.Empty;
    }
}
