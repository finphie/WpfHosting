using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WpfHosting;

/// <summary>
/// WPFアプリケーションを実行するクラスです。
/// </summary>
public sealed class WpfApp : IDisposable
{
    /// <summary>
    /// <see cref="WpfApp"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="services">アプリケーションの構成済みサービス</param>
    /// <exception cref="ArgumentNullException"><paramref name="services"/>がnullです。</exception>
    internal WpfApp(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Services = services;
    }

    /// <summary>
    /// アプリケーションの構成済みサービスを取得します。
    /// </summary>
    /// <value>
    /// <see cref="CreateDefaultBuilder"/>メソッドで作成された場合は、
    /// "appsettings.json"の読み取りを設定した<see cref="IServiceProvider"/>を返します。
    /// </value>
    public IServiceProvider Services { get; }

    /// <summary>
    /// アプリケーションの構成プロパティのセットを取得します。
    /// </summary>
    /// <value>
    /// <see cref="Services"/>プロパティに登録された<see cref="IConfiguration"/>を返します。
    /// </value>
    public IConfiguration Configuration => Services.GetRequiredService<IConfiguration>();

    /// <summary>
    /// <see cref="WpfAppBuilder"/>クラスの新しいインスタンスをデフォルト設定で初期化します。
    /// </summary>
    /// <returns><see cref="WpfAppBuilder"/>クラスのインスタンスを返します。</returns>
    public static WpfAppBuilder CreateDefaultBuilder()
       => new(true);

    /// <summary>
    /// <see cref="WpfAppBuilder"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <returns><see cref="WpfAppBuilder"/>のインスタンスを返します。</returns>
    public static WpfAppBuilder CreateBuilder()
        => new(false);

    /// <summary>
    /// アプリケーションを実行します。
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// <see cref="Services"/>プロパティに<see cref="Application"/>クラスまたは<see cref="Window"/>クラスが
    /// 登録されていません。
    /// </exception>
    public void Run()
    {
        // https://stackoverflow.com/q/64946371
        // https://github.com/dotnet/winforms/issues/5071
        Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
        Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

        var application = Services.GetRequiredService<Application>();
        var window = Services.GetRequiredService<Window>();

        application.Run(window);
    }

    /// <inheritdoc />
    public void Dispose() => (Configuration as IDisposable)?.Dispose();
}
