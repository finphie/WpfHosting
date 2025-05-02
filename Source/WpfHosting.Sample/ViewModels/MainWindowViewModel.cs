using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WpfHosting.Sample.ViewModels;

/// <summary>
/// MainWindow ViewModel
/// </summary>
public sealed partial class MainWindowViewModel
{
    readonly ILogger<MainWindowViewModel> _logger;
    readonly AppSettings _settings;

    /// <summary>
    /// <see cref="MainWindowViewModel"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="settings">設定</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="settings"/>がnullです。</exception>
    public MainWindowViewModel(ILogger<MainWindowViewModel> logger, IOptions<AppSettings> settings)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(settings);

        _logger = logger;
        _settings = settings.Value;

        Test();
    }

    /// <summary>
    /// タイトルを取得します。
    /// </summary>
    /// <value>
    /// "appsettings.json"で設定したタイトルを返します。
    /// </value>
    public string Title => _settings.Title;

    [LoggerMessage(0, LogLevel.Information, "Test")]
    partial void Test();
}
