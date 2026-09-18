# Expense Tracker

A full-stack personal expense tracking application built with ASP.NET Core (Clean Architecture) and Angular, using PostgreSQL, EF Core, and Dapper.

## Status
🚧 In active development. See [DAILY_PROGRESS.md](./DAILY_PROGRESS.md) for current progress.

## Tech Stack

**Backend**
- ASP.NET Core Web API (.NET 8)
- Clean Architecture (Domain / Application / Infrastructure / Api)
- PostgreSQL
- EF Core (writes) + Dapper (reporting queries)
- JWT Authentication
- FluentValidation

**Frontend**
- Angular
- Chart.js / ngx-charts (reporting)

**Testing**
- xUnit (unit + integration tests)
- Playwright (.NET) for E2E tests

## Project Structure

\```
ExpenseTracker.Domain          → Entities, enums, domain logic (no external dependencies)
ExpenseTracker.Application     → Use cases, DTOs, interfaces
ExpenseTracker.Infrastructure  → EF Core / Dapper implementations, PostgreSQL
ExpenseTracker.Api             → Controllers, middleware, auth, DI wiring
ExpenseTracker.Tests           → Unit + integration tests
frontend/                      → Angular app (added in Week 4)
\```

## Architecture Decisions

- **CQRS-flavored read/write split**: EF Core handles writes (transactional integrity), Dapper handles reads for reporting (performance on aggregation queries).
- **Feature-based organization** inside `Application` — code is grouped by feature (Auth, Expenses, Categories, Budgets), not by technical type.
- **DTOs at every API boundary** — EF entities are never returned directly from controllers.
- **Soft delete** on expenses — preserves historical report accuracy.

## Getting Started

> Setup instructions will be added once the backend is runnable (Week 1).

## Requirements & Planning

- [REQUIREMENTS.md](./REQUIREMENTS.md) — full functional & non-functional requirements
- [DAILY_PROGRESS.md](./DAILY_PROGRESS.md) — day-by-day build log

## License

Personal portfolio project.
