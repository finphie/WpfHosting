using System.Windows;
using Microsoft.Extensions.Hosting;

namespace WpfHosting;

/// <summary>
/// WPFアプリケーションのブートストラッパーです。
/// </summary>
/// <typeparam name="TMainWindow">The type of the main window of the WPF application.</typeparam>
sealed class Bootstrapper<TMainWindow> : IHostedService
    where TMainWindow : Window
{
    readonly TMainWindow _window;

    /// <summary>
    /// <see cref="Bootstrapper{TMainWindow}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="window">表示するメインウィンドウ</param>
    public Bootstrapper(TMainWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        _window = window;
    }

    /// <inheritdoc/>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _window.Show();
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
