using System.Text.Json;
using Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Service.Services;

/// <summary>
/// timer service 
/// </summary>
/// <param name="scopeFactory"></param>
public class ProductService(IServiceScopeFactory scopeFactory)
    : IHostedService
{ 
    private Timer? _timer = null;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ProductContext>();

        await context.Database.EnsureCreatedAsync(cancellationToken);

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
              TimeSpan.FromSeconds(10));

        await context.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    /// <summary>
    /// send product to json console
    /// </summary>
    /// <param name="state"></param>
    private async void DoWork(object? state)
    {
        using var scope = scopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ProductContext>();

        Console.Out.WriteLine(JsonSerializer.Serialize(context.Products));
    }
}
