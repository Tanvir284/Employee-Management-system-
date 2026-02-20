using Employeemanagment.Models;
using System.Data;
using System.Data.SqlClient;

namespace Employeemanagment.Services
{
    public class EmployeeLifecycleService
    {
        public void OnboardEmployee(EmployeeProfile employee)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();
            string query = @"INSERT INTO employee (name, ID, salary, email, joindate, shift)
                             VALUES (@Name, @ID, @Salary, @Email, @JoinDate, @Shift)";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@ID", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
            cmd.Parameters.AddWithValue("@Shift", employee.Shift);
            cmd.ExecuteNonQuery();
        }

        public void OffboardEmployee(string employeeId, string reason)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            using SqlTransaction tx = con.BeginTransaction();
            string archiveQuery = @"INSERT INTO employee_offboarding (EmployeeId, OffboardDate, Reason)
                                    VALUES (@EmployeeId, @OffboardDate, @Reason)";
            using SqlCommand archiveCmd = new SqlCommand(archiveQuery, con, tx);
            archiveCmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            archiveCmd.Parameters.AddWithValue("@OffboardDate", DateTime.UtcNow);
            archiveCmd.Parameters.AddWithValue("@Reason", reason);
            archiveCmd.ExecuteNonQuery();

            string deleteQuery = "DELETE FROM employee WHERE ID = @EmployeeId";
            using SqlCommand deleteCmd = new SqlCommand(deleteQuery, con, tx);
            deleteCmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            deleteCmd.ExecuteNonQuery();

            tx.Commit();
        }

        public DataTable GetEmployeeDirectory()
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = "SELECT name, ID, email, salary, shift, joindate FROM employee";
            using SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
