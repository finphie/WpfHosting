using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;

namespace WpfHosting.Sample;

/// <summary>
/// App.xamlの相互作用ロジック
/// </summary>
/// <param name="logger">ロガー</param>
sealed partial class App(ILogger<App> logger) : Application
{
    readonly ILogger<App> _logger = logger;

    void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) => Error(e?.Exception);

    [LoggerMessage(Level = LogLevel.Error, Message = "An unhandled exception occurred.")]
    partial void Error(Exception? ex);
}
