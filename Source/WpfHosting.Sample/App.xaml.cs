using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;

namespace WpfHosting.Sample;

/// <summary>
/// App.xamlの相互作用ロジック
/// </summary>
sealed partial class App : Application
{
    readonly ILogger<App> _logger;

    /// <summary>
    /// <see cref="App"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    public App(ILogger<App> logger)
    {
        _logger = logger;
        InitializeComponent();
    }

    void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) => Error(e?.Exception);

    [LoggerMessage(Level = LogLevel.Error, Message = "An unhandled exception occurred.")]
    partial void Error(Exception? ex);
}
