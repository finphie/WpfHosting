using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WpfHosting;

/// <summary>
/// Settings for constructing an <see cref="WpfAppBuilder{TApplication, TMainWindow}"/>.
/// </summary>
/// <typeparam name="TApplication">The type of the WPF application.</typeparam>
/// <typeparam name="TMainWindow">The type of the main window of the WPF application.</typeparam>
public sealed class WpfAppBuilder<TApplication, TMainWindow>
    where TApplication : Application
    where TMainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WpfAppBuilder{TApplication, TMainWindow}"/> class with pre-configured defaults.
    /// </summary>
    /// <param name="settings">
    /// <inheritdoc cref="HostApplicationBuilder(HostApplicationBuilderSettings?)" path="/param[@name='settings']"/>
    /// </param>
    internal WpfAppBuilder(HostApplicationBuilderSettings? settings)
        => HostBuilder = Host.CreateEmptyApplicationBuilder(settings);

    /// <summary>
    /// Gets the <see cref="HostApplicationBuilder"/> instance used to configure the application.
    /// </summary>
    public HostApplicationBuilder HostBuilder { get; }

    /// <inheritdoc cref="HostApplicationBuilder.Environment"/>
    public IHostEnvironment Environment => HostBuilder.Environment;

    /// <inheritdoc cref="HostApplicationBuilder.Configuration"/>
    public ConfigurationManager Configuration => HostBuilder.Configuration;

    /// <inheritdoc cref="HostApplicationBuilder.Services"/>
    public IServiceCollection Services => HostBuilder.Services;

    /// <inheritdoc cref="HostApplicationBuilder.Logging"/>
    public ILoggingBuilder Logging => HostBuilder.Logging;

    /// <inheritdoc cref="HostApplicationBuilder.Metrics"/>
    public IMetricsBuilder Metrics => HostBuilder.Metrics;

    /// <summary>
    /// <inheritdoc cref="HostApplicationBuilder.Build" path="/summary"/>
    /// </summary>
    /// <returns>An initialized <see cref="WpfApp"/>.</returns>
    public WpfApp Build()
    {
        HostBuilder.Services.AddHostedService<Bootstrapper<TApplication, TMainWindow>>();
        HostBuilder.Services.AddSingleton<TApplication>();
        HostBuilder.Services.AddTransient<TMainWindow>();

        var host = HostBuilder.Build();
        return new(host);
    }
}
