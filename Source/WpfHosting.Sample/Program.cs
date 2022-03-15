using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfHosting;
using WpfHosting.Sample;
using WpfHosting.Sample.ViewModels;
using WpfHosting.Sample.Views;

var app = WpfApp.CreateDefaultBuilder()
    .ConfigureServices(static (configuration, services) =>
    {
        services.Configure<AppSettings>(configuration.GetSection(AppSettings.ConfigurationSectionName));
        services.AddSingleton<ShellViewModel>();
    })
    .ConfigureLogging(static x => x.AddDebug())
    .UseWpfApp<App, ShellWindow>()
    .Build();

app.Run();
