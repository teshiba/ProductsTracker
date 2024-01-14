namespace ProductsTracker;

using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.AccessControl;

using Redmine.Net.Api;
using Redmine.Net.Api.Async;
using Redmine.Net.Api.Types;

/// <summary>
/// RedmineManager Wrapper class.
/// </summary>
public class RedmineManager : Redmine.Net.Api.RedmineManager
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RedmineManager"/> class.
    /// dummy default.
    /// </summary>
    public RedmineManager()
        : base("localhost")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RedmineManager"/> class.
    /// </summary>
    /// <param name="host">The host name.</param>
    /// <param name="apiKey">The API key.</param>
    public RedmineManager(string host, string apiKey)
        : base(host, apiKey)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RedmineManager"/> class.
    /// </summary>
    /// <param name="host">The host name.</param>
    /// <param name="login">The login name.</param>
    /// <param name="password">The login password.</param>
    /// <param name="timeout">network timeout.</param>
    /// <param name="proxy">network proxy.</param>
    public RedmineManager(string host, string login, string password, TimeSpan timeout, IWebProxy? proxy)
        : base(host, login, password, timeout: timeout, proxy: proxy)
    {
    }

    /// <summary>
    /// Gets or sets system API.
    /// </summary>
    public ISystemApi SystemApi { get; set; } = new SystemApi();

    /// <summary>
    /// Gets Redmine Isuue.
    /// </summary>
    /// <param name="id">issue id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public virtual async Task<Issue> GetIssueAsync(int id)
    {
        var parameters = new NameValueCollection {
            { RedmineKeys.INCLUDE, RedmineKeys.RELATIONS },
        };

        return await RedmineManagerAsync.GetObjectAsync<Issue>(this, id.ToString(), parameters);
    }

    /// <summary>
    /// Open Issue in a web browser.
    /// </summary>
    /// <param name="issueId"> issue ID.</param>
    public void OpenIssue(int issueId)
    {
        OpenBrowser($"{Host}/issues/{issueId}");
    }

    /// <summary>
    /// Open specified URI.
    /// </summary>
    /// <param name="requestUri">URI string.</param>
    /// <returns>browser process.</returns>
    public virtual Process? OpenBrowser(string requestUri)
    {
        Process? ret;

        try {
            ret = SystemApi.Start(requestUri);
        } catch (Win32Exception noBrowser) {
            Debug.Print(noBrowser.Message);
            throw;
        } catch (Exception other) {
            Debug.Print(other.Message);
            throw;
        }

        return ret;
    }
}
