namespace Employeemanagment.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public DateTime WorkDate { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public string Mode { get; set; } = "Office";
        public bool IsLate { get; set; }
    }
}
