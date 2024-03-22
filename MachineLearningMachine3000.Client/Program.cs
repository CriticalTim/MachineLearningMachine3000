using MachineLearningMachine3000.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped<IFactCaseService, FactCaseService>();
builder.Services.AddScoped<IFactCaseForecastService, FactCaseForecastService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});




await builder.Build().RunAsync();
