# WpfHosting

[![Build(.NET)](https://github.com/finphie/WpfHosting/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/WpfHosting/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/WpfHosting?color=0078d4&label=NuGet)](https://www.nuget.org/packages/WpfHosting/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7/Packages/ea55a98f-3510-4b2e-9ef1-a9c04bf6a92f/Badge)](https://dev.azure.com/finphie/Main/_packaging?_a=package&feed=18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7&package=ea55a98f-3510-4b2e-9ef1-a9c04bf6a92f&preferRelease=true)

WPFアプリケーションの構築を行うライブラリです。

## 説明

Minimal APIとMicrosoft.Extensions.DependencyInjectionを使用した、WPFアプリケーションの構築を行うライブラリです。

## インストール

### NuGet（正式リリース版）

```console
dotnet add package WpfHosting
```

### Azure Artifacts（開発用ビルド）

```console
dotnet add package WpfHosting -s https://pkgs.dev.azure.com/finphie/Main/_packaging/DotNet/nuget/v3/index.json
```

## 使い方

App.xamlとApp.xaml.csを作成して次のように記述します。

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

ShellWindow.xamlとShellWindow.xaml.csを作成して次のように記述します。

```xml
<Window x:Class="WpfHosting.Sample.Views.ShellWindow"
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

public sealed partial class ShellWindow : Window
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
```

Program.csファイルを作成して次のように記述します。

```csharp
using WpfHosting;

var app = WpfApp.CreateDefaultBuilder()
    .UseWpfApp<App, ShellWindow>()
    .Build();

app.Run();
```

[サンプルプロジェクト](https://github.com/finphie/WpfHosting/tree/main/Source/WpfHosting.Sample)

## サポートフレームワーク

- .NET 6

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [Microsoft.Extensions.Configuration](https://github.com/dotnet/runtime)
- [Microsoft.Extensions.Configuration.Json](https://github.com/dotnet/runtime)
- [Microsoft.Extensions.DependencyInjection](https://github.com/dotnet/runtime)
- [Microsoft.Extensions.Logging](https://github.com/dotnet/runtime)
- [Microsoft.Extensions.Options](https://github.com/dotnet/runtime)

### テスト

- [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
- [Microsoft.NET.Test.Sdk](https://github.com/microsoft/vstest)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [NuGet.Frameworks](https://github.com/NuGet/NuGet.Client)
- [xunit](https://github.com/xunit/xunit)
- [xunit.runner.visualstudio](https://github.com/xunit/visualstudio.xunit)

### アナライザー

- Microsoft.CodeAnalysis.NetAnalyzers (SDK組み込み)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### その他

- [Microsoft.SourceLink.GitHub](https://github.com/dotnet/sourcelink)
