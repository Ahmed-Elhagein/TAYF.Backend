# TAYF.Backend — Web API

> This file describes the existing TAYF.Backend solution. It is generated based on the actual repository state.

## Project Context

TAYF.Backend is a .NET 8 Web API solution with a layered structure:
- **TAYF.Domain** – Contains domain entities, enums, and interfaces (no dependencies on other projects).
- **TAYF.Application** – Contains application services, DTOs, validators, and interfaces. It depends on TAYF.Domain and TAYF.Infrastructure (for the EF Core DbContext).
- **TAYF.Infrastructure** – Contains the EF Core DbContext (`TayfDbContext`), migrations, and seed data. It depends only on TAYF.Domain.
- **TAYF.API** – ASP.NET Core API project with controllers, routing, and service registration. It depends on TAYF.Application, TAYF.Infrastructure, and TAYF.Domain.
- **TAYF.TelemetrySimulator** – A standalone console worker that simulates telemetry data and sends it to the API. It depends on TAYF.Application, TAYF.Domain, and TAYF.Infrastructure.

The solution follows a traditional layered architecture where the Application layer depends on Infrastructure for persistence (via the concrete `TayfDbContext`). This is a common pragmatic approach, though it deviates from strict Clean Architecture (which would abstract the persistence layer behind interfaces in Application).

## Tech Stack

- **.NET 8** / C# 12
- **ASP.NET Core Controllers** – Uses `[ApiController]` and attribute routing (`[Route]`, `[HttpGet]`, etc.).
- **Entity Framework Core** – EF Core 8 with SQL Server provider (`Microsoft.EntityFrameworkCore.SqlServer`).
- **FluentValidation** – Used for request validation (e.g., `TelemetryDtoValidator`).
- **Caching** – `Microsoft.Extensions.Caching.Memory` registered (currently not used in code).
- **Logging** – Built-in ASP.NET Core logging (no Serilog).
- **Dependency Injection** – Core ASP.NET Core DI container.
- **No authentication/authorization configured** – `app.UseAuthorization()` is present but no authentication scheme is added; controllers do not have `[Authorize]` attributes.
- **Testing** – No test projects present in the solution.

## Architecture

### Layered (Pragmatic) Architecture

```
TAYF.Backend/
├── TAYF.Domain.csproj          # Domain layer
├── TAYF.Application.csproj     # Application layer (references Domain + Infrastructure)
├── TAYF.Infrastructure.csproj  # Infrastructure layer (references Domain)
├── TAYF.API.csproj             # API layer (references Application, Infrastructure, Domain)
└── TAYF.TelemetrySimulator.csproj # Worker (references Application, Infrastructure, Domain)
```

**Key points:**
- Domain layer has no dependencies on other layers.
- Application layer depends on Domain and Infrastructure (for EF Core DbContext).
- Infrastructure layer depends only on Domain.
- API layer depends on Application, Infrastructure, and Domain (to wire up services and controllers).
- The TelemetrySimulator is a separate worker that reuses application services and infrastructure.

## Coding Standards

- **C# 12 features** — Use primary constructors (where applicable), collection expressions, etc.
- **File-scoped namespaces** — Consistently used across the codebase.
- **`var` for obvious types** — Use explicit types when the type isn't clear from context.
- **Naming** — PascalCase for public members, `_camelCase` for private fields, async methods suffixed with `Async`.
- **No regions** — Avoid.
- **Prefer async/await** — Avoid blocking calls like `.Result` or `.Wait()` (current code contains violations that should be fixed).

## Skills

Load these dotnet-claude-kit skills for context (based on what is actually present or recommended):

- `modern-csharp` — C# 12 language features and idioms.
- `ef-core` — DbContext patterns, query optimization, migrations.
- `validation` — FluentValidation usage (covers request validation).
- `configuration` — Options pattern, connection strings, appsettings.
- `dependency-injection` — Service registration in `Program.cs`.
- `logging` — Built-in logging (consider adding Serilog for structured logging).
- `workflow-mastery` — Parallel worktrees, verification loops, subagent patterns.
- `instinct-system` — Capture corrections and discoveries.
- `wrap-up` — Structured session handoff.

## MCP Tools

> **Setup:** Install once globally with `dotnet tool install -g CWM.RoslynNavigator` and register with `claude mcp add --scope user cwm-roslyn-navigator -- cwm-roslyn-navigator --solution ${workspaceFolder}`. After that, these tools are available in every .NET project.

Use `cwm-roslyn-navigator` tools to minimize token consumption:
- **Before modifying a type** — Use `find_symbol` to locate it, `get_public_api` to understand its surface.
- **Before adding a reference** — Use `find_references` to understand existing usage.
- **To understand architecture** — Use `get_project_graph` to see project dependencies.
- **To find implementations** — Use `find_implementations` instead of grep for interface/abstract class implementations.
- **To check for errors** — Use `get_diagnostics` after changes.

## Commands

```bash
# Build the solution
dotnet build

# Run the API (development)
dotnet run --project TAYF.API

# Run the telemetry simulator
dotnet run --project TAYF.TelemetrySimulator

# Add EF migration (migrations live in TAYF.Infrastructure)
dotnet ef migrations add [Name] --project TAYF.Infrastructure

# Apply migrations
dotnet ef database update --project TAYF.Infrastructure

# Format check
dotnet format --verify-no-changes
```

## Workflow

- **Plan first** — Enter plan mode for any non-trivial task (3+ steps or architecture decisions). Iterate until the plan is solid before writing code.
- **Verify before done** — Run `dotnet build` after changes. Use `get_diagnostics` via MCP to catch warnings and errors. Ask: "Would a staff engineer approve this?"
- **Fix bugs autonomously** — When given a bug report, investigate and fix it without hand-holding. Check logs, errors, failing tests (if any) — then resolve them.
- **Stop and re-plan** — If implementation goes sideways, STOP and re-plan. Don't push through a broken approach.
- **Use subagents** — Offload research, exploration, and parallel analysis to subagents. One task per subagent for focused execution.
- **Learn from corrections** — After any correction, capture the pattern in memory so the same mistake never recurs.

## Anti-patterns

Do NOT generate code that:

- Defines endpoints in Program.cs — use controllers with `[ApiController]` and attribute routing.
- Uses `DateTime.Now` or `DateTime.UtcNow` — inject `TimeProvider` and use `TimeProvider.GetUtcNow()`.
- Creates `new HttpClient()` — use `IHttpClientFactory` via DI.
- Uses `async void` — always return `Task`.
- Blocks with `.Result` or `.Wait()` — await instead.
- Uses `Results.Ok()` — use `TypedResults.Ok()` only if switching to Minimal APIs; otherwise return controller methods like `Ok()`.
- Returns domain entities from endpoints — always map to response DTOs (current code has one violation: `PlantsController.GetPlant` returns `Plant` entity directly).
- Creates repository abstractions over EF Core — if you abstract, do it via interfaces in Application and implement in Infrastructure; otherwise use `DbContext` directly (current approach uses `DbContext` directly in Application services).
- Uses in-memory database for tests — use Testcontainers if you add tests.
- Catches bare `Exception` — catch specific exception types, let the global handler catch the rest.
- Uses string interpolation in log messages — use structured logging templates (if adopting Serilog).