# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0

## Source Control
- **Source Branch**: develop
- **Working Branch**: upgrade-dotnet-10
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Auto (Merge)

## Upgrade Options

### Strategy
- Upgrade Strategy: All-at-Once

### Project Structure
- Package Management: Per-Project

### Compatibility
- Unsupported API Handling: Fix Inline

### Modernization
- Nullable Reference Types: Leave Disabled

## Strategy
**Selected**: All-at-Once
**Rationale**: 3 SDK-style projects on net8.0, shallow dependency chain (Core → WebApplication / Core.Tests), low assessed difficulty.

### Execution Constraints
- Single atomic upgrade — update all project TFMs and package references together, then restore
- Build the full solution and fix all compilation errors in one bounded pass; 0 errors before testing
- Testing comes after the atomic upgrade builds successfully
- No tier ordering or multi-targeting
- src\InstructorIQ.JobRunner (net6.0) is not in the solution — out of scope

## Decisions
- Commit strategy changed from After Each Task to Single Commit at End — better fit for All-at-Once
- Pre-existing baseline break (MediatR.CommandQuery 16.6.2: base types are now records, ICacheQueryResult → ICacheResult): user chose to fix code (convert command/query classes to records, use ICacheResult) as part of the upgrade, not roll back the package
- NuGet vulnerability warnings: pin patched transitive versions (Newtonsoft.Json 13.0.1, starkbank-ecdsa 1.3.2, System.Security.Cryptography.Pkcs 9.0.21, NuGet.Protocol 6.12.5)
- AutoMapper 14.0.0 (high-severity advisory): user chose to pin AutoMapper 15.1.3 now and handle the commercial license themselves; license key read from configuration `AutoMapper:LicenseKey`
