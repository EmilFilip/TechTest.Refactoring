namespace DeveloperTest.Application.Commands.PostMakePayment;

public class PostMakePaymentCommandResponseModel
{
    public PostMakePaymentCommandResponseModel(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; }
}
