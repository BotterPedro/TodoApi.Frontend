using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoApi.Frontend;
using TodoApi.Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ITokenStorage, TokenStorage>();
builder.Services.AddScoped<AuthHeaderHandler>();
builder.Services.AddScoped<AuthState>();
builder.Services.AddScoped<ThemeService>();

builder.Services
    .AddHttpClient<ITarefaService, TarefaService>(client =>
    {
        client.BaseAddress = new Uri("https://todoapi-lhrs.onrender.com/");
    })
    .AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services
    .AddHttpClient<IAuthService, AuthService>(client =>
    {
        client.BaseAddress = new Uri("https://todoapi-lhrs.onrender.com/");
    })
    .AddHttpMessageHandler<AuthHeaderHandler>();

await builder.Build().RunAsync();