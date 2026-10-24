# Solution Changes & Preparation Summary

This document records all changes, refactorings, security fixes, configuration sanitizations, and documentation additions made to prepare the **"MVC Practice"** solution for public GitHub release on the `github-ready` branch.

---

## 📋 Phase-by-Phase Change Log

### **Phase 1 — Repo Hygiene**
- **Changes**:
  - Created a comprehensive .NET `.gitignore` with explicit exclusions for Visual Studio cache (`.vs/`), build outputs (`[Bb]in/`, `[Oo]bj/`), NuGet package downloads (`packages/`, `**/packages/`), and user preferences (`*.user`, `*.suo`).
  - Added open-source `LICENSE` file (MIT License, Author: *Rajat Pandya*).
  - Ensured all binaries and user configuration artifacts remained untracked.
- **Build Verification**:
  - `dotnet build`: Both .NET 8 projects succeeded with 0 errors and 0 warnings.
  - `MSBuild.exe`: `BusinessLayer` succeeded with 0 errors and 0 warnings.
- **Commit**: `40b963a` — *Phase 1: Repo hygiene - Add .gitignore and LICENSE (MIT), untrack build artifacts*

---

### **Phase 2 — Structure and Naming**
- **Changes**:
  - **Typo Fix**: Renamed folder `CRUD Opertation in MVC Using Business Layer and Scaffolding` to `CRUD Operation in MVC Using Business Layer and Scaffolding` and renamed its project file to `CRUD Operation in MVC Using Business Layer and Scaffolding.csproj` using `git mv` (preserving history). Maintained `<RootNamespace>` intact to satisfy preservation rules.
  - **Controller Organization**: Moved `CustomerController.cs` from `Models/` into `Controllers/` in `CRUD Operations In ASP.NET Core Using Entity Framework Core Code First` using `git mv`. Updated its namespace to `...Controllers` and added `using ...Models;` to properly resolve `CustomerViewModel`.
  - **SQL Scripts Restructuring**: Moved all SQL scripts from `Solution Items` into `/database` using `git mv` and renamed them in logical run order:
    1. `01_Employee_and_StoredProcedures.sql`
    2. `02_tblStudent.sql`
    3. `03_Emp.sql`
    4. `04_Products.sql`
    Added clear header comments to each script declaring database targets and consuming projects.
  - **Solution File**: Updated `MVC Practice.slnx` with the new folder paths and project references.
  - **Architecture Documentation**: Moved `context.md` to `docs/ARCHITECTURE.md` using `git mv`. Fixed GitHub Mermaid diagram syntax errors (removed stray `subframeCORE` line and fixed the `-->` inside the edge label).
- **Build Verification**:
  - `dotnet build`: Both .NET 8 projects succeeded with 0 errors and 0 warnings.
  - `MSBuild.exe`: All 4 .NET Framework 4.8 projects succeeded with 0 errors and 0 warnings.
- **Commit**: `ebc56bf` — *Phase 2: Structure and naming - Fix project naming typo, move CustomerController to Controllers, organize SQL scripts into database folder, and update architecture docs*

---

### **Phase 3 — Small Fixes**
Each bug fix was committed individually to keep git history modular:

1. **Fix `spInsertEmployeeDetails` Parameter Insertion**:
   - Replaced empty string literals (`N''`) in `database/01_Employee_and_StoredProcedures.sql` with the passed stored procedure parameters: `@EmployeeName`, `@EmployeeGender`, and `@EmployeeDesignation`.
   - **Commit**: `2d79342` — *Fix spInsertEmployeeDetails stored procedure to insert parameters*

2. **Parameterize Project 2 `GetStudentByID`**:
   - Replaced raw string concatenation (`"Select * from tblStudent where student_id=" + intStudentID`) in `CRUDModel.cs` with parameterized SQL (`@student_id`) to prevent SQL injection vulnerabilities.
   - **Commit**: `5ce9f23` — *Parameterize SQL query in Project 2 GetStudentByID*

3. **Read Connection String from `Web.config` in Project 2**:
   - Added `<connectionStrings>` with `name="DBCS"` to `CRUD Operation in ASP.NET MVC Using ADO.NET/Web.config`.
   - Updated `CRUDModel.cs` to dynamically read `ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString` rather than hard-coding connection strings in method bodies.
   - **Commit**: `d9e8c12` — *Make Project 2 read connection string from Web.config instead of hard-coding it*

4. **Project 4 Delete POST Action with Anti-Forgery Token**:
   - Converted the unsafe HTTP GET `Delete` in `EmployeeController.cs` into an `[HttpPost]` action protected with `[ValidateAntiForgeryToken]`.
   - Updated `Index.cshtml` to submit deletion requests via an inline POST form containing `@Html.AntiForgeryToken()` and a client-side JavaScript confirmation prompt.
   - **Commit**: `f0a02d4` — *Make Delete a POST action with ValidateAntiForgeryToken in Project 4*

5. **Remove Duplicate Connection String in Project 1**:
   - Removed the obsolete, unused `ADO_CRUD_MVCEntities` connection string from `MVC CRUD Operations Using Entity Framework/Web.config`, preserving the active `ADO_CRUD_MVCEntities1` string.
   - **Commit**: `ba32937` — *Remove duplicate connection string in Project 1*

---

### **Phase 4 — Sanitize Configuration**
- **Changes**:
  - Replaced machine-specific server name `RAJAT\SQLEXPRESS06` with `.\SQLEXPRESS06` across all configuration files:
    - `ASP.NET Core Web App MVC/appsettings.json`
    - `CRUD Operations In ASP.NET Core Using Entity Framework Core Code First/appsettings.json`
    - `CRUD Operation in ASP.NET MVC Using ADO.NET/Web.config`
    - `CRUD Operation in MVC Using Business Layer and Scaffolding/Web.config`
    - `CRUD Operation in MVC Using Business Layer and Scaffolding/Views/web.config`
    - `MVC CRUD Operations Using Entity Framework/Web.config`
  - Preserved the instance name `SQLEXPRESS06`, `Integrated Security=True`, and `TrustServerCertificate=True`.
- **Build Verification**:
  - `dotnet build`: Both .NET 8 projects succeeded (0 errors, 0 warnings).
  - `MSBuild.exe`: All 4 .NET Framework 4.8 projects succeeded (0 errors, 0 warnings).
- **Commit**: `ecc4031` — *Phase 4: Sanitize configuration - Replace server name RAJAT\SQLEXPRESS06 with .\SQLEXPRESS06*

---

### **Phase 5 — Documentation**
- **Changes**:
  - **Root `README.md`**: Created a comprehensive portfolio guide featuring:
    - Executive summary paragraph.
    - Projects overview table detailing framework, data-access strategy, and key educational takeaways.
    - Mermaid architecture diagram illustrating request lifecycles and database connections.
    - System prerequisites (.NET 8 SDK, .NET Framework 4.8 Targeting Pack, VS 2022, SQL Server).
    - Database configuration instructions detailing how to adapt `.\SQLEXPRESS06` if local instances differ.
    - A structured "Learning Path" guiding readers through the conceptual progression of patterns.
  - **Project-Level `README.md` Files**: Added a focused `README.md` in each of the 6 project folders detailing:
    - Purpose
    - Key files
    - What to notice in the code
    - Known limitations
- **Build Verification**:
  - All 6 projects verified with `dotnet build` and `MSBuild.exe` (0 errors, 0 warnings).
- **Commit**: `30e9d9a` — *Phase 5: Documentation - Add root README with architecture overview, learning path, and project-level READMEs*

---

## 🔍 Verification & Observations

- **Build Verification**:
  - All 6 projects compile cleanly with 0 errors and 0 warnings using:
    - `dotnet build` (for .NET 8 Core projects)
    - `MSBuild.exe` v18.11 (for .NET Framework 4.8 projects)
- **Git History Integrity**:
  - All moves and renames were executed with `git mv`, preserving complete revision history.
- **Static vs Live Testing**:
  - Static analysis, compile-time type checking, and SQL script structure were verified.
  - Live HTTP requests against active database instances were not executed as the preparation environment does not run an active local SQL Server daemon.

---

## ⚠️ Educational Quirks & Known Architectural Trade-offs

1. **Project 2 (Raw ADO.NET)**:
   - Views still iterate over untyped `DataTable` rows (`@row["student_name"]`) and lack CSRF token protection on create/update operations. This is intentionally retained as the historical "naïve" baseline.
2. **Project 4 (Layered MVC 5)**:
   - `EmployeeController` constructs `new EmployeeBusinessLayer()` manually rather than using Dependency Injection, illustrating pre-DI N-tier architecture.
3. **Project 6 (ASP.NET Core Web App MVC)**:
   - Implements read operations (`Index` and `Details`); write actions (`Create`, `Edit`, `Delete`) can be added by implementing corresponding methods on `IProductService`.
4. **SQL Instance Mapping**:
   - Connection strings default to `.\SQLEXPRESS06`. Developers using default `.\SQLEXPRESS` or LocalDB `(localdb)\mssqllocaldb` can adjust connection strings as described in the root `README.md`.
