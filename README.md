# TicketFlow API (Helpdesk & Department Ticket Management System) 🎫🏢
> A powerful, serverless-ready Enterprise IT Helpdesk, Department Management, and Ticketing RESTful Web API built with **ASP.NET Core 8.0**, **C#**, **Entity Framework Core**, **SQL Server**, **AWS Lambda**, and **Swagger / OpenAPI**.

---

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512BD4.svg?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120.svg?style=flat&logo=csharp)](https://learn.microsoft.com/dotnet/csharp/)
[![ASP.NET Core Web API](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4.svg?style=flat)](https://learn.microsoft.com/aspnet/core)
[![EF Core](https://img.shields.io/badge/ORM-EF%20Core-512BD4.svg?style=flat)](https://learn.microsoft.com/ef/core)
[![AWS Lambda](https://img.shields.io/badge/Serverless-AWS%20Lambda-FF9900.svg?style=flat&logo=amazon-aws)](https://aws.amazon.com/lambda/)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC292B.svg?style=flat&logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![Swagger / OpenAPI](https://img.shields.io/badge/API%20Docs-Swagger%20%2F%20OpenAPI-85EA2D.svg?style=flat&logo=swagger)](https://swagger.io/)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat)]()

---

## 📖 Overview

**TicketFlow API** (formerly *APIs_C*) is a multi-tenant ready backend solution designed to streamline IT support requests, cross-department ticket assignments, employee directory management, and password recovery workflows.

Engineered with decoupled **Repository Patterns** and cloud-native **AWS Lambda ASP.NET Core Server integration**, TicketFlow API delivers high-throughput ticket resolution workflows for single-page web applications (React, Angular, Vue) and enterprise mobile clients.

---

## 🌟 Key Modules & Features

### 🎫 1. Support Ticket Lifecycle Management (`/api/Tickets`)
- **Ticket Creation & Assignment**: Issue creation automatically linked to `Creator` and assigned `Handler` (support agent).
- **Multi-Criteria Filtering**:
  - Filter tickets by **Status** (Open, In Progress, Resolved, Closed).
  - Filter tickets by **Department** (IT, HR, Sales, Billing).
  - Filter tickets by **Creator ID** (`/api/Tickets/Create?idc=...`).
  - Filter tickets by **Assigned Handler** (`/api/Tickets/Take?idt=...`).
- **Full Ticket CRUD**: Real-time status updates, content edits, and deletion.

### 🏢 2. Department & Employee Organization (`/api/Department`)
- **Department Hierarchy**: Create and manage company departments.
- **Staff Assignment**: Add employees to departments (`InsertEmp`) and reassign or remove staff (`RemoveEmp`).
- **Staff Roster Queries**: Fetch all employees associated with a given department.

### 👤 3. User Accounts & Authentication (`/api/Users`)
- **User Registration**: Register employees with mandatory department binding.
- **Authentication**: Fast credential validation via email and password lookup.
- **Email Validation**: Dedicated lookup endpoint to check email availability.
- **Role Assignment**: Manage administrative, manager, and support agent roles.

### 🔑 4. Secure Password Recovery (`/api/Password_Reset`)
- Tokenized password reset workflow tracking email, security tokens, and creation timestamps.

---

## 🏗️ Architecture & Design

```
   ┌────────────────────────────────────────────────────────┐
   │         Clients (Web App / Mobile / AWS API Gateway)   │
   └───────────────────────────┬────────────────────────────┘
                               │ JSON / HTTPS
                               ▼
   ┌────────────────────────────────────────────────────────┐
   │             ASP.NET Core 8 Web API Pipeline            │
   │  [TicketsController] [DepartmentController] [Users]    │
   └───────────────────────────┬────────────────────────────┘
                               │ Dependency Injection
                               ▼
   ┌────────────────────────────────────────────────────────┐
   │               Repository Layer (IRepository)           │
   │  • TicketRepository       • DepartmentRepository       │
   │  • UserRepository         • Password_ResetRepository   │
   └───────────────────────────┬────────────────────────────┘
                               │ Entity Framework Core
                               ▼
   ┌────────────────────────────────────────────────────────┐
   │            Microsoft SQL Server (`db : DbContext`)     │
   └────────────────────────────────────────────────────────┘
```

---

## 📡 REST API Reference

### 🎫 Support Tickets (`/api/Tickets`)
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Tickets` | Fetch all support tickets |
| `GET` | `/api/Tickets/{id}` | Fetch ticket by ID |
| `GET` | `/api/Tickets/Status?status={n}` | Filter tickets by status integer |
| `GET` | `/api/Tickets/Create?idc={id}` | Filter tickets created by user ID |
| `GET` | `/api/Tickets/Take?idt={id}` | Filter tickets assigned to handler ID |
| `GET` | `/api/Tickets/Department?idt={id}` | Filter tickets belonging to department ID |
| `POST` | `/api/Tickets` | Create and dispatch a new support ticket |
| `PUT` | `/api/Tickets?id={id}` | Update ticket details or status |
| `DELETE` | `/api/Tickets/{id}` | Delete ticket by ID |

---

### 🏢 Departments (`/api/Department`)
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Department` | List all departments |
| `GET` | `/api/Department/{id}` | Get department details and member list |
| `POST` | `/api/Department/InsertDep` | Create a new department |
| `PUT` | `/api/Department?departmentId={d}&userId={u}` | Assign employee to department |
| `DELETE` | `/api/Department?departmentId={d}&Userid={u}` | Remove employee from department |

---

### 👤 Users (`/api/Users`)
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Users` | List all registered users |
| `GET` | `/api/Users/{id}` | Get user by ID |
| `GET` | `/api/Users/users?email={e}&password={p}` | Authenticate user credentials |
| `GET` | `/api/Users/Email?email={e}` | Check user existence by email |
| `POST` | `/api/Users` | Register new user with department binding |
| `PUT` | `/api/Users?id={id}` | Update user profile |
| `DELETE` | `/api/Users/{id}` | Delete user account |

---

### 🔑 Password Reset (`/api/Password_Reset`)
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Password_Reset` | Fetch password reset requests |
| `GET` | `/api/Password_Reset/token?email={e}&token={t}` | Verify reset token |
| `POST` | `/api/Password_Reset` | Generate password reset request |

---

## 🗄️ Database Entities

### `Ticket`
```csharp
public class Ticket {
    public int id { get; set; }
    public string title { get; set; }
    public int department { get; set; }
    public int status { get; set; }
    public int id_create { get; set; }      // Creator User ID
    public int take_user { get; set; }       // Assigned Handler User ID
    public User Creator { get; set; }
    public User Handler { get; set; }
}
```

### `Department`
```csharp
public class Department {
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public List<User> User { get; set; }
}
```

### `User`
```csharp
public class User {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public int DepartmentId { get; set; }
    public string role { get; set; }
}
```

---

## 🚀 Quick Start Guide

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or Azure SQL)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) / [VS Code](https://code.visualstudio.com/)

---

### Setup & Run

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/MustafaTaweel1/APIs_C.git
   cd APIs_C
   ```

2. **Configure Database Connection**:
   Open [`APIs/Program.cs`](file:///c:/Users/Mustafa/Desktop/testopencode/APIs_C/APIs/Program.cs) and verify your connection string:
   ```csharp
   options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Create_API;Integrated Security=True;");
   ```

3. **Apply EF Core Database Migrations**:
   ```bash
   dotnet ef database update --project APIs
   ```

4. **Run Application**:
   ```bash
   dotnet run --project APIs
   ```

5. **Access Swagger UI**:
   Navigate to `https://localhost:7000/swagger` in your browser.

---

## ☁️ AWS Serverless Deployment

This project includes `Amazon.Lambda.AspNetCoreServer` support. To deploy as an AWS Lambda function:

```bash
dotnet tool install -g Amazon.Lambda.Tools
dotnet lambda deploy-serverless
```

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
