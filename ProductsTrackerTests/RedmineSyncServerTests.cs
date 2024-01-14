namespace ProductsTrackerTests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProductsTracker;

[TestClass]
[TestCategory("UseActualServer")]
public class RedmineSyncServerTests
{
    private const string ManagerHost = "http://192.168.0.10/redmine/";
    private const string ManagerHostUser = "testUser";
    private const string ManagerHostPass = "12345678";

    private const string TargetHost = "http://192.168.0.15";
    private const string TargetHostUser = "user";
    private const string TargetHostPass = "12345678";

    private RedmineManager manager = new ();
    private RedmineManager target = new ();

    [TestInitialize]
    public void TestInit()
    {
        var timeout = TimeSpan.FromSeconds(5);
        manager = new RedmineManager(ManagerHost, ManagerHostUser, ManagerHostPass, timeout, null);
        target = new RedmineManager(TargetHost, TargetHostUser, TargetHostPass, timeout, null);
    }

    [TestMethod]
    public void RedmineSyncTest()
    {
        // Arrange
        var expManager = manager;
        var expTarget = target;

        // Act
        var testClass = new RedmineSync(expManager, expTarget);
        var actVal = testClass;

        // Assert
        Assert.AreEqual(expManager, actVal.ManagerRedmine);
        Assert.AreEqual(expTarget, actVal.TargetRedmine);
    }

    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
#pragma warning disable VSTHRD002 // Avoid problematic synchronous waits
#pragma warning disable VSTHRD104 // Offer async methods

    [TestMethod]
    public void GetIssueAsyncTest()
    {
        // Arrange
        var expId = 5;

        // Act
        var testClass = new RedmineSync(manager, target);
        var actVal = testClass.GetIssueAsync(expId).Result;

        // Assert
        Assert.AreEqual(expId, actVal.Id);
    }

    [TestMethod]
    public void GetTargetIssueAsyncTest()
    {
        // Arrange
        var manageId = 5;
        var expTargetIssueId = 1;

        // Act
        var testClass = new RedmineSync(manager, target);
        var actVal = testClass.GetTargetIssueAsync(manageId).Result;

        // Assert
        Assert.AreEqual(expTargetIssueId, actVal?.Id);
    }

#pragma warning restore VSTHRD104 // Offer async methods
#pragma warning restore VSTHRD002 // Avoid problematic synchronous waits
    /////////////////////////////////////////////////////////////////////////////////
}