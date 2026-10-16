# .NET Version Upgrade Plan

## Overview

**Target**: Upgrade InstructorIQ.sln from net8.0 to net10.0 (LTS)
**Scope**: Small solution — 3 SDK-style projects (Core library, ASP.NET Core web app, xUnit tests), ~44k LOC

### Selected Strategy
**All-At-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: 3 projects, all on .NET 8, shallow dependency chain (Core → WebApplication / Core.Tests).

**Projects**:
- Libraries: `src\InstructorIQ.Core`
- Applications: `src\InstructorIQ.WebApplication`
- Tests: `test\InstructorIQ.Core.Tests`

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | All-at-Once | 3 SDK-style projects on net8.0 → net10.0 with a shallow dependency chain; a single pass is fastest. |
| Package Management | Per-Project | Only 3 projects with no version conflicts; CPM overhead not justified now. |
| Unsupported API Handling | Fix Inline | The 17 flagged API changes are minor (overload ambiguities, obsolete accessors) and mechanical. |
| Nullable Reference Types | Leave Disabled | ~44k LOC; enabling during the upgrade would add a large volume of warnings. |

## Tasks

### 01-prerequisites: Verify .NET 10 SDK and update CI toolchain

Confirm the .NET 10 SDK is installed and that no `global.json` pins an older SDK. The repository has no `global.json`, so the main toolchain change is the GitHub Actions build workflow (`.github\workflows\dotnet.yml`), which currently installs `dotnet-version: 8.0.x` and would fail to build net10.0 projects.

**Done when**: .NET 10 SDK is confirmed available locally, and the CI workflow installs the .NET 10 SDK.

---

### 02-upgrade-solution: Upgrade all projects to net10.0, update packages, and fix breaking changes

Retarget `InstructorIQ.Core`, `InstructorIQ.WebApplication`, and `InstructorIQ.Core.Tests` from `net8.0` to `net10.0` together. Update the packages the assessment flags for upgrade: `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (8.0.32 → 10.0.x), `Microsoft.EntityFrameworkCore.SqlServer` (9.0.21 → 10.0.x), and `Microsoft.VisualStudio.Web.CodeGeneration.Design` (9.0.0 → 10.0.x). Deprecated packages (`FluentValidation.AspNetCore`, `MediatR.CommandQuery.Audit`/`.EntityFrameworkCore`, `xunit` v2) remain compatible and are not replaced in this upgrade.

Fix the API issues the assessment reports: 1 binary-incompatible (`ServiceCollectionExtensions` in Core), 16 source-incompatible (`TimeSpan.FromDays/FromHours/FromMinutes/FromSeconds` overload ambiguity with new integer overloads, obsolete `IActionContextAccessor`/`ActionContextAccessor`, `AddEntityFrameworkStores` from Identity EF), and review 11 behavioral changes (`Uri` construction/`PathAndQuery`, `JsonDocument`, `UseExceptionHandler(string)`). The out-of-solution `src\InstructorIQ.JobRunner` project (net6.0) is not part of the solution and is out of scope.

Research starting points: query the assessment per file for exact locations; check the EF Core 10 / ASP.NET Core 10 breaking-change notes for Identity and EF stores; ensure all build warnings in modified projects are resolved.

**Done when**: All three projects target net10.0, flagged packages are updated, the solution builds with 0 errors and 0 new warnings.

---

### 03-final-validation: Run tests and validate the upgraded solution

Run the full test suite in `InstructorIQ.Core.Tests` against the upgraded solution and fix any failures caused by the upgrade. Review behavioral-change areas flagged by the assessment for runtime impact. Note any deferred recommendations (e.g., replacing deprecated packages, moving to xunit v3, central package management, the stale JobRunner project).

**Done when**: Solution builds cleanly and all tests that passed before the upgrade still pass.
