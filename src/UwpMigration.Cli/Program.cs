using System.CommandLine;
using UwpMigration.Cli.Commands;
using UwpMigration.Mechanical;

var processRunner = new ProcessRunner();
var evaluator = new MsBuildProjectItemEvaluator(processRunner);
var engine = new MechanicalMigration.Engine(processRunner, evaluator);

var root = new RootCommand(
    "Deterministic UWP to WinUI 3 mechanical migration.");
root.Subcommands.Add(new MigrateCommand(engine));
root.Subcommands.Add(new MigrateVerifyCommand(evaluator));
root.Subcommands.Add(new MigrateProjectItemDecisionCommand(evaluator));

var parseResult = root.Parse(args);
return await parseResult.InvokeAsync(
    parseResult.InvocationConfiguration,
    CancellationToken.None);
