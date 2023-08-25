using HRManagement.Client;
using HRManagement.Shared.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("HRManagement.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HRManagement.ServerAPI"));
builder.Services.AddScoped<IAnagraficaModel, Benefit>();
builder.Services.AddScoped<IAnagraficaModel, HardSkill>();
builder.Services.AddScoped<IAnagraficaModel, LivelloContrattuale>();
builder.Services.AddScoped<IAnagraficaModel, Mansione>();
builder.Services.AddScoped<IAnagraficaModel, SoftSkill>();
builder.Services.AddScoped<IAnagraficaModel, TipologiaColloquio>();
builder.Services.AddScoped<IAnagraficaModel, TipologiaContratto>();
builder.Services.AddScoped<IAnagraficaModel, TipologiaDocumento>();
builder.Services.AddScoped<IAnagraficaModel, TitoloStudio>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
