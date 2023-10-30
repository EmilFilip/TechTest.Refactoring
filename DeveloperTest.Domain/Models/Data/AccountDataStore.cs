namespace DeveloperTest.Domain.Models.Data;

public class AccountDataStore : IAccountDataStore
{
    public Account GetAccount(string accountNumber)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Account
        {
            AccountNumber = accountNumber,
            Balance = 2470,
            Status = AccountStatus.Live,
            AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
        };
    }

    public void UpdateAccount(Account account)
    {
        // Update account in database, code removed for brevity
    }
}
