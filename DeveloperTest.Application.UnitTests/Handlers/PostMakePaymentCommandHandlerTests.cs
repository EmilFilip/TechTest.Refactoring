namespace DeveloperTest.Application.UnitTests.Handlers;

public class PostMakePaymentCommandHandlerTests
{
    protected Mock<IConfiguration> _configurationMock { get; }
   
    protected PostMakePaymentCommand _postMakePaymentCommand;
    protected PostMakePaymentCommandHandler _commandHandlerSut;

    private Fixture _fixture;

    public PostMakePaymentCommandHandlerTests()
    {
        _fixture = new Fixture();

        _configurationMock = new Mock<IConfiguration>();
        _postMakePaymentCommand = _fixture.Create<PostMakePaymentCommand>();

        _commandHandlerSut = new PostMakePaymentCommandHandler(_configurationMock.Object);
    }

    [Fact]
    public async Task WhenPostMakePayment_WithDataStoreTypeProvided_ReturnsPostMakePaymentCommandResponseModel()
    {
        // Arrange
        _configurationMock.Setup(_ => _["DataStoreType"]).Returns("Backup");

        // Act
        var result = await _commandHandlerSut.Handle(_postMakePaymentCommand, default(CancellationToken));

        // Assert
        Assert.NotNull(result);
        Assert.IsType<PostMakePaymentCommandResponseModel>(result);
    }

    [Fact]
    public async Task WhenPostMakePayment_WithDataStoreTypeNotProvided_ThrowsConfigNotFoundException()
    {
        // Act
        await Assert.ThrowsAsync<ConfigNotFoundException>(() => _commandHandlerSut.Handle(_postMakePaymentCommand, default(CancellationToken)));
    }
}
