# Project 1: MVC CRUD Operations Using Entity Framework

## Purpose
Demonstrates traditional **Entity Framework 6 (EF6) Database-First** development in **ASP.NET MVC 5 (.NET Framework 4.8)** using visual EDMX modeling, scaffolded controllers/views, and stored procedure function imports.

## Key Files
- `Model1.edmx`: Visual EDMX designer artifact mapping SQL Server tables (`Emp`, `Employee`, `tblStudent`) and stored procedures.
- `Model1.Context.cs`: T4-generated `DbContext` (`ADO_CRUD_MVCEntities1`).
- `Controllers/EmpsController.cs`: Controller implementing standard CRUD operations over the `Emp` entity.
- `Views/Emps/*.cshtml`: Scaffolded Razor views (`Index`, `Details`, `Create`, `Edit`, `Delete`).
- `Web.config`: Contains the `ADO_CRUD_MVCEntities1` metadata connection string.

## What to Notice in the Code
- **Implicit Change Tracking**: The controller manipulates entity state directly (`db.Entry(emp).State = EntityState.Modified; db.SaveChanges()`).
- **Security Defenses**: Scaffolded POST actions include `[ValidateAntiForgeryToken]` and attribute binding `[Bind(Include = "...")]` to prevent mass-assignment/overposting.
- **Stored Procedure Imports**: The generated context exposes stored procedures (`spGetAllEmployees`, `spDeleteEmployee`, etc.) as strongly-typed C# methods via `ObjectContext.ExecuteFunction`.

## Known Limitations
- **Tight Coupling**: The controller directly instantiates the DbContext, making unit testing without a live database difficult.
- **Legacy EDMX**: EDMX visual modeling has been replaced in modern .NET by code-first migrations and fluent configurations.
- **Broad Context Scope**: Multiple independent entity sets (`Emp`, `Employee`, `tblStudent`) share a single DbContext.
