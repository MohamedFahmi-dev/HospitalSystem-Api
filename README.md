# Hospital Management System API

A comprehensive hospital management system built with ASP.NET Core, implementing Clean Architecture principles with CQRS pattern using MediatR.

## 🏗️ Architecture

- **Clean Architecture** with separated layers
- **CQRS Pattern** using MediatR
- **Repository Pattern** with Entity Framework Core
- **JWT Authentication** with role-based authorization
- **AutoMapper** for object mapping
- **FluentValidation** for request validation

## 🔧 Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- ASP.NET Core Identity
- MediatR
- AutoMapper
- FluentValidation
- JWT Bearer Authentication
- SQL Server

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/hospital-management-system.git
   cd hospital-management-system
   ```

2. **Set up User Secrets**
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=HospitalDB;Trusted_Connection=true;TrustServerCertificate=true;"
   dotnet user-secrets set "Jwt:SecurityKey" "YourSuperSecretJWTKeyHere123456789"
   dotnet user-secrets set "Jwt:IssuerIP" "https://localhost:7001"
   dotnet user-secrets set "Jwt:AudienceIP" "https://localhost:7001"
   ```

3. **Update Database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

## 📡 API Endpoints

### Authentication

#### Register User
```http
POST /api/auth/register
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "Password123",
  "confirmPassword": "Password123",
  "role": "Patient"
}
```

#### Login User
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "Password123"
}
```

### Available Roles
- `Admin` - Full system access
- `Doctor` - Medical staff access
- `Nurse` - Nursing staff access
- `Patient` - Patient portal access

## 🔐 Authentication & Authorization

The system uses JWT tokens for authentication with role-based authorization:

```csharp
[Authorize(Roles = "Admin")]
[HttpGet("admin-only")]
public IActionResult AdminEndpoint() { ... }

[Authorize(Roles = "Admin,Doctor")]
[HttpGet("medical-staff")]
public IActionResult MedicalStaffEndpoint() { ... }
```

## 🏛️ Project Structure

```
Hospital.Api/                 # API Layer
├── Controllers/              # API Controllers
Hospital.Core/                # Application Layer  
├── Features/                 # CQRS Commands/Queries
│   ├── Auth/                # Authentication features
├── Base/                    # Base classes
Hospital.Infrastructure/      # Infrastructure Layer
├── Data/                    # Database context
├── Repositories/            # Data access
Hospital.Services/           # Application Services
├── Abstract/                # Service interfaces
├── Implementation/          # Service implementations
```

## 🧪 Testing

### Test Registration
```bash
curl -X POST "https://localhost:7001/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Test",
    "lastName": "User",
    "email": "test@example.com",
    "password": "Password123",
    "confirmPassword": "Password123",
    "role": "Patient"
  }'
```

### Test Login
```bash
curl -X POST "https://localhost:7001/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "password": "Password123"
  }'
```

## 📝 Features

- ✅ User Registration with validation
- ✅ JWT Authentication
- ✅ Role-based Authorization (Admin, Doctor, Nurse, Patient)
- ✅ Secure password handling
- ✅ Database transaction support
- ✅ Comprehensive error handling
- ✅ Clean API responses

## 🔄 Upcoming Features

- [ ] Patient Management
- [ ] Doctor Management
- [ ] Appointment Scheduling
- [ ] Medical Records
- [ ] Prescription Management
- [ ] Department Management
- [ ] Audit Logging

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

Your Name - [your.email@example.com](mailto:your.email@example.com)

## 🙏 Acknowledgments

- Clean Architecture by Robert C. Martin
- CQRS Pattern implementation
- ASP.NET Core Identity framework
