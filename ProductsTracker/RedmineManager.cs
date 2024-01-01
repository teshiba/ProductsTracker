namespace ProductsTracker;

using System.Collections.Specialized;

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
    public RedmineManager(string host, string login, string password)
        : base(host, login, password)
    {
    }

    /// <summary>
    /// Gets a Redmine object.
    /// </summary>
    /// <typeparam name="T">The type of objects to retrieve.</typeparam>
    /// <param name="id">The id of the object.</param>
    /// <param name="parameters">Optional filters and/or optional fetched data.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public virtual async Task<T> GetObjectAsync<T>(string id, NameValueCollection parameters)
        where T : class, new()
    {
        return await RedmineManagerAsync.GetObjectAsync<T>(this, id, parameters);
    }

    /// <summary>
    /// Gets Redmine Isuue.
    /// </summary>
    /// <param name="id">issue id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public virtual async Task<Issue> GetIssueAsync(int id)
    {
        var parameters = new NameValueCollection {
            {
                RedmineKeys.INCLUDE,
                RedmineKeys.RELATIONS
            },
        };

        return await RedmineManagerAsync.GetObjectAsync<Issue>(this, id.ToString(), parameters);
    }
}
