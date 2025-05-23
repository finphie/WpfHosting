# WpfHosting

[![Build(.NET)](https://github.com/finphie/WpfHosting/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/WpfHosting/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/WpfHosting?color=0078d4&label=NuGet)](https://www.nuget.org/packages/WpfHosting/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/ea55a98f-3510-4b2e-9ef1-a9c04bf6a92f/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/WpfHosting?preferRelease=true)

Generic Hostを使用したWPFアプリケーションの構築を行うライブラリです

## 説明

Generic Host (`Host.CreateEmptyApplicationBuilder`)を使用して、WPFアプリケーションの構築を行うライブラリです。

## インストール

### NuGet（正式リリース版）

```shell
dotnet add package WpfHosting
```

### Azure Artifacts（開発用ビルド）

```shell
dotnet add package WpfHosting -s https://pkgs.dev.azure.com/finphie/Main/_packaging/DotNet/nuget/v3/index.json
```

## 使い方

`App.xaml`と`App.xaml.cs`を作成して次のように記述します。

```xml
<Application x:Class="WpfHosting.Sample.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
</Application>
```

```csharp
using System.Windows;

public sealed partial class App : Application
{
    public App() => InitializeComponent();
}
```

`MainWindow.xaml`と`MainWindow.xaml.cs`を作成して次のように記述します。

```xml
<Window x:Class="WpfHosting.Sample.Views.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="WpfHosting.Sample" Height="450" Width="800">
</Window>
```

```csharp
using System.Windows;

public sealed partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
```

`Program.cs`を作成して次のように記述します。

```csharp
using WpfHosting;

var builder = WpfApp.CreateBuilder<App, MainWindow>();
var app = builder.Build();
app.Run();
```

[サンプルプロジェクト](https://github.com/finphie/WpfHosting/tree/main/Source/WpfHosting.Sample)

## サポートフレームワーク

- .NET 9
- .NET 8

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### アナライザー

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### その他

- [PolySharp](https://github.com/Sergio0694/PolySharp)
