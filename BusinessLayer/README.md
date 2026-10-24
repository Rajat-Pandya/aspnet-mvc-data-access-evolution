# Project 3: BusinessLayer

## Purpose
A reusable **Class Library (DLL)** targeting **.NET Framework 4.8** that encapsulates business logic and stored-procedure-based data access for the `Employee` domain.

## Key Files
- `Employee.cs`: Plain Old CLR Object (POCO) decorated with DataAnnotations (`[Required]`).
- `EmployeeBusinessLayer.cs`: Business layer executing SQL Server stored procedures via `SqlCommand` and `SqlDataReader`.
- `BusinessLayer.csproj`: Class library project compiled into `BusinessLayer.dll`.

## What to Notice in the Code
- **Stored Procedure Abstraction**: Translates stored procedures (`spGetAllEmployees`, `spInsertEmployeeDetails`, `spUpdateEmployee`, `spDeleteEmployee`) into strongly-typed C# domain operations.
- **Hydration via SqlDataReader**: Transforms relational result sets directly into `List<Employee>` collections.
- **Shared Validation Rules**: DataAnnotations defined on `Employee` drive both client-side and server-side validation in consuming web applications.
- **Configuration Decoupling**: Reads `ConfigurationManager.ConnectionStrings["DBCS"]` at runtime from the consuming application's `Web.config`.

## Known Limitations
- **Lacks Interface Abstraction**: `EmployeeBusinessLayer` is a concrete class without an interface (e.g. `IEmployeeBusinessLayer`), limiting mockability in unit tests.
- **Database Engine Coupling**: Bound to SQL Server stored procedures rather than a database-agnostic repository.
