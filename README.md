# WebSchool

A robust and scalable REST API for comprehensive school management systems, built with layered architecture and .NET 10.
This project is a test for studying the C# language and the .NET framework, as well as Clean Architecture.
[GitHub](https://github.com/gabrieldu4rte/WebSchool) | [.NET 10.0](https://dotnet.microsoft.com/)

## Table of Contents

- [Overview](#overview)
- [Main Features](#main-features)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation and Configuration](#installation-and-configuration)
- [Project Structure](#project-structure)
- [Database Configuration](#database-configuration)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Docker](#docker)
- [Code Conventions](#code-conventions)
- [Contributing](#contributing)
- [Author](#author)

## Overview

WebSchool is a complete backend platform for managing educational institutions. It provides a well-structured REST API that enables managing courses, classes, students, grades, and tuition register efficiently and securely.

The project follows industry best practices, including:
- Clean Architecture with layered separation
- Dependency Injection pattern
- JWT authentication
- Exception handling
- Automatic documentation via Swagger/OpenAPI
- Pagination support
- PostgreSQL database integration

## Main Features

### Academic Management
- Complete CRUD operations for courses and classes
- Student grade management and tracking
- User management (students, teachers, administrators)
- Class organization and student distribution

### Security
- JWT-based authentication
- Role-based authorization (Admin, Teacher, Student)
- Password hashing with Salt
- Data validation across multiple layers

### Operational
- Result pagination with metadata
- Centralized exception handling
- Structured logging
- Interactive API documentation via Swagger

## Architecture

The project implements Clean Architecture with 5 main layers:

```
Layer 1: Presentation
- WebSchool.API (Controllers, Middleware, HTTP handling)
		|
		v
Layer 2: Application
- WebSchool.Application (Services, DTOs, Interfaces)
		|
		v
Layer 3: Domain
- WebSchool.Domain (Entities, Business Rules, Interfaces)
		|
		v
Layer 4: Data Access
- WebSchool.Infra.Data (Repositories, DbContext, Migrations)
		|
		v
Layer 5: Configuration
- WebSchool.Infra.IoC (Dependency Injection Container)
```

### Layer Responsibilities

| Layer | Responsibility | Examples |
|-------|---|---|
| **API** | HTTP requests, Controllers, Middleware | `CourseController`, `ExceptionMiddleware` |
| **Application** | Business logic, Service implementations | `CourseService`, `UserService` |
| **Domain** | Core entities, Business rules | `User`, `Course`, `Note` |
| **Infra.Data** | Data persistence, Repositories | `CourseRepository`, `DbContext` |
| **Infra.IoC** | Service registration and injection | Container configuration |

## Technologies Used

### Framework and Language
- .NET 10.0 - Modern, high-performance framework
- C# 13 - Strongly-typed language with latest features

### Database
- PostgreSQL 14+ - Robust relational database
- Entity Framework Core 10.0.9 - ORM framework
- Npgsql 10.0.3 - PostgreSQL EF Core provider

### Key Dependencies
- Swashbuckle.AspNetCore 10.2.3 - Swagger/OpenAPI documentation
- Microsoft.AspNetCore.Authentication.JwtBearer 10.0.10 - JWT authentication
- DotNetEnv 3.2.0 - Environment variable management

### Development Tools
- Visual Studio Community 2026
- Docker & Docker Compose
- .NET CLI

## Prerequisites

Ensure you have the following installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL 14+](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)
- [Docker](https://www.docker.com/) (optional)
- [Visual Studio Community 2026](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Verify Installation

```bash
dotnet --version
psql --version
git --version
```

## Installation and Configuration

### 1. Clone the Repository

```bash
git clone https://github.com/gabrieldu4rte/WebSchool.git
cd WebSchool
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Configure Environment Variables

Create an `.env` file at the project root:

```env
# Database
DB_USER=postgres
DB_PASSWORD=your_password
DB_HOST=localhost
DB_PORT=5432
DB_NAME=WebSchool

# JWT
JWT_SECRET_KEY="Your Key Here"
JWT_ISSUER=webschool-api
JWT_AUDIENCE=webschool-frontend
```

### 4. Update appsettings.json

Edit `WebSchool.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
	"DefaultConnection": "User ID=postgres;Password=your_password;Host=localhost;Port=5432;Database=WebSchool;Pooling=true;Trust Server Certificate=false;"
  },
  "Jwt": {
	"SecretKey": "your_secret_key_here",
	"Issuer": "webschool-api",
	"Audience": "webschool-frontend"
  }
}
```

### 5. Initialize the Database

```bash
# Navigate to the data project
cd WebSchool.Infra.Data

# Apply Entity Framework migrations
dotnet ef database update --project ../WebSchool.Infra.Data

# Return to root directory
cd ..
```

### 6. Run the Application

```bash
cd WebSchool.API
dotnet run

# API will be available at:
# https://localhost:5001
# Swagger UI: https://localhost:5001/swagger
```

## Project Structure

```
WebSchool/
├── WebSchool.API/
│   ├── Controllers/                    # HTTP Controllers
│   │   ├── CourseController.cs
│   │   ├── NoteController.cs
│   │   ├── SchoolClassController.cs
│   │   ├── TuitionController.cs
│   │   └── UserController.cs
│   ├── Middleware/                     # Custom middleware
│   │   └── ExceptionMiddleware.cs
│   ├── Models/                         # Request/Response DTOs
│   ├── Extensions/                     # HTTP extensions
│   ├── Errors/                         # Error definitions
│   ├── Program.cs                      # Application configuration
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Dockerfile
│   └── launchSettings.json
│
├── WebSchool.Application/
│   ├── Services/                       # Business logic
│   │   ├── CourseService.cs
│   │   ├── NoteService.cs
│   │   ├── SchoolClassService.cs
│   │   ├── TuitionService.cs
│   │   └── UserService.cs
│   ├── Interfaces/                     # Service contracts
│   ├── DTOs/                           # Data Transfer Objects
│   │   ├── Course/
│   │   ├── Note/
│   │   ├── SchoolClass/
│   │   ├── Tuition/
│   │   └── User/
│   └── Exceptions/                     # Custom exceptions
│
├── WebSchool.Domain/
│   ├── Entities/                       # Domain models
│   │   ├── Course.cs
│   │   ├── Note.cs
│   │   ├── SchoolClass.cs
│   │   ├── Tuition.cs
│   │   └── User.cs
│   ├── Interfaces/                     # Repository contracts
│   │   ├── ICourseRepository.cs
│   │   ├── INoteRepository.cs
│   │   ├── ISchoolClassRepository.cs
│   │   ├── ITuitionRepository.cs
│   │   └── IUserRepository.cs
│   ├── Account/                        # Authentication
│   │   └── IAuthenticate.cs
│   └── Pagination/                     # Pagination utilities
│
├── WebSchool.Infra.Data/
│   ├── Repositories/                   # Repository implementations
│   ├── DbContext/                      # Entity Framework context
│   └── Migrations/                     # Database migrations
│
├── WebSchool.Infra.IoC/                # Dependency Injection
│   └── ServiceCollectionExtensions.cs
│
├── WebSchool.slnx                      # Solution file
├── README.md
├── .gitignore
└── docker-compose.yml
```

## Database Configuration

### Create Database Manually

```sql
-- Connect as PostgreSQL admin
CREATE DATABASE "WebSchool";

-- Optional: Create dedicated user
CREATE USER webschool_user WITH PASSWORD 'secure_password';
GRANT ALL PRIVILEGES ON DATABASE "WebSchool" TO webschool_user;
```

### Entity Framework Migrations

```bash
# Create new migration
dotnet ef migrations add MigrationName --project WebSchool.Infra.Data

# Apply migrations
dotnet ef database update --project WebSchool.Infra.Data

# Revert to previous migration
dotnet ef database update PreviousMigrationName --project WebSchool.Infra.Data

# Remove last migration (unapplied)
dotnet ef migrations remove --project WebSchool.Infra.Data
```

### Main Entities

#### User
```csharp
public class User
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public byte[] PasswordHash { get; set; }
	public byte[] PasswordSalt { get; set; }
	public string Profile { get; set; }       // Admin, Teacher, Student
	public bool IsDeleted { get; set; }
	public ICollection<Tuition> Tuitions { get; set; }
}
```

#### Course
```csharp
public class Course
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public ICollection<SchoolClass> SchoolClasses { get; set; }
}
```

#### SchoolClass
```csharp
public class SchoolClass
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int CourseId { get; set; }
	public Course Course { get; set; }
	public ICollection<Note> Notes { get; set; }
}
```

#### Note
```csharp
public class Note
{
	public int Id { get; set; }
	public decimal Value { get; set; }
	public int UserId { get; set; }
	public int SchoolClassId { get; set; }
	public SchoolClass SchoolClass { get; set; }
}
```

#### Tuition
```csharp
public class Tuition
{
	public int Id { get; set; }
	public decimal Value { get; set; }
	public DateTime DueDate { get; set; }
	public DateTime? PaymentDate { get; set; }
	public bool IsPaid { get; set; }
	public int UserId { get; set; }
	public User User { get; set; }
}
```

## Getting Started

### Run Tests

```bash
# List all tests
dotnet test --list-tests

# Run all tests
dotnet test

# Run specific project tests
dotnet test WebSchool.Application.Tests
```

### API Endpoints

After starting the application, visit:

Swagger UI: `https://localhost:5001/swagger`

You can interact with all endpoints directly through the interface.

### Request Examples

#### 1. User Login

```bash
POST /api/users/login
Content-Type: application/json

{
  "email": "admin@webschool.com",
  "password": "secure_password"
}

Response: 200 OK
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expires": "2025-01-31T10:30:00Z"
}
```

#### 2. Create Course

```bash
POST /api/courses
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": ".NET Development",
  "description": "Advanced .NET 10 development course"
}

Response: 201 Created
{
  "id": 1,
  "name": ".NET Development",
  "description": "Advanced .NET 10 development course"
}
```

#### 3. List Courses with Pagination

```bash
GET /api/courses?pageNumber=1&pageSize=10
Authorization: Bearer {token}

Response: 200 OK
{
  "items": [...],
  "totalCount": 25,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 3
}
```

#### 4. Register Grade

```bash
POST /api/notes
Authorization: Bearer {token}
Content-Type: application/json

{
  "value": 8.5,
  "userId": 1,
  "schoolClassId": 1
}

Response: 201 Created
```

## Authentication

### How It Works

1. Submit email and password to `/api/users/login`
2. Receive a valid JWT token in response
3. Include token in request header: `Authorization: Bearer {token}`
4. Token automatically refreshes on each successful request

### JWT Structure

```
Header:
{
  "alg": "HS256",
  "typ": "JWT"
}

Payload:
{
  "sub": "user@example.com",
  "name": "User Name",
  "profile": "Admin",
  "exp": 1704067200
}

Signature: HMACSHA256(...)
```

### User Roles

- Admin: Full system access
- Student: View own grades and tuition status

## Docker

### Docker Compose

```bash
# Start all services (API + PostgreSQL)
docker-compose up -d

# Stop services
docker-compose down

# View logs
docker-compose logs -f api

# Rebuild image
docker-compose up --build
```

### Build Locally

```bash
# Build image
docker build -t webschool:latest -f WebSchool.API/Dockerfile .

# Run container
docker run -p 5001:5001 \
  -e ConnectionStrings__DefaultConnection="..." \
  webschool:latest
```

## Code Conventions

### Naming Conventions

- Classes: PascalCase (UserService)
- Methods: PascalCase (GetUserById)
- Private fields: camelCase with underscore prefix (_userRepository)
- Constants: UPPER_CASE (MAX_PAGE_SIZE)

### Service Structure

```csharp
public class CourseService : ICourseService
{
	private readonly ICourseRepository _courseRepository;

	public CourseService(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task<CourseGetDTO> GetByIdAsync(int id)
	{
		var course = await _courseRepository.GetByIdAsync(id);
		if (course == null)
			throw new NotFoundException($"Course with ID {id} not found.");

		return MapToDTO(course);
	}
}
```

### DTOs Pattern

```csharp
// Get DTO
public class CourseGetDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
}

// Create DTO
public class CoursePostDTO
{
	[Required]
	public string Name { get; set; }
	public string Description { get; set; }
}

// Update DTO
public class CoursePutDTO
{
	public string Name { get; set; }
	public string Description { get; set; }
}
```

## Contributing

Contributions are welcome. To contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/new-feature`)
3. Commit changes (`git commit -m 'Add new feature'`)
4. Push to branch (`git push origin feature/new-feature`)
5. Open a Pull Request with detailed description

### Reporting Issues

Use GitHub Issues with:

- Detailed description of the problem
- Steps to reproduce
- Expected vs. actual behavior
- Error logs (if available)
- .NET version and operating system

## Author

Gabriel Duarte

- GitHub: [@gabrieldu4rte](https://github.com/gabrieldu4rte)
- Repository: [WebSchool](https://github.com/gabrieldu4rte/WebSchool)

## Useful Links

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [JWT.io](https://jwt.io/)
- [OpenAPI/Swagger](https://swagger.io/)

## FAQ

Q: How do I reset the database?

A: Run `dotnet ef database drop --project WebSchool.Infra.Data` followed by `dotnet ef database update --project WebSchool.Infra.Data`.

Q: Can I use SQL Server instead of PostgreSQL?

A: Yes, replace `Npgsql.EntityFrameworkCore.PostgreSQL` with `Microsoft.EntityFrameworkCore.SqlServer` and update the connection string.

Q: How do I configure CORS?

A: Add to `Program.cs`:
```csharp
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder => 
		builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
app.UseCors("AllowAll");
```
