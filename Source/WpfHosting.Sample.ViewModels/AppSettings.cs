namespace WpfHosting.Sample.ViewModels;

/// <summary>
/// アプリケーション設定
/// </summary>
/// <param name="Title">タイトル</param>
public sealed record AppSettings(string Title)
{
    /// <summary>
    /// セクション名
    /// </summary>
    public const string ConfigurationSectionName = $"{nameof(WpfHosting)}.{nameof(Sample)}";

    /// <summary>
    /// <see cref="AppSettings"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    public AppSettings()
        : this(string.Empty)
    {
    }
}
