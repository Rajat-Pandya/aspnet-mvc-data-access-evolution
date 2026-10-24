# Project 5: CRUD Operations In ASP.NET Core Using Entity Framework Core Code First

## Purpose
Demonstrates modern **.NET 8 ASP.NET Core MVC** with **Entity Framework Core Code-First**, automated database migrations, audit trail inheritance, and Fluent API configurations.

## Key Files
- `DbEntities/BaseEntity.cs`: Abstract base class encapsulating enterprise audit properties (`Id`, `AddedDate`, `ModifiedDate`, `IPAddress`).
- `DbEntities/Customer.cs`: Domain entity inheriting from `BaseEntity`.
- `DbEntities/CustomerMap.cs`: Fluent API mapping enforcing primary keys and required constraints via `IEntityTypeConfiguration`.
- `DbEntities/CRUDContext.cs`: EF Core `DbContext` configuring database options and entity maps.
- `Controllers/CustomerController.cs`: Controller implementing CRUD actions with injected `CRUDContext`.
- `Models/CustomerViewModel.cs`: Dedicated View Model isolating the UI contract from database schemas.
- `Migrations/`: EF Core Code-First migration definitions targeting the `CRUDDb` database.
- `Program.cs`: .NET 8 top-level statements configuring services and request pipeline.

## What to Notice in the Code
- **Dependency Injection**: `CRUDContext` is registered via `builder.Services.AddDbContext<CRUDContext>` and injected into the controller constructor.
- **Automated Audit Tracking**: Captures client remote IP addresses (`HttpContext.Connection.RemoteIpAddress`) and UTC timestamps on create/update operations.
- **Unified Add/Edit Workflow**: Single action pair (`AddEditCustomer`) seamlessly handles both inserts (`id == null`) and updates (`id != null`).
- **Separation of Concerns via ViewModels**: Domain entity `Customer` is transformed to and from `CustomerViewModel`, preventing overposting attacks.

## Known Limitations
- **DbContext in Controller**: While injected via DI, the controller still queries the DbContext directly without an intermediate service layer.
- **Manual Mapping**: Relies on manual LINQ projection rather than automated mapping profiles.
