using SingBoxLib.Parsing;
using System.Collections.Concurrent;

namespace SingBoxLib.Runtime.Testing;

public class ParallelUrlTester
{
    private int _maxThreads;
    private ConcurrentStack<UrlTester> _testers;

    private int _activeThreads;
    public int ActiveThreads { get => _activeThreads; }

    public ParallelUrlTester(SingBoxWrapper singBox, IEnumerable<int> localPorts, int maxThreads, int timeout, int attempts, string? url = null)
    {
        if (localPorts.Count() < maxThreads)
        {
            throw new ArgumentException($"Number of local ports count must be equal or higher than max threads.");
        }

        _maxThreads = maxThreads;
        _testers = new ConcurrentStack<UrlTester>(localPorts
            .Select(p => new UrlTester(singBox, p, timeout, attempts, url)));
    }

    public async Task ParallelTestAsync(IEnumerable<ProfileItem> profiles, IProgress<UrlTestResult> progressReporter, CancellationToken cancellationToken)
    {
        await Parallel.ForEachAsync(profiles, new ParallelOptions { MaxDegreeOfParallelism = _maxThreads }, async (profile, ct) =>
        {
            Interlocked.Increment(ref _activeThreads);
            _testers.TryPop(out var tester);

            var result = await tester!.TestAsync(profile);
            progressReporter.Report(result);

            _testers.Push(tester);
            Interlocked.Decrement(ref _activeThreads);
        });
    }
}