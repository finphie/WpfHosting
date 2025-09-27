# WpfHosting

[![NuGet](https://img.shields.io/nuget/v/WpfHosting?color=0078d4&label=NuGet)](https://www.nuget.org/packages/WpfHosting/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/ea55a98f-3510-4b2e-9ef1-a9c04bf6a92f/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/WpfHosting?preferRelease=true)

[日本語 (Japanese)](README.ja.md)

Library for building WPF applications using Generic Host.

## 説明

A library for building WPF applications using Generic Host (`Host.CreateEmptyApplicationBuilder`).

## Installation

### NuGet (Stable Release)

```shell
dotnet add package WpfHosting
```

### Azure Artifacts (Development Builds)

```shell
dotnet add package WpfHosting -s https://pkgs.dev.azure.com/finphie/Main/_packaging/DotNet/nuget/v3/index.json
```

## Usage

Create `App.xaml` and `App.xaml.cs` and write the following:

```xml
<Application x:Class="WpfHosting.Sample.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
</Application>
```

```csharp
using System.Windows;

public sealed partial class App : Application;
```

Create `MainWindow.xaml` and `MainWindow.xaml.cs` and write the following:

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

Create `Program.cs` and write the following:

```csharp
using WpfHosting;

var builder = WpfApp.CreateBuilder<App, MainWindow>();
var app = builder.Build();
app.Run();
```

[Sample Project](https://github.com/finphie/WpfHosting/tree/main/Source/WpfHosting.Sample)

## Supported Frameworks

- .NET 9
- .NET 8

## Author

finphie

## License

MIT

## Credits

This project uses the following libraries, etc.

### Analyzers

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### Others

- [PolySharp](https://github.com/Sergio0694/PolySharp)
