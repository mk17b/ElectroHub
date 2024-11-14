using ElectroHub.WebUI;
using ElectroHub.WebUI.Common.Configuration;
using ElectroHub.WebUI.Common.Services;
using MudBlazor.Services;
using SnackbarService = ElectroHub.WebUI.Common.Services.SnackbarService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var settings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

builder.Services.RegisterApplication(settings!);

builder.Services.AddMudServices();

builder.Services.AddScoped<ISnackbarService, SnackbarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.AutomateDbMigrations();

app.Run();