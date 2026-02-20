using Employeemanagment.Models;
using System.Text.Json;

namespace Employeemanagment.Services
{
    public class AdvancedHrFacade
    {
        private readonly EmployeeLifecycleService _employeeLifecycleService;
        private readonly AttendanceManagementService _attendanceManagementService;
        private readonly LeaveManagementService _leaveManagementService;
        private readonly PerformanceAndPayrollService _performanceAndPayrollService;
        private readonly AiInsightsService _aiInsightsService;

        public AdvancedHrFacade(
            EmployeeLifecycleService employeeLifecycleService,
            AttendanceManagementService attendanceManagementService,
            LeaveManagementService leaveManagementService,
            PerformanceAndPayrollService performanceAndPayrollService,
            AiInsightsService aiInsightsService)
        {
            _employeeLifecycleService = employeeLifecycleService;
            _attendanceManagementService = attendanceManagementService;
            _leaveManagementService = leaveManagementService;
            _performanceAndPayrollService = performanceAndPayrollService;
            _aiInsightsService = aiInsightsService;
        }

        public async Task<AiInsightResponse> BuildMonthlyHrSummaryAsync(int month, int year)
        {
            var topPerformers = _performanceAndPayrollService.GetTopPerformers(4);
            var pendingLeaves = _leaveManagementService.GetPendingLeaveRequests();
            var attendance = _attendanceManagementService.GetAttendanceForRange(
                new DateTime(year, month, 1),
                new DateTime(year, month, DateTime.DaysInMonth(year, month)));

            var context = new
            {
                Month = month,
                Year = year,
                TopPerformers = topPerformers.Rows.Count,
                PendingLeaves = pendingLeaves.Rows.Count,
                AttendanceRows = attendance.Rows.Count
            };

            return await _aiInsightsService.GenerateEmployeeInsightAsync(new AiInsightRequest
            {
                Prompt = "Generate a monthly HR executive summary with risks and action items.",
                ContextJson = JsonSerializer.Serialize(context)
            });
        }
    }
}
