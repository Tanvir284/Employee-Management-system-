# Advanced Features & AI Integration

This project now includes an extensible service layer for advanced employee management.

## New modules

- **Employee lifecycle management** (`Services/EmployeeLifecycleService.cs`)
  - onboarding
  - offboarding with archival
  - directory data retrieval

- **Attendance management** (`Services/AttendanceManagementService.cs`)
  - save daily attendance
  - date-range reports
  - monthly attendance percentage

- **Leave workflow** (`Services/LeaveManagementService.cs`)
  - create leave requests
  - approve/reject requests
  - pending request dashboard feed

- **Performance & payroll intelligence** (`Services/PerformanceAndPayrollService.cs`)
  - performance review records
  - increment recommendation rules
  - payroll forecasting
  - top performer retrieval

- **AI insights** (`Services/AiInsightsService.cs`)
  - OpenAI-compatible chat completion integration
  - graceful heuristic fallback when API settings are missing

- **Facade orchestration** (`Services/AdvancedHrFacade.cs`)
  - monthly HR summary composition across attendance, leave, and performance
  - AI-generated executive insights

## Configuration

Add your AI key in `Configuration/appsettings.json`:

```json
"AiIntegration": {
  "Endpoint": "https://api.openai.com/v1/chat/completions",
  "ApiKey": "YOUR_KEY",
  "Model": "gpt-4o-mini"
}
```

## Database

Run `Database/SQLQuery1.sql` to create advanced tables:

- `attendance`
- `leave_requests`
- `performance_reviews`
- `employee_offboarding`
