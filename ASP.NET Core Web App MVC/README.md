# Project 6: ASP.NET Core Web App MVC

## Purpose
Exemplifies enterprise-grade **Clean Architecture** and the **Dependency Inversion Principle (DIP)** in **.NET 8 ASP.NET Core MVC** using interface abstractions, service layers, and Dependency Injection.

## Key Files
- `Models/IProductService.cs`: Interface contract defining data operations (`GetAllProducts`, `GetProductById`).
- `Models/DbProductService.cs`: Production EF Core implementation of `IProductService`.
- `Models/ProductService.cs`: Alternative in-memory implementation showcasing implementation swappability.
- `Models/AppDbContext.cs`: EF Core `DbContext` mapping the `Products` table with Fluent API precision configuration.
- `Controllers/ProductController.cs`: Clean controller depending exclusively on the `IProductService` abstraction.
- `Program.cs`: Configures the DI container (`builder.Services.AddScoped<IProductService, DbProductService>()`).

## What to Notice in the Code
- **Dependency Inversion**: `ProductController` has no knowledge of `AppDbContext` or SQL Server. It relies entirely on `IProductService`.
- **High Testability**: Decoupled interface architecture allows effortless unit testing and mocking without spun-up database instances.
- **Fluent Precision Configuration**: Explicitly maps monetary precision via `modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);` to ensure monetary integrity.
- **Zero-Friction Provider Swapping**: Switching from EF Core to in-memory caching or an external microservice requires editing only a single line in `Program.cs`.

## Known Limitations
- **Read-Focused Actions**: The controller currently features `Index` and `Details` actions; create, update, and delete actions follow the same service pattern when extended.
