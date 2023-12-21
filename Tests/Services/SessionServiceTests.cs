using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Implementations;
using Moq;

namespace Tests.Services;

[TestClass]
public class SessionServiceTests
{
    #region Setup

    private readonly Guid _sessionId1 = Guid.NewGuid();
    private readonly Guid _clientId1 = Guid.NewGuid();
    
    private Session _existingSession1 = null!;
    
    private Mock<ISessionRepository> _mockSessionRepository = null!;
    private SessionService _sessionService = null!;

    [TestInitialize]
    public void Initialize()
    {
        _mockSessionRepository = new Mock<ISessionRepository>(MockBehavior.Strict);
        _sessionService = new SessionService(_mockSessionRepository.Object);

        SetupTestModels();
    }

    private void SetupTestModels()
    {
        _existingSession1 = new Session(
            id: _sessionId1,
            clientId: _clientId1,
            lastSessionDate: DateTime.Now.Subtract(TimeSpan.FromDays(1))
        );
    }

    #endregion
    
    #region Tests

    [TestMethod]
    public void RefreshSessionAsync_SessionDoesNotExist_PerformsInsert()
    {
        _mockSessionRepository.Setup(x =>
            x.GetSessionByClientIdAsync(_clientId1)).ReturnsAsync((Session?)null);

        _mockSessionRepository.Setup(x =>
            x.InsertSessionAsync(It.IsAny<Session>())).ReturnsAsync(1);

        Guid result = _sessionService.RefreshSessionAsync(_clientId1).GetAwaiter().GetResult();
        
        Assert.IsNotNull(result);
        Assert.AreNotEqual(Guid.Empty, result);
        
        _mockSessionRepository.Verify(x => 
            x.InsertSessionAsync(It.IsAny<Session>()), Times.Once);
        
        _mockSessionRepository.Verify(x => 
            x.UpdateSessionAsync(It.IsAny<Session>()), Times.Never);
    }
    
    [TestMethod]
    public void RefreshSessionAsync_SessionExists_PerformsUpdate()
    {
        DateTime prevSessionDate = _existingSession1.LastSessionDate;
        
        _mockSessionRepository.Setup(x =>
            x.GetSessionByClientIdAsync(_clientId1)).ReturnsAsync(_existingSession1);

        _mockSessionRepository.Setup(x =>
            x.UpdateSessionAsync(It.Is<Session>(s =>
                ReferenceEquals(s, _existingSession1) && s.LastSessionDate > prevSessionDate)))
            .ReturnsAsync(1);

        Guid result = _sessionService.RefreshSessionAsync(_clientId1).GetAwaiter().GetResult();
        
        Assert.IsNotNull(result);
        Assert.AreNotEqual(Guid.Empty, result);
        
        _mockSessionRepository.Verify(x => 
            x.InsertSessionAsync(It.IsAny<Session>()), Times.Never);
        
        _mockSessionRepository.Verify(x => 
            x.UpdateSessionAsync(_existingSession1), Times.Once);
    }
    
    #endregion
}
