namespace ProductsTracker;

using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

using ProductsTracker.Properties;
using Redmine.Net.Api.Exceptions;
using Redmine.Net.Api.Types;

/// <summary>
/// Controler of FormRedmine.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CtrlRedmine"/> class.
/// </remarks>
/// <param name="manageProjectId">manage project ID.</param>
public class CtrlRedmine
{
    /// <summary>
    /// Gets redmineSync class.
    /// </summary>
    public RedmineSync RedmineSync { get; private set; } = new (new (), new ());

    private static Settings Settings => Settings.Default;

    /// <summary>
    /// Reload redmine manager.
    /// </summary>
    /// <param name="settings">setting data.</param>
    public void ReloadManager()
    {
        try {
            var timeout = TimeSpan.FromSeconds(5);
            var manegerProxy = Settings.ManageUsingProxy ? WebRequest.GetSystemWebProxy() : null;
            var targetProxy = Settings.TargetUsingProxy ? WebRequest.GetSystemWebProxy() : null;

            var manager = new RedmineManager(
                Settings.ManageHost, Settings.ManageUser, Settings.ManagePassword, timeout, manegerProxy);
            var target = new RedmineManager(
                Settings.TargetHost, Settings.TargetUser, Settings.TargetPassword, timeout, targetProxy);

            RedmineSync = new RedmineSync(manager, target) {
                CustomFieldId = Settings.CustomFieldIndexOfTrackingId,
                ProjectId = Settings.ManageProjectId,
            };
        } catch (RedmineException ex) {
            Debug.WriteLine($"Initialization Failed. {ex.Message}");
        }
    }

    /// <summary>
    /// Create ticket listView.
    /// </summary>
    /// <param name="isOpenedOnly">if <see langword="true"/>, listing opened issue.</param>
    /// <returns>ListViewItem array.</returns>
    public ListViewItem[] CreateTicketListView(bool isOpenedOnly)
    {
        var ret = new List<ListViewItem>();

        var issues = isOpenedOnly
            ? RedmineSync.OpenedIssues
            : RedmineSync.Issues;

        foreach (var issue in issues) {
            var listviewItem = new ListViewItem(issue.Id.ToString()) {
                Tag = issue,
            };
            var targetIssueId = RedmineSync.GetTargetIssueId(issue);

            listviewItem.SubItems.AddRange(FormRedmineHelpers.NewSubItems([
                issue.Status.Name,
                issue.Subject,
                targetIssueId,
                issue.Description,
            ]));

            ret.Add(listviewItem);
        }

        return [.. ret];
    }
}