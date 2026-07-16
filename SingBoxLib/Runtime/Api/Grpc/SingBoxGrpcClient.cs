using Grpc.Net.Client;

namespace SingBoxLib.Runtime.Api.Grpc;

/// <summary>
/// A gRPC client for interacting with sing-box's native gRPC API.
/// </summary>
public sealed class SingBoxGrpcClient : IDisposable
{
    private readonly GrpcChannel _channel;
    private readonly StatsService.StatsServiceClient _statsClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="SingBoxGrpcClient"/> class.
    /// </summary>
    /// <param name="address">The gRPC server address (e.g. "http://127.0.0.1:2333").</param>
    public SingBoxGrpcClient(string address)
    {
        _channel = GrpcChannel.ForAddress(address);
        _statsClient = new StatsService.StatsServiceClient(_channel);
    }

    /// <summary>
    /// Gets the statistics for a specific tag/name.
    /// </summary>
    /// <param name="name">The name/tag of the stat counter.</param>
    /// <param name="reset">Whether to reset the stats counter after retrieving.</param>
    /// <returns>The stat value.</returns>
    public async Task<long> GetStatsAsync(string name, bool reset = false)
    {
        var response = await _statsClient.GetStatsAsync(new GetStatsRequest { Name = name, Reset = reset });
        return response.Stat?.Value ?? 0;
    }

    /// <summary>
    /// Queries the statistics using search terms or regex patterns.
    /// </summary>
    /// <param name="patterns">The patterns to match.</param>
    /// <param name="regexp">Whether to treat the patterns as regular expressions.</param>
    /// <param name="reset">Whether to reset the stats counters after retrieving.</param>
    /// <returns>A dictionary containing matching tags and their stat values.</returns>
    public async Task<IDictionary<string, long>> QueryStatsAsync(IEnumerable<string> patterns, bool regexp = false, bool reset = false)
    {
        var request = new QueryStatsRequest
        {
            Regexp = regexp,
            Reset = reset
        };
        request.Patterns.AddRange(patterns);

        var response = await _statsClient.QueryStatsAsync(request);
        return response.Stat.ToDictionary(s => s.Name, s => s.Value);
    }

    /// <summary>
    /// Retrieves system statistics (memory, uptime, live objects, etc.).
    /// </summary>
    /// <returns>The system statistics response.</returns>
    public async Task<SysStatsResponse> GetSysStatsAsync()
    {
        return await _statsClient.GetSysStatsAsync(new SysStatsRequest());
    }

    /// <summary>
    /// Disposes the underlying gRPC channel.
    /// </summary>
    public void Dispose()
    {
        _channel.Dispose();
    }
}
