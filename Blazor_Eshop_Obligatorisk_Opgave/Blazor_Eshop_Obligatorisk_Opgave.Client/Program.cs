using Blazor_Eshop_Obligatorisk_Opgave.Client.Service;
using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Service;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
