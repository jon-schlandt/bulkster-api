using Bulkster_API.Controllers;
using Bulkster_API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Controllers;

[TestClass]
public class ClientControllerTests
{
    #region Setup

    private Mock<IAuthUserService> _mockAuthUserService = null!;
    private Mock<IClientService> _mockClientService = null!;
    private Mock<IClientOptionsService> _mockClientOptionsService = null!;
    private Mock<ILogger<ClientController>> _mockLogger = null!;

    private ClientController _clientController = null!;

    [TestInitialize]
    public void Initialize()
    {
        _mockAuthUserService = new Mock<IAuthUserService>(MockBehavior.Strict);
        _mockClientService = new Mock<IClientService>(MockBehavior.Strict);
        _mockClientOptionsService = new Mock<IClientOptionsService>(MockBehavior.Strict);
        _mockLogger = new Mock<ILogger<ClientController>>(MockBehavior.Strict);

        _clientController = new ClientController(
            _mockAuthUserService.Object,
            _mockClientService.Object,
            _mockClientOptionsService.Object,
            _mockLogger.Object
        );
    }
    
    #endregion
}
