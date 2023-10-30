namespace DeveloperTest.Domain.Models;

public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; }
    public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

    public void SetFromDataStore(
    string debtorAccountNumber,
    IAccountDataStore accountDataStore)
    {
        var account = accountDataStore.GetAccount(debtorAccountNumber);

        AccountNumber = account.AccountNumber;
        Balance = account.Balance;
        Status = account.Status;
        AllowedPaymentSchemes = account.AllowedPaymentSchemes;
    }
}
