namespace Employeemanagment.Models
{
    public class PayrollForecast
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal CurrentPayrollCost { get; set; }
        public decimal ForecastedPayrollCost { get; set; }
        public decimal GrowthPercentage { get; set; }
    }
}
