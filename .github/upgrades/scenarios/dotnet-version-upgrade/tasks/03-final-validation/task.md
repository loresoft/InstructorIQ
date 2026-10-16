# 03-final-validation: Run tests and validate the upgraded solution

Run the full test suite in `InstructorIQ.Core.Tests` against the upgraded solution and fix any failures caused by the upgrade. Review behavioral-change areas flagged by the assessment for runtime impact. Note any deferred recommendations (e.g., replacing deprecated packages, moving to xunit v3, central package management, the stale JobRunner project).

**Done when**: Solution builds cleanly and all tests that passed before the upgrade still pass.

## Research Findings
- Test project: service\test\InstructorIQ.Core.Tests (21 tests). Domain tests (Group/Location/Tenant/Topic) need SQL Server `(local)` database `InstructorIQ` (appsettings.json).
- xunit.v3 4.x uses Microsoft.Testing.Platform v2 (`IsTestingPlatformApplication=true`); .NET 10 SDK rejects the VSTest target for MTP apps → opt in via repo-root `global.json` `test.runner = Microsoft.Testing.Platform`; run with `dotnet test --project <csproj>`.
- CI workflow does not run tests, so no workflow change needed.
