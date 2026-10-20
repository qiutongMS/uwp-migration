# UWP to WinUI 3 migration

This repository owns the UWP-to-WinUI 3 migration product: deterministic
mechanical conversion, versioned migration contracts, semantic workflow
guidance, and executable enforcement.

The implementation is intentionally separated from the general-purpose
WinApp CLI and WinUI analyzer:

- WinApp CLI provides Windows app build, package, launch, debugging, and UI
  automation primitives.
- `Microsoft.Windows.SDK.BuildTools.WinUIAnalyzer` provides static WinUI
  diagnostics.
- This repository owns UWP-specific migration state, transformations,
  verification, evidence, replay, and closure.

## Repository layout

```text
plugins/                         UWP migration Agent Plugin and Skill
src/UwpMigration.Contracts/      Versioned JSON contracts
src/UwpMigration.Mechanical/     Deterministic migration and verification
src/UwpMigration.Cli/            `uwp-migrate` command line
src/UwpMigration.Enforcement/    Phase, evidence, replay, and closure gates (future)
tests/                           Unit and integration tests
```

The mechanical implementation owns schema 1.4 reports, source and dependency
inventory, activation declarations, safe filesystem handling, deterministic
XAML and C# transforms, residual findings, target-project graph verification,
MSBuild item evaluation, and the six explicit project-item decision strategies.
Report updates are transaction-locked and persisted atomically.

The standalone CLI uses System.CommandLine and exposes:

```text
uwp-migrate create <source> --output <target>
uwp-migrate migrate <source> --output <target>
uwp-migrate verify <target>
uwp-migrate decide-project-item <target> <item> <strategy> <rationale>
```

The mechanical engine depends only on a narrow process runner for
`dotnet new winui` and `dotnet msbuild`. Enforcement is intentionally not part
of this milestone.
