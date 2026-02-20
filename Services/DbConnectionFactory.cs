using System.Data.SqlClient;

namespace Employeemanagment.Services
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            return new SqlConnection(ConfigHelper.GetConnectionString());
        }
    }
}
