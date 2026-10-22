using AIJOURNALMATCHERWEB;
using AIJOURNALMATCHERWEB.Services; // <-- أضف هذا السطر
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
//                   Authorization & Authentication
// ============================================================
builder.Services.AddAuthorizationCore();

// ربط مزود المصادقة المخصص الذي أنشأناه
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// ============================================================
//                   Run
// ============================================================
var host = builder.Build();

await host.RunAsync();


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// تأكد من هالسطرين (ضروريين للـ Auth)
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

await builder.Build().RunAsync();