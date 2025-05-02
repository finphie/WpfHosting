using System.Windows;
using WpfHosting.Sample.ViewModels;

namespace WpfHosting.Sample.Views;

/// <summary>
/// MainWindow.xamlの相互作用ロジック
/// </summary>
sealed partial class MainWindow : Window
{
    /// <summary>
    /// <see cref="MainWindow"/>クラスの新しいインスタンスを取得します。
    /// </summary>
    /// <param name="viewModel"><see cref="MainWindow"/>クラスに対応するViewModel</param>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
