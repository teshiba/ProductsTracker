namespace ProductsTracker;

using System.Collections.Specialized;
using System.Diagnostics;

using Redmine.Net.Api.Async;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Net;
using System;

/// <summary>
/// Sync multiple redmine ticket.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RedmineSync"/> class.
/// </remarks>
/// <param name="manager">manageer.</param>
/// <param name="target">sync target redmine.</param>
public class RedmineSync(RedmineManager manager, RedmineManager target)
{
    /// <summary>
    /// Gets or sets the ID of CustomField, which is set as a target project ID.
    /// </summary>
    public int CustomFieldId { get; set; }

    /// <summary>
    /// Gets project ID.
    /// </summary>
    public int ProjectId { get; init; }

    /// <summary>
    /// Gets target RedmineManager.
    /// </summary>
    public RedmineManager TargetRedmine { get; init; } = target;

    /// <summary>
    /// Gets redmineManager.
    /// </summary>
    public RedmineManager ManagerRedmine { get; init; } = manager;

    /// <summary>
    /// Gets issue status list.
    /// </summary>
    public List<IssueStatus> IssueStatuses { get; private set; } = [];

    /// <summary>
    /// Gets issue list.
    /// </summary>
    public List<Issue> Issues { get; private set; } = [];

    /// <summary>
    /// Gets opened issues.
    /// </summary>
    public List<Issue> OpenedIssues
    {
        get
        {
            var openedStatusIdList = IssueStatuses.Where((x) => !x.IsClosed).Select((item) => item.Id);
            var ret = Issues.Where((issue) => openedStatusIdList.Contains(issue.Status.Id)).ToList();

            return ret;
        }
    }

    /// <summary>
    /// Get issue of target redimie.
    /// </summary>
    /// <param name="id">target issue id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Issue?> GetTargetIssueAsync(int id)
    {
        Issue? targetIssue = null;
        var issue = await ManagerRedmine.GetIssueAsync(id);

        foreach (var item in issue.CustomFields) {
            Debug.WriteLine($"CustomField[{item.Id}] {item.Name}: {item.Value}");

            if (item.Id == CustomFieldId) {
                if (int.TryParse(item.Value, out var issueid)) {
                    targetIssue = await TargetRedmine.GetIssueAsync(issueid);
                    break;
                }
            }
        }

        return targetIssue;
    }

    /// <summary>
    /// Get issue of redmine.
    /// </summary>
    /// <param name="id">target issue ID.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Issue> GetIssueAsync(int id)
        => await ManagerRedmine.GetIssueAsync(id);

    /// <summary>
    /// Get Issues.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> LoadIssuesAsync()
    {
        return await LoadIssuesAsync(ProjectId)
            && await LoadIssueStatusListAsync();
    }

    /// <summary>
    /// Get target issue ID.
    /// </summary>
    /// <param name="issue">manage issue ID.</param>
    /// <returns>Issue ID.</returns>
    public string GetTargetIssueId(Issue issue)
        => issue.CustomFields.First((x) => x.Id == CustomFieldId).Values[0].Info;

    /// <summary>
    /// Get Issues.
    /// </summary>
    /// <param name="projectId">target project ID.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private async Task<bool> LoadIssuesAsync(int projectId)
    {
        bool ret = true;

        var parameters = new NameValueCollection {
            { RedmineKeys.STATUS_ID, RedmineKeys.ALL },
            { RedmineKeys.PROJECT_ID, projectId.ToString() },
        };

        try {
            Issues = await ManagerRedmine.GetObjectsAsync<Issue>(parameters);
        } catch (WebException) {
            ret = false;
        }

        return ret;
    }

    /// <summary>
    /// Get Issue status list.
    /// </summary>
    /// <returns>Issue status list.</returns>
    private async Task<bool> LoadIssueStatusListAsync()
    {
        var parameters = new NameValueCollection {
            { RedmineKeys.ISSUE_STATUS, RedmineKeys.ALL },
        };

        IssueStatuses = await ManagerRedmine.GetObjectsAsync<IssueStatus>(parameters);

        return IssueStatuses is not null;
    }
}