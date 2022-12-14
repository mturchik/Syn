using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syn.Client;
using Syn.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// System Level Services
builder.Services.AddLogging();
builder.Services.AddHttpClient("Syn.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
// Nuget Package Services
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredToast();
// Custom Services
builder.Services.AddScoped<IWebApiService, WebApiService>();
builder.Services.AddScoped<ILocalService, LocalService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

await builder.Build().RunAsync();
