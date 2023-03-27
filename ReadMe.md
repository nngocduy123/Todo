# Todo App

## Prerequisite

To build this project, we need to prepare these tools:

- .NET 7.0 ([download link](https://dotnet.microsoft.com/en-us/download/dotnet/7.0))
- EF Core tools ([installation guide](https://learn.microsoft.com/en-us/ef/core/cli/dotnet))
- SQL Server 2017

## Getting Started

### Prepare Database

1. Create an empty database on SQL Server

2. Setting Up The Connection String in your `appsetting.json` to your newly created database:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<DB_HOST>;Database=<DB_NAME>;User ID=<DB_USER>;Password=<DB_PASSWORD>;Connection Timeout=30;Encrypt=false;TrustServerCertificate=true"
}
```

3. Apply Migrations To Your Database

```bash
cd Todo.Data  # change directory to Todo.Data
dotnet ef database update  # Apply migrations
```

### Run Project

```bash
cd Todo.API  # change directory to Todo.API
dotnet run  # Run the API
```

### Test Project

```bash
cd Todo.Test  # change directory to Todo.Test
dotnet test  # Run tests
```

## Notes

To save time, I only created one test for businesses and controllers.

## Author

Nguyen Ngoc Duy
