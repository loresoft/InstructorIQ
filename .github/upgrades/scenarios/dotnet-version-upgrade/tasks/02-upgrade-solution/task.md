# 02-upgrade-solution: Upgrade all projects to net10.0, update packages, and fix breaking changes

Retarget `InstructorIQ.Core`, `InstructorIQ.WebApplication`, and `InstructorIQ.Core.Tests` from `net8.0` to `net10.0` together. Update the packages the assessment flags for upgrade: `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (8.0.32 → 10.0.x), `Microsoft.EntityFrameworkCore.SqlServer` (9.0.21 → 10.0.x), and `Microsoft.VisualStudio.Web.CodeGeneration.Design` (9.0.0 → 10.0.x). Deprecated packages (`FluentValidation.AspNetCore`, `MediatR.CommandQuery.Audit`/`.EntityFrameworkCore`, `xunit` v2) remain compatible and are not replaced in this upgrade.

Fix the API issues the assessment reports: 1 binary-incompatible (`ServiceCollectionExtensions` in Core), 16 source-incompatible (`TimeSpan.FromDays/FromHours/FromMinutes/FromSeconds` overload ambiguity with new integer overloads, obsolete `IActionContextAccessor`/`ActionContextAccessor`, `AddEntityFrameworkStores` from Identity EF), and review 11 behavioral changes (`Uri` construction/`PathAndQuery`, `JsonDocument`, `UseExceptionHandler(string)`). The out-of-solution `src\InstructorIQ.JobRunner` project (net6.0) is not part of the solution and is out of scope.

Research starting points: query the assessment per file for exact locations; check the EF Core 10 / ASP.NET Core 10 breaking-change notes for Identity and EF stores; ensure all build warnings in modified projects are resolved.

**Done when**: All three projects target net10.0, flagged packages are updated, the solution builds with 0 errors and 0 new warnings.

## Research Findings

### Pre-existing baseline break (net8.0, before any change)
- Core fails with 90 errors (CS8865, CS0534, CS0538, CS0246) in ~43 files. Cause: MediatR.CommandQuery 16.6.2 base types (`PrincipalQueryBase`, `PrincipalCommandBase`, `EntityModelCommand`, `CacheableQueryBase`, `EntityIdentifierQuery`, `EntityPagedQuery`, `EntitySelectQuery`) are now `record`s; `ICacheQueryResult` renamed to `ICacheResult` (adds `GetCacheTag()`).
- Decision (user): convert derived `class` declarations to `record` and switch `TenantSlugQuery` to `ICacheResult`.

### Project/package actions
- TFM net8.0 → net10.0: Core, WebApplication, Core.Tests csproj (line 3).
- Identity.EntityFrameworkCore 8.0.32 → 10.0.x; EF SqlServer 9.0.21 → 10.0.x (Core); CodeGeneration.Design 9.0.0 → 10.0.x (WebApplication).

### API locations
- `Core\Extensions\ServiceCollectionExtensions.cs` L11/15: `IActionContextAccessor`/`ActionContextAccessor` obsolete in ASP.NET Core 10.
- TimeSpan.FromX(int) ambiguity flags — SecurityOptions.cs:11, TenantSlugQuery.cs:29/34, SendUserInviteEmailCommandHandler.cs:111, Program.cs:51/75/277, EventController.cs:47 — expected to compile unchanged.
- Behavioral (review only): JsonDisplayTagHelper.cs:38 JsonDocument.Parse; LinkTokenCreateCommandHandler.cs:73 / UriExtensionsTests new Uri; Program.cs:236 UseExceptionHandler; AddEntityFrameworkStores (Program.cs:138, DependencyInjectionFixture.cs:33).

### Additional pre-existing package breaks discovered during execution
- FluentCommand: `SqlParameter(name, DataTable)` renamed to `ParameterStructured` (ImportProcessService.cs:112).
- Ical.Net 5: `CalDateTime.HasTime` read-only → use `new CalDateTime(dt, hasTime: true)` (EventController.cs:74/77).
- XUnit.Hosting 4.1.0 depends on xunit.v3 → replace `xunit` 2.9.3 with `xunit.v3`; `TestHostBase` ctor takes only the fixture; `Xunit.Abstractions` namespace removed; xUnit1051 → pass `TestCancellation`.
- MediatR.CommandQuery ctors take `ClaimsPrincipal` instead of `IPrincipal`.
- AutoMapper 15.1.3 (vulnerability fix): `AddAutoMapper(Assembly)` removed → `AddAutoMapper(cfg => { }, assembly)`; license key bound via `IOptions<MapperConfigurationExpression>`.
