# CoursesAcademy

A relational database system for a course academy, built with **SQL Server** and queried through **Entity Framework Core** (Database-First approach) using **LINQ**. The app is a .NET console application that performs CRUD operations on the data.

## Features

- Store and manage students, instructors, departments, topics and courses
- Track which students take which courses (with grades)
- Track which instructors teach which courses (with evaluations)
- Database-First mapping from an existing SQL Server database to C# classes
- CRUD operations and queries written with LINQ

## Tech Stack

| Area | Technology |
|---|---|
| Language | C# |
| Framework | .NET |
| ORM | Entity Framework Core (Database-First) |
| Database | Microsoft SQL Server |
| Querying | LINQ |

## Database Design

### Entities

| Table | Description |
|---|---|
| `Topic` | Subject categories (e.g. Programming, Databases) |
| `Course` | Courses offered, each belonging to one topic |
| `Department` | Academic departments, each managed by an instructor |
| `Instructor` | Instructors with salary, bonus and hourly rate |
| `Student` | Students, each belonging to one department |
| `Instructor_Teach_Course` | Many-to-many link between instructors and courses (with `Evaluation`) |
| `Student_Take_Course` | Many-to-many link between students and courses (with `Grade`) |

### Relationships

- **Topic → Course**: one-to-many
- **Department → Student**: one-to-many
- **Department → Instructor**: one-to-many
- **Instructor → Department**: one-to-one (department manager)
- **Instructor ↔ Course**: many-to-many
- **Student ↔ Course**: many-to-many

### ERD

![ERD](Diagrams/ERD.png)

## Project Structure

```
CoursesAcademy/
├── CoursesAcademy/     # .NET project (DbContext, models, and console app)
├── Database/           # Database files
├── Diagrams/           # ERD and schema diagrams
├── SQL_Queries/        # SQL scripts
└── .gitignore
```

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express edition is enough) and SQL Server Management Studio (SSMS)
- Visual Studio or VS Code

### Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/yousabgamal/CoursesAcademy.git
   cd CoursesAcademy
   ```

2. **Create the database**

   Restore the database from the files in the `Database` folder, or run the scripts in `SQL_Queries` using SSMS.

3. **Update the connection string**

   Open the `DbContext` class (or `appsettings.json`, if used) and set the connection string to match your SQL Server instance:

   ```
   Server=YOUR_SERVER_NAME;Database=CoursesAcademy;Trusted_Connection=True;TrustServerCertificate=True;
   ```

4. **Run the application**

   ```bash
   cd CoursesAcademy
   dotnet run
   ```

## Scaffolding Command (Database-First)

The models and `DbContext` were generated from the existing database using:

```bash
dotnet ef dbcontext scaffold "Server=YOUR_SERVER_NAME;Database=CoursesAcademy;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

## What I Learned

- Designing an ERD and turning it into a relational schema
- Modeling one-to-many and many-to-many relationships
- Mapping an existing database with EF Core (Database-First)
- Writing queries and CRUD operations with LINQ

## Author

**Yousab Gamal**

- GitHub: [@yousabgamal](https://github.com/yousabgamal)
