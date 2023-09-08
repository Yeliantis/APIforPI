using APIforPI.Web;
using APIforPI.Web.Services;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7273/ ") });
builder.Services.AddScoped<IProductWebService, ProductWebService>();
builder.Services.AddScoped<ICartItemWebService, CartItemWebService>();
await builder.Build().RunAsync();
