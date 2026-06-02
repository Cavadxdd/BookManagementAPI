# Book Management API

A RESTful API built with .NET 8 and Clean Architecture principles.

## Tech Stack
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core 8
- MSSQL
- Swagger

## Architecture
BookManagement.API         → Controllers
BookManagement.Application → DTOs, Interfaces, Services
BookManagement.Domain      → Entities, Enums
BookManagement.Infrastructure → DbContext, Repositories

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/books | Get all books |
| GET | /api/books/{id} | Get book by id |
| GET | /api/books/genre/{genre} | Get books by genre |
| POST | /api/books | Create book |
| PUT | /api/books/{id} | Update book |
| DELETE | /api/books/{id} | Delete book |

## Genres
Fiction, NonFiction, Science, History, Technology, Biography, Fantasy, Mystery

## Setup
1. Clone the repository
2. Update connection string in `appsettings.Development.json`
3. Run migrations:
Update-Database
4. Run the project and navigate to `/swagger`