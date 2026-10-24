# Project 2: CRUD Operation in ASP.NET MVC Using ADO.NET

## Purpose
Serves as an architectural baseline demonstrating **raw, low-level ADO.NET** data access within an **ASP.NET MVC 5 (.NET Framework 4.8)** application without an ORM.

## Key Files
- `Models/CRUDModel.cs`: Data-access class executing imperative ADO.NET SQL commands via `SqlConnection`, `SqlCommand`, and `SqlDataAdapter`.
- `Controllers/CRUDController.cs`: MVC controller coordinating input/output with the view and data access layer.
- `Views/CRUD/Home.cshtml`: Primary listing view that directly traverses an untyped `DataTable`.
- `Web.config`: Configures the `DBCS` connection string read via `ConfigurationManager`.

## What to Notice in the Code
- **Direct ADO.NET Lifecycle**: Connections and commands are scoped with `using` blocks to ensure prompt disposal.
- **Parameterized SQL**: Queries in `InsertStudent`, `UpdateStudent`, `DeleteStudent`, and `GetStudentByID` use parameters (`@studid`, `@student_id`) to prevent SQL injection.
- **Config-Driven Connection**: Database connectivity is retrieved centrally from `ConfigurationManager.ConnectionStrings["DBCS"]`.

## Known Limitations
- **Untyped Data in Views**: Consuming `DataTable` in views forfeits compile-time safety, refactoring support, and Razor IntelliSense.
- **Manual Form Parsing**: Controller reads raw request data from `FormCollection` rather than relying on automatic model binding.
- **Missing Anti-Forgery Tokens**: POST actions do not enforce CSRF validation (`[ValidateAntiForgeryToken]`).
