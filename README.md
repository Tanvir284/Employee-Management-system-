# 💼 EMS Pro: Enterprise Employee Management System

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dot-net&logoColor=white) 

**EMS Pro** is a robust, completely modernized enterprise-grade desktop application built in C# (.NET 6 WinForms) designed to handle complete employee lifecycles. 

Recently completely overhauled from top-to-bottom, the system leaves behind legacy ADO.NET SQL queries in favor of a modern **Entity Framework Core (LINQ)** architecture, integrated tightly with **Role-Based Access Control (RBAC)** security and beautiful **LiveCharts** WPF-backed data visualization.

---

## ✨ Key Features & Modern Architecture

### 🛡️ Enterprise Security (Role-Based Access Control)
EMS Pro is powered by a custom `SessionManager` that globally enforces Role-Based Access Control.
* **Smart Auth Routing:** The system detects roles on login. `Employees` are routed to a read-only self-service portal, while `Admins` are routed to the master dashboard.
* **Dynamic UI Engine:** The proprietary `UITheme.cs` engine sweeps across every form at load-time. If a regular employee manages to open an Admin window, any feature tagged as `AdminOnly` will dynamically conceal itself to protect sensitive data.
* **BCrypt Hashing:** Passwords are never stored in plaintext. Utilizing `BCrypt.Net-Next`, all user credentials undergo advanced salting and hashing.

### 📊 Advanced Data Visualization (WPF Interop)
The system leverages `LiveCharts.WinForms` (powered by Windows Presentation Foundation APIs) to provide beautiful, animated, and real-time data insights directly on the dashboard:
* **Attendance Tracking Line Chart:** Dynamically charts the exact counts of "Present" vs "Absent" employees over a rolling 7-day period.
* **Shift Distribution Pie Chart:** Automatically maps and visualizes the distribution of the workforce across 'Morning', 'Day', and 'Evening' organizational shifts.

### ⚡ Entity Framework Core (Pure LINQ)
Massive raw SQL queries have been completely eradicated from the codebase.
* **100% ORM Migration:** The entire Data Access Layer (DAL) has been modeled using EF Core (`EmployeeDbContext`). 
* **Zero SQL Injection:** The application relies entirely on parameterized LINQ queries, closing critical security vulnerabilities.
* **Resource Safe:** Strict `using var db = new EmployeeDbContext()` scoping ensures database connections are automatically pooled and disposed of instantly, preventing memory leaks over long sessions.

### 🎨 Stunning Custom Dark Mode UI
Standard gray, floating-border Windows Forms designs have been overridden. EMS integrates a sprawling custom styling engine (`UITheme.cs`) that applies:
* **Deep Space Aesthetics:** A completely custom dark palette utilizing Slate, Cyan, and Crimson branding.
* **Custom Input Layouts:** Text fields have been redesigned to feature borderless inputs floating cleanly above glowing cyan underlines.
* **Unified Component Design:** 7 different fragmented "Employee Data" screens were deleted and merged into a single, beautiful mathematically-anchored `EmployeeOperationsForm`.

---

## ⚙️ Core Modules
- **HR Insights & Analytics:** Calculates dynamic employee turnover risk, flags high performers, and tracks absenteeism rates.
- **Leave Management System:** Administers and approves Annual, Sick, Casual, and Maternity leave cleanly mapped through the EF Core generic `LeaveRequests` table.
- **Intelligent Payroll Forecasting:** A predictive module that evaluates total organizational compensation obligations across departments.
- **Offboarding Engine:** Securely archives exiting employees into a dedicated `OffboardedEmployees` tracking ledger while wiping them from active production tables.

---

## 🚀 Getting Started

### Prerequisites
* [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* SQL Server (LocalDB or full instance)

### Installation & Setup
1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/EMS-Pro.git
   cd EMS-Pro
   ```

2. **Database Configuration**
   - Open `Core/ConfigHelper.cs`.
   - By default, the system looks for a local SQL Server Express instance: `Data Source=localhost\sqlexpress`. Update the connection string to match your local SQL Server instance name.

3. **Build the Solution**
   - Ensure you are targeting `net6.0-windows`. The application is configured with `<UseWPF>true</UseWPF>` to support the advanced charting libraries.
   ```bash
   dotnet build
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

---
*Built with modern C# standards to redefine what WinForms can look and feel like in the enterprise.*
