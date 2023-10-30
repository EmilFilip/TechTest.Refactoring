namespace DeveloperTest.Domain.Models;

public class Payment
{
    public bool IsSuccess { get; set; }

    public void SetPaymentResponse(
        PaymentScheme paymentScheme,
        decimal amount,
        Account account)
    {
        IsSuccess = true;

        switch (paymentScheme)
        {
            case PaymentScheme.Bacs:
                if (account == null)
                {
                    IsSuccess = false;
                }
                else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                {
                    IsSuccess = false;
                }
                break;

            case PaymentScheme.FasterPayments:
                if (account == null)
                {
                    IsSuccess = false;
                }
                else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                {
                    IsSuccess = false;
                }
                else if (account.Balance < amount)
                {
                    IsSuccess = false;
                }
                break;

            case PaymentScheme.Chaps:
                if (account == null)
                {
                    IsSuccess = false;
                }
                else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
                {
                    IsSuccess = false;
                }
                else if (account.Status != AccountStatus.Live)
                {
                    IsSuccess = false;
                }
                break;
        }
    }

    public void MakePayment(
        DataStore dataStore,
        decimal amount,
        Account account
        )
    {
        if (IsSuccess)
        {
            account.Balance -= amount;
            dataStore.AccountDataStore.UpdateAccount(account);
        }
    }
}