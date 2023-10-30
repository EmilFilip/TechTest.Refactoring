namespace DeveloperTest.Domain.Models.Data;

public class BackupAccountDataStore : IAccountDataStore
{
    public Account GetAccount(string accountNumber)
    {
        // Access backup data base to retrieve account, code removed for brevity 
        return new Account
        {
            AccountNumber = accountNumber,
            Balance = 2470,
            Status = AccountStatus.Disabled,
            AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
        };
    }

    public void UpdateAccount(Account account)
    {
        // Update account in backup database, code removed for brevity
    }
}
