namespace DeveloperTest.Domain.Models.Contracts;

public interface IAccountDataStore
{
    Account GetAccount(string accountNumber);

    void UpdateAccount(Account account);
}
