# Employee-Management-system-
2nd year Software development project.

## Project Structure

- `Core/` - core startup and shared configuration helper classes.
- `Configuration/` - runtime configuration files (`appsettings.json`).
- `Forms/Main/` - landing and entry forms.
- `Forms/Auth/` - login-related forms.
- `Forms/Admin/` - admin dashboard form.
- `Forms/Employee/` - employee management forms (add/search/update/delete/salary/shift/info).
- `Models/` - domain models for advanced features.
- `Services/` - business logic for advanced employee management and AI integration.
- `Assets/Icons/` - icon files used by the application.
- `Database/` - SQL scripts.
- `Docs/` - supporting project documents.

## Advanced Features Added

- Attendance tracking and analytics.
- Leave management workflow (request + approval).
- Performance reviews and increment recommendation rules.
- Payroll forecasting support.
- Employee offboarding archive.
- AI-based HR insights (with fallback summary when AI is not configured).

See `Docs/ADVANCED_FEATURES.md` for details.

## License

This project is licensed under the [MIT License](LICENSE).
