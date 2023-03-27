**Prepare Database**

Create empty database SQL Server

**Setting Up The Connection String in your `appseting.json`** </br>
Set connection string to your existing SQL Server Database
```
"ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=Todo;User ID=sa;Password=reallyStrongPwd123;Connection Timeout = 30;Encrypt=false;TrustServerCertificate=true"
  }
```

**Apply Migration To Your Database**
```bash
1. Open terminal from Todo.Data 
2. Run following command:
3. dotnet ef database update
```

## Run Project

```bash
1. Open terminal from Todo.API 
2. Run following command:
3. dotnet run
```

## Test Project

```
1. Open terminal from Todo.Test 
2. Run following command:
3. dotnet test
```

## Notes
To save time, I only created one test for business and controllers as well.

## Author
Nguyen Ngoc Duy
