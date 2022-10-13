namespace ClearBank.DeveloperTest.WebApi.Controllers;

[ApiController]
//[Authorize]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public PaymentsController(
        IMediator mediator,
        ILogger<PaymentsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Option to pay with an 3DS unregistered card.
    /// </summary>
    /// <returns> Returns success status.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostMakePaymentCommandResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("makepayment")]
    public async Task<IActionResult> SubmitPayment([FromBody] PostMakePaymentCommandParameters parameters)
    {
        try
        {
            _logger.LogInformation("MakePayment request received");

            var result = await _mediator.Send(new PostMakePaymentCommand(
                creditorAccountNumber: parameters.CreditorAccountNumber,
                debtorAccountNumber: parameters.DebtorAccountNumber,
                amount: parameters.Amount,
                paymentDate: parameters.PaymentDate,
                paymentScheme: parameters.PaymentScheme));

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Making Payment");
            throw;
        }
    }
}