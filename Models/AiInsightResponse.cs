namespace Employeemanagment.Models
{
    public class AiInsightResponse
    {
        public bool IsSuccess { get; set; }
        public string Insight { get; set; } = string.Empty;
        public string Source { get; set; } = "Heuristic";
    }
}
