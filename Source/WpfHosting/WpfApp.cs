using System.Windows;
using Microsoft.Extensions.Hosting;

namespace WpfHosting;

/// <summary>
/// Provides static methods for creating and configuring a WPF application using a hosting model.
/// </summary>
public static class WpfApp
{
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
}
