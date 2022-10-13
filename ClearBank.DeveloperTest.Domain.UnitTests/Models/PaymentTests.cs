namespace ClearBank.DeveloperTest.Domain.UnitTests.Models;

public class PaymentTests
{
    protected Account _account;
    private Fixture _fixture;

    public PaymentTests()
    {
        _fixture = new Fixture();
        _account = _fixture.Create<Account>();
    }

    [Theory]
    [InlineData(PaymentScheme.Bacs, AllowedPaymentSchemes.Bacs)]
    [InlineData(PaymentScheme.FasterPayments, AllowedPaymentSchemes.FasterPayments)]
    [InlineData(PaymentScheme.Chaps, AllowedPaymentSchemes.Chaps)]
    public async Task SetPaymentResponse_WhenPaymentSchemeAndAllowedPaymentSchemeMatched_ReturnsTrue(
        PaymentScheme paymentScheme,
        AllowedPaymentSchemes allowedPaymentSchemes)
    {
        // Arrange
        _account.AllowedPaymentSchemes = allowedPaymentSchemes;

        // Act
        var payment = new Payment();
        payment.SetPaymentResponse(
            paymentScheme: paymentScheme,
            amount: _account.Balance - 10,
            account: _account);

        // Assert
        Assert.NotNull(payment);
        Assert.True(payment.IsSuccess);
    }

    [Fact]
    public async Task SetPaymentResponse_WhenNotEnoughFunds_ReturnsFalse()
    {
        // Arrange
        _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;

        // Act
        var payment = new Payment();
        payment.SetPaymentResponse(
            paymentScheme: PaymentScheme.FasterPayments,
            amount: _account.Balance + 10,
            account: _account);

        // Assert
        Assert.NotNull(payment);
        Assert.False(payment.IsSuccess);
    }
}
