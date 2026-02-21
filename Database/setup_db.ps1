# Setup script for Employee Management System Database
$mdfPath = "$env:USERPROFILE\Documents\employeeDb.mdf"
$ldfPath = "$env:USERPROFILE\Documents\employeeDb_log.ldf"
$instanceName = "MSSQLLocalDB"

# Find sqlcmd
$sqlcmdPaths = @(
    "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\sqlcmd.exe",
    "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\160\Tools\Binn\sqlcmd.exe",
    "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\150\Tools\Binn\sqlcmd.exe",
    "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\sqlcmd.exe",
    "sqlcmd"
)

$sqlcmd = $null
foreach ($path in $sqlcmdPaths) {
    if ($path -eq "sqlcmd") {
        try { 
            $null = Get-Command sqlcmd -ErrorAction Stop
            $sqlcmd = "sqlcmd"
            break
        } catch {}
    } elseif (Test-Path $path) {
        $sqlcmd = $path
        break
    }
}

if (-not $sqlcmd) {
    # Try to find it via where
    $found = where.exe sqlcmd 2>$null
    if ($found) { $sqlcmd = $found }
}

Write-Host "Using sqlcmd: $sqlcmd"
Write-Host "MDF Path: $mdfPath"

# Step 1: Start LocalDB instance
Write-Host "`n--- Starting LocalDB instance ---"
& SqlLocalDB start $instanceName

Start-Sleep -Seconds 2

# Step 2: Create the .mdf database using sqlcmd
$createDbSql = @"
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'employeeDb')
BEGIN
    CREATE DATABASE [employeeDb]
    ON PRIMARY (
        NAME = N'employeeDb',
        FILENAME = N'$mdfPath'
    )
    LOG ON (
        NAME = N'employeeDb_log',
        FILENAME = N'$ldfPath'
    );
    PRINT 'Database created.';
END
ELSE
BEGIN
    PRINT 'Database already exists.';
END
"@

Write-Host "`n--- Creating database ---"
$createDbSql | & $sqlcmd -S "(localdb)\$instanceName" -E

Start-Sleep -Seconds 2

# Step 3: Create tables and seed data
$setupSql = @"
USE [employeeDb];

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'login')
BEGIN
    CREATE TABLE [login] (
        Id       NVARCHAR(50) NOT NULL PRIMARY KEY,
        password NVARCHAR(100) NOT NULL
    );
    PRINT 'login table created.';
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'employee')
BEGIN
    CREATE TABLE [employee] (
        name     NVARCHAR(100),
        ID       NVARCHAR(50) NOT NULL PRIMARY KEY,
        age      NVARCHAR(10),
        salary   NVARCHAR(50),
        email    NVARCHAR(100),
        num      NVARCHAR(50),
        DOB      NVARCHAR(50),
        joindate NVARCHAR(50),
        address  NVARCHAR(200),
        shift    NVARCHAR(50),
        gender   NVARCHAR(20)
    );
    PRINT 'employee table created.';
END

IF NOT EXISTS (SELECT * FROM [login] WHERE Id = '1')
BEGIN
    INSERT INTO [login] (Id, password) VALUES ('1', 'password');
    PRINT 'Admin user seeded.';
END

PRINT 'Setup complete!';
"@

Write-Host "`n--- Creating tables and seeding data ---"
$setupSql | & $sqlcmd -S "(localdb)\$instanceName" -E -d "employeeDb"

Write-Host "`n--- Done! Database is ready. ---"
Write-Host "Login with ID=1, Password=password"
