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
plugins/uwp-migration/           Agent Plugins 1.0 package and migration Skill
src/UwpMigration.Contracts/      Versioned JSON contracts
src/UwpMigration.Mechanical/     Deterministic migration and verification
src/UwpMigration.Cli/            `uwp-migrate` command line
src/UwpMigration.Enforcement/    Phase, evidence, replay, and closure gates
tests/                           Unit and integration tests
```

The first milestone is behavioral parity with the qualified mechanical
migration baseline. Enforcement is added only after that parity is proven.

The plugin is currently a preview workflow. It consumes migration-report schema
1.4 and keeps behavioral state-plan schema 1.0 separate. Released WinApp CLI
0.7 builds, registers, launches, diagnoses, and automates apps, but does not
currently provide the schema 1.4 UWP migration command.
