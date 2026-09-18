# Personal Expense Tracker — Day-by-Day Progress

> Check off each day. If a day runs over, don't skip ahead — finish it before moving on. Adjust dates to your actual calendar.

---

## Week 1 — Foundation + Auth Backend

- [ ] **Day 1:** Create solution, set up Clean Architecture folders (Domain, Application, Infrastructure, Api)
- [ ] **Day 2:** Configure PostgreSQL connection, first EF Core migration
- [ ] **Day 3:** `User` entity, register endpoint, password hashing (BCrypt)
- [ ] **Day 4:** Login endpoint, JWT generation
- [ ] **Day 5:** Test full auth flow in Swagger (register → login → protected endpoint)
- [ ] **Weekend:** (Stretch) Refresh token support; write 2–3 unit tests for auth logic

✅ **Checkpoint:** Register, log in, and hit a `[Authorize]` endpoint with a valid token.

---

## Week 2 — Categories + Expenses Backend

- [ ] **Day 1:** `Category` entity + repository interface + EF implementation, seed default categories
- [ ] **Day 2:** Category CRUD endpoints + FluentValidation
- [ ] **Day 3:** `Expense` entity, start CRUD endpoints
- [ ] **Day 4:** Finish Expense CRUD, DTOs for all endpoints (no EF entities exposed)
- [ ] **Day 5:** Pagination + filtering on `GET /expenses` (date range, category)
- [ ] **Weekend:** Integration tests for expense endpoints; verify `UserId` comes from JWT claims everywhere, not query params

✅ **Checkpoint:** Create categories and expenses, list them filtered/paginated, all user-scoped.

---

## Week 3 — Budgets + Reports (Backend)

- [ ] **Day 1:** `Budget` entity + CRUD
- [ ] **Day 2:** Budget-vs-actual calculation logic + unit tests
- [ ] **Day 3:** Reports endpoint: monthly summary (Dapper)
- [ ] **Day 4:** Reports endpoint: category breakdown (Dapper)
- [ ] **Day 5:** Reports endpoint: trend over N months (Dapper); (stretch) CSV export
- [ ] **Weekend:** Swagger docs/annotations, global exception handling middleware, full backend consistency review

✅ **Checkpoint:** Backend is functionally complete — everything works via Swagger/Postman.

---

## Week 4 — Angular: Auth + Shell

- [ ] **Day 1:** Angular project setup, routing, basic layout/nav
- [ ] **Day 2:** Login page (reactive form)
- [ ] **Day 3:** Register page (reactive form), API service layer
- [ ] **Day 4:** HTTP interceptor to attach JWT, route guards for protected pages
- [ ] **Day 5:** Store token in memory (not localStorage), handle 401 → redirect to login
- [ ] **Weekend:** Polish auth UX (error messages, loading states)

✅ **Checkpoint:** Register/login through the Angular UI, land on a protected dashboard shell.

---

## Week 5 — Angular: Core Features

- [ ] **Day 1:** Category list UI
- [ ] **Day 2:** Category add/edit UI
- [ ] **Day 3:** Expense list (paginated, filterable)
- [ ] **Day 4:** Expense add/edit form
- [ ] **Day 5:** Expense delete with confirmation
- [ ] **Weekend:** Budget setup UI, budget-vs-actual indicator (progress bar / color-coded)

✅ **Checkpoint:** Fully manage categories, expenses, and budgets through the UI — no Swagger/Postman needed.

---

## Week 6 — Dashboard, Testing, Deployment

- [ ] **Day 1:** Dashboard: total spend for current month
- [ ] **Day 2:** Dashboard: category breakdown pie/donut chart
- [ ] **Day 3:** Dashboard: spend trend chart
- [ ] **Day 4:** Playwright E2E test (register → login → add expense → see it on dashboard); Dockerize backend
- [ ] **Day 5:** docker-compose with PostgreSQL, deploy backend (Azure App Service / Render), deploy frontend, fix CORS/env issues
- [ ] **Weekend:** Write README (architecture diagram, setup steps, screenshots/GIF), final polish pass

✅ **Checkpoint:** Live demo link, working repo, README that explains architecture decisions.

---

## Daily Log

> One line per day: what you did, what blocked you, what to pick up tomorrow.

| Date | Day | What I did | Blockers / Notes |
|---|---|---|---|
| | | | |
| | | | |
| | | | |
| | | | |
| | | | |
