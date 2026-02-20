using Employeemanagment.Models;
using System.Data;
using System.Data.SqlClient;

namespace Employeemanagment.Services
{
    public class PerformanceAndPayrollService
    {
        public void SavePerformanceReview(PerformanceReview review)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = @"INSERT INTO performance_reviews (EmployeeId, ReviewDate, Rating, Goals, ManagerComments)
                             VALUES (@EmployeeId, @ReviewDate, @Rating, @Goals, @ManagerComments)";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", review.EmployeeId);
            cmd.Parameters.AddWithValue("@ReviewDate", review.ReviewDate.Date);
            cmd.Parameters.AddWithValue("@Rating", review.Rating);
            cmd.Parameters.AddWithValue("@Goals", review.Goals);
            cmd.Parameters.AddWithValue("@ManagerComments", review.ManagerComments);
            cmd.ExecuteNonQuery();
        }

        public decimal RecommendIncrementPercentage(int averageRating)
        {
            return averageRating switch
            {
                >= 5 => 15,
                4 => 10,
                3 => 6,
                2 => 3,
                _ => 0
            };
        }

        public PayrollForecast ForecastPayroll(int month, int year, decimal plannedGrowthPercentage)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = "SELECT ISNULL(SUM(CAST(salary AS DECIMAL(18,2))), 0) FROM employee";
            using SqlCommand cmd = new SqlCommand(query, con);
            decimal currentPayroll = Convert.ToDecimal(cmd.ExecuteScalar());
            decimal forecast = currentPayroll * (1 + plannedGrowthPercentage / 100);

            return new PayrollForecast
            {
                Month = month,
                Year = year,
                CurrentPayrollCost = currentPayroll,
                ForecastedPayrollCost = forecast,
                GrowthPercentage = plannedGrowthPercentage
            };
        }

        public DataTable GetTopPerformers(int minRating)
        {
            using SqlConnection con = DbConnectionFactory.Create();
            con.Open();

            string query = @"SELECT EmployeeId, ReviewDate, Rating, Goals
                             FROM performance_reviews
                             WHERE Rating >= @MinRating
                             ORDER BY Rating DESC, ReviewDate DESC";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@MinRating", minRating);

            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
