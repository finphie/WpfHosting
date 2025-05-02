using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfHosting;
using WpfHosting.Sample;
using WpfHosting.Sample.ViewModels;
using WpfHosting.Sample.Views;

var builder = WpfApp.CreateBuilder<App, MainWindow>();

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(AppSettings.ConfigurationSectionName));
builder.Services.AddLogging(static x => x.AddDebug());

builder.Services.AddTransient<MainWindowViewModel>();

var app = builder.Build();
app.Run();
