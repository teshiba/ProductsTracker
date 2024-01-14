namespace ProductsTracker;
using System.Diagnostics;

/// <summary>
/// System API Interface.
/// </summary>
public interface ISystemApi
{
    /// <summary>
    /// Open specified URI.
    /// </summary>
    /// <param name="requestUri">URI string.</param>
    /// <returns>start process.</returns>
    public Process? Start(string requestUri);
}