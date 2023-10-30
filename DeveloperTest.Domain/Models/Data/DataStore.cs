namespace DeveloperTest.Domain.Models.Data;

public class DataStore
{
    public IAccountDataStore AccountDataStore { get; set; }

    public void SetAccountDataStore(string dataStoreType)
    {
        if (dataStoreType == "Backup")
        {
            AccountDataStore = new BackupAccountDataStore();
        }
        else
        {
            AccountDataStore = new AccountDataStore();
        }
    }
}
