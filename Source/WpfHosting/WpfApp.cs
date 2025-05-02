using System.Windows;
using Microsoft.Extensions.Hosting;

namespace WpfHosting;

/// <summary>
/// Provides static methods for creating and configuring a WPF application using a hosting model.
/// </summary>
public sealed class WpfApp
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
    /// Creates a new instance of the <see cref="WpfAppBuilder{TApplication, TMainWindow}"/> class for configuring the application.
    /// </summary>
    /// <typeparam name="TApplication">The type of the WPF application.</typeparam>
    /// <typeparam name="TMainWindow">The type of the main window of the WPF application.</typeparam>
    /// <param name="settings">Optional settings for configuring the <see cref="WpfAppBuilder{TApplication, TMainWindow}"/>.</param>
    /// <returns>A new <see cref="WpfAppBuilder{TApplication, TMainWindow}"/> instance.</returns>
    public static WpfAppBuilder<TApplication, TMainWindow> CreateBuilder<TApplication, TMainWindow>(HostApplicationBuilderSettings? settings = null)
        where TApplication : Application
        where TMainWindow : Window
        => new(settings);

    /// <summary>
    /// Runs the WPF application by starting the main application loop.
    /// </summary>
    public void Run()
    {
        // https://stackoverflow.com/q/64946371
        // https://github.com/dotnet/winforms/issues/5071
        Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
        Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

        Host.Run();
    }
}
