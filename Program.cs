using AIJOURNALMATCHERWEB;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ============================================================
//                   HttpClient
// ============================================================
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// ============================================================
//                   LocalStorage
// ============================================================
builder.Services.AddBlazoredLocalStorage();

// ============================================================
//                   Authorization
// ============================================================
builder.Services.AddAuthorizationCore();

// ============================================================
//                   Run
// ============================================================
var host = builder.Build();

await host.RunAsync();