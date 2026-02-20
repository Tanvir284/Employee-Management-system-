namespace Employeemanagment.Models
{
    public class AiInsightRequest
    {
        public string Prompt { get; set; } = string.Empty;
        public string ContextJson { get; set; } = "{}";
    }
}
