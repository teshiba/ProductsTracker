namespace ProductsTracker;

using System.Diagnostics;
using System.Net;

using ProductsTracker.Properties;

using Redmine.Net.Api.Exceptions;

/// <summary>
/// Controler of FormRedmine.
/// </summary>
public class CtrlRedmine : IDisposable
{
    private readonly Settings settings = Settings.Default;

    /// <summary>
    /// Gets redmineSync class.
    /// </summary>
    public RedmineSync RedmineSync { get; private set; } = new (new (), new ());

    /// <summary>
    /// Reload redmine manager.
    /// </summary>
    /// <returns>If <see langword="true"/> initialize success.</returns>
    public bool ReloadManager()
    {
        var ret = false;

        try {
            var timeout = TimeSpan.FromSeconds(5);
            var manegerProxy = settings.ManageUsingProxy ? WebRequest.GetSystemWebProxy() : null;
            var targetProxy = settings.TargetUsingProxy ? WebRequest.GetSystemWebProxy() : null;

            var manager = new RedmineManager(settings.ManageHost, settings.ManageUser, settings.ManagePassword, timeout, manegerProxy);
            var target = new RedmineManager(settings.TargetHost, settings.TargetUser, settings.TargetPassword, timeout, targetProxy);

            RedmineSync = new RedmineSync(manager, target) {
                CustomFieldId = settings.CustomFieldIndexOfTrackingId,
            };
            ret = true;
        } catch (RedmineException ex) {
            Debug.WriteLine($"Initialization Failed. {ex.Message}");
        }

        return ret;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing) {
            SaveSettings();
        }
    }

    private static void SaveSettings() => Settings.Default.Save();
}