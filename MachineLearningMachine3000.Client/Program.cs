using MachineLearningMachine3000.Client;
using MachineLearningMachine3000.Client.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddDbContext<DataContextLocal>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

await builder.Build().RunAsync();
