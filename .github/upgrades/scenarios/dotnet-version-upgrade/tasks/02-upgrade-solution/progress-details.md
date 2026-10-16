# 02-upgrade-solution — Progress Details

## What changed
- **TFM**: Core, WebApplication, Core.Tests → `net10.0`.
- **Packages**:
  - Core: Microsoft.AspNetCore.Identity.EntityFrameworkCore 10.0.13, Microsoft.EntityFrameworkCore.SqlServer 10.0.13.
  - Core: vulnerability pins added: AutoMapper 15.1.3, Newtonsoft.Json 13.0.1, starkbank-ecdsa 1.3.2, System.Security.Cryptography.Pkcs 9.0.21.
  - WebApplication: Microsoft.VisualStudio.Web.CodeGeneration.Design 10.0.2; NuGet.Protocol 6.12.5 pin.
  - Core.Tests: `xunit` 2.9.3 replaced by `xunit.v3` 4.0.2 (required by XUnit.Hosting 4.1.0).
- **.NET 10 API fixes**: `IActionContextAccessor` (obsolete) replaced by `IHttpContextAccessor` + `IUrlHelperFactory` in `ServiceCollectionExtensions.cs`.
- **Pre-existing package breaks fixed (from Dependabot bumps on develop)**:
  - MediatR.CommandQuery 16.6.2: 43 command/query types converted to `record`, `IPrincipal` → `ClaimsPrincipal`, `ICacheQueryResult` → `ICacheResult` (TenantSlugQuery).
  - FluentCommand: `SqlParameter` → `ParameterStructured` (ImportProcessService).
  - Ical.Net 5: `CalDateTime(dt, hasTime: true)` (EventController).
  - XUnit.Hosting 4.1.0 / xunit.v3: removed `Xunit.Abstractions`, updated `TestHostBase` ctor, `MockPrincipal` typed as `ClaimsPrincipal`, `TestCancellation` passed to `mediator.Send`.
  - AutoMapper 15: `AddAutoMapper(_ => { }, assembly)`; license key bound from configuration `AutoMapper:LicenseKey`.
- **CI**: `.github\workflows\dotnet.yml` uses `10.0.x` (task 01).

## Build results
- Clean build of `service\InstructorIQ.sln`: **0 errors, 0 warnings** (including NuGet audit warnings).

## Issues / notes
- A `--no-incremental` build can fail on the WebApplication static web assets (`bundle.css` not found) because BuildBundlerMinifier regenerates bundles during build; a normal / clean build succeeds. Not caused by the upgrade.
- AutoMapper 15 requires a commercial license key — must be configured via `AutoMapper:LicenseKey` (user secrets / app settings) before production use.
