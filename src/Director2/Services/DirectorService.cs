using Microsoft.Extensions.Hosting;

namespace Director2.Services;

public sealed class DirectorService : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartAsync");
        return Task.FromResult(Task.CompletedTask);
    }
    
    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartingAsync");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartedAsync");
        return Task.CompletedTask;
    }

    public Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("ExecAsync");
        return Task.CompletedTask;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StopAsync");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppingAsync");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppedAsync");
        return Task.CompletedTask;
    }
}