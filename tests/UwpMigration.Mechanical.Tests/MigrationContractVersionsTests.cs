using UwpMigration.Contracts;

namespace UwpMigration.Mechanical.Tests;

public sealed class MigrationContractVersionsTests
{
    [Fact]
    public void MechanicalAndStateContractsRemainIndependentlyVersioned()
    {
        Assert.Equal("1.4", MigrationContractVersions.MechanicalReport);
        Assert.Equal("1.0", MigrationContractVersions.StatePlan);
    }
}
