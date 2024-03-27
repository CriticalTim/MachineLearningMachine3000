using MachineLearningMachine3000.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<IFactCaseService, FactCaseService>();
builder.Services.AddScoped<IFactCaseForecastService, FactCaseForecastService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    //BaseAddress = new Uri("https://localhost:5011/api/")
});




await builder.Build().RunAsync();
