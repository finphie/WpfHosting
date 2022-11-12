using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace WpfHosting;

/// <summary>
/// <see cref="WpfAppBuilder"/>クラス関連の拡張メソッド集です。
/// </summary>
public static class WpfAppBuilderExtensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/>にサービスを登録します。
    /// </summary>
    /// <param name="builder"><see cref="WpfAppBuilder"/>クラスのインスタンス</param>
    /// <param name="configureDelegate">設定を行うデリゲート</param>
    /// <returns><see cref="WpfAppBuilder"/>クラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/>または<paramref name="configureDelegate"/>がnullです。</exception>
    public static WpfAppBuilder ConfigureServices(this WpfAppBuilder builder, Action<IServiceCollection> configureDelegate)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureDelegate);

        configureDelegate(builder.Services);
        return builder;
    }

    /// <summary>
    /// <see cref="IServiceCollection"/>にサービスを登録します。
    /// </summary>
    /// <param name="builder"><see cref="WpfAppBuilder"/>クラスのインスタンス</param>
    /// <param name="configureDelegate">設定を行うデリゲート</param>
    /// <returns><see cref="WpfAppBuilder"/>クラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/>または<paramref name="configureDelegate"/>がnullです。</exception>
    public static WpfAppBuilder ConfigureServices(this WpfAppBuilder builder, Action<IConfiguration, IServiceCollection> configureDelegate)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureDelegate);

        configureDelegate(builder.Configuration, builder.Services);
        return builder;
    }

    /// <summary>
    /// アプリケーションの設定を構成します。
    /// </summary>
    /// <param name="builder"><see cref="WpfAppBuilder"/>クラスのインスタンス</param>
    /// <param name="configureDelegate">設定を行うデリゲート</param>
    /// <returns><see cref="WpfAppBuilder"/>クラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/>または<paramref name="configureDelegate"/>がnullです。</exception>
    public static WpfAppBuilder ConfigureAppConfiguration(this WpfAppBuilder builder, Action<IConfigurationBuilder> configureDelegate)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureDelegate);

        configureDelegate(builder.Configuration);
        return builder;
    }

    /// <summary>
    /// ロギングの設定を構成します。
    /// </summary>
    /// <param name="builder"><see cref="WpfAppBuilder"/>クラスのインスタンス</param>
    /// <param name="configureDelegate">設定を行うデリゲート</param>
    /// <returns><see cref="WpfAppBuilder"/>クラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/>または<paramref name="configureDelegate"/>がnullです。</exception>
    public static WpfAppBuilder ConfigureLogging(this WpfAppBuilder builder, Action<ILoggingBuilder> configureDelegate)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configureDelegate);

        configureDelegate(builder.Logging);
        return builder;
    }

    /// <summary>
    /// <see cref="WpfAppBuilder.Services"/>に<typeparamref name="TApplication"/>と<typeparamref name="TShellWindow"/>を登録します。
    /// </summary>
    /// <typeparam name="TApplication">アプリケーション</typeparam>
    /// <typeparam name="TShellWindow">メインウィンドウ</typeparam>
    /// <param name="builder"><see cref="WpfAppBuilder"/>クラスのインスタンス</param>
    /// <returns><see cref="WpfAppBuilder"/>クラスのインスタンスを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/>がnullです。</exception>
    public static WpfAppBuilder UseWpfApp<TApplication, TShellWindow>(this WpfAppBuilder builder)
        where TApplication : Application
        where TShellWindow : Window
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.TryAddSingleton<Application, TApplication>();
        builder.Services.TryAddSingleton<Window, TShellWindow>();

        return builder;
    }
}
