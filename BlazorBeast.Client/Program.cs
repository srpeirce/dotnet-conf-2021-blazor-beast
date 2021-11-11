using BlazorBeast.Client;
using BlazorBeast.Shared.Rendering;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Timers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// builder.RootComponents.Add<NoOp>("#loading");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ITimerFactory, TimerFactory>();

builder.Services.AddSingleton<RenderLocation, RenderedOnClient>();

await builder.Build().RunAsync();
