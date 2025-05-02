using System.Windows;
using Microsoft.Extensions.Hosting;

namespace WpfHosting;

/// <summary>
/// WPFアプリケーションのブートストラッパーです。
/// </summary>
/// <typeparam name="TApplication">The type of the WPF application.</typeparam>
/// <typeparam name="TMainWindow">The type of the main window of the WPF application.</typeparam>
sealed class Bootstrapper<TApplication, TMainWindow> : BackgroundService
    where TApplication : Application
    where TMainWindow : Window
{
    readonly TApplication _application;
    readonly TMainWindow _window;
    readonly IHostApplicationLifetime _lifetime;

    /// <summary>
    /// <see cref="Bootstrapper{TApplication, TMainWindow}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="application">WPFアプリケーションのインスタンス</param>
    /// <param name="window">表示するメインウィンドウ</param>
    /// <param name="lifetime">アプリケーションのライフタイム管理を提供するインターフェイス</param>
    public Bootstrapper(TApplication application, TMainWindow window, IHostApplicationLifetime lifetime)
    {
        ArgumentNullException.ThrowIfNull(application);
        ArgumentNullException.ThrowIfNull(window);
        ArgumentNullException.ThrowIfNull(lifetime);

        _application = application;
        _window = window;
        _lifetime = lifetime;
    }

    /// <inheritdoc/>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _application.Startup += (_, _) => _window.Show();
        _application.Exit += (_, _) => _lifetime.StopApplication();
        _application.Run();

        return Task.CompletedTask;
    }
}
