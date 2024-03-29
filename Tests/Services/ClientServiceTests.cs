using Bulkster_API.Data;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Implementations;
using Bulkster_API.Services.Interfaces;
using Moq;
using IDbContextTransaction = Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction;

namespace Tests.Services;

[TestClass]
public class ClientServiceTests
{
    #region Setup
    
    private readonly Guid _clientId1 = Guid.NewGuid();
    private readonly string _authUserId1 = TestDataUtil.GenerateRandomString(24);
    private readonly Guid _genderId1 = Guid.NewGuid();
    private readonly Guid _activityLevelId1 = Guid.NewGuid();

    private Client _client1 = null!;
    
    private Mock<IClientRepository> _mockClientRepository = null!;
    private Mock<IBulksterDbContext> _mockBulksterContext = null!;
    private Mock<IDbContextTransaction> _mockDbContextTransaction = null!;
    
    private IClientService _clientService = null!;

    [TestInitialize]
    public void Initialize()
    {
        _mockClientRepository = new Mock<IClientRepository>(MockBehavior.Strict);
        _mockBulksterContext = new Mock<IBulksterDbContext>(MockBehavior.Strict);
        _mockDbContextTransaction = new Mock<IDbContextTransaction>(MockBehavior.Strict);

        _clientService = new ClientService(_mockClientRepository.Object);

        SetupDefaultMocks();
        SetupTestModels();
    }

    private void SetupDefaultMocks()
    {
        _mockBulksterContext.Setup(x => 
            x.BeginTransactionAsync()).ReturnsAsync(_mockDbContextTransaction.Object);
        
        _mockDbContextTransaction.Setup(x => 
            x.CommitAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        _mockDbContextTransaction.Setup(x => 
            x.RollbackAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        _mockDbContextTransaction.Setup(x => 
            x.DisposeAsync()).Returns(ValueTask.CompletedTask);
    }

    private void SetupTestModels()
    {
        _client1 = new Client(
            id: _clientId1,
            authUserId: _authUserId1,
            genderId: _genderId1,
            age: 30,
            weight: 190,
            height: 90,
            activityLevelId: _activityLevelId1,
            calorieModifier: 300,
            dailyCalorieGoal: 3300
        );
    }
    
    #endregion
    
    #region Tests
    
    #region InitializeClientAsync

    [TestMethod]
    public void InitializeClientAsync_IsSuccessful_ReturnsClientId()
    {
        _mockClientRepository.Setup(x => 
            x.InsertClientAsync(_client1)).ReturnsAsync(1);
        
        Guid result = _clientService.CreateClientAsync(_client1).GetAwaiter().GetResult();
        Assert.AreEqual(_client1.Id, result);
    }
    
    #endregion
    
    #region GetClientAsync

    [TestMethod]
    public void GetClientAsync_IsSuccessful_ReturnsClient()
    {
        _mockClientRepository.Setup(x => 
            x.GetClientByAuthUserIdAsync(_authUserId1)).ReturnsAsync(_client1);

        Client? result = _clientService.GetClientByAuthUserIdAsync(_authUserId1).GetAwaiter().GetResult();
        
        Assert.IsNotNull(result);
        Assert.AreEqual(_client1, result);
    }
    
    #endregion
    
    #region UpdateClientAsync

    [TestMethod]
    public void UpdateClientAsync_IsSuccessful_ReturnsClientId()
    {
        _mockClientRepository.Setup(x => 
            x.UpdateClientAsync(_client1)).ReturnsAsync(1);

        Guid result = _clientService.UpdateClientAsync(_client1).GetAwaiter().GetResult();
        Assert.AreEqual(_clientId1, result);
    }
    
    #endregion
    
    #endregion
}
