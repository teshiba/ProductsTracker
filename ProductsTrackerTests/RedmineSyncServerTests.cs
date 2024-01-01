namespace ProductsTrackerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProductsTracker;

[TestClass]
[TestCategory("UseActualServer")]
public class RedmineSyncServerTests
{
    [TestMethod]
    public void RedmineSyncTest()
    {
        // Arrange
        var expManager = new RedmineManager("http://192.168.0.10", "testUser", "12345678");
        var expTarget = new RedmineManager("http://192.168.0.15", "user", "12345678");

        // Act
        var testClass = new RedmineSync(expManager, expTarget);
        var actVal = testClass;

        // Assert
        Assert.AreEqual(expManager, actVal.RedmineManager);
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
        var manager = new RedmineManager("http://192.168.0.10/redmine/", "testUser", "12345678");
        var target = new RedmineManager("http://192.168.0.15", "user", "12345678");
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
        var manager = new RedmineManager("http://192.168.0.10/redmine/", "testUser", "12345678");
        var target = new RedmineManager("http://192.168.0.15", "user", "12345678");
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