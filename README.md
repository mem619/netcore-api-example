# README #

Example Api Rest using Auth Bearer Token, Swagger, Generic Repository, Migrations and Mapper.

## Get Started
SDK netcore 2+
SQL Server (SQL Server high level user for migrations).

Restore packages.
```
dotnet restore
````


Configure String Database Connection appsetting file.
```
"ConnectionStrings": {
    "DefaultConnection": "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
  }
````

Run Migration with Package Console in DBContext Project.
```
add-migration InitialCreate
update-database

````

Build Application.
```
dotnet build
````

Run Application and Test.
```
dotnet run --project WB.WAPP.SEG.Api
````

Run Unit Test.
```
dotnet test
````

## How to Engage, Contribute, and Give Feedback

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
