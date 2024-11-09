using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WpfHosting;

/// <summary>
/// WPFアプリケーションの設定を構築するクラスです。
/// </summary>
public sealed class WpfAppBuilder
{
    readonly WpfApplicationServiceCollection _services = [];

    WpfApp? _application;
    ILoggingBuilder? _logging;

    /// <summary>
    /// <see cref="WpfAppBuilder"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="useDefaults">
    /// デフォルト設定を使用する場合は<see langword="true"/>、
    /// 使用しない場合は<see langword="false"/>。
    /// </param>
    internal WpfAppBuilder(bool useDefaults)
    {
        Services.AddSingleton<IConfiguration>(Configuration);

        if (!useDefaults)
        {
            return;
        }

        Configuration.AddJsonFile("appsettings.json", true, true);
    }

    /// <summary>
    /// アプリケーションに関連付けるサービスのコレクションを取得します。
    /// </summary>
    /// <value>
    /// デフォルト設定で作成された場合は、"appsettings.json"の読み取りを設定した<see cref="IServiceCollection"/>を返します。
    /// </value>
    public IServiceCollection Services => _services;

    /// <summary>
    /// アプリケーションに関連付ける構成プロバイダーを取得します。
    /// </summary>
    /// <value>
    /// <see cref="ConfigurationManager"/>クラスのインスタンスを返します。
    /// </value>
    public ConfigurationManager Configuration { get; } = new();

    /// <summary>
    /// アプリケーションが作成するロギングプロバイダーのコレクションを取得します。
    /// </summary>
    /// <value>
    /// 初回アクセス時、<see cref="Services"/>プロパティにロギング関連のサービスを登録します。
    /// </value>
    public ILoggingBuilder Logging
    {
        get
        {
            return _logging ??= InitializeLogging();

            ILoggingBuilder InitializeLogging()
            {
                Services.AddLogging();
                return new LoggingBuilder(Services);
            }
        }
    }

    /// <summary>
    /// 構築された設定から<see cref="WpfApp"/>クラスのインスタンスを作成します。
    /// </summary>
    /// <returns><see cref="WpfApp"/>クラスのインスタンスを返します。</returns>
    public WpfApp Build()
    {
        var serviceProvider = _services.BuildServiceProvider();
        _application = new(serviceProvider);
        _services.IsReadOnly = true;

        return _application;
    }

    sealed class LoggingBuilder(IServiceCollection services) : ILoggingBuilder
    {
        public IServiceCollection Services { get; } = services;
    }
}
