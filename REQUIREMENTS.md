# Personal Expense Tracker — Requirements Document

## 1. Project Overview

A full-stack web application that lets a user track personal expenses, categorize spending, set budgets, and view reports — built to demonstrate Clean Architecture, secure API design, and a connected Angular frontend.

**Tech stack:** ASP.NET Core Web API (C#), Angular, PostgreSQL, EF Core + Dapper, JWT Auth

---

## 2. Functional Requirements

### 2.1 Authentication & User Management
| ID | Requirement |
|---|---|
| FR-1 | User can register with email + password |
| FR-2 | Password stored using a secure hash (BCrypt/Argon2, never plain text or reversible encryption) |
| FR-3 | User can log in and receive a JWT access token |
| FR-4 | Refresh token support (stretch — improves security realism) |
| FR-5 | User can log out (client-side token clear + optional token blacklist) |

### 2.2 Categories
| ID | Requirement |
|---|---|
| FR-6 | System provides default categories (Food, Transport, Bills, Shopping, Health, Entertainment, Other) |
| FR-7 | User can create custom categories |
| FR-8 | User can edit/delete their own custom categories (not defaults) |
| FR-9 | Deleting a category with existing expenses must be handled explicitly (block delete, or reassign to "Other" — decide and document your choice) |

### 2.3 Expenses
| ID | Requirement |
|---|---|
| FR-10 | User can add an expense: amount, category, date, payment method, optional note |
| FR-11 | User can edit an existing expense |
| FR-12 | User can delete an expense (soft delete recommended — keeps report history accurate) |
| FR-13 | User can view a paginated, filterable list of expenses (by date range, category, payment method) |
| FR-14 | User can search expenses by note/keyword |
| FR-15 | Amount must be > 0; validated both client and server side |

### 2.4 Budgets
| ID | Requirement |
|---|---|
| FR-16 | User can set a monthly budget limit per category |
| FR-17 | System calculates % of budget used in real time |
| FR-18 | System flags/warns when a category is over budget |
| FR-19 | User can view all budgets vs. actual spend in one place |

### 2.5 Reports & Dashboard
| ID | Requirement |
|---|---|
| FR-20 | Dashboard shows current month's total spend |
| FR-21 | Category-wise breakdown (pie/donut chart) |
| FR-22 | Month-over-month spend trend (line/bar chart) |
| FR-23 | Top 5 expense categories for the selected period |
| FR-24 | Date range filter for all reports (this month, last 3 months, custom range) |

### 2.6 Export (stretch)
| ID | Requirement |
|---|---|
| FR-25 | Export expenses to CSV for a given date range |

---

## 3. Non-Functional Requirements

| Category | Requirement |
|---|---|
| **Security** | JWT auth on all endpoints except register/login; all queries filtered by `UserId` (no cross-user data leakage); HTTPS enforced; CORS restricted to frontend origin only |
| **Performance** | Expense list endpoint paginated (never return unbounded results); indexed queries on `(UserId, Date)` |
| **Validation** | Server-side validation via FluentValidation — never trust client-side validation alone |
| **Data integrity** | Monetary values as `decimal`, never `float`/`double` |
| **Usability** | Responsive UI (usable on mobile) |
| **Maintainability** | Clean Architecture layering; DTOs for all API boundaries (never expose EF entities) |
| **Testability** | Unit tests on business logic (budget calculations, validation rules); integration tests on key API endpoints; Playwright E2E tests on critical user flows |
| **Documentation** | Swagger/OpenAPI for the API; README with setup instructions and architecture diagram |
| **Deployment** | Containerized with Docker; deployed to a live URL (Azure App Service / Render) |

---

## 4. Domain Model (Entities)

```
User
 ├─ Id, Email, PasswordHash, CreatedAt

Category
 ├─ Id, UserId (nullable = default category), Name, IsDefault

Expense
 ├─ Id, UserId, CategoryId, Amount (decimal), Date, PaymentMethod, Note, IsDeleted, CreatedAt

Budget
 ├─ Id, UserId, CategoryId, MonthlyLimit, EffectiveMonth
```

---

## 5. API Endpoints (v1)

```
POST   /api/auth/register
POST   /api/auth/login
POST   /api/auth/refresh

GET    /api/categories
POST   /api/categories
PUT    /api/categories/{id}
DELETE /api/categories/{id}

GET    /api/expenses?page=&pageSize=&categoryId=&from=&to=
POST   /api/expenses
PUT    /api/expenses/{id}
DELETE /api/expenses/{id}

GET    /api/budgets
POST   /api/budgets
PUT    /api/budgets/{id}

GET    /api/reports/summary?month=
GET    /api/reports/category-breakdown?from=&to=
GET    /api/reports/trend?months=6

GET    /api/expenses/export?from=&to=  (CSV)
```

Every non-auth endpoint requires `Authorization: Bearer <token>` and must resolve `UserId` from the JWT claims — never from a request parameter.

---

## 6. Out of Scope for v1

- Multi-currency support
- Recurring/scheduled expenses
- Receipt image upload/OCR
- Shared/family expense tracking
- Mobile app (native)

---

## 7. Architecture

```
ExpenseTracker.Domain        → Entities, enums, domain logic (no dependencies)
ExpenseTracker.Application   → Use cases, DTOs, interfaces (IExpenseRepository, etc.)
ExpenseTracker.Infrastructure→ EF Core / Dapper implementations, PostgreSQL
ExpenseTracker.Api           → Controllers, middleware, auth, DI wiring
ExpenseTracker.Tests         → Unit + integration tests

/frontend                    → Angular app
```

**Design decision:** EF Core for writes (Command side), Dapper for reads (Query side — reports especially). Lightweight CQRS-flavored approach — EF Core for transactional integrity, Dapper for performance on read-heavy reporting queries.

**Key pitfalls to avoid:**
- Business logic in controllers instead of the Application layer
- Returning EF entities directly from API responses — always map to DTOs
- Storing money as `float`/`double` — use `decimal`
- Missing `UserId` filtering on queries — security hole
- JWT stored in localStorage — vulnerable to XSS; use memory or httpOnly cookie
