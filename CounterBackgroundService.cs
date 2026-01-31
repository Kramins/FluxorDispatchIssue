using System;
using Fluxor;
using FluxorDispatchIssue.Store;
using Microsoft.Extensions.Logging;

namespace FluxorDispatchIssue;

public class CounterBackgroundService : IAsyncDisposable
{
    private IServiceProvider _serviceProvider;
    private ILogger<CounterBackgroundService> _logger;

    public CounterBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<CounterBackgroundService> logger
    )
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync()
    {
        // Simulate some background work that dispatches an action, with random delays
        _ = Task.Run(async () =>
        {
            var random = new Random();
            while (true)
            {
                await Task.Delay(random.Next(1000, 2000));
                IncrementCounterActionWithScopedService();
            }
        });
        return Task.CompletedTask;
    }

    private void IncrementCounterActionWithScopedService()
    {
        using var scope = _serviceProvider.CreateScope();
        var dispatcher = scope.ServiceProvider.GetRequiredService<IDispatcher>();

        dispatcher.Dispatch(new IncrementCounterAction());
        _logger.LogInformation(
            "IncrementCounterAction dispatched successfully at {Time}",
            DateTime.UtcNow
        );
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}
