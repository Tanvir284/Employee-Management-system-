using Employeemanagment.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Employeemanagment.Services
{
    public class AiInsightsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _apiKey;
        private readonly string _model;

        public AiInsightsService(HttpClient httpClient, string endpoint, string apiKey, string model)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
            _apiKey = apiKey;
            _model = model;
        }

        public async Task<AiInsightResponse> GenerateEmployeeInsightAsync(AiInsightRequest request)
        {
            if (string.IsNullOrWhiteSpace(_endpoint) || string.IsNullOrWhiteSpace(_apiKey))
            {
                return BuildFallbackInsight(request);
            }

            string fullPrompt = $"You are an HR analytics assistant. Use this context: {request.ContextJson}. Request: {request.Prompt}";

            var payload = new
            {
                model = _model,
                messages = new[]
                {
                    new { role = "system", content = "Provide concise and actionable HR insights." },
                    new { role = "user", content = fullPrompt }
                },
                temperature = 0.2
            };

            using HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, _endpoint);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            httpRequest.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
            string responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return BuildFallbackInsight(request, $"AI API error: {response.StatusCode}");
            }

            using JsonDocument doc = JsonDocument.Parse(responseBody);
            string insight = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? "No insight returned.";

            return new AiInsightResponse
            {
                IsSuccess = true,
                Insight = insight,
                Source = "AI"
            };
        }

        private static AiInsightResponse BuildFallbackInsight(AiInsightRequest request, string? reason = null)
        {
            string prefix = string.IsNullOrWhiteSpace(reason)
                ? "AI is not configured."
                : $"{reason}.";

            return new AiInsightResponse
            {
                IsSuccess = false,
                Source = "Heuristic",
                Insight = $"{prefix} Suggested baseline action: review attendance consistency, identify top performers, and plan targeted upskilling for low-rated employees. User prompt was: {request.Prompt}"
            };
        }
    }
}
