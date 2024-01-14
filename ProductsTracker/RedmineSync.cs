namespace ProductsTracker;

using System.Collections.Specialized;
using System.Diagnostics;

using Redmine.Net.Api.Async;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using ProductsTracker.Properties;

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
    /// Gets or sets project ID.
    /// </summary>
    public int ProjectId { get; set; } = Settings.Default.ManageProjectId;

    /// <summary>
    /// Gets target RedmineManager.
    /// </summary>
    public RedmineManager TargetRedmine { get; init; } = target;

    /// <summary>
    /// Gets redmineManager.
    /// </summary>
    public RedmineManager ManagerRedmine { get; init; } = manager;

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
    public async Task<List<Issue>> GetIssuesAsync()
        => await GetIssuesAsync(ProjectId);

    /// <summary>
    /// Get Issues.
    /// </summary>
    /// <param name="projectId">target project ID.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<List<Issue>> GetIssuesAsync(int projectId)
    {
        var parameters = new NameValueCollection {
            { RedmineKeys.STATUS_ID, RedmineKeys.ALL },
            { RedmineKeys.PROJECT_ID, projectId.ToString() },
        };

        var issueList = await ManagerRedmine.GetObjectsAsync<Issue>(parameters);

        return issueList;
    }
}