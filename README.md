# Connection String Test Project

This project contains .NET implementations to test and create SQL Server connection strings with CodeQL security analysis.

## Project Structure

### .NET Framework 4.8 Version (For Windows environments)
- `ConnStringTest.csproj` - .NET Framework 4.8 project file
- `ConnectionStringHelper.cs` - Main class for creating and testing connection strings
- `App.config` - Configuration file with sample connection strings

### .NET 8 Version (Cross-platform)
- `ConnStringTest.Modern.csproj` - .NET 8 library project
- `ConnStringDemo.csproj` - .NET 8 console demo application
- `Program.cs` - Demo application showing usage examples

### CodeQL Configuration
- `.github/workflows/codeql.yml` - CodeQL security analysis workflow
- `codeql-database.yml` - CodeQL database configuration

### Additional Files
- `Properties/AssemblyInfo.cs` - Assembly information
- `README.md` - Project documentation
- `.gitignore` - Git ignore rules

## Features

The `ConnectionStringHelper` class provides the following functionality:

- **CreateConnectionString()** - Creates a connection string with specified parameters
- **TestConnection()** - Tests if a connection string is valid
- **GetConnectionStringFromConfig()** - Retrieves connection strings from app.config
- **CreateConnection()** - Creates a SqlConnection object from a connection string

## Security Features

- Uses SqlConnectionStringBuilder for safe connection string construction
- Enforces encryption by default (`Encrypt=true`)
- Disables trust of server certificates (`TrustServerCertificate=false`)
- Includes proper timeout settings
- CodeQL analysis for security vulnerability detection

## Building the Project

### .NET Framework 4.8 (Windows only)
```bash
# Requires .NET Framework 4.8 Developer Pack
nuget restore ConnStringTest.csproj
msbuild ConnStringTest.csproj /p:Configuration=Release
```

### .NET 8 (Cross-platform)
```bash
# Build the library
dotnet build ConnStringTest.Modern.csproj

# Build and run the demo
dotnet build ConnStringDemo.csproj
dotnet run --project ConnStringDemo.csproj
```

## CodeQL Analysis

The project includes CodeQL configuration for security analysis:
- Analyzes C# code for security vulnerabilities
- Runs on push, pull requests, and weekly schedule
- Includes security-and-quality query suite
- Detects SQL injection vulnerabilities and insecure connection practices

## Known Security Issues

⚠️ **Note**: This project intentionally uses `System.Data.SqlClient` version 4.8.5 which has known vulnerabilities to demonstrate CodeQL detection capabilities. In production, use `Microsoft.Data.SqlClient` instead.

## Usage Example

```csharp
// Create a connection string with Windows authentication
string connStr = ConnectionStringHelper.CreateConnectionString(
    "localhost", 
    "MyDatabase", 
    useIntegratedSecurity: true
);

// Test the connection
bool isValid = ConnectionStringHelper.TestConnection(connStr);

// Get connection string from config
string configConnStr = ConnectionStringHelper.GetConnectionStringFromConfig("DefaultConnection");

// Create a connection object
using (var connection = ConnectionStringHelper.CreateConnection(connStr))
{
    connection.Open();
    // Use the connection...
}
```

## Demo Output Example

```
Connection String Test Demo
==========================
Windows Auth Connection String:
Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False

SQL Auth Connection String:
Data Source=server.example.com;Initial Catalog=ProductionDB;Integrated Security=False;User ID=dbuser;Password=password123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False

Config Connection String:
Server=localhost;Database=TestDB;Integrated Security=true;Encrypt=true;TrustServerCertificate=false;

Testing connection validity...
Connection test result: FAILED

Demo completed successfully!
```