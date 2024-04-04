using Blazor_Eshop_Obligatorisk_Opgave.Client.Service;
using EshopSharedLibrary.Interface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ClientService>();

await builder.Build().RunAsync();
