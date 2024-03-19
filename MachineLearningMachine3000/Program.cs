using MachineLearningMachine3000.Components;
using MachineLearningMachine3000.Data;
using MachineLearningMachine3000.Services;
using Microsoft.EntityFrameworkCore;
using MachineLearningMachine3000.Client.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeringerDBConnection")
   ));

builder.Services.AddDbContext<DataContextLocal>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeringerDBConnection")
   ));

builder.Services.AddScoped<IFactCaseService, FactCaseService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseWebAssemblyDebugging();
    //app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MachineLearningMachine3000.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
//app.MapAdditionalIdentityEndpoints();

app.Run();
