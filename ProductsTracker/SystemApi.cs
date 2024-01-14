namespace ProductsTracker;
using System.Diagnostics;

/// <summary>
/// System API class.
/// </summary>
public class SystemApi : ISystemApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SystemApi"/> class.
    /// </summary>
    /// <param name="user32api">user32 API.</param>
    public SystemApi()
    {
    }

    /// <summary>
    /// Starts the process.
    /// </summary>
    /// <param name="requestUri">request Uri.</param>
    /// <returns>Process.</returns>
    public Process? Start(string requestUri)
        => Process.Start(new ProcessStartInfo("cmd", $"/c start {requestUri}") { CreateNoWindow = true });
}
