using Employeemanagment.Models;
using System.Data;
using System.Data.SqlClient;

namespace Employeemanagment.Services
{
    public class LeaveManagementService
    {
        public void CreateLeaveRequest(LeaveRequest request)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = @"INSERT INTO leave_requests (EmployeeId, StartDate, EndDate, LeaveType, Reason, ApprovalStatus)
                             VALUES (@EmployeeId, @StartDate, @EndDate, @LeaveType, @Reason, @ApprovalStatus)";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", request.EmployeeId);
            cmd.Parameters.AddWithValue("@StartDate", request.StartDate.Date);
            cmd.Parameters.AddWithValue("@EndDate", request.EndDate.Date);
            cmd.Parameters.AddWithValue("@LeaveType", request.LeaveType);
            cmd.Parameters.AddWithValue("@Reason", request.Reason);
            cmd.Parameters.AddWithValue("@ApprovalStatus", request.ApprovalStatus);
            cmd.ExecuteNonQuery();
        }

        public void UpdateLeaveApproval(int leaveRequestId, string approvalStatus)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = "UPDATE leave_requests SET ApprovalStatus = @ApprovalStatus WHERE Id = @Id";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApprovalStatus", approvalStatus);
            cmd.Parameters.AddWithValue("@Id", leaveRequestId);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetPendingLeaveRequests()
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = @"SELECT Id, EmployeeId, StartDate, EndDate, LeaveType, Reason
                             FROM leave_requests
                             WHERE ApprovalStatus = 'Pending'
                             ORDER BY StartDate";

            using SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
