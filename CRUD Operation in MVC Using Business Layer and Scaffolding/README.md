# Project 4: CRUD Operation in MVC Using Business Layer and Scaffolding

## Purpose
Demonstrates an **N-Tier Layered Architecture** in **ASP.NET MVC 5 (.NET Framework 4.8)** where the web application contains no database commands, delegating all operations to a compiled `BusinessLayer.dll`.

## Key Files
- `Controllers/EmployeeController.cs`: Thin MVC controller delegating CRUD operations to `EmployeeBusinessLayer`.
- `Views/Employee/Index.cshtml`: Strongly-typed view displaying employees with inline POST deletion forms.
- `Views/Employee/Create.cshtml` & `Edit.cshtml`: Form views leveraging automatic model binding and DataAnnotation validation.
- `Web.config`: Defines the `DBCS` connection string required by the referenced `BusinessLayer`.
- `.csproj`: Contains the `<ProjectReference>` linking to `../BusinessLayer/BusinessLayer.csproj`.

## What to Notice in the Code
- **Separation of Concerns**: The controller has zero references to `System.Data` or SQL syntax; it interacts solely with domain POCOs and business services.
- **Secure State Changes**: The `Delete` action requires an HTTP POST with `[ValidateAntiForgeryToken]` and client-side confirmation, preventing accidental or CSRF-driven deletions.
- **Centralized Validation**: `ModelState.IsValid` verifies fields based on rules defined in the shared `BusinessLayer.Employee` class.

## Known Limitations
- **Direct Instantiation**: The controller manually constructs `new EmployeeBusinessLayer()`, violating the Inversion of Control (IoC) principle.
- **Synchronous Execution**: Database calls are synchronous, blocking web server request threads under high concurrency.
