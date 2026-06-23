using CliWrap;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace SingBoxLib.Runtime;

/// <summary>
/// Wrapper class for managing the lifecycle and logging of a sing-box process.
/// </summary>
public class SingBoxWrapper
{
    private string _singBoxPath;

    /// <summary>
    /// Fired when a new log line is received from either standard output or standard error.
    /// </summary>
    public event Action<SingBoxWrapper, LogEventArgs>? OnLog;

    /// <summary>
    /// Initializes a new instance of the <see cref="SingBoxWrapper"/> class.
    /// </summary>
    /// <param name="executablePath">The file path to the sing-box executable.</param>
    public SingBoxWrapper(string executablePath)
    {
        _singBoxPath = executablePath;
    }

    /// <summary>
    /// Starts the sing-box process with the provided configuration and waits for it to exit.
    /// </summary>
    /// <param name="config">The configuration model.</param>
    /// <param name="cancellationToken">Cancellation token to terminate the process.</param>
    /// <returns>A command execution result task.</returns>
    public async Task<CommandResult> StartAsync(SingBoxConfig config, CancellationToken cancellationToken)
    {
        return await Cli.Wrap(_singBoxPath)
                         .WithArguments("run -c stdin")
                         .WithStandardInputPipe(PipeSource.FromString(config.ToJson()))
                         .WithStandardOutputPipe(PipeTarget.ToDelegate(HandleStdoutLineAsync))
                         .WithStandardErrorPipe(PipeTarget.ToDelegate(HandleStderrLineAsync))
                         .ExecuteAsync(cancellationToken);
    }

    private Task HandleStdoutLineAsync(string line, CancellationToken cancellationToken)
    {
        OnLog?.Invoke(this, new LogEventArgs(line, LogStream.StandardOutput));
        return Task.CompletedTask;
    }

    private Task HandleStderrLineAsync(string line, CancellationToken cancellationToken)
    {
        OnLog?.Invoke(this, new LogEventArgs(line, LogStream.StandardError));
        return Task.CompletedTask;
    }
}
