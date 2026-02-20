-- Advanced Employee Management System schema extensions

IF OBJECT_ID('attendance', 'U') IS NULL
BEGIN
    CREATE TABLE attendance (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId NVARCHAR(50) NOT NULL,
        WorkDate DATE NOT NULL,
        CheckInTime TIME NOT NULL,
        CheckOutTime TIME NOT NULL,
        Mode NVARCHAR(20) NOT NULL,
        IsLate BIT NOT NULL DEFAULT 0
    );
END
GO

IF OBJECT_ID('leave_requests', 'U') IS NULL
BEGIN
    CREATE TABLE leave_requests (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId NVARCHAR(50) NOT NULL,
        StartDate DATE NOT NULL,
        EndDate DATE NOT NULL,
        LeaveType NVARCHAR(50) NOT NULL,
        Reason NVARCHAR(500) NOT NULL,
        ApprovalStatus NVARCHAR(20) NOT NULL DEFAULT 'Pending'
    );
END
GO

IF OBJECT_ID('performance_reviews', 'U') IS NULL
BEGIN
    CREATE TABLE performance_reviews (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId NVARCHAR(50) NOT NULL,
        ReviewDate DATE NOT NULL,
        Rating INT NOT NULL,
        Goals NVARCHAR(1000) NOT NULL,
        ManagerComments NVARCHAR(2000) NOT NULL
    );
END
GO

IF OBJECT_ID('employee_offboarding', 'U') IS NULL
BEGIN
    CREATE TABLE employee_offboarding (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        EmployeeId NVARCHAR(50) NOT NULL,
        OffboardDate DATETIME2 NOT NULL,
        Reason NVARCHAR(1000) NOT NULL
    );
END
GO
