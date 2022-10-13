namespace ClearBank.DeveloperTest.Domain.UnitTests.Models;

public class DataStoreTests
{
    [Fact]
    public async Task SetAccountDataStore_WhenBackup_ReturnsBackupAccountDataStore()
    {
        // Act
        var dataStore = new DataStore();
        dataStore.SetAccountDataStore("Backup");

        // Assert
        Assert.NotNull(dataStore);
        Assert.IsType<BackupAccountDataStore>(dataStore.AccountDataStore);
    }
}
