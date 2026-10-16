# 01-prerequisites: Verify .NET 10 SDK and update CI toolchain

Confirm the .NET 10 SDK is installed and that no `global.json` pins an older SDK. The repository has no `global.json`, so the main toolchain change is the GitHub Actions build workflow (`.github\workflows\dotnet.yml`), which currently installs `dotnet-version: 8.0.x` and would fail to build net10.0 projects.

**Done when**: .NET 10 SDK is confirmed available locally, and the CI workflow installs the .NET 10 SDK.

## Research Findings
- Local SDKs installed: 8.0.426, 9.0.319, 10.0.402 — `validate_dotnet_sdk_installation(net10.0)` reports a compatible SDK.
- No `global.json` in the repo — nothing pins an older SDK.
- CI: `.github\workflows\dotnet.yml` uses `actions/setup-dotnet@v6` with `dotnet-version: 8.0.x` → change to `10.0.x`. `merge.yml` (Dependabot auto-merge) has no .NET toolchain.
