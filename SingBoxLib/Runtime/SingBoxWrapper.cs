using CliWrap;
using SingBoxLib.Configuration;

namespace SingBoxLib.Runtime;

public class SingBoxWrapper
{
    private string _singBoxPath;

    public event EventHandler<string>? OnLog;

    public SingBoxWrapper(string executablePath)
    {
        _singBoxPath = executablePath;
    }

    public async Task<CommandResult> StartAsync(SingBoxConfig config, CancellationToken cancellationToken)
    {
        return await Cli.Wrap(_singBoxPath)
                         .WithArguments("run -c stdin")
                         .WithStandardInputPipe(PipeSource.FromString(config.ToJson()))
                         .WithStandardErrorPipe(PipeTarget.ToDelegate(HandleLogLineAsync))
                         .ExecuteAsync(cancellationToken);
    }

    private Task HandleLogLineAsync(string line, CancellationToken cancellationToken)
    {
        OnLog?.Invoke(this, line);
        return Task.CompletedTask;
    }
}