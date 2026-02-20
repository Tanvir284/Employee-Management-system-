using Employeemanagment.Models;
using System.Data;
using System.Data.SqlClient;

namespace Employeemanagment.Services
{
    public class AttendanceManagementService
    {
        public void SaveAttendance(AttendanceRecord record)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = @"INSERT INTO attendance (EmployeeId, WorkDate, CheckInTime, CheckOutTime, Mode, IsLate)
                             VALUES (@EmployeeId, @WorkDate, @CheckInTime, @CheckOutTime, @Mode, @IsLate)";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", record.EmployeeId);
            cmd.Parameters.AddWithValue("@WorkDate", record.WorkDate.Date);
            cmd.Parameters.AddWithValue("@CheckInTime", record.CheckInTime);
            cmd.Parameters.AddWithValue("@CheckOutTime", record.CheckOutTime);
            cmd.Parameters.AddWithValue("@Mode", record.Mode);
            cmd.Parameters.AddWithValue("@IsLate", record.IsLate);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAttendanceForRange(DateTime fromDate, DateTime toDate)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = @"SELECT EmployeeId, WorkDate, CheckInTime, CheckOutTime, Mode, IsLate
                             FROM attendance
                             WHERE WorkDate BETWEEN @FromDate AND @ToDate
                             ORDER BY WorkDate DESC";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
            cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public decimal GetMonthlyAttendancePercentage(string employeeId, int month, int year)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string presentQuery = @"SELECT COUNT(*) FROM attendance
                                    WHERE EmployeeId = @EmployeeId
                                      AND MONTH(WorkDate) = @Month
                                      AND YEAR(WorkDate) = @Year";
            using SqlCommand presentCmd = new SqlCommand(presentQuery, con);
            presentCmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            presentCmd.Parameters.AddWithValue("@Month", month);
            presentCmd.Parameters.AddWithValue("@Year", year);

            int presentDays = Convert.ToInt32(presentCmd.ExecuteScalar());
            int totalWorkingDays = DateTime.DaysInMonth(year, month) - 8;
            if (totalWorkingDays <= 0)
            {
                return 0;
            }

            return (decimal)presentDays / totalWorkingDays * 100;
        }
    }
}
