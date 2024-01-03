namespace ProductsTrackerTests.TestUtility;

using System;
using System.Threading.Tasks;

using Redmine.Net.Api.Types;

public class TestRedmineManager : ProductsTracker.RedmineManager
{
    public const string ManagerHost = "managerHost";
    public const string TargetHost = "targetHost";

    private readonly string host;

    public TestRedmineManager(string host, string apiKey)
    {
        if (string.IsNullOrEmpty(host)) {
            throw new ArgumentException($"'{nameof(host)}' cannot be null or empty.", nameof(host));
        }

        if (string.IsNullOrEmpty(apiKey)) {
            throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or empty.", nameof(apiKey));
        }

        this.host = host;
    }

    public TestRedmineManager(string host, string login, string password)
    {
        if (string.IsNullOrEmpty(host)) {
            throw new ArgumentException($"'{nameof(host)}' cannot be null or empty.", nameof(host));
        }

        if (string.IsNullOrEmpty(login)) {
            throw new ArgumentException($"'{nameof(login)}' cannot be null or empty.", nameof(login));
        }

        if (string.IsNullOrEmpty(password)) {
            throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
        }

        this.host = host;
    }

    public override async Task<Issue> GetIssueAsync(int id)
    {
        return await Task.Run(() =>
        {
            var issue = new Issue {
                CustomFields = new List<IssueCustomField>() {
                    CreateIssueCustomField(1),
                },
            };

            issue.SetProperty("Id", GetIssueId(host));

            return issue;
        });
    }

    private static int GetIssueId(string host)
    {
        return host switch {
            ManagerHost => 5,
            TargetHost => 1,
            _ => -1,
        };
    }

    private static IssueCustomField CreateIssueCustomField(int id)
    {
        var issueCustomField = IdentifiableName.Create<IssueCustomField>(id);

        issueCustomField.Values = new List<CustomFieldValue> {
                new () {
                    Info = "Issue custom field Values 1",
                },
            };
        return issueCustomField;
    }
}
