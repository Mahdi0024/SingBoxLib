using Grpc.Net.Client;

namespace SingBoxLib.Runtime.Api.Grpc;

/// <summary>
/// A gRPC client for interacting with sing-box's native gRPC API.
/// </summary>
public sealed class SingBoxGrpcClient : IDisposable
{
    private readonly GrpcChannel _channel;
    private readonly BoxService.BoxServiceClient _boxClient;
    private readonly StatsService.StatsServiceClient _statsClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="SingBoxGrpcClient"/> class.
    /// </summary>
    /// <param name="address">The gRPC server address (e.g. "http://127.0.0.1:2333").</param>
    public SingBoxGrpcClient(string address)
    {
        _channel = GrpcChannel.ForAddress(address);
        _boxClient = new BoxService.BoxServiceClient(_channel);
        _statsClient = new StatsService.StatsServiceClient(_channel);
    }

    /// <summary>
    /// Resets the sing-box instance with the provided configuration JSON.
    /// </summary>
    /// <param name="configJson">The new configuration JSON string.</param>
    public async Task ResetAsync(string configJson)
    {
        await _boxClient.ResetAsync(new ResetRequest { Config = configJson });
    }

    /// <summary>
    /// Gracefully stops the sing-box instance.
    /// </summary>
    public async Task StopAsync()
    {
        await _boxClient.StopAsync(new StopRequest());
    }

    /// <summary>
    /// Gets the statistics for a specific tag.
    /// </summary>
    /// <param name="tag">The statistics category or tag.</param>
    /// <param name="reset">Whether to reset the stats counter after retrieving.</param>
    /// <returns>The stat value.</returns>
    public async Task<long> GetStatsAsync(string tag, bool reset = false)
    {
        var response = await _statsClient.GetAsync(new GetRequest { Tag = tag, Reset = reset });
        return response.Stat;
    }

    /// <summary>
    /// Queries the statistics using a search term or regex pattern.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="reset">Whether to reset the stats counters after retrieving.</param>
    /// <returns>A dictionary containing matching tags and their stat values.</returns>
    public async Task<IDictionary<string, long>> GetQueryStatsAsync(string query, bool reset = false)
    {
        var response = await _statsClient.GetQueryAsync(new GetQueryRequest { Query = query, Reset = reset });
        return response.Stats;
    }

    /// <summary>
    /// Streams real-time statistics updates from the sing-box instance.
    /// </summary>
    /// <param name="intervalSeconds">The update interval in seconds.</param>
    /// <param name="cancellationToken">The cancellation token to stop streaming.</param>
    /// <returns>An async enumerable stream of statistics updates.</returns>
    public async IAsyncEnumerable<IDictionary<string, long>> StreamStatsAsync(int intervalSeconds, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var streamingCall = _statsClient.GetStats(new GetStatsRequest { Interval = intervalSeconds }, cancellationToken: cancellationToken);
        while (await streamingCall.ResponseStream.MoveNext(cancellationToken))
        {
            yield return streamingCall.ResponseStream.Current.Stats;
        }
    }

    /// <summary>
    /// Disposes the underlying gRPC channel.
    /// </summary>
    public void Dispose()
    {
        _channel.Dispose();
    }
}
