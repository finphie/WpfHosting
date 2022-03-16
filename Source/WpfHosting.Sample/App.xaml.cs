using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;

namespace WpfHosting.Sample;

/// <summary>
/// App.xamlの相互作用ロジック
/// </summary>
public sealed partial class App : Application
{
    readonly ILogger _logger;

    /// <summary>
    /// <see cref="App"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public App(ILogger<App> logger!!)
    {
        _logger = logger;
        InitializeComponent();
    }

    [SuppressMessage("Performance", "CA1848:LoggerMessage デリゲートを使用する", Justification = "このメソッドが呼ばれた場合、アプリケーションは終了するのでデリゲートを作成する必要なし。")]
    void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        => _logger.LogError("An unhandled exception occurred.", e.Exception);
}
