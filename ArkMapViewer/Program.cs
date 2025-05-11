using ArkMapViewer;
using ArkMapViewer.Components;
using Microsoft.Extensions.DependencyInjection;
using SavegameToolkit;
using SavegameToolkitAdditions;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<MapCalibrations>();
builder.Services.AddSingleton<ArkDataCollection>(JsonSerializer.Deserialize<ArkDataCollection>(File.ReadAllText("ark-data.json"))!);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
