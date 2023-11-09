using APIforPI.Web;
using APIforPI.Web.Services;
using APIforPI.Web.Services.Contracts;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7273/ ") });
builder.Services.AddScoped<IProductWebService, ProductWebService>();
builder.Services.AddScoped<ICartItemWebService, CartItemWebService>();
builder.Services.AddScoped<IOrderWebService, OrderWebService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IProductLocalStorageService, ProductLocalStorageService>();
builder.Services.AddScoped<ICartItemsLocalStorageService, CartItemsLocalStorageService>();

await builder.Build().RunAsync();
