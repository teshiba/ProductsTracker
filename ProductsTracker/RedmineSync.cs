namespace ProductsTracker;

using System.Diagnostics;

using Redmine.Net.Api.Types;

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
    private const int CustomFieldId = 1;

    /// <summary>
    /// Gets redmineManager.
    /// </summary>
    public RedmineManager RedmineManager { get; init; } = manager;

    /// <summary>
    /// Gets target RedmineManager.
    /// </summary>
    public RedmineManager TargetRedmine { get; init; } = target;

    /// <summary>
    /// Get issue of target redimie.
    /// </summary>
    /// <param name="id">target issue id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Issue?> GetTargetIssueAsync(int id)
    {
        Issue? targetIssue = null;
        var issue = await RedmineManager.GetIssueAsync(id);

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
    /// Get issue of redimie.
    /// </summary>
    /// <param name="id">target issue id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Issue> GetIssueAsync(int id)
        => await RedmineManager.GetIssueAsync(id);
}