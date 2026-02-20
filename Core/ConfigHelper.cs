using System;
using System.IO;
using System.Text.Json;

namespace Employeemanagment
{
    public static class ConfigHelper
    {
        public static string GetConnectionString()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Configuration file not found at {path}");
                }
                string json = File.ReadAllText(path);
                using JsonDocument doc = JsonDocument.Parse(json);
                return doc.RootElement.GetProperty("ConnectionStrings")
                                       .GetProperty("DefaultConnection")
                                       .GetString() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
