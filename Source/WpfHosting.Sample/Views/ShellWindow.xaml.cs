using System.Windows;
using WpfHosting.Sample.ViewModels;

namespace WpfHosting.Sample.Views;

/// <summary>
/// ShellWindow.xamlの相互作用ロジック
/// </summary>
public sealed partial class ShellWindow : Window
{
    /// <summary>
    /// <see cref="ShellWindow"/>クラスの新しいインスタンスを取得します。
    /// </summary>
    /// <param name="viewModel"><see cref="ShellWindow"/>クラスに対応するViewModel</param>
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
