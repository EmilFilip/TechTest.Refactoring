namespace ClearBank.DeveloperTest.Application.Commands.PostMakePayment;

public class PostMakePaymentCommandParameters
{
    public string CreditorAccountNumber { get; set; }

    public string DebtorAccountNumber { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public PaymentScheme PaymentScheme { get; set; }
}
