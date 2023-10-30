namespace DeveloperTest.Application.Commands.PostMakePayment;

public class PostMakePaymentCommandHandler : IRequestHandler<PostMakePaymentCommand, PostMakePaymentCommandResponseModel>
{
    private readonly IConfiguration _configuration;

    public PostMakePaymentCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<PostMakePaymentCommandResponseModel> Handle(
        PostMakePaymentCommand command,
        CancellationToken cancellationToken)
    {
        var dataStoreType = _configuration["DataStoreType"] ?? throw new ConfigNotFoundException("DataStoreType is null");

        var dataStore = new DataStore();
        dataStore.SetAccountDataStore(dataStoreType);

        var account = new Account();
        account.SetFromDataStore(
            debtorAccountNumber: command.DebtorAccountNumber,
            accountDataStore: dataStore.AccountDataStore);

        var payment = new Payment();
        payment.SetPaymentResponse(
            paymentScheme: command.PaymentScheme,
            amount: command.Amount,
            account: account);
        payment.MakePayment(
            dataStore: dataStore,
            amount: command.Amount,
            account: account);

        return new PostMakePaymentCommandResponseModel(payment.IsSuccess);
    }
}
