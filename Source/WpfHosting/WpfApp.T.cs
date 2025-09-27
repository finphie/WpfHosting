using System.Windows;
using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfHosting;

/// <summary>
/// Represents a WPF application that integrates with the .NET Generic Host.
/// </summary>
/// <typeparam name="TApplication">The type of the WPF application.</typeparam>
public sealed class WpfApp<TApplication>
    where TApplication : Application
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WpfApp"/> class.
    /// </summary>
    /// <param name="host">The <see cref="IHost"/> instance that provides application services.</param>
    internal WpfApp(IHost host)
    {
        ArgumentNullException.ThrowIfNull(host);
        Host = host;
    }

    /// <summary>
    /// Gets the <see cref="IHost"/> instance used by the application.
    /// </summary>
    public IHost Host { get; }

    /// <inheritdoc cref="IHost.Services"/>
    public IServiceProvider Services => Host.Services;

    /// <summary>
    /// Runs the WPF application by starting the main application loop.
    /// </summary>
    public void Run()
    {
        // https://stackoverflow.com/q/64946371
        // https://github.com/dotnet/winforms/issues/5071
        Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
        Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

        var application = Services.GetRequiredService<TApplication>();
        var lifetime = Services.GetRequiredService<IHostApplicationLifetime>();

        application.Startup += (_, _) => Host.Start();
        application.Exit += (_, _) => lifetime.StopApplication();

        (application as IComponentConnector)?.InitializeComponent();
        application.Run();
    }
}
