using Blazor.IndexedDB.Framework;
using MachineLearningMachine3000.Client;
using MachineLearningMachine3000.Client.Data;
using MachineLearningMachine3000.Client.Forecast;
using MachineLearningMachine3000.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped<IFactCaseForecastService, FactCaseForecastService>();

builder.Services.AddScoped<IIndexedDbFactory, IndexedDbFactory>();

builder.Services.AddScoped<Calculation>();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});




await builder.Build().RunAsync();
